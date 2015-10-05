<%@ Page Title="Products" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterpages/Site.Master" CodeBehind="Products.aspx.vb" Inherits="MyWebPage.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ProductsStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products</h2>
    <p></p>
    By Product Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;By Supplier Name:<br />
    <asp:DropDownList ID="ProductsDropDownList" runat="server">

    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="SupplierDropDownList" runat="server">

    </asp:DropDownList><br />
    <p></p>
    <asp:Button ID="SearchProductButton" runat="server" Text="Search Product" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="SearchProductButton_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="SearchSupplierButton" runat="server" Text="Search Supplier" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="SearchSupplierButton_Click" />
    <p></p>
    <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    <p></p>
    <asp:GridView ID="ProductsGridView" runat="server" Font-Bold="True" Width="1000px" >
    </asp:GridView>
</asp:Content>

