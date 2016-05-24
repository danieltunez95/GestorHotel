<%@ Page Title="" Language="C#" MasterPageFile="~/Demo/web/web.master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="Gh.Presentation.web.Comprar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-inline">
        <div class="form-group">
            <h2>Datos de acceso</h2>
            <p>Necesarios para consultar el estado de su reserva y obtener bonificaciones.</p>
            <asp:TextBox runat="server" ID="emailBox" TextMode="Email" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
            <asp:TextBox runat="server" ID="contraseñaBox" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
        </div>
    </div>
    <div class="form-inline">
        <div class="form-group">
            <h2>Datos personales</h2>
            <asp:TextBox runat="server" ID="nombreBox" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            <asp:TextBox runat="server" ID="primerApellidoBox" CssClass="form-control" placeholder="Primer apellido"></asp:TextBox>
            <asp:TextBox runat="server" ID="segundoApellidoBox" CssClass="form-control" placeholder="Segundo apellido"></asp:TextBox>
            <asp:TextBox runat="server" ID="telefonoBox" CssClass="form-control" placeholder="Teléfono"></asp:TextBox>
            <asp:TextBox runat="server" ID="dniBox" CssClass="form-control" placeholder="DNI"></asp:TextBox>
            <asp:TextBox runat="server" ID="fechaNacimiento" TextMode="Date" CssClass="form-control" placeholder="Fecha de nacimiento (31/01/2016)"></asp:TextBox>
        </div>
    </div>
    <div class="form-inline">
        <div class="form-group">
            <h2>Datos bancarios</h2>
            <p>Pendiente de integrar con la entidad bancaria (podría ser una pasarela finalmente).</p>
            <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Número"></asp:TextBox>
            <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" placeholder="Caducidad (01/16)"></asp:TextBox>
            <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" placeholder="CP"></asp:TextBox>
        </div>
    </div>
    <p>
        <asp:Button ID="finalizarButton" runat="server" CssClass="btn btn-lg btn-primary" OnClick="finalizarButton_Click" Text="Finalizar" />
    </p>
    <p>*Bonificaciones según plan de hotel.</p>
</asp:Content>
