﻿<%@ Page Title="Editar Tipo Habitación" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="Gh.Presentation.Create.EditarHabitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="/Demo/Create/scripts/EditarHabitacion.js"></script>
    <asp:Panel runat="server" ID="MenuTipoHabitacion" Visible="true">
        <div class="col-sm-4">
            <asp:DropDownList runat="server" Id="DropDownTipoHabitacion" CssClass="form-control"></asp:DropDownList> &nbsp;
        </div>
        <asp:Button ID="editarButton" CssClass="btn btn-info" runat="server" Text="Editar" OnClick="editarButton_Click" /> &nbsp;
        <asp:Button ID="crearButton" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="crearButton_Click" /> &nbsp;
        <asp:Button ID="eliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" />
        <br />
        <br />
        <asp:Button ID="replicarTodasButton" CssClass="btn btn-group" runat="server" Text="Replicar en todas" OnClick="replicarTodasButton_Click" /> &nbsp;
        <asp:Button ID="replicarSeleccionButton" CssClass="btn btn-group" runat="server" Text="Seleccionar habitaciones" OnClick="replicarSeleccionButton_Click" />
    </asp:Panel>
    <br />
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


</asp:Content>
