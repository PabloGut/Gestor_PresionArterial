<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/EstructuraBase.Master" AutoEventWireup="true" CodeBehind="ConsultarMediciones.aspx.cs" Inherits="Shiart_AppWeb.PaginasWeb.ConsultarMediciones" %>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderLinkGrafico" runat="server">

   <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
          var data = google.visualization.arrayToDataTable(<%=graficar()%>);

          var options = {
              title: 'Mediciones de presión arterial',
              curveType: 'function',
              width: 1500,
              legend: { position: 'bottom' },
              vAxis: { title: 'Diastolica/Sistólica' },
              hAxis: {
                  textPosition: 'out',
                  textStyle: { fontSize: 9 },
                  format: 'M/d/yy',
                     },
              pointSize: 5,
              chartArea: { left: 'auto'}
          };

          var chart = new google.visualization.LineChart(document.getElementById('grafico'));


          chart.draw(data, options);
      }
    </script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="RegistrarMedicion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HistoriaClinica" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ConsultarMediciones" runat="server">
   
    <div class="container-fluid RegMedicionesForm">
       
        <div class="row">

            <div class="col-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFechaDesde" Text="Fecha Desde" CssClass="col-sm-2"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaDesde" CssClass="form-control" AutoPostBack="false"></asp:TextBox>
                    <!--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFechaDesde"></asp:CompareValidator>-->
                </div>
                <div class="form-group">
                    <asp:Calendar runat="server" ID="cFechaDesde" OnSelectionChanged="cFechaDesde_SelectionChanged"></asp:Calendar>
                </div>

            </div>

            <div class="col-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="Label1" Text="Fecha Desde" CssClass="col-sm-2"></asp:Label>
                    <asp:TextBox runat="server" ID="txtFechaHasta" CssClass="form-control" AutoPostBack="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Calendar runat="server" ID="cFechaHasta" OnSelectionChanged="cFechaHasta_SelectionChanged"></asp:Calendar>
                </div>

            </div>

        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFiltroTipoExtremidad" Text="Extremidad" CssClass="col-sm-2"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlFiltroExtremidad" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlFiltroExtremidad_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div> 
            <div class="col">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFiltroUbicacion" Text="Ubicacion" CssClass="col-sm-2"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlFiltroUbicacion" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                </div>
            </div>
            <div class="col">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFiltroPosicion" Text="Posición" CssClass="col-sm-2"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlFiltroPosicion" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="True"></asp:DropDownList>
                </div>
            </div> 
        </div>

         <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFiltroMomentoDia" Text="Momento del día" CssClass="col-sm-2"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlFiltroMomentoDia" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                </div>
            </div>
             <div class="col">
                 <div class="form-group">
                     <asp:Label runat="server" ID="lblFiltroSitioMedicion" Text="Sitio de Medición" CssClass="col-sm-2"></asp:Label>
                     <asp:DropDownList runat="server" ID="ddlFiltroSitioMedicion" CssClass="form-control" AutoPostBack="false" ControlToValidate="ddlSitioMedicion"></asp:DropDownList>
                 </div>
             </div>
        </div>


        <div class="row justify-content-around">
            <div class="form-group">
                <asp:Button runat="server" ID="btnBuscarMediciones" CssClass="btn btn-primary" AutoPostBack="false" Text="Buscar" OnClick="btnBuscarMediciones_Click"></asp:Button>
            </div>
        </div>
       
    </div>
    
    
    <div class="container-fluid">
            <h2>Mediciones</h2>
    <div class="row">
        <div class="col justify-content-start bordePrueba" id="grafico" style='height: 280px;'>
        </div>
    </div>
    <asp:Repeater ID="RepeaterMediciones" runat="server" OnItemDataBound="RepeaterMediciones_ItemDataBound">
        <ItemTemplate>
            <div class="row listaMediciones">
                <div class="col ">
                    <h4>Hora Inicio: <%# DataBinder.Eval(Container.DataItem,"Hora Inicio") %></h4>
                    <h4>Fecha: <%# DataBinder.Eval(Container.DataItem,"Fecha") %></h4>
                    <h4>Extremidad: <%# DataBinder.Eval(Container.DataItem,"Extremidad") %></h4>
                    <h4>Ubicación Extremidad: <%# DataBinder.Eval(Container.DataItem,"Ubicacion Extremidad") %></h4>
                    <h4>Sitio de Medición: <%# DataBinder.Eval(Container.DataItem,"Sitio Medicion") %></h4>
                    <h4>Momento del Día: <%# DataBinder.Eval(Container.DataItem,"Momento del día") %></h4>
                    <h4>Posición: <%# DataBinder.Eval(Container.DataItem,"Posición") %></h4>
                </div>
                <div class="col">
                            <asp:GridView ID="gvDetalleMediciones" runat="server" Width="743px" AutoGenerateColumns="False" CssClass="table table-responsive-sm table-responsive-md table-responsive-lg  table-responsive-xl grillaDetalle">
                                <Columns>
                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                    <asp:BoundField DataField="Valor Máximo" HeaderText="Sistólica" />
                                    <asp:BoundField DataField="Valor Mínimo" HeaderText="Diastólica" />
                                    <asp:BoundField DataField="Pulso" HeaderText="Pulso" />
                                </Columns>
                            </asp:GridView>
                     <h4>Promedio Sistólica: <%# DataBinder.Eval(Container.DataItem,"Promedio Sistólica") %></h4>
                     <h4>Promedio Diastólica: <%# DataBinder.Eval(Container.DataItem,"Promedio Diastólica") %></h4>
                     <h4>Promedio Valor Pulso: <%# DataBinder.Eval(Container.DataItem,"Promedio Pulso") %></h4>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
