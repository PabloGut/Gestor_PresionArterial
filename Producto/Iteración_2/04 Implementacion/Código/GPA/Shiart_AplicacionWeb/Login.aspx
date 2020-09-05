<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shiart_AplicacionWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server" class="form-horizontal login" >
    <div class="container">
                <div>
                    <h2>Iniciar Sesión</h2>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Usuario" CssClass=" col-sm-2"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*Ingrese el usuario" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass=" col-sm-2"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContraseña" ErrorMessage="*Ingrese la contraseña" ForeColor="Red" ValidationGroup="usuario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group col-xs-10 col-sm-10 col-md-10 col-lg-10 col-xl-10 ">
                    <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar" CssClass="form-control btn btn-primary" OnClick="btnIniciarSesion_Click" ValidationGroup="usuario" />

                </div>

         <asp:Label ID="lblNoExisteUsuario" runat="server" Text="Label" Visible="false"></asp:Label>

    </div>
    </form>
</asp:Content>
