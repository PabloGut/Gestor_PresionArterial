﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/ShiartMaster.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.IniciarSesion" %>
<asp:Content runat="server" ID="IniciarSesion" ContentPlaceHolderID="ContenedorInicio" >
    <form id="form1" runat="server">
       <div class="login">
       <asp:Login ID="logInicioSesion" runat="server" OnAuthenticate="Login1_Authenticate">
 
       </asp:Login>
       </div>
   </form>
</asp:Content>