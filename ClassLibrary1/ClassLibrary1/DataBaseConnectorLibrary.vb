' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Option Explicit On
Option Strict On

Imports System.Configuration

Namespace LibraryClass
    Public Class DataBaseConnection
        Private _The_Connection_String As String
        Private _Error_Message As String

#Region "Constructors"
        Public Sub New()
            _The_Connection_String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        End Sub

        Sub New(ByVal ConnectionString As String)
            _The_Connection_String = ConnectionString    ' Constructor to set the connection string for the database
        End Sub
#End Region

#Region "Function For Returning DataSet"
        Public Function ReturnDataSet(ByVal Command As System.Data.OleDb.OleDbCommand) As Data.DataSet  ' Function that takes the command and returns the data set
            Dim TheOleDbConnection As System.Data.OleDb.OleDbConnection = Nothing   ' Declares the connection and sets it to nothing
            Dim TheDataSet As New Data.DataSet

            Try
                TheOleDbConnection = New System.Data.OleDb.OleDbConnection(_The_Connection_String)

                With Command
                    .Connection = TheOleDbConnection
                End With

                Dim TheOleDbDataAdapter As New System.Data.OleDb.OleDbDataAdapter(Command)

                TheOleDbDataAdapter.Fill(TheDataSet, "TheTable")

            Catch ex As Exception
                _Error_Message = ex.Message
            Finally
                If TheOleDbConnection Is Nothing OrElse TheOleDbConnection.State = ConnectionState.Closed Then

                Else
                    TheOleDbConnection.Close()
                End If
            End Try

            Return TheDataSet

        End Function
#End Region

#Region "Function For Returning Data Reader"
        Public Function ReturnDataReader(ByVal Command As System.Data.OleDb.OleDbCommand) As OleDb.OleDbDataReader  ' function that takes the command and returns the reader
            Dim TheOleDbConnection As System.Data.OleDb.OleDbConnection = Nothing
            TheOleDbConnection = New System.Data.OleDb.OleDbConnection(_The_Connection_String)

            With Command
                .Connection = TheOleDbConnection
                .Connection.Open()
            End With

            Return Command.ExecuteReader(CommandBehavior.CloseConnection)

        End Function
#End Region

#Region "Function For Returning Scalar For Altering Data"
        Public Function AlterData(ByVal Command As System.Data.OleDb.OleDbCommand) As Integer   ' Funtion for the altering of data in the database
            Dim TheOleDbConnection As System.Data.OleDb.OleDbConnection = Nothing   ' declares the connection and sets it to nothing
            Dim ReturnValue As Integer = 0

            Try
                TheOleDbConnection = New System.Data.OleDb.OleDbConnection(_The_Connection_String)  ' sets the connection string to the connection variable

                Command.Connection = TheOleDbConnection ' sets the connection in the command
                TheOleDbConnection.Open()   ' opens the connection
                ReturnValue = Command.ExecuteNonQuery()   ' runs the query in the database

            Catch ex As Exception
                _Error_Message = ex.Message ' if error occurs the message is saved to be sent back
            Finally
                If TheOleDbConnection Is Nothing OrElse TheOleDbConnection.State = ConnectionState.Closed Then
                    ' finally block to make sure the connection to the database is closed
                Else
                    TheOleDbConnection.Close()
                End If
            End Try

            Return ReturnValue
        End Function
#End Region

#Region "Function For Returning Scalar For Data Check"
        Public Function DataCheck(ByVal Command As System.Data.OleDb.OleDbCommand) As Integer
            Dim TheOleDbConnection As System.Data.OleDb.OleDbConnection = Nothing
            Dim RetrunValue As Integer = 0

            Try
                TheOleDbConnection = New System.Data.OleDb.OleDbConnection(_The_Connection_String)

                Command.Connection = TheOleDbConnection
                TheOleDbConnection.Open()
                RetrunValue = Convert.ToInt32(Command.ExecuteScalar())


            Catch ex As Exception
                _Error_Message = ex.Message
            Finally
                If TheOleDbConnection Is Nothing OrElse TheOleDbConnection.State = ConnectionState.Closed Then
                    ' finally block to make sure the connection to the database is closed
                Else
                    TheOleDbConnection.Close()
                End If
            End Try

            Return RetrunValue
        End Function
#End Region

#Region "Properties"
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _Error_Message
            End Get
        End Property
#End Region
    End Class
End Namespace
