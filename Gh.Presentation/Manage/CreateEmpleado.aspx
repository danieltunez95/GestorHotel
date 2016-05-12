<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateEmpleado.aspx.cs" Inherits="Gh.Presentation.Manage.CreateEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=FechaNacimiento]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
            $("[id$=FechaContrato]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
            $("[id$=FechaExpiracion]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
    </script>
    <asp:Button ID="crearTurnoButton" runat="server" Text="Turnos de trabajo" OnClick="crearTurnoButton_Click" /> <br /><br />
    <asp:Label ID="NombreLabel" runat="server" Text="Nombre: " CssClass="formLabel"></asp:Label>
    <asp:TextBox ID="Nombre" runat="server" CssClass="formButton" placeholder="Nombre"></asp:TextBox>
    <asp:TextBox ID="PrimerApellido" runat="server" CssClass="formButton" placeholder="Primer apellido"></asp:TextBox>
    <asp:TextBox ID="SegundoApellido" runat="server" CssClass="formButton" placeholder="Segundo apellido"></asp:TextBox>
    <div style="clear:right"></div>
    <br />
    <br />
    <asp:Label ID="NifLabel" runat="server" Text="NIF: " CssClass="formLabel"></asp:Label>
    <asp:TextBox ID="Nif" runat="server" CssClass="formButton" placeholder="NIF"></asp:TextBox>
    <div style="clear:right"></div>
    <br />
    <br />
    <asp:Label ID="FechaNacimientoLabel" runat="server" Text="Fecha nacimiento: " CssClass="formLabel"></asp:Label>
    <asp:TextBox ID="FechaNacimiento" runat="server" CssClass="formButton"></asp:TextBox>
    <br />
    <br />
    
    <%--<asp:Calendar ID="FechaNacimientoCalendar" runat="server" CssClass="formButton" OnSelectionChanged="FechaNacimientoCalendar_SelectionChanged"></asp:Calendar>--%>
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
