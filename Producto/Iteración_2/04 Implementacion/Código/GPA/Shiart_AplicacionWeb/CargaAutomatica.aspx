<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="CargaAutomatica.aspx.cs" Inherits="WebApplication1.CargaAutomatica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
        .auto-style2 {
            height: 41px;
            width: 150px;
        }
        .auto-style3 {
            width: 150px;
        }
        .auto-style4 {
            width: 169px;
        }
        .auto-style5 {
            width: 91px;
        }
        .titulo {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1 class="titulo">Formulario para registrar las mediciones de un tensiometro digital</h1>
    <br />
    <br />
    <div class="container border">
        <div class="row justify-content-start col-12">
            <h3>Información General</h3>
            <div class="col-10">
                <asp:Label runat="server" ID="Label1" Text="Extremidad" CssClass="col-sm-2"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlExtremidad" CssClass="col-sm-2" OnSelectedIndexChanged="ddlExtremidad_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                <asp:Label runat="server" ID="Label2" Text="Posición" CssClass="col-sm-2"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlPosicion" CssClass="col-sm-2"></asp:DropDownList>

                <asp:Label runat="server" ID="lblSitioMedición" Text="Sitio de Medición" CssClass="col-sm-2"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlSitioMedicion" CssClass="col-sm-2"></asp:DropDownList>

            </div>
        </div>
        <br />
        <div class="row justify-content-start col-12">
            <div class="col-10">
                <asp:Label runat="server"  ID="lblUbicación" Text="Ubicación" CssClass="col-sm-2"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlUbicación" CssClass="col-sm-2" AutoPostBack="False" OnSelectedIndexChanged="ddlUbicación_SelectedIndexChanged"></asp:DropDownList>

                 <asp:Label runat="server" ID="lblMomentoDelDia" Text="Momento del día" CssClass="col-sm-2"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlMomentoDelDia" CssClass="col-sm-2"></asp:DropDownList>
            </div>
        </div>
        <br />
       
    </div>
     <br />
    <div class="container border">
        <div class="row justify-content-between">
            <div class="col-4">
                <h3>Lectura del Dispositivo</h3>
                <asp:TextBox runat="server" ID="txtMediciones" TextMode="MultiLine" Height="20px"></asp:TextBox>
            </div>
        </div>

        <div class="row justify-content-start">
            <div class="col-5">
                 <asp:ListBox runat="server" ID="lstMediciones" CssClass="border" Width="931px" Height="137px"></asp:ListBox>
            </div>
        </div>

        <div class="row justify-content-start">
            <div class="col-10">
                <asp:Button runat="server" ID="btnIniciar" Text="Iniciar" />
                <asp:Button runat="server" ID="btnCerrar" Text="Cerrar" />
            </div>
        </div>
    </div>

    <br />

    <div class="container border">

         <div class="row justify-content-start">
              <div class="col-12 align-items-center">
                 <asp:Label ID="Label3" Text="Cantidad de Mediciones" runat="server"></asp:Label>
                 <asp:TextBox ID="txtCantidadDeMediciones" runat="server"></asp:TextBox>
                 <br />
                 <br />
                 <div class="col-12 border">
                     <asp:GridView ID="gvMediciones" runat="server" Width="873px">
                         <Columns>
                             <asp:BoundField DataField="Número" HeaderText="Número" />
                             <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                             <asp:BoundField DataField="sistólica" HeaderText="Sistólica" />
                             <asp:BoundField DataField="diastólica" HeaderText="Diastólica" />
                             <asp:BoundField DataField="pulso" HeaderText="Pulso" />
                         </Columns>
                     </asp:GridView>
                 </div>
            </div>
            <div class="col-10">
                <br />
               <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
            </div>
        </div>
    </div>
</asp:Content>
