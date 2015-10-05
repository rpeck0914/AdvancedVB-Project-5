<%@ Page Title="Order Form" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterpages/Site.Master" CodeBehind="OrderForm.aspx.vb" Inherits="MyWebPage.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/OrderFormStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Form</h2>
    <p></p>
    <asp:Panel ID="CustomerInfoPanel" runat="server" Visible="true">
        <h3>Customer Information:</h3>
        Customer Name:&nbsp;<asp:DropDownList ID="CompanyNameDropDownList" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Employee Name:&nbsp;<asp:DropDownList ID="EmployeeNameDropDownList" runat="server" ></asp:DropDownList>&nbsp;&nbsp;<br /><br />
        Required Date:&nbsp;<asp:TextBox ID="RequiredDateTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*ex dd-Jan-yy<br /><br />
        Ship Via:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ShipViaDropDownList" runat="server"></asp:DropDownList><br /><br />
        Ship Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ShipNameTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Ship Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ShipAddressTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Ship City:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ShipCityTextBox" runat="server"></asp:TextBox><br /><br />
        Ship Region:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ShipRegionTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Ship Postal Code:&nbsp;<asp:TextBox ID="ShipPostalCodeTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Ship Country:&nbsp;<asp:TextBox ID="ShipCountryTextBox" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="StartOrderButton" runat="server" Text="StartOrder" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="StartOrderButton_Click" /><br /><br />
        <asp:Label ID="ConfirmationLabel" runat="server" Text=""></asp:Label><br /><br />
    </asp:Panel>
    <asp:Panel ID="ProductInformationPanel" runat="server" Visible="false">
        <h3>Product Information:</h3>
        Product:&nbsp;<asp:DropDownList ID="ProductDropDownList" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
        Quantity:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox><br /><br />
        Order Number:&nbsp;&nbsp;<asp:TextBox ID="OrderNumberTextBox" runat="server" Enabled="false" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Discount Code:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="DiscountTextBox" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="AddItemButton" runat="server" Text="Add Item" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" Enabled="false" OnClick="AddItemButton_Click" /><br /><br />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label><br /><br />
    </asp:Panel>
    <asp:Panel ID="OrderedItemsPanel" runat="server" Visible="false">
        <h3>Ordered Items</h3>
        <asp:GridView ID="OrderGridView" runat="server" Font-Bold="True" Width="617px" Visible="False"></asp:GridView><br /><br />
    </asp:Panel>
</asp:Content>
