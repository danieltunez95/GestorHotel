<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Gh.Presentation.Create.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:dropdownlist runat="server" id="hotelList"></asp:dropdownlist>
    <asp:button runat="server" text="Editar estructura" id="estructuraButton" OnClick="estructuraButton_Click" />
    <asp:button runat="server" text="Editar habitaciones" id="habitacionesButton" OnClick="habitacionesButton_Click" />
    <asp:button runat="server" text="Detalles" id="detallesButton" OnClick="detallesButton_Click" />
</asp:Content>
