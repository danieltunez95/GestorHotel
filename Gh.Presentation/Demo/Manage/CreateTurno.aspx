<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateTurno.aspx.cs" Inherits="Gh.Presentation.Manage.CreateTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="nombreBox" CssClass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
    <br />
    <asp:TextBox ID="turnoPrimeroInicioBox" CssClass="form-control" runat="server" placeholder="Primer turno (inicio)"></asp:TextBox>
    <br />
    <asp:TextBox ID="turnoPrimeroFinalBox" CssClass="form-control" runat="server" placeholder="Primer turno (final)"></asp:TextBox>
    <br />
    <asp:TextBox ID="turnoSegundoInicioBox" CssClass="form-control" runat="server" placeholder="Segundo turno (inicio)"></asp:TextBox>
    <br />
    <asp:TextBox ID="turnoSegundoFinalBox" CssClass="form-control" runat="server" placeholder="Segundo turno (final)"></asp:TextBox>
    <br />
    <asp:TextBox ID="jornadaBox" CssClass="form-control" runat="server" placeholder="Jornada (h. semanales)"></asp:TextBox>
    <br />
    <asp:Button ID="crearTurnoButton" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Crear" OnClick="crearTurnoButton_Click" />
</asp:Content>
