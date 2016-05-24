<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Gh.Presentation.Manage.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="username" CssClass="form-control" placeholder="Usuario" runat="server"></asp:TextBox><br />
    <asp:TextBox ID="password" CssClass="form-control" placeholder="Contraseña" runat="server"></asp:TextBox><br />
    <asp:DropDownList ID="role" CssClass="form-control" placeholder="Rol" runat="server"></asp:DropDownList><br />
    <asp:TextBox ID="minHour" CssClass="form-control" placeholder="Hora mínima de conexión" runat="server"></asp:TextBox><br />
    <asp:TextBox ID="maxHour" CssClass="form-control" placeholder="Hora máxima de conexión" runat="server"></asp:TextBox><br />
    <asp:Button ID="createButton" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="createButton_Click" />
    <asp:Button ID="updateButton" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="updateButton_Click" />
    <asp:Button ID="deleteButton" CssClass="btn btn-danger" runat="server" OnClick="eliminarButton_Click" Text="Eliminar" />
</asp:Content>
