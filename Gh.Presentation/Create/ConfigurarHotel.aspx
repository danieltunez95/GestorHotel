﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigurarHotel.aspx.cs" Inherits="Gh.Presentation.Create.ConfigurarHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/Style.css" rel="stylesheet" type="text/css" />
    <script src="scripts/CrearHotel.js"></script>
    <style type="text/css">
        #Text1 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="datosPanel" runat="server">
            <h1>Datos</h1>
            <asp:Label ID="Label8" runat="server" Text="nombre:"></asp:Label>
            <asp:TextBox ID="nombreBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
            <asp:TextBox ID="direccionBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Municipio:"></asp:Label>
            <asp:TextBox ID="municipioBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Población:"></asp:Label>
            <asp:TextBox ID="poblacionBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="País:"></asp:Label>
            <asp:TextBox ID="paisBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Estrellas:"></asp:Label>
            <asp:TextBox ID="estrellasBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="usuarioBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="passwordBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
            <br />
            <hr />
            <h1>Forma</h1>
            <p>Utilizarás estos datos para crear visualmente el hotel.</p>
            <asp:Label ID="Label3" runat="server" Text="Plantas: "></asp:Label>
            <asp:TextBox ID="plantasTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Largo (X): "></asp:Label>
            <asp:TextBox ID="largoTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Ancho (Y): "></asp:Label>
            <asp:TextBox ID="anchoTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="datosButton" runat="server" Text="Siguiente" OnClick="datosButton_Click" />
        </asp:Panel>

        <asp:Panel ID="fisicoPanel" runat="server" Visible="false">
            <asp:Button ID="plantillaButton" runat="server" OnClick="plantillaButton_Click" Text="plantillaButton plantilla" />
            <br />
            <asp:Label ID="plantaActualTextBox" runat="server" BorderStyle="None"></asp:Label>
            <asp:Panel ID="hotelPanel" runat="server">
            </asp:Panel>
            <asp:Panel ID="ocultarPanel" runat="server">
                <asp:Button runat="server" type="button" ID="crearPlantaButton" value="Siguiente planta" OnClientClick="crearPlanta();" OnClick="crearPlantaButton_Click" />
                <input runat="server" id="hiddenHotel" type="text" />
            </asp:Panel>
            <br />
            <br />
            &nbsp;
        <br />
            <br />
            <br />
            <asp:Button ID="crearHotelButton" runat="server" Text="Finalizar" Visible="false" OnClick="crearHotelButton_Click" />

        </asp:Panel>
    </form>


</body>
</html>
