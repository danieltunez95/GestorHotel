<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Gh.Presentation.Manage.Main1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-4 center">
        <h2><asp:Label ID="habitacionesLibresLabel" runat="server"></asp:Label></h2>
        <asp:Label runat="server" text="habitaciones libres de "></asp:Label>
        <asp:Label ID="habitacionesTotalLabel" runat="server"></asp:Label>
    </div>
    <div class="col-md-4 center">
        <h2><asp:Label ID="entradasLabel" runat="server"></asp:Label></h2>
        <asp:Label runat="server" Text=" entradas hoy."></asp:Label>
    </div>
    <div class="col-md-4 center">
        <h2><asp:Label ID="salidasLabel" runat="server"></asp:Label></h2>
        <asp:Label  runat="server" Text=" salidas hoy."></asp:Label>
    </div>
</asp:Content>
