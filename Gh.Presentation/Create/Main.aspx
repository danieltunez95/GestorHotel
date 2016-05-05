<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Gh.Presentation.Create.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:dropdownlist runat="server" id="hotelList"></asp:dropdownlist>
    <asp:button runat="server" text="Editar estructura" id="estructuraButton" />
    <asp:button runat="server" text="Editar habitaciones" id="habitacionesButton" />
    <asp:button runat="server" text="Detalles" id="detallesButton" />
</asp:Content>
