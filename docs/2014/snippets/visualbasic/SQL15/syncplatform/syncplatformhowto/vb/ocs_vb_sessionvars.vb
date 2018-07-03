﻿'<snippetOCS_VB_SessionVars>
Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports Microsoft.Synchronization
Imports Microsoft.Synchronization.Data
Imports Microsoft.Synchronization.Data.Server
Imports Microsoft.Synchronization.Data.SqlServerCe


Class Program

    Shared Sub Main(ByVal args() As String)
        'The Utility class handles all functionality that is not
        'directly related to synchronization, such as holding 
        'connection string information and making changes to the 
        'server and client databases.
        Dim util As New Utility()

        'The SampleStats class handles information from the SyncStatistics
        'object that the Synchronize method returns.
        Dim sampleStats As New SampleStats()

        'Request a password for the client database, and delete
        'and re-create the database. The client synchronization
        'provider also enables you to create the client database 
        'if it does not exist.
        util.SetClientPassword()
        util.RecreateClientDatabase()

        'Initial synchronization. Instantiate the SyncAgent
        'and call Synchronize.
        Dim sampleSyncAgent As New SampleSyncAgent()
        Dim syncStatistics As SyncStatistics = sampleSyncAgent.Synchronize()
        sampleStats.DisplayStats(syncStatistics, "initial")

        'Make changes on the server and client.
        util.MakeDataChangesOnServer("Vendor")
        util.MakeDataChangesOnClient("Vendor")

        'Subsequent synchronization.
        syncStatistics = sampleSyncAgent.Synchronize()
        sampleStats.DisplayStats(syncStatistics, "subsequent")

        'Return the server data back to its original state.
        util.CleanUpServer()

        'Exit.
        Console.Write(vbLf + "Press Enter to close the window.")
        Console.ReadLine()

    End Sub 'Main
End Class 'Program

'Create a class that is derived from 
'Microsoft.Synchronization.SyncAgent.
Public Class SampleSyncAgent
    Inherits SyncAgent

    Public Sub New()

        'Instantiate a client synchronization provider and specify it
        'as the local provider for this synchronization agent.
        Me.LocalProvider = New SampleClientSyncProvider()

        'Instantiate a server synchronization provider and specify it
        'as the remote provider for this synchronization agent.
        Me.RemoteProvider = New SampleServerSyncProvider()

        'Add the Vendor table: specify a synchronization direction of
        'Bidirectional, and that an existing table should be dropped.
        Dim vendorSyncTable As New SyncTable("Vendor")
        vendorSyncTable.CreationOption = TableCreationOption.DropExistingOrCreateNewTable
        vendorSyncTable.SyncDirection = SyncDirection.Bidirectional
        Me.Configuration.SyncTables.Add(vendorSyncTable)

    End Sub 'New
End Class 'SampleSyncAgent

