<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Gh.Presentation.Manage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Label runat="server" Text="Usuario: "></asp:Label><asp:TextBox ID="username" runat="server"></asp:TextBox><br/>
            <asp:Label runat="server" Text="Contraseña"></asp:Label><asp:TextBox ID="password" runat="server"></asp:TextBox><br/>
            <asp:Label runat="server" Text="Rol"></asp:Label><asp:DropDownList ID="role" runat="server"></asp:DropDownList><br/>
            <asp:Label runat="server" Text="Hora mínima de conexión: "></asp:Label><asp:TextBox ID="minHour" runat="server"></asp:TextBox><br/>
            <asp:Label runat="server" Text="Hora máxima de conexión: "></asp:Label><asp:TextBox ID="maxHour" runat="server"></asp:TextBox><br/>
            <asp:Button ID="createButton" runat="server" Text="Crear" OnClick="createButton_Click" />
            <asp:Button ID="updateButton" runat="server" Text="Actualizar" OnClick="updateButton_Click" />
            <asp:Button ID="deleteButton" runat="server" OnClick="eliminarButton_Click" Text="Eliminar" />
</asp:Content>
