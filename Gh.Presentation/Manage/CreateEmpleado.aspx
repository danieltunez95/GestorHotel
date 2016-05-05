<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Main.Master" AutoEventWireup="true" CodeBehind="CreateEmpleado.aspx.cs" Inherits="Gh.Presentation.Manage.CreateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:TextBox ID="Nombre" runat="server" CssClass="formButton"></asp:TextBox>
    <asp:TextBox ID="PrimerApellido" runat="server" CssClass="formButton"></asp:TextBox>
    <asp:TextBox ID="SegundoApellido" runat="server" CssClass="formButton"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="Nif" runat="server" CssClass="formButton"></asp:TextBox>

    <br />
    <br />

    <asp:TextBox ID="FechaNacimiento" runat="server" CssClass="formButton"></asp:TextBox>
    <br />
    <br />
    <asp:Calendar ID="FechaNacimientoCalendar" runat="server" CssClass="formButton" OnSelectionChanged="FechaNacimientoCalendar_SelectionChanged"></asp:Calendar>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    <asp:DropDownList ID="pais" runat="server" CssClass="formButton"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="poblacion" runat="server" CssClass="formButton"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="municipio" runat="server" CssClass="formButton"></asp:DropDownList>
    
    <br />
    <br />
    
    <asp:DropDownList ID="oficio" runat="server" CssClass="formButton"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="turno" runat="server" CssClass="formButton"></asp:DropDownList>
    
    <br />
    <br />
    
    <asp:TextBox ID="SalarioBruto" runat="server" CssClass="formButton"></asp:TextBox>
    <asp:TextBox ID="CuentaBancaria" runat="server" CssClass="formButton"></asp:TextBox>

    <br />
    <br />

    <asp:TextBox ID="FechaContrato" runat="server" CssClass="formButton"></asp:TextBox>
    <asp:Calendar ID="FechaContratoCalendar" runat="server" CssClass="formButton" OnSelectionChanged="FechaContratoCalendar_SelectionChanged"></asp:Calendar>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:TextBox ID="FechaExpiracion" runat="server" CssClass="formButton"></asp:TextBox>
    <asp:Calendar ID="FechaExpiracionCalendar" runat="server" CssClass="formButton" OnSelectionChanged="FechaExpiracionCalendar_SelectionChanged"></asp:Calendar>
    <br />

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <asp:Button ID="crearButton" runat="server" CssClass="formButton" Text="Crear" OnClick="crearButton_Click" />
</asp:Content>
