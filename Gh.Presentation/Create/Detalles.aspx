<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="Gh.Presentation.Create.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="nombreBox" runat="server"></asp:TextBox>
    <asp:TextBox ID="direccionBox" runat="server"></asp:TextBox>
    <asp:TextBox ID="poblacionBox" runat="server"></asp:TextBox>
    <asp:TextBox ID="municipioBox" runat="server"></asp:TextBox>
    <asp:TextBox ID="propietairoBox" runat="server"></asp:TextBox>
    <asp:TextBox ID="estrellasBox" runat="server"></asp:TextBox>

    <asp:Button ID="actualizarButton" runat="server" Text="Actualizar" OnClick="actualizarButton_Click" />
</asp:Content>
