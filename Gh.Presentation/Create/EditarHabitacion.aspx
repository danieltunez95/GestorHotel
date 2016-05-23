<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="Gh.Presentation.Create.EditarHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="MenuTipoHabitacion">
        <asp:DropDownList runat="server" Id="DropDownTipoHabitacion" CssClass="form-control"></asp:DropDownList>
    </asp:Panel>
    <asp:Panel runat="server" ID="CrearTipoHabitacion">
        <asp:Label ID="Instrucciones" runat="server" CssClass="formLabel" Text="Seleccione las caracteristicas para el tipo de habitación."></asp:Label>
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
    <asp:Panel runat="server" ID="EditarTipoHabitacion">
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
    </asp:Panel>

</asp:Content>
