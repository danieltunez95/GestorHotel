<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Gh.Presentation.Manage.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button id="createUserButton" CssClass="btn btn-success margin-bottom" runat="server" text="Crear usuario" OnClick="createUserButton_Click"/>
    <asp:GridView ID="usersView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="usersView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" m>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="UserId" />
            <asp:BoundField DataField="Username" HeaderText="Usuario" />
            <asp:BoundField DataField="Role" HeaderText="Rol" />
            <asp:BoundField DataField="MinHour" HeaderText="Hora de entrada" />
            <asp:BoundField DataField="MaxHour" HeaderText="Hora de salida" />
            <asp:ButtonField Text="Editar" CommandName="Select" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
