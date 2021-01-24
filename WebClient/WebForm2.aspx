<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebClient.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Таблица с поставщиками"></asp:Label>
<asp:GridView ID="GridView1" runat="server" CellPadding="3" Height="212px" Width="689px" BackColor="#DEBA84" BorderColor="Black" BorderStyle="none" BorderWidth="1px" CellSpacing="2">
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#FFFFFF" Font-Bold="True" ForeColor="Black" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFFFF" ForeColor="Black" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
</asp:GridView><br />
<div><asp:Label ID="Label2" runat="server" Text="Поставщик: "></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Укажите поставщика!" ForeColor="Red"></asp:RequiredFieldValidator></div><br />
<asp:Button ID="btn1" runat="server" OnClick="Button1_Click" Text="Добавить" Height="40px" Width="200px" BackColor="#FFFFFF" />
</asp:Content>
