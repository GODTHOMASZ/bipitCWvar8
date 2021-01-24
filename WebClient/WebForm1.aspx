<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebClient.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Таблица с накладными"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" Height="258px" Width="846px" CellPadding="3" BackColor="#DEBA84" BorderColor="Black" BorderStyle="none" BorderWidth="2px" CellSpacing="2">
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
    <div style="width: 810px"><asp:Label ID="Label2" runat="server" Text="Дата: "></asp:Label>
    <asp:TextBox ID="Date" runat="server" TextMode="Date" Width="152px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Date" runat="server" ErrorMessage="Укажите дату!" ForeColor="Red"></asp:RequiredFieldValidator></div><br />
    <div style="width: 808px"><asp:Label ID="Label3" runat="server" Text="Поставщик: "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList></div><br />
    <div style="width: 808px"><asp:Label ID="Label4" runat="server" Text="Сумма: "></asp:Label>
    <asp:TextBox ID="TextBox1" TextMode="Number" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox1" runat="server" ErrorMessage="Укажите сумму!" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1"  ControlToValidate="TextBox1" runat="server" ErrorMessage="Число должно быть положительным!" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
    </div><br />
    <asp:Button ID="Button1" runat="server" BackColor="#FFFFFF" Height="40px" Text="Добавить" Width="200px" OnClick="Button1_Click" />
</asp:Content>
