<%@ Page Language="C#" enableEventValidation="true" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gh.Presentation.Manage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <link href="/Style/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h2 class="form-signin-heading">Inicie sesión</h2>
        <label for="inputEmail" class="sr-only">Usuario</label>
        <asp:TextBox runat="server" id="Username" class="form-control" placeholder="Usuario" required="" autofocus=""/>
        <label for="inputPassword" class="sr-only">Contraseña</label>
        <asp:TextBox runat="server" type="password" id="Password" class="form-control" placeholder="Contraseña" required=""/>
        <asp:Button ID="loginButton" runat="server"  class="btn btn-lg btn-primary btn-block" type="submit" Text="Enviar" OnClick="loginButton_Click"></asp:Button>

    </div>
    </form>
</body>
</html>
