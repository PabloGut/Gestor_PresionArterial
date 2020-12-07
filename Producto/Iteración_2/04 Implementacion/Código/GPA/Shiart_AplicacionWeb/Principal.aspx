<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Shiart_AplicacionWeb.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container-fluid">
        <div class="row border">
            <img class="img-fluid float-center" src="Images/Medicina.jpg" alt="Chania" width="100%"/>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row funciones">
            <div class="col col-xs-12 border">
                <h2>Historia Clínica</h2>
                <p>Shiart posibilita al paciente visualizar la historia clínica</p>
            </div>

            <div class="col col-xs-12 border">
                <h2>Carga automática</h2>
                <p>Shiart permite la carga automática de mediciones desde un tensiometro digital</p>
            </div>

            <div class="col col-xs-12 border">
                <h2>Carga manual</h2>
                <p>Shiart permite la carga manual de mediciones</p>
            </div>
        </div>
    </div>



</asp:Content>
