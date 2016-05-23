<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Web.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="Gh.Presentation.web.Reserva" %>

<%@ MasterType VirtualPath="~/Web/Web.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/hotelGrafico.css" rel="stylesheet" />
    <script src="Scripts/Reserva.js?v=8"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-inline">
        <div class="form-group">
            <asp:TextBox ID="fechaInicioBox" class="form-control" TextMode="Date" runat="server" placeholder="Fecha final: 23/12/2016"></asp:TextBox>
            <asp:TextBox ID="fechaFinalBox" class="form-control" TextMode="Date" runat="server" placeholder="Fecha final: 25/12/2016"></asp:TextBox>
            <asp:TextBox ID="numeroPersonas" class="form-control" TextMode="Number" runat="server" placeholder="Personas"></asp:TextBox>

            <asp:Button ID="verButton" class="btn btn-default" runat="server" Text="Buscar" OnClick="verButton_Click" />
        </div>
    </div>
    <br />

    <h1 id="plantaActual" runat="server"></h1>
    <div class="row">
        <h2 id="nueroHabitacionesLabel" runat="server"></h2>
        <div class="col-lg-1">
            <img id="arrowUp" src="Sources/arrowUp.png" onclick="siguientePlanta();" style="visibility: hidden" />
            <br />
            <img id="arrowDown" src="Sources/arrowDown.png" onclick="anteriorPlanta();" style="visibility: hidden" />
            <br />
        </div>
        <div class="col-lg-11">
            <asp:Panel ID="hotelTable" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
