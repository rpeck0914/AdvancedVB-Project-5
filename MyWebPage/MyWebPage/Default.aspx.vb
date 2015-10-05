Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub EnterButton_Click(sender As Object, e As EventArgs)
        Try
            Server.Transfer("Home.aspx", True)
        Catch ex As Exception

        End Try
    End Sub
End Class