' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 04/10/2015

Option Strict On
Option Explicit On
Imports DataBaseConnectorLibrary.LibraryClass

Namespace Tables
    Public Class SelectTables
        Private _ErrorMessage As String
        Private aFunction As DataBaseConnectorLibrary.LibraryClass.DataBaseConnection

#Region "Constructor"
        Sub New()
            aFunction = New DataBaseConnectorLibrary.LibraryClass.DataBaseConnection()
        End Sub
#End Region

#Region "Select Functions For Drop Down List Fills 'Data Readers'"
        Public Function ProdoctsDataReader() As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT ProductName " &
                                   "FROM Products " &
                                   "ORDER BY ProductName"
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function SuppliersDataReader() As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CompanyName " &
                                   "FROM Suppliers " &
                                   "ORDER BY CompanyName"
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function SupplierArrayFiller(ByVal FilterString As String) As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax " &
                                   "FROM Suppliers " &
                                   "WHERE CompanyName LIKE ? + '%' " &
                                   "ORDER BY CompanyName"
                    .Parameters.Add("@CompanyName", System.Data.OleDb.OleDbType.VarChar).Value = FilterString
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function RetreiveCompanyNames() As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CustomerID, CompanyName " &
                                   "FROM Customers " &
                                   "ORDER BY CustomerID"
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function RetreiveEmployeeNames() As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT EmployeeID, LastName, FirstName " &
                                   "FROM Employees " &
                                   "ORDER BY EmployeeID"
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)

            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function
#End Region

