<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="Gh.Presentation.Create.EditarHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="TipoHabitacion">
        <asp:Label ID="Instrucciones" runat="server" CssClass="form-control" Text="Seleccione las caracteristicas para el tipo estándard de habitación (se aplicarán en todas)."></asp:Label>
        <br />
        <asp:TextBox ID="NombreTipoHabitacion" runat="server" CssClass="form-control" placeholder="Nombre para el tipo de habitación"></asp:TextBox>
        <br />
        <asp:TextBox ID="Descripcion" runat="server" CssClass="form-control" placeholder="Descripción de la habitación"></asp:TextBox>
        <br />
        <asp:TextBox ID="MetrosCuadrados" runat="server" CssClass="form-control" placeholder="Metros cuadrados "></asp:TextBox>
        <br />
        <asp:TextBox ID="Precio" runat="server" CssClass="form-control" placeholder="Precio de la habitación"></asp:TextBox>
        <br />
        <asp:Button ID="createButton" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="createButton_Click" />
    </asp:Panel>

</asp:Content>
