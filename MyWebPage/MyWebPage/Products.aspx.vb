' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Imports SelectTablesLibrary.Tables.SelectTables

Public Class WebForm3
    Inherits System.Web.UI.Page

    Private aProductQuery As New SelectTablesLibrary.Tables.SelectTables

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProductsGridView.Visible = False
        ErrorLabel.Text = String.Empty
        Try
            With aProductQuery.ProdoctsDataReader()
                If .HasRows Then
                    Do While .Read
                        ProductsDropDownList.Items.Add(.GetString(0))
                    Loop
                End If
            End With

            With aProductQuery.SuppliersDataReader()
                If .HasRows Then
                    Do While .Read
                        SupplierDropDownList.Items.Add(.GetString(0))
                    Loop
                End If
            End With
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub

#Region "Button Events"
    Protected Sub SearchProductButton_Click(sender As Object, e As EventArgs)
        Try
            ProductsGridView.DataSource = (aProductQuery.RetrieveProducts(ProductsDropDownList.Text.Trim)).Tables(0)
            ProductsGridView.DataBind()
            ProductsGridView.Visible = True
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub SearchSupplierButton_Click(sender As Object, e As EventArgs)
        Try
            ProductsGridView.DataSource = (aProductQuery.RetrieveProductsViaSuppliers(SupplierDropDownList.Text.Trim)).Tables(0)
            ProductsGridView.DataBind()
            ProductsGridView.Visible = True
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
        End Try
    End Sub
#End Region
End Class