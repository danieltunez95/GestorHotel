<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="Gh.Presentation.Create.EditarHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="MenuTipoHabitacion" Visible="true">
        <asp:DropDownList runat="server" Id="DropDownTipoHabitacion" CssClass="form-control col-lg-6"></asp:DropDownList> &nbsp;
        <asp:Button ID="editarButton" CssClass="btn btn-info" runat="server" Text="Editar" OnClick="editarButton_Click" /> &nbsp;
        <asp:Button ID="crearButton" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="crearButton_Click" /> &nbsp;
        <asp:Button ID="eliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" />
    </asp:Panel>
    <br />
    <asp:Panel runat="server" ID="TipoHabitacion" Visible="false">
        <asp:Label ID="Instrucciones" runat="server" CssClass="formLabel" Text="Seleccione las caracteristicas para el tipo de habitación."></asp:Label>
        <br />
        <asp:TextBox ID="NombreTipoHabitacion" runat="server" CssClass="form-control" placeholder="Nombre para el tipo de habitación"></asp:TextBox>
        <br />
        <asp:TextBox ID="Descripcion" runat="server" CssClass="form-control" placeholder="Descripción de la habitación" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:TextBox ID="MetrosCuadrados" runat="server" CssClass="form-control" placeholder="Metros cuadrados" TextMode="Number"></asp:TextBox>
        <br />
        <asp:TextBox ID="Precio" runat="server" CssClass="form-control" placeholder="Precio de la habitación"></asp:TextBox>
        <br />
        <asp:Button ID="createButton" CssClass="btn btn-success" runat="server" Text="Crear tipo" OnClick="createButton_Click" />
        <asp:Button ID="editButton" CssClass="btn btn-info" runat="server" Text="Editar tipo" OnClick="editButton_Click" />
    </asp:Panel>
<%--    <asp:Panel runat="server" ID="EditarTipoHabitacion" Visible="false">
        <asp:Label ID="Label1" runat="server" CssClass="formLabel" Text="Seleccione las caracteristicas para el tipo de habitación."></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Nombre para el tipo de habitación"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Descripción de la habitación"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Metros cuadrados "></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Precio de la habitación"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="createButton_Click" />
    </asp:Panel>--%>

</asp:Content>
