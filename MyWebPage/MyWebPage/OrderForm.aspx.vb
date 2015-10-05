' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Imports SelectTablesLibrary.Tables.SelectTables

Public Class WebForm5
    Inherits System.Web.UI.Page

    Private anOrderQuery As New SelectTablesLibrary.Tables.SelectTables
    Private Qty As Integer = Nothing

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ErrorLabel.Text = ""
        LoadDropDownLists()
    End Sub

    Public Sub LoadDropDownLists()
        ShipViaDropDownList.Items.Add("")
        ShipViaDropDownList.Items.Add("1 - Speedy Express")
        ShipViaDropDownList.Items.Add("2 - United Package")
        ShipViaDropDownList.Items.Add("3 - Federal Shipping")

        Try
            With anOrderQuery.ProdoctsDataReader()
                If .HasRows Then
                    Do While .Read
                        ProductDropDownList.Items.Add(.GetString(0))
                    Loop
                End If
            End With
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try

        Try
            With anOrderQuery.RetreiveCompanyNames()
                If .HasRows Then
                    Do While .Read
                        Dim ID As String = .Item(0)
                        Dim Name As String = .Item(1)
                        Dim CombinationString As String = (ID + " - " + Name)
                        CompanyNameDropDownList.Items.Add(CombinationString)
                    Loop
                End If
            End With
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try

        Try
            With anOrderQuery.RetreiveEmployeeNames()
                If .HasRows Then
                    Do While .Read
                        Dim ID As Integer = .Item(0)
                        Dim FirstName As String = .GetString(2)
                        Dim LastName As String = .GetString(1)
                        Dim CombinationString As String = (ID.ToString() + " - " + FirstName + " " + LastName)
                        EmployeeNameDropDownList.Items.Add(CombinationString)
                    Loop
                End If
            End With
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Button Events"
    Protected Sub StartOrderButton_Click(sender As Object, e As EventArgs)
        If ValidateCustomerInput() Then
            Try
                If (anOrderQuery.CreateOrderID(CompanyNameDropDownList.Text.Substring(0, 5), EmployeeNameDropDownList.Text.Substring(0, 1), SetDate(), Convert.ToDateTime(RequiredDateTextBox.Text), ShipViaDropDownList.Text.Substring(0, 1), ShipNameTextBox.Text, ShipAddressTextBox.Text, ShipCityTextBox.Text, ShipRegionTextBox.Text, ShipPostalCodeTextBox.Text, ShipCountryTextBox.Text)) = 1 Then
                    ConfirmationLabel.Text = "Success, Please Proceed To Add Items To Your Order"
                    StartOrderButton.Enabled = False
                    AddItemButton.Enabled = True
                    With anOrderQuery.GetOrderID(CompanyNameDropDownList.Text.Substring(0, 5), EmployeeNameDropDownList.Text.Substring(0, 1), SetDate())
                        .Read()
                        OrderNumberTextBox.Text = .Item(0)
                    End With

                    ProductInformationPanel.Visible = True
                    CustomerInfoPanel.Visible = False
                Else
                    ErrorLabel.Text = "Error, Please Check Over Customer Information And Try Again"
                End If
            Catch ex As Exception
                ConfirmationLabel.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub AddItemButton_Click(sender As Object, e As EventArgs)
        Dim ProductID As Integer = Nothing
        Dim UnitPrice As Double = Nothing
        Try
            With anOrderQuery.GrabProductIDAndUnitPrice(ProductDropDownList.Text)
                .Read()
                ProductID = .Item(0)
                UnitPrice = .Item(1)
            End With

            If ValidateQty() Then
                If (anOrderQuery.AddItemToOrderDetails(ProductID, UnitPrice, QuantityTextBox.Text, OrderNumberTextBox.Text, SetDiscount(DiscountTextBox.Text))) = 1 Then
                    ErrorLabel.Text = "Product Successfully Added To Order"
                Else
                    ErrorLabel.Text = "Error, Product Not Added To Order"
                End If
            End If

            OrderGridView.DataSource = (anOrderQuery.RetrieveOrderDetails(OrderNumberTextBox.Text)).Tables(0)
            OrderGridView.DataBind()
            OrderGridView.Visible = True
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
        OrderedItemsPanel.Visible = True
    End Sub
#End Region

