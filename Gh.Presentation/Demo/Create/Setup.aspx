<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Gh.Presentation.Create.Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="/Style/hotelGrafico.css" rel="stylesheet" />
    <script src="/Demo/Create/scripts/CrearHotel.js?v=3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Panel ID="datosPanel" runat="server">
            <div class="form-inline">
                <div class="form-group">
                    <h1>Datos</h1>
                    <asp:TextBox ID="nombreBox" class="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                    <asp:TextBox ID="direccionBox" class="form-control" placeholder="Dirección" runat="server"></asp:TextBox>
                    <asp:TextBox ID="municipioBox" class="form-control" placeholder="Municipio" runat="server"></asp:TextBox>
                    <asp:TextBox ID="poblacionBox" class="form-control" placeholder="Población" runat="server"></asp:TextBox>
                    <asp:TextBox ID="paisBox" class="form-control" placeholder="País" runat="server"></asp:TextBox>
                    <asp:TextBox ID="estrellasBox" class="form-control" placeholder="Estrellas" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <h1> Datos de inicio de sesión</h1>
                    <p> Necesarios para la primera configuración</p>
                    <asp:TextBox ID="usuarioBox" class="form-control" placeholder="Usuario" runat="server"></asp:TextBox>
                    <asp:TextBox ID="passwordBox" class="form-control" placeholder="Contraseña" runat="server"></asp:TextBox>
                    <asp:TextBox ID="emailBox" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                </div>
                <br />
                <hr />
                <div class="form-group">
                    <h1>Forma</h1>
                    <p>Utilizarás estos datos para crear visualmente el hotel.</p>
                    <asp:TextBox ID="plantasTextBox" class="form-control" placeholder="Plantas" runat="server"></asp:TextBox>
                    <asp:TextBox ID="largoTextBox" class="form-control" placeholder="Largo (X)" runat="server"></asp:TextBox>
                    <asp:TextBox ID="anchoTextBox" class="form-control" placeholder="Ancho (Y)" runat="server"></asp:TextBox>
                    <asp:Button ID="datosButton" class="form-control"  runat="server" Text="Siguiente" OnClick="datosButton_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="fisicoPanel" runat="server" Visible="false">
            <asp:Label runat="server" Text="Ancho: "></asp:Label>
            <asp:TextBox ID="anchoDisabledBox" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Largo: "></asp:Label>
            <asp:TextBox ID="largoDisabledBox" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Plantas: "></asp:Label>
            <asp:TextBox ID="plantasDisabledBox" class="form-control" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Button ID="plantillaButton" runat="server" OnClick="plantillaButton_Click" Text="Generar plantilla" />
            <br />
            <span>Planta
                <asp:Label ID="plantaActualTextBox" runat="server" BorderStyle="None"></asp:Label>
                de 
                <asp:Label ID="plantasMaximas" runat="server" BorderStyle="None" /></span>
            <asp:Panel ID="hotelPanel" runat="server">
            </asp:Panel>
            <asp:Panel ID="ocultarPanel" runat="server">
                <asp:Button runat="server" type="button" ID="crearPlantaButton" value="Siguiente planta" OnClientClick="crearPlanta();" OnClick="crearPlantaButton_Click" Text="Siguiente planta" />
                <asp:TextBox ID="hiddenHotel" runat="server" CssClass="hiddenLabel"></asp:TextBox>
            </asp:Panel>
        <br />
            <asp:Panel runat="server" ID="graficoPanel"></asp:Panel>
            <asp:Button ID="crearHotelButton" runat="server" Text="Finalizar" Visible="false" OnClientClick="generarPlantilla();" OnClick="crearHotelButton_Click" />

        </asp:Panel>
</asp:Content>

