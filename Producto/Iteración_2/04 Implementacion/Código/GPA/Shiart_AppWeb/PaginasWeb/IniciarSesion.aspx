<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/InicioSesion.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.IniciarSesion" %>

<asp:Content runat="server" ID="IniciarSesion" ContentPlaceHolderID="ContenedorInicio" >
            
          <div class=" col-sm-2 col-md-3 col-lg-4 col-xl-4 izq d-none  d-md-none  d-md-block">

          </div>
            
           <div class="col-12 col-sm-8 col-md-6 col-lg-4 col-xl-4 centro align-content-center">
               <asp:Login ID="logInicioSesion" runat="server" OnAuthenticate="Login1_Authenticate">
    
               </asp:Login>
           </div>

           <div class=" col-sm-2 col-md-3 col-lg-4 col-xl-4 der d-none d-md-none  d-md-block">
               
           </div>
</asp:Content>