#Region "Vaildations"
    Public Function ValidateCustomerInput() As Boolean
        If RequiredDateTextBox.Text <> String.Empty Then
            If ShipViaDropDownList.Text <> String.Empty Then
                If ShipNameTextBox.Text <> String.Empty Then
                    If ShipAddressTextBox.Text <> String.Empty Then
                        If ShipCityTextBox.Text <> String.Empty Then
                            If ShipRegionTextBox.Text <> String.Empty Then
                                If ShipPostalCodeTextBox.Text <> String.Empty Then
                                    If ShipCountryTextBox.Text <> String.Empty Then
                                        Return True
                                    Else
                                        ConfirmationLabel.Text = "Ship Country Error. Please Enter A Valid Ship Country"
                                        With ShipCountryTextBox
                                            .Text = String.Empty
                                            .Focus()
                                        End With
                                    End If
                                Else
                                    ConfirmationLabel.Text = "Ship Postal Code Error. Please Enter A Valid Ship Postal Code"
                                    With ShipPostalCodeTextBox
                                        .Text = String.Empty
                                        .Focus()
                                    End With
                                End If
                            Else
                                ConfirmationLabel.Text = "Ship Region Error. Please Enter A Valid Ship Region"
                                With ShipRegionTextBox
                                    .Text = String.Empty
                                    .Focus()
                                End With
                            End If
                        Else
                            ConfirmationLabel.Text = "Ship City Error. Please Enter A Valid Ship City"
                            With ShipCityTextBox
                                .Text = String.Empty
                                .Focus()
                            End With
                        End If
                    Else
                        ConfirmationLabel.Text = "Ship Address Error. Please Enter A Valid Ship Address"
                        With ShipAddressTextBox
                            .Text = String.Empty
                            .Focus()
                        End With
                    End If
                Else
                    ConfirmationLabel.Text = "Ship Name Error. Please Enter A Valid Ship Name"
                    With ShipNameTextBox
                        .Text = String.Empty
                        .Focus()
                    End With
                End If
            Else
                ConfirmationLabel.Text = "Please Select A Shipping Provider From The List"
                With ShipViaDropDownList
                    .Focus()
                End With
            End If
        Else
            ConfirmationLabel.Text = "Required Date Error. Please Enter A Valide Required Date"
            With RequiredDateTextBox
                .Text = String.Empty
                .Focus()
            End With
        End If

        Return False
    End Function

    Public Function ValidateQty() As Boolean
        Try
            Dim qty As Integer = Integer.Parse(QuantityTextBox.Text)
            Return True
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
            With QuantityTextBox
                .Text = String.Empty
                .Focus()
            End With
        End Try

        Return False
    End Function
#End Region

#Region "Set Functions"
    Public Function SetDate() As Date
        Dim RetrunValue As Date = Nothing
        RetrunValue = (Format(Now, "dd")) + "-" + (SetMonth(Date.Today.Month)) + "-" + (Format(Now, "yy"))
        Return RetrunValue
    End Function

    Public Function SetMonth(ByVal month As Integer) As String
        Dim ReturnValue As String = Nothing

        Select Case month
            Case 1
                ReturnValue = "Jan"
            Case 2
                ReturnValue = "Feb"
            Case 3
                ReturnValue = "Mar"
            Case 4
                ReturnValue = "Apr"
            Case 5
                ReturnValue = "May"
            Case 6
                ReturnValue = "Jun"
            Case 7
                ReturnValue = "Jul"
            Case 8
                ReturnValue = "Aug"
            Case 9
                ReturnValue = "Sep"
            Case 10
                ReturnValue = "Oct"
            Case 11
                ReturnValue = "Nov"
            Case 12
                ReturnValue = "Dec"
            Case Else
                ReturnValue = "Date out of range"
        End Select

        Return ReturnValue
    End Function

    Public Function SetDiscount(ByVal discountCode As String) As Double
        Dim RetrunValue As Double = Nothing

        Select Case discountCode
            Case 1111
                RetrunValue = 0.05
            Case 2222
                RetrunValue = 0.1
            Case 3333
                RetrunValue = 0.15
            Case 4444
                RetrunValue = 0.2
            Case Else
                RetrunValue = 0.0
        End Select

        Return RetrunValue
    End Function
#End Region
End Class