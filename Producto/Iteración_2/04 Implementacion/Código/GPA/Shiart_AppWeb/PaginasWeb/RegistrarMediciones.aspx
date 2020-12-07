<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/EstructuraBase.Master" AutoEventWireup="true" CodeBehind="RegistrarMediciones.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.RegistrarMediciones" %>

<asp:Content runat="server" ID="RegistrarMediciones" ContentPlaceHolderID="RegistrarMedicion">
    Registrar Mediciones
            <div class="container-fluid RegMedicionesForm">

            <div class="form-group">
                 <asp:Label runat="server" ID="lblTipoExtremidad" Text="Extremidad" CssClass="col-sm-2"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlExtremidad" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlExtremidad_SelectedIndexChanged" AppendDataBoundItems="True"></asp:DropDownList>
            </div>
            
             <div class="form-group">
                 <asp:Label runat="server" ID="lblUbicacion" Text="Ubicacion" CssClass="col-sm-2"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlUbicacion" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
             </div>

             <div class="form-group">
                 <asp:Label runat="server" ID="lblPosicion" Text="Posición" CssClass="col-sm-2"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlPosicion" CssClass="form-control" AutoPostBack="True"  AppendDataBoundItems="True"></asp:DropDownList>
             </div>

            <div class="form-group">
                 <asp:Label runat="server" ID="lblMomentoDia" Text="Momento del día" CssClass="col-sm-2"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlMomentoDia" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
            </div>
            
        <div class="form-group">
            <asp:Label runat="server" ID="lblSitioMedicion" Text="Sitio de Medición" CssClass="col-sm-2"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlSitioMedicion" CssClass="form-control" AutoPostBack="True" ControlToValidate="ddlSitioMedicion"></asp:DropDownList>
        </div>


             </div>
        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="10600" ontick="Timer1_Tick"></asp:Timer>
            <div class="row filaRegMedicion">
                <div class="columna2RegMedicion col-12 col-x2-12 col-sm-12 col-md-12">
                    <div  class="form-group grillaMediciones" id="grillaMediciones">
                        <asp:GridView ID="gvMediciones" runat="server" Width="743px" AutoGenerateColumns="False" CssClass="table table-responsive-sm table-responsive-md table-responsive-lg  table-responsive-xl" >
                         <Columns>
                             <asp:BoundField DataField="Fecha de Medición" HeaderText="Fecha de Medición"/>
                             <asp:BoundField DataField="Extremidad" HeaderText="Extremidad"/>
                             <asp:BoundField DataField="Ubicación Extremidad" HeaderText="Ubicación Extremidad" />
                             <asp:BoundField DataField="Posición" HeaderText="Posición"/>
                             <asp:BoundField DataField="Momento del Día" HeaderText="Momento del Día"/>
                             <asp:BoundField DataField="Sitio Medición" HeaderText="Sitio de Medición"/>
                             <asp:BoundField DataField="Número" HeaderText="Número"/>
                             <asp:BoundField DataField="Hora" HeaderText="Hora" />
                             <asp:BoundField DataField="Sistólica" HeaderText="Sistólica"/>
                             <asp:BoundField DataField="Diastólica" HeaderText="Diastólica" />
                             <asp:BoundField DataField="Pulso" HeaderText="Pulso" />
                         </Columns>
                     </asp:GridView>
                    </div>

                    <div class="form-group">
                        <asp:Button runat="server" ID="btnIniciar" CssClass="btn btn-primary" AutoPostBack="True" Text="Iniciar" OnClick="btnIniciar_Click"></asp:Button>
                        <asp:Button runat="server" ID="btnMostrarMediciones" CssClass="btn btn-primary" AutoPostBack="True" Text="Mostrar" OnClick="btnMostrarMediciones_Click"></asp:Button>
                        <asp:Button runat="server" ID="Button2" CssClass="btn btn-primary" AutoPostBack="True" Text="Salir"></asp:Button>
                    </div>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>