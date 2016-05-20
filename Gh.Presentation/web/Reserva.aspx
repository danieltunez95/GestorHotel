<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Web.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="Gh.Presentation.web.Reserva" %>

<%@ MasterType VirtualPath="~/Web/Web.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/hotelGrafico.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="fechaInicioBox" runat="server" placeholder="Fecha final: 23/12/2016"></asp:TextBox>
    <asp:TextBox ID="fechaFinalBox" runat="server" placeholder="Fecha final: 25/12/2016"></asp:TextBox>
    <asp:Button ID="verButton" runat="server" Text="Button" OnClick="verButton_Click" />

    <br />

    <h1 id="plantaActual" runat="server"></h1>
    <div class="row">
        <div class="col-lg-1">
            <asp:ImageButton ID="arrowUp" runat="server"  src="Sources/arrowUp.png" OnClick="arrowUp_Click"  /> <br />
            <asp:ImageButton ID="arrowDown" runat="server"  src="Sources/arrowDown.png" OnClick="arrowDown_Click" /> <br />
        </div>
        <div class="col-lg-11">
            <asp:Panel ID="hotelTable" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
