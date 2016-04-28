<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigurarHotel.aspx.cs" Inherits="Hotel.CrearHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/Style.css" rel="stylesheet" type="text/css" />
    <script src="scripts/CrearHotel.js"></script>
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
        <input type="text" id="matrizOculta" runat="server"/>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar plantilla" />
        <asp:Panel ID="hotelPanel" runat="server">
        </asp:Panel>
        <asp:Button ID="crearButton" runat="server" Text="Crear hotel" OnClick="crearButton_Click"></asp:Button>
    </form>
    

</body>
</html>
