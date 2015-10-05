' Program: Program 5, Final
'  Author: Robert Peck
'    Date: 4/10/2015

Imports SelectTablesLibrary.Tables.SelectTables

Public Class WebForm6
    Inherits System.Web.UI.Page

    Private anOrderDetailsQuery As New SelectTablesLibrary.Tables.SelectTables
    Private AccumulatedTotal As Double = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With anOrderDetailsQuery.RetrieveOrderNumbers()
                If .HasRows Then
                    Do While .Read
                        OrdersDropDownList.Items.Add(.Item(0))
                    Loop
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub SearchOrderButton_Click(sender As Object, e As EventArgs)
        Try
            OrderDetailsGridView.DataSource = (anOrderDetailsQuery.RetrieveOrderDetails(OrdersDropDownList.Text))
            OrderDetailsGridView.DataBind()
            OrderDetailsGridView.Visible = True

            Dim Price As Double = Nothing
            Dim Qty As Integer = Nothing
            Dim Discount As Double = Nothing
            Dim CostOfItem As Double = Nothing


            With anOrderDetailsQuery.RetrieveOrderDetailsForCalculations(OrdersDropDownList.Text)
                If .HasRows Then
                    Do While .Read
                        Price = .Item(0)
                        Qty = .Item(1)
                        Discount = .Item(2)
                        If Discount > 0 Then
                            CostOfItem = (Price - (Price * Discount)) * Qty
                            AccumulatedTotal += CostOfItem
                        Else
                            CostOfItem = Price * Qty
                            AccumulatedTotal += CostOfItem
                        End If
                        
                    Loop
                End If
            End With
        Catch ex As Exception
            TotalsLabel.Text = ex.Message
        End Try

        TotalsLabel.Text = AccumulatedTotal.ToString("c")
        AccumulatedTotal = Nothing
        OrderedItemsPanel.Visible = True
    End Sub
End Class