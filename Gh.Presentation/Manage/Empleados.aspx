<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="Gh.Presentation.Manage.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button id="createEmployeeButton" runat="server" text="Crear empleado" OnClick="createEmployeeButton_Click"/>
    <asp:GridView ID="usersView" runat="server" AutoGenerateColumns="true">
    </asp:GridView>
</asp:Content>
