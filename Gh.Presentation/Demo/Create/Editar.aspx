<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Gh.Presentation.Demo.Create.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/hotelGrafico.css" rel="stylesheet" />
    <script src="scripts/CrearHotel.js?v=1"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="form-inline">
            <div class="form-group">
                <h1>Forma</h1>
                <p>Si quiere añadir o eliminar filas, columnas o plantas, cambie los valores a continuación:</p>
                <asp:textbox id="plantasTextBox" class="form-control" placeholder="Plantas" runat="server"></asp:textbox>
                <asp:textbox id="largoTextBox" class="form-control" placeholder="Largo (X)" runat="server"></asp:textbox>
                <asp:textbox id="anchoTextBox" class="form-control" placeholder="Ancho (Y)" runat="server"></asp:textbox>
                <asp:button id="datosButton" class="form-control" runat="server" text="Siguiente" onclick="datosButton_Click" />
            </div>
        </div>
    </div>

    <div class="row">
        <asp:panel id="graficoPanel" runat="server">
            </asp:panel>
    </div>
</asp:Content>