'Create a class that is derived from 
'Microsoft.Synchronization.Server.DbServerSyncProvider.
Public Class SampleServerSyncProvider
    Inherits DbServerSyncProvider

    Public Sub New()

        'Create a connection to the sample server database.
        Dim util As New Utility()
        Dim serverConn As New SqlConnection(util.ServerConnString)
        Me.Connection = serverConn

        'Create a command to retrieve a new anchor value from
        'the server. In this case, we use a timestamp value
        'that is retrieved and stored in the client database.
        'During each synchronization, the new anchor value and
        'the last anchor value from the previous synchronization
        'are used: the set of changes between these upper and
        'lower bounds is synchronized.
        '
        'SyncSession.SyncNewReceivedAnchor is a string constant; 
        'you could also use @sync_new_received_anchor directly in 
        'your queries.
        '<snippetOCS_VB_SessionVars_NewAnchorCommand>
        Dim selectNewAnchorCommand As New SqlCommand()
        Dim newAnchorVariable As String = "@" + SyncSession.SyncNewReceivedAnchor
        With selectNewAnchorCommand
            .CommandText = "SELECT " + newAnchorVariable + " = min_active_rowversion() - 1"
            .Parameters.Add(newAnchorVariable, SqlDbType.Timestamp)
            .Parameters(newAnchorVariable).Direction = ParameterDirection.Output
            .Connection = serverConn
        End With
        Me.SelectNewAnchorCommand = selectNewAnchorCommand
        '</snippetOCS_VB_SessionVars_NewAnchorCommand>

        'Create a command that enables you to pass in a 
        'client ID (a GUID) and get back the orginator ID (an integer) 
        'that is defined in a mapping table on the server.
        '<snippetOCS_VB_SessionVars_ClientIdCommand>
        Dim selectClientIdCommand As New SqlCommand()
        With selectClientIdCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "usp_GetOriginatorId"
            .Parameters.Add("@" + SyncSession.SyncClientId, SqlDbType.UniqueIdentifier)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int).Direction = ParameterDirection.Output
            .Connection = serverConn
        End With
        Me.SelectClientIdCommand = selectClientIdCommand
        '</snippetOCS_VB_SessionVars_ClientIdCommand>

        'Create a SyncAdapter for the Vendor table, and then define
        'the commands to synchronize changes:
        '* SelectIncrementalInsertsCommand, SelectIncrementalUpdatesCommand,
        '  and SelectIncrementalDeletesCommand are used to select changes
        '  from the server that the client provider then applies to the client.
        '* InsertCommand, UpdateCommand, and DeleteCommand are used to apply
        '  to the server the changes that the client provider has selected
        '  from the client.

        'Create the SyncAdapter
        Dim vendorSyncAdapter As New SyncAdapter("Vendor")

        'Select inserts from the server.
        'This command includes three session variables:
        '@sync_last_received_anchor, @sync_new_received_anchor,
        'and @sync_originator_id. The anchor variables are used with
        'SelectNewAnchorCommand to determine the set of changes to 
        'synchronize. In other example code, the commands use 
        '@sync_client_id instead of @sync_originator_id. In this case, 
        '@sync_originator_id is used because the SelectClientIdCommand 
        'is specified.
        Dim vendorIncrInserts As New SqlCommand()
        With vendorIncrInserts
            .CommandText = _
                "SELECT VendorId, VendorName, CreditRating, PreferredVendor " _
              & "FROM Sales.Vendor " _
              & "WHERE (InsertTimestamp > @sync_last_received_anchor " _
              & "AND InsertTimestamp <= @sync_new_received_anchor " _
              & "AND InsertId <> @sync_originator_id)"
            .Parameters.Add("@" + SyncSession.SyncLastReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncNewReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.SelectIncrementalInsertsCommand = vendorIncrInserts

        'Apply inserts to the server.
        'This command includes @sync_row_count, which returns
        'a count of how many rows were affected by the
        'last database operation. In SQL Server, the variable
        'is assigned the value of @@rowcount. The count is used
        'to determine whether an operation was successful or
        'was unsuccessful due to a conflict or an error.
        Dim vendorInserts As New SqlCommand()
        With vendorInserts
            .CommandText = _
                "INSERT INTO Sales.Vendor (VendorId, VendorName, CreditRating, PreferredVendor, InsertId, UpdateId) " _
              & "VALUES (@VendorId, @VendorName, @CreditRating, @PreferredVendor, @sync_originator_id, @sync_originator_id) " _
              & "SET @sync_row_count = @@rowcount"
            .Parameters.Add("@VendorId", SqlDbType.UniqueIdentifier)
            .Parameters.Add("@VendorName", SqlDbType.NVarChar)
            .Parameters.Add("@CreditRating", SqlDbType.NVarChar)
            .Parameters.Add("@PreferredVendor", SqlDbType.NVarChar)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Parameters.Add("@" + SyncSession.SyncRowCount, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.InsertCommand = vendorInserts

        'Select updates from the server
        '<snippetOCS_VB_SessionVars_VendorIncrUpdate>
        Dim vendorIncrUpdates As New SqlCommand()
        With vendorIncrUpdates
            .CommandText = _
                "SELECT VendorId, VendorName, CreditRating, PreferredVendor " _
              & "FROM Sales.Vendor " _
              & "WHERE (UpdateTimestamp > @sync_last_received_anchor " _
              & "AND UpdateTimestamp <= @sync_new_received_anchor " _
              & "AND UpdateId <> @sync_originator_id " _
              & "AND NOT (InsertTimestamp > @sync_last_received_anchor " _
              & "AND InsertId <> @sync_originator_id))"
            .Parameters.Add("@" + SyncSession.SyncLastReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncNewReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.SelectIncrementalUpdatesCommand = vendorIncrUpdates
        '</snippetOCS_VB_SessionVars_VendorIncrUpdate>

        'Apply updates to the server.
        'This command includes @sync_force_write, which can
        'be used to apply changes in case of a conflict.
        '<snippetOCS_VB_SessionVars_VendorUpdate>
        Dim vendorUpdates As New SqlCommand()
        With vendorUpdates
            .CommandText = _
                "UPDATE Sales.Vendor SET " _
              & "VendorName = @VendorName, CreditRating = @CreditRating, " _
              & "PreferredVendor = @PreferredVendor, " _
              & "UpdateId = @sync_originator_id " _
              & "WHERE (VendorId = @VendorId) " _
              & "AND (@sync_force_write = 1 " _
              & "OR (UpdateTimestamp <= @sync_last_received_anchor " _
              & "OR UpdateId = @sync_originator_id)) " _
              & "SET @sync_row_count = @@rowcount"
            .Parameters.Add("@VendorName", SqlDbType.NVarChar)
            .Parameters.Add("@CreditRating", SqlDbType.NVarChar)
            .Parameters.Add("@PreferredVendor", SqlDbType.NVarChar)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Parameters.Add("@VendorId", SqlDbType.UniqueIdentifier)
            .Parameters.Add("@" + SyncSession.SyncForceWrite, SqlDbType.Bit)
            .Parameters.Add("@" + SyncSession.SyncLastReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncRowCount, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.UpdateCommand = vendorUpdates
        '</snippetOCS_VB_SessionVars_VendorUpdate>

        'Select deletes from the server.
        'This command includes @sync_initialized, which is
        'used to determine whether a client has been 
        'initialized already. If this variable returns 0,
        'this is the first synchronization for this client ID
        'or originator ID.
        '<snippetOCS_VB_SessionVars_VendorIncrDelete>
        Dim vendorIncrDeletes As New SqlCommand()
        With vendorIncrDeletes
            .CommandText = _
                "SELECT VendorId, VendorName, CreditRating, PreferredVendor " _
              & "FROM Sales.Vendor_Tombstone " _
              & "WHERE (@sync_initialized = 1 " _
              & "AND DeleteTimestamp > @sync_last_received_anchor " _
              & "AND DeleteTimestamp <= @sync_new_received_anchor " _
              & "AND DeleteId <> @sync_originator_id)"
            .Parameters.Add("@" + SyncSession.SyncInitialized, SqlDbType.Bit)
            .Parameters.Add("@" + SyncSession.SyncLastReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncNewReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.SelectIncrementalDeletesCommand = vendorIncrDeletes
        '</snippetOCS_VB_SessionVars_VendorIncrDelete>

        'Apply deletes to the server.            
        Dim vendorDeletes As New SqlCommand()
        With vendorDeletes
            .CommandText = _
                "DELETE FROM Sales.Vendor " _
              & "WHERE (VendorId = @VendorId) " _
              & "AND (@sync_force_write = 1 " _
              & "OR (UpdateTimestamp <= @sync_last_received_anchor " _
              & "OR UpdateId = @sync_originator_id)) " _
              & "SET @sync_row_count = @@rowcount " _
              & "IF (@sync_row_count > 0)  BEGIN " _
              & "UPDATE Sales.Vendor_Tombstone " _
              & "SET DeleteId = @sync_originator_id " _
              & "WHERE (VendorId = @VendorId) " _
              & "END"
            .Parameters.Add("@VendorId", SqlDbType.UniqueIdentifier)
            .Parameters.Add("@" + SyncSession.SyncForceWrite, SqlDbType.Bit)
            .Parameters.Add("@" + SyncSession.SyncLastReceivedAnchor, SqlDbType.Timestamp)
            .Parameters.Add("@" + SyncSession.SyncOriginatorId, SqlDbType.Int)
            .Parameters.Add("@" + SyncSession.SyncRowCount, SqlDbType.Int)
            .Connection = serverConn
        End With
        vendorSyncAdapter.DeleteCommand = vendorDeletes


        'Add the SyncAdapter to the server synchronization provider.
        Me.SyncAdapters.Add(vendorSyncAdapter)

    End Sub 'New 
End Class 'SampleServerSyncProvider

'Create a class that is derived from 
'Microsoft.Synchronization.Data.SqlServerCe.SqlCeClientSyncProvider.
'You can just instantiate the provider directly and associate it
'with the SyncAgent, but here we use this class to handle client 
'provider events.
Public Class SampleClientSyncProvider
    Inherits SqlCeClientSyncProvider


    Public Sub New()
        'Specify a connection string for the sample client database.
        Dim util As New Utility()
        Me.ConnectionString = util.ClientConnString

        'We use the CreatingSchema event to change the schema
        'by using the API. We use the SchemaCreated event to 
        'change the schema by using SQL.
        AddHandler Me.CreatingSchema, AddressOf SampleClientSyncProvider_CreatingSchema
        AddHandler Me.SchemaCreated, AddressOf SampleClientSyncProvider_SchemaCreated

    End Sub 'New


    Private Sub SampleClientSyncProvider_CreatingSchema(ByVal sender As Object, ByVal e As CreatingSchemaEventArgs)

        'Set the RowGuid property because it is not copied
        'to the client by default. This is also a good time
        'to specify literal defaults with .Columns[ColName].DefaultValue,
        'but we will specify defaults like NEWID() by calling
        'ALTER TABLE after the table is created.
        Console.Write("Creating schema for " + e.Table.TableName + " | ")
        e.Schema.Tables("Vendor").Columns("VendorId").RowGuid = True

    End Sub 'SampleClientSyncProvider_CreatingSchema


    Private Sub SampleClientSyncProvider_SchemaCreated(ByVal sender As Object, ByVal e As SchemaCreatedEventArgs)

        'Call ALTER TABLE on the client. This must be done
        'over the same connection and within the same
        'transaction that Synchronization Services uses
        'to create the schema on the client.
        Dim util As New Utility()
        util.MakeSchemaChangesOnClient(e.Connection, e.Transaction, e.Table.TableName)
        Console.WriteLine("Schema created for " + e.Table.TableName)

    End Sub 'SampleClientSyncProvider_SchemaCreated
End Class 'SampleClientSyncProvider

'Handle the statistics that are returned by the SyncAgent.
Public Class SampleStats

    Public Sub DisplayStats(ByVal syncStatistics As SyncStatistics, ByVal syncType As String)
        Console.WriteLine(String.Empty)
        If syncType = "initial" Then
            Console.WriteLine("****** Initial Synchronization ******")
        ElseIf syncType = "subsequent" Then
            Console.WriteLine("***** Subsequent Synchronization ****")
        End If

        Console.WriteLine("Start Time: " & syncStatistics.SyncStartTime)
        Console.WriteLine("Total Changes Uploaded: " & syncStatistics.TotalChangesUploaded)
        Console.WriteLine("Total Changes Downloaded: " & syncStatistics.TotalChangesDownloaded)
        Console.WriteLine("Complete Time: " & syncStatistics.SyncCompleteTime)
        Console.WriteLine(String.Empty)

    End Sub 'DisplayStats
End Class 'SampleStats
'</snippetOCS_VB_SessionVars>