' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub HomeButton_Click(sender As Object, e As EventArgs)
        ButtonEnables(HomeButton.Text)
        Try
            Server.Transfer("Home.aspx", True)
        Catch ex As Exception
            LoadLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub ProductsButton_Click(sender As Object, e As EventArgs)
        ButtonEnables(ProductsButton.Text)
        Try
            Server.Transfer("Products.aspx", True)
        Catch ex As Exception
            LoadLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub SuppliersButton_Click(sender As Object, e As EventArgs)
        ButtonEnables(SuppliersButton.Text)
        Try
            Server.Transfer("Suppliers.aspx", True)
        Catch ex As Exception
            LoadLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub OrderFormButton_Click(sender As Object, e As EventArgs)
        ButtonEnables(OrderFormButton.Text)
        Try
            Server.Transfer("OrderForm.aspx", True)
        Catch ex As Exception
            LoadLabel.Text = ex.Message
        End Try
    End Sub

    Protected Sub OrderDetailsButton_Click(sender As Object, e As EventArgs)
        ButtonEnables(OrderDetailsButton.Text)
        Try
            Server.Transfer("OrderDetails.aspx", True)
        Catch ex As Exception
            LoadLabel.Text = ex.Message
        End Try
    End Sub

    Public Sub ButtonEnables(ByVal ButtonName As String)
        ErrorLabel.Text = String.Empty
        HomeButton.Enabled = True
        ProductsButton.Enabled = True
        SuppliersButton.Enabled = True
        OrderFormButton.Enabled = True
        OrderDetailsButton.Enabled = True

        Select Case ButtonName
            Case Is = "Home"
                HomeButton.Enabled = False
            Case Is = "Products"
                ProductsButton.Enabled = False
            Case Is = "Suppliers"
                SuppliersButton.Enabled = False
            Case Is = "Order Form"
                OrderFormButton.Enabled = False
            Case Is = "Order Details"
                OrderDetailsButton.Enabled = False
            Case Else
                ErrorLabel.Text = "Internal Error"
        End Select
    End Sub
End Class