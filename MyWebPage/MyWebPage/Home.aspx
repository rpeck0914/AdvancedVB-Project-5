<%@ Page Title="Home" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterpages/Site.Master" CodeBehind="Home.aspx.vb" Inherits="MyWebPage.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/HomeStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome to the Kalamazoo Goods database website!</h2>
    <br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This Website Consists Of Four Pages That Allow You to Search Products, Search Supplier Information, Order Products, And Also Review Orders<br /><br />
        <ol>
            <li>Products: Allows The User To Search Products By Name Or Search The Listed Products A Certain Supplier Offers.</li>
            <li>Suppliers: Allows The User To Look At Supplier Information By Searching By Their Supplier Name. Also Allows <br />The User To Update Existing Or Add New Supplier Information. If A Supplier Record Is Needs To Be Deleted,<br />The User Will Also Be Able To Accomplish This.</li>
            <li>Order Form: Allows The User To Place An Order Of Product(s) And Records The Data Into The Database. After This A Bill Is Shown On The Screen.</li>
            <li>Order Details: Allows The User To View The Details Of An Order They May Have Pending Or Old Order History</li>
        </ol>
</asp:Content>
