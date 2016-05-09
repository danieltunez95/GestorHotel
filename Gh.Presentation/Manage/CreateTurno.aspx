<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateTurno.aspx.cs" Inherits="Gh.Presentation.Manage.CreateTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Primer turno (inicio): "></asp:Label>
    <asp:TextBox ID="turnoPrimeroInicioBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Primer turno (final):"></asp:Label>
    <asp:TextBox ID="turnoPrimeroFinalBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Segundo turno (inicio): "></asp:Label>
    <asp:TextBox ID="turnoSegundoInicioBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Segundo turno (final): "></asp:Label>
    <asp:TextBox ID="turnoSegundoFinalBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Jornada (h. semanales): "></asp:Label>
    <asp:TextBox ID="jornadaBox" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="crearTurnoButton" runat="server" Text="Crear" OnClick="crearTurnoButton_Click" />
</asp:Content>
