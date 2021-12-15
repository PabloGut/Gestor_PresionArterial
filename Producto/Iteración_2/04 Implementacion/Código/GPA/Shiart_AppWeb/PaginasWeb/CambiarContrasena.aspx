<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/EstructuraBase.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.CambiarContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderLinkGrafico" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RegistrarMedicion" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HistoriaClinica" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ConsultarMediciones" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ModificarContrasena" runat="server">

        <div class="row">
            <div class=" col-md-3 col-lg-3 col-xl-3  d-none  d-md-none  d-md-block align-content-center">
                </div>
           <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 borde align-content-center">
                
               <div class="container-fluid ">

                   <div class="row">

                       <div class="col-12">
                           <div class="form-group">
                               <asp:Label runat="server" ID="Label1" Text="Modificar Contraseña" CssClass="col-sm-2"></asp:Label>
                           </div>
                       </div>
                   </div>
                     <div class="row">

                       <div class="col-12">
                           <div class="form-group">
                               <asp:Label runat="server" ID="Label2" Text="Contraseña actual" CssClass="col-sm-2"></asp:Label>
                               <asp:TextBox runat="server" ID="txtContrasenaActual" CssClass="form-control" TextMode="Password"></asp:TextBox>
                               <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtContrasenaActual"></asp:CompareValidator>
                           </div>
                       </div>
                   </div>
                   <div class="row">

                       <div class="col-12">
                           <div class="form-group">
                               <asp:Label runat="server" ID="lblNuevaContraseña" Text="Nueva Contraseña" CssClass="col-sm-2"></asp:Label>
                               <asp:TextBox runat="server" ID="txtNuevaContraseña" CssClass="form-control" TextMode="Password"></asp:TextBox>
                               <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNuevaContraseña"></asp:CompareValidator>
                           </div>
                       </div>

                   </div>

                          
                   <div class="row">

                       <div class="col-12">
                           <div class="form-group">
                               <asp:Label runat="server" ID="lblConfirmarContraseña" Text="Confirmar Contraseña" CssClass="col-sm-2"></asp:Label>
                               <asp:TextBox runat="server" ID="txtConfirmarContraseña" CssClass="form-control" TextMode="Password"></asp:TextBox>
                               <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmarContraseña"></asp:CompareValidator>
                           </div>
                       </div>

                   </div>

                   <div class="row botonHistoriaClinica">
                       <div class="col col-sm-12 col-lg-12 form-group">
                           <asp:Button runat="server" ID="btnActualizarContrasena" CssClass="btn btn-primary" AutoPostBack="True" Text="Guardar" OnClick="BtnActualizarContrasena_Click"></asp:Button>

                       </div>
                   </div>

               </div>
           </div>
                  <div class="col-md-3 col-lg-3 col-xl-3  d-none  d-md-none  d-md-block align-content-center">
                </div>
          </div>
</asp:Content>
