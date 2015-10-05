<%@ Page Title="Suppliers" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterpages/Site.Master" CodeBehind="Suppliers.aspx.vb" Inherits="MyWebPage.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/SuppliersStyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Suppliers</h2>
    <p></p>
    Search Suppliers:<br />
    <asp:DropDownList ID="SuppliersDropDownList" runat="server"></asp:DropDownList><br /><br />
    <asp:Button ID="SearchSupplierButton" runat="server" Text="Search Suppliers" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="SearchSupplierButton_Click" /><br />
    <p></p>
    <asp:CheckBox ID="EditCheckBox" runat="server" Text=" Edit Supplier Info" AutoPostBack="true" Checked="false" OnCheckedChanged="EditCheckBox_CheckedChanged" />
    <p></p>
    <asp:Panel ID="EditPanel" runat="server" Visible="false">
        Company Name:&nbsp;&nbsp;<asp:TextBox ID="CompanyNameTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        Contact Name:&nbsp;&nbsp;<asp:TextBox ID="ContactNameTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        Contact Title:&nbsp;<asp:TextBox ID="ContactTitleTextBox" runat="server"></asp:TextBox><br /><br />
        Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        Region:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="RegionTextBox" runat="server"></asp:TextBox><br /><br />
        Postal Code:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="PostalCodeTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        Country:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="CountryTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox><br /><br />
        Fax:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="FaxTextBox" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="SaveButton" runat="server" Text="Save"  BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="SaveButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="Delete" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="DeleteButton_Click" />
    </asp:Panel><br />
    <asp:Panel ID="DeleteConfirmationPanel" runat="server" Visible="false">
        Verify Supplier ID:&nbsp;<asp:TextBox ID="IDInputTextBox" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="DeleteConfirmationButton" runat="server" Text="Delete Supplier" BackColor="Crimson" BorderColor="Black" Width="120px" Height="25px" OnClick="DeleteConfirmationButton_Click" />
    </asp:Panel>
    <asp:Label ID="ErrorLabel" runat="server" Text="Location Test"></asp:Label>
    <p></p>
    <asp:GridView ID="SuppliersGridView" runat="server" Font-Bold="True" Width="1800px" Visible="False">
        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
