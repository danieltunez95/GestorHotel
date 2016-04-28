<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigurarHotel.aspx.cs" Inherits="GestorHotel.CrearHotel" %>

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
    <div>
        
        <asp:Label ID="Label1" runat="server" Text="Largo (X): "></asp:Label>
        <asp:TextBox ID="largoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ancho (Y): "></asp:Label>
        <asp:TextBox ID="anchoTextBox" runat="server"></asp:TextBox>
        
    </div>
        <asp:Label ID="Label3" runat="server" Text="Plantas: "></asp:Label>
        <asp:TextBox ID="plantasTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="plantillaButton" runat="server" OnClick="plantillaButton_Click" Text="plantillaButton plantilla" />
        <asp:Panel ID="hotelPanel" runat="server">
        </asp:Panel>
        <br />
        <br />
        <input id="hiddenHotel" type="text" />
        <input type="button" id="crearButton" value="Crear hotel" onclick="crearHotel();"/>

    </form>
    

</body>
</html>
