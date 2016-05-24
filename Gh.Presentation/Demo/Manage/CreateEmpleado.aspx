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
    <asp:TextBox ID="Nombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
    <asp:TextBox ID="PrimerApellido" runat="server" CssClass="form-control" placeholder="Primer apellido"></asp:TextBox>
    <asp:TextBox ID="SegundoApellido" runat="server" CssClass="form-control" placeholder="Segundo apellido"></asp:TextBox>
    <div style="clear:right"></div>
    <br />
    <asp:TextBox ID="Nif" runat="server" CssClass="form-control" placeholder="NIF"></asp:TextBox>
    <div style="clear:right"></div>
    <br />
    <asp:TextBox ID="FechaNacimiento" runat="server" CssClass="form-control" placeholder="Fecha nacimiento"></asp:TextBox>
    <br />
    
    <%--<asp:Calendar ID="FechaNacimientoCalendar" runat="server" CssClass="formButton" OnSelectionChanged="FechaNacimientoCalendar_SelectionChanged"></asp:Calendar>--%>
    <br />
    
    <asp:DropDownList ID="pais" runat="server" CssClass="form-control"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="poblacion" runat="server" CssClass="form-control"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="municipio" runat="server" CssClass="form-control"></asp:DropDownList>
    
    <br />
    <br />
    
    <asp:DropDownList ID="oficio" runat="server" CssClass="form-control"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="turno" runat="server" CssClass="form-control"></asp:DropDownList>
    
    <br />
    <br />
    
    <asp:TextBox ID="SalarioBruto" runat="server" CssClass="form-control" placeholder="Salario bruto"></asp:TextBox>
    <asp:TextBox ID="CuentaBancaria" runat="server" CssClass="form-control" placeholder="Cuenta bancaria"></asp:TextBox>

    <br />
    <br />

    <asp:TextBox ID="FechaContrato" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Calendar ID="FechaContratoCalendar" runat="server" OnSelectionChanged="FechaContratoCalendar_SelectionChanged"></asp:Calendar>
    <br />
    <asp:TextBox ID="FechaExpiracion" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Calendar ID="FechaExpiracionCalendar" runat="server" OnSelectionChanged="FechaExpiracionCalendar_SelectionChanged"></asp:Calendar>
    <br />

    <asp:Button ID="crearButton" runat="server" CssClass="btn btn-success" Text="Crear" OnClick="crearButton_Click" />
</asp:Content>
