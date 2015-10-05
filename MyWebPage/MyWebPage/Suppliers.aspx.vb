' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Imports SelectTablesLibrary.Tables.SelectTables

Public Class WebForm4
    Inherits System.Web.UI.Page

    Private aSupplierQuery As New SelectTablesLibrary.Tables.SelectTables
    Private SupplierID As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ErrorLabel.Text = String.Empty
        Try
            With aSupplierQuery.SuppliersDataReader()
                If .HasRows Then
                    Do While .Read
                        SuppliersDropDownList.Items.Add(.GetString(0))
                    Loop
                End If
            End With
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub

#Region "Button Events"
    Protected Sub SearchSupplierButton_Click(sender As Object, e As EventArgs)
        Try
            SuppliersGridView.DataSource = (aSupplierQuery.RetrieveSuppliersDataSet(SuppliersDropDownList.Text.Trim)).Tables(0)
            SuppliersGridView.DataBind()
            SuppliersGridView.Visible = True

            Dim TextBoxFillArray(9) As String
            With aSupplierQuery.SupplierArrayFiller(SuppliersDropDownList.Text.Trim)
                If .HasRows Then
                    .Read()
                    For index As Integer = 0 To 9
                        If IsDBNull(.Item(index)) Then
                            TextBoxFillArray(index) = String.Empty
                        Else
                            TextBoxFillArray(index) = .Item(index)
                        End If
                    Next
                End If
            End With
            FillTextBoxes(TextBoxFillArray)
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub SaveButton_Click(sender As Object, e As EventArgs)
        Try
            If (aSupplierQuery.RecordCheck(CompanyNameTextBox.Text, ContactNameTextBox.Text)) > 0 Then
                With aSupplierQuery.GrabSupplierID(CompanyNameTextBox.Text)
                    .Read()
                    SupplierID = .Item(0)
                End With
                If (aSupplierQuery.UpdateSupplierRecord(CompanyNameTextBox.Text, ContactNameTextBox.Text, ContactTitleTextBox.Text, AddressTextBox.Text, CityTextBox.Text, RegionTextBox.Text, PostalCodeTextBox.Text, CountryTextBox.Text, PhoneTextBox.Text, FaxTextBox.Text, SupplierID)) = 1 Then
                    ErrorLabel.Text = "Record Saved Successfully"
                Else
                    ErrorLabel.Text = "Error, Record Not Saved"
                End If
            Else
                If (aSupplierQuery.AddSupplierRecord(CompanyNameTextBox.Text, ContactNameTextBox.Text, ContactTitleTextBox.Text, AddressTextBox.Text, CityTextBox.Text, RegionTextBox.Text, PostalCodeTextBox.Text, CountryTextBox.Text, PhoneTextBox.Text, FaxTextBox.Text)) = 1 Then
                    ErrorLabel.Text = "Record Saved Successfully"
                Else
                    ErrorLabel.Text = "Error, Record Not Saved"
                End If
            End If
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
        SupplierID = Nothing
        Call SearchSupplierButton_Click(sender, e)
    End Sub

    Protected Sub DeleteButton_Click(sender As Object, e As EventArgs)
        DeleteConfirmationPanel.Visible = True
    End Sub

    Protected Sub DeleteConfirmationButton_Click(sender As Object, e As EventArgs)
        Try
            With aSupplierQuery.GrabSupplierID(CompanyNameTextBox.Text)
                .Read()
                SupplierID = .Item(0)
            End With

            If (IDInputTextBox.Text = SupplierID) Then
                If (aSupplierQuery.DeleteSuppliers(CompanyNameTextBox.Text, IDInputTextBox.Text)) = 1 Then
                    ErrorLabel.Text = "Record Has Been Successfully Deleted"
                Else
                    ErrorLabel.Text = "Error, Record Was Not Deleted"
                End If
            Else
                ErrorLabel.Text = "Supplier ID Numbers Do Not Match. Please Re-Enter The Supplier ID"
            End If
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try

        DeleteConfirmationPanel.Visible = False
    End Sub
#End Region

#Region "Check Box Event"
    Protected Sub EditCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EditCheckBox.CheckedChanged
        If EditCheckBox.Checked = True Then
            EditPanel.Visible = True
        Else
            EditPanel.Visible = False
        End If
    End Sub
#End Region

#Region "Supplier Text Box Information Fill"
    Public Sub FillTextBoxes(ByVal Arrary() As String)
        CompanyNameTextBox.Text = Arrary(0)
        ContactNameTextBox.Text = Arrary(1)
        ContactTitleTextBox.Text = Arrary(2)
        AddressTextBox.Text = Arrary(3)
        CityTextBox.Text = Arrary(4)
        RegionTextBox.Text = Arrary(5)
        PostalCodeTextBox.Text = Arrary(6)
        CountryTextBox.Text = Arrary(7)
        PhoneTextBox.Text = Arrary(8)
        FaxTextBox.Text = Arrary(9)
    End Sub
#End Region
End Class