#Region "Select Functions For Products"
        Public Function RetrieveProducts(ByVal FilterString As String) As Data.DataSet
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataSet As New Data.DataSet

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT ProductName, QuantityPerUnit, UnitPrice, CompanyName " &
                                   "FROM Products " &
                                   "LEFT OUTER JOIN Suppliers ON Products.SupplierID=Suppliers.SupplierID " &
                                   "WHERE ProductName LIKE ? + '%' " &
                                   "ORDER BY ProductName"
                    .Parameters.Add("@ProductName", System.Data.OleDb.OleDbType.VarChar).Value = FilterString
                End With

                _TheDataSet = aFunction.ReturnDataSet(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataSet
        End Function

        Public Function RetrieveProductsViaSuppliers(ByVal FilterString As String) As Data.DataSet
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataSet As New Data.DataSet

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT ProductName, QuantityPerUnit, UnitPrice, CompanyName " &
                                   "FROM Products " &
                                   "LEFT OUTER JOIN Suppliers ON Products.SupplierID=Suppliers.SupplierID " &
                                   "WHERE CompanyName LIKE ? + '%' " &
                                   "ORDER BY ProductName"
                    .Parameters.Add("@CompanyName", System.Data.OleDb.OleDbType.VarChar).Value = FilterString
                End With

                _TheDataSet = aFunction.ReturnDataSet(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataSet
        End Function
#End Region

#Region "Select Functions For Suppliers"
        Public Function RetrieveSuppliersDataSet(ByVal FilterString As String) As Data.DataSet
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataSet As New Data.DataSet

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax " &
                                   "FROM Suppliers " &
                                   "WHERE CompanyName LIKE ? + '%' " &
                                   "ORDER BY CompanyName"
                    .Parameters.Add("@CompanyName", System.Data.OleDb.OleDbType.VarChar).Value = FilterString
                End With

                _TheDataSet = aFunction.ReturnDataSet(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataSet
        End Function

#Region "Record Check"
        Public Function RecordCheck(ByVal CompanyName As String, ByVal ContatctName As String) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT COUNT (*) " &
                                   "FROM Suppliers " &
                                   "WHERE [CompanyName] = @companyName AND [ContactName] = @contactName "
                    .Parameters.Add("@companyName", System.Data.OleDb.OleDbType.VarChar).Value = CompanyName
                    .Parameters.Add("@contactName", System.Data.OleDb.OleDbType.VarChar).Value = ContatctName
                End With

                ReturnValue = aFunction.DataCheck(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function
#End Region

#Region "Add Data To Suppliers"
        Public Function AddSupplierRecord(ByVal companyName As String, ByVal contactName As String, ByVal contactTitle As String, ByVal address As String, ByVal city As String, ByVal region As String, ByVal postalCode As String, ByVal country As String, ByVal phone As String, ByVal fax As String) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " &
                                   "VALUES (companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax)"
                    .Parameters.Add("@companyName", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(companyName)
                    .Parameters.Add("@contactName", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(contactName)
                    .Parameters.Add("@contactTitle", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(contactTitle)
                    .Parameters.Add("@address", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(address)
                    .Parameters.Add("@city", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(city)
                    .Parameters.Add("@region", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(region)
                    .Parameters.Add("@postalCode", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(postalCode)
                    .Parameters.Add("@country", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(country)
                    .Parameters.Add("@phone", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(phone)
                    .Parameters.Add("@fax", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(fax)
                End With

                ReturnValue = aFunction.AlterData(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function
#End Region

#Region "Update Data To Suppliers"
        Public Function UpdateSupplierRecord(ByVal companyName As String, ByVal contactName As String, ByVal contactTitle As String, ByVal address As String, ByVal city As String, ByVal region As String, ByVal postalCode As String, ByVal country As String, ByVal phone As String, ByVal fax As String, ByVal id As Integer) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE Suppliers SET [CompanyName] = @companyName, [ContactName] = @contactName, [ContactTitle] = @contactTitle, [Address] = @address, [City] = @city, [Region] = @region, [PostalCode] = @postalCode, [Country] = @country, [Phone] = @phone, [Fax] = @fax WHERE [SupplierID] = @supplierID"

                    .Parameters.Add("@companyName", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(companyName)
                    .Parameters.Add("@contactName", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(contactName)
                    .Parameters.Add("@contactTitle", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(contactTitle)
                    .Parameters.Add("@address", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(address)
                    .Parameters.Add("@city", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(city)
                    .Parameters.Add("@region", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(region)
                    .Parameters.Add("@postalCode", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(postalCode)
                    .Parameters.Add("@country", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(country)
                    .Parameters.Add("@phone", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(phone)
                    .Parameters.Add("@fax", System.Data.OleDb.OleDbType.VarChar).Value = WriteParameter(fax)
                    .Parameters.Add("@supplierID", System.Data.OleDb.OleDbType.Integer).Value = id
                End With

                ReturnValue = aFunction.AlterData(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function
#End Region

#Region "Delete Data To Suppliers"
        Public Function DeleteSuppliers(ByVal companyName As String, ByVal id As Integer) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM Suppliers WHERE SupplierID = @supplierID AND CompanyName = @companyName"
                    .Parameters.Add("@supplierID", System.Data.OleDb.OleDbType.Integer).Value = id
                    .Parameters.Add("@companyName", System.Data.OleDb.OleDbType.VarChar).Value = companyName
                End With

                ReturnValue = aFunction.AlterData(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function
#End Region

#Region "Sets Nulls To Empty Strings"
        Public Function WriteParameter(ByVal input As String) As Object
            Dim ReturnValue As Object = Nothing

            If String.IsNullOrEmpty(input) = True Then
                ReturnValue = DBNull.Value
            Else
                ReturnValue = input
            End If

            Return ReturnValue
        End Function
#End Region

#Region "Retrieve Supplier ID"
        Public Function GrabSupplierID(ByVal companyName As String) As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT SupplierID " &
                                   "FROM Suppliers " &
                                   "WHERE [CompanyName] = @companyName"
                    .Parameters.Add("@companyName", System.Data.OleDb.OleDbType.VarChar).Value = companyName
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function
#End Region

#End Region

#Region "Functions For Order Form"
        Public Function CreateOrderID(ByVal customerID As String, ByVal employeeID As Integer, ByVal orderDate As Date, ByVal requiredDate As Date, ByVal shipVia As Integer, ByVal shipName As String, ByVal shipAddress As String, ByVal shipCity As String, ByVal shipRegion As String, ByVal shipPostalCode As String, ByVal shipCountry As String) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShipVia, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " &
                                   "VALUES (customerID, employeeID, orderDate, requiredDate, shipVia, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry)"
                    .Parameters.Add("@customerID", System.Data.OleDb.OleDbType.VarChar).Value = customerID
                    .Parameters.Add("@employeeID", System.Data.OleDb.OleDbType.Integer).Value = employeeID
                    .Parameters.Add("@orderDate", System.Data.OleDb.OleDbType.Date).Value = orderDate
                    .Parameters.Add("@requiredDate", System.Data.OleDb.OleDbType.Date).Value = requiredDate
                    .Parameters.Add("@shipVia", System.Data.OleDb.OleDbType.Integer).Value = shipVia
                    .Parameters.Add("@shipName", System.Data.OleDb.OleDbType.VarChar).Value = shipName
                    .Parameters.Add("@shipAddress", System.Data.OleDb.OleDbType.VarChar).Value = shipAddress
                    .Parameters.Add("@shipCity", System.Data.OleDb.OleDbType.VarChar).Value = shipCity
                    .Parameters.Add("@shipRegion", System.Data.OleDb.OleDbType.VarChar).Value = shipRegion
                    .Parameters.Add("@shipPostalCode", System.Data.OleDb.OleDbType.VarChar).Value = shipPostalCode
                    .Parameters.Add("@shipCountry", System.Data.OleDb.OleDbType.VarChar).Value = shipCountry
                End With

                ReturnValue = aFunction.AlterData(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function

        Public Function GetOrderID(ByVal customerID As String, ByVal employeeID As Integer, ByVal orderDate As Date) As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT OrderID " &
                                   "FROM Orders " &
                                   "WHERE [CustomerID] = @customerID AND [EmployeeID] = @employeeID AND [OrderDate] = @orderDate"
                    .Parameters.Add("@customerID", System.Data.OleDb.OleDbType.VarChar).Value = customerID
                    .Parameters.Add("@employeeID", System.Data.OleDb.OleDbType.Integer).Value = employeeID
                    .Parameters.Add("@orderDate", System.Data.OleDb.OleDbType.Date).Value = orderDate
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function GrabProductIDAndUnitPrice(ByVal productName As String) As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT ProductID, UnitPrice " &
                                   "FROM Products " &
                                   "WHERE [ProductName] = @productName"
                    .Parameters.Add("@productName", System.Data.OleDb.OleDbType.VarChar).Value = productName
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function AddItemToOrderDetails(ByVal productID As String, ByVal unitPrice As Double, ByVal qty As Integer, ByVal orderNumber As Integer, ByVal discount As Double) As Integer
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim ReturnValue As Integer = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity, Discount) " &
                                   "VALUES (orderNumber, productID, unitPrice, qty, discount)"
                    .Parameters.Add("@orderNumber", System.Data.OleDb.OleDbType.Integer).Value = orderNumber
                    .Parameters.Add("@productID", System.Data.OleDb.OleDbType.Integer).Value = productID
                    .Parameters.Add("@unitPrice", System.Data.OleDb.OleDbType.Double).Value = unitPrice
                    .Parameters.Add("@qty", System.Data.OleDb.OleDbType.Integer).Value = qty
                    .Parameters.Add("@discount", System.Data.OleDb.OleDbType.Double).Value = discount
                End With

                ReturnValue = aFunction.AlterData(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return ReturnValue
        End Function

        Public Function RetrieveOrderDetails(ByVal orderNumber As Integer) As Data.DataSet
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataSet As Data.DataSet = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT OrderID, ProductName, OrderDetails.UnitPrice, Quantity, Discount " &
                                   "FROM OrderDetails " &
                                   "LEFT OUTER JOIN Products ON OrderDetails.ProductID=Products.ProductID " &
                                   "WHERE [OrderID] = @orderNumber " &
                                   "ORDER BY ProductName"
                    .Parameters.Add("@orderNumber", System.Data.OleDb.OleDbType.Integer).Value = orderNumber
                End With

                _TheDataSet = aFunction.ReturnDataSet(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataSet
        End Function
#End Region

#Region "Functions For Order Details"
        Public Function RetrieveOrderNumbers() As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT OrderID " &
                                   "FROM Orders " &
                                   "ORDER BY OrderID"
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception
                _ErrorMessage = aFunction.ErrorMessage
            End Try

            Return _TheDataReader
        End Function

        Public Function RetrieveOrderDetailsForCalculations(ByVal orderNumber As Integer) As OleDb.OleDbDataReader
            Dim TheOleDbCommand As New System.Data.OleDb.OleDbCommand
            Dim _TheDataReader As OleDb.OleDbDataReader = Nothing

            Try
                With TheOleDbCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT UnitPrice, Quantity, Discount " &
                                   "FROM OrderDetails " &
                                   "WHERE OrderID = @orderNumber"
                    .Parameters.Add("@orderNumber", System.Data.OleDb.OleDbType.Integer).Value = orderNumber
                End With

                _TheDataReader = aFunction.ReturnDataReader(TheOleDbCommand)
            Catch ex As Exception

            End Try

            Return _TheDataReader
        End Function
#End Region

#Region "Properties"
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _ErrorMessage
            End Get
        End Property
#End Region
    End Class
End Namespace
