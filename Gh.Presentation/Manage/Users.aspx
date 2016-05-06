<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Gh.Presentation.Manage.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button id="createUserButton" runat="server" text="Crear usuario" OnClick="createUserButton_Click" />
    <asp:GridView ID="usersView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="usersView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="UserId" />
            <asp:BoundField DataField="Username" HeaderText="Usuario" />
            <asp:BoundField DataField="Role" HeaderText="Rol" />
            <asp:BoundField DataField="MinHour" HeaderText="Hora de entrada" />
            <asp:BoundField DataField="MaxHour" HeaderText="Hora de salida" />
            <asp:ButtonField Text="Editar" CommandName="Select" />
        </Columns>
    </asp:GridView>
</asp:Content>
