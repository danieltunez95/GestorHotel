<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Gh.Presentation.Manage.Turnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="crearTurnoButton" runat="server" OnClick="crearTurnoButton_Click" Text="Crear turno" />
<asp:GridView ID="turnosView" runat="server"></asp:GridView>
</asp:Content>
