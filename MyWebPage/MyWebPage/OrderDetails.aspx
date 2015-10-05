<%@ Page Title="Order Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterpages/Site.Master" CodeBehind="OrderDetails.aspx.vb" Inherits="MyWebPage.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/OrderDetailsStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Details</h2>
    Select Order Number:&nbsp;<asp:DropDownList ID="OrdersDropDownList" runat="server"></asp:DropDownList><br /><br />
    <asp:Button ID="SearchOrderButton" runat="server" Text="Search Order" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="SearchOrderButton_Click" /><br /><br />
    <asp:Panel ID="OrderedItemsPanel" runat="server" Visible="false">
        <h3>Ordered Items</h3>
        <asp:GridView ID="OrderDetailsGridView" runat="server" Visible="false" ></asp:GridView><br /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Total Cost For All Products:&nbsp;<asp:Label ID="TotalsLabel" runat="server" Text="" Font-Size="15pt"></asp:Label>
    </asp:Panel>
</asp:Content>
