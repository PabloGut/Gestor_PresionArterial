using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidades.Clases;
using GPA.Manejadores;
using LogicaNegocio;

namespace GPA
{
    public partial class ConsultarMedicionesPaciente : Form
    {
        private int idHc { set; get; }
        public DataTable mediciones;
        public DataTable detalleMediciones;
        public ConsultarMedicionesPaciente(int idHc)
        {
            InitializeComponent();
            this.idHc = idHc;
        }

        private void ConsultarMedicionesPaciente_Load(object sender, EventArgs e)
        {
            cargarMedicionesPresionArterial();
            obtenerDatosYGraficar();
        }
        public void obtenerDatosYGraficar()
        {
            mediciones = presentarMediciones(idHc,null,null,null,null,null,null,null);
            detalleMediciones = MedicionDePresionArterialLN.obtenerMedicionesConFiltro(idHc, null, null, null, null, null, null, null);
            dgvConsultarMediciones.DataSource = mediciones;
            graficar(detalleMediciones);
        }
        public void cargarMedicionesPresionArterial()
        {
            Utilidades.cargarCombo(cboExtremidad, ExtremidadLN.mostrarExtremidades(), "id_extremidad", "nombre");
            Utilidades.cargarCombo(cboPosicion, PosicionLN.mostrarPosiciones(), "id_posicion", "nombre");
            Utilidades.cargarCombo(cboSitioMedicion, SitioMedicionLN.mostrarSitiosDeMedicion(), "id_sitioMedicion", "nombre");
            Utilidades.cargarCombo(cboMomentoDia, MomentoDiaLN.mostrarMomentosDelDia(), "id_momentoDelDia", "nombre");
        }

        private void cboExtremidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilidades.cargarCombo(cboUbicacionExtremidad, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(cboExtremidad.SelectedValue)), "id_ubicacionExtremidad", "nombre");
        }
        public DataTable presentarMediciones(int idHc, DateTime? fechaDesde, DateTime? fechaHasta, String extremidad, String momentoDia, String posicion, String ubicacionExtremidad, String sitioMedicion)
        {
            return MedicionDePresionArterialLN.obtenerMedicionesPresionArterial(idHc,fechaDesde,fechaHasta,extremidad,momentoDia,posicion,ubicacionExtremidad, sitioMedicion);
        }

        private void dgvConsultarMediciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultarMediciones.Rows.Count == 0 || dgvConsultarMediciones.Rows == null)
            {
                return;
            }
            mtbHoraInicio.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Hora Inicio"].Value);
            DateTime fechaMedicion= Convert.ToDateTime(dgvConsultarMediciones.CurrentRow.Cells["Fecha"].Value);
            mtbFecha.Text = fechaMedicion.ToShortDateString();
            txtExtremidad.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Extremidad"].Value);
            txtUbicacionExtremidad.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Ubicacion Extremidad"].Value);
            txtSitioMedicion.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Sitio Medicion"].Value);
            txtMomentoDia.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Momento del día"].Value);
            txtPosicion.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Posición"].Value);
            txtPromedioSistolica.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Promedio Valor Máximo"].Value);
            txtPromedioDiastolica.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Promedio Valor Mínimo"].Value);
            txtPromedioPulso.Text = Convert.ToString(dgvConsultarMediciones.CurrentRow.Cells["Promedio Pulso"].Value);

            int id_medicion = Convert.ToInt32(dgvConsultarMediciones.CurrentRow.Cells["id_medicion"].Value);


            dgvDetalleMediciones.DataSource = presentarDetalleMediciones(id_medicion, idHc);
        }
        public DataTable presentarDetalleMediciones(int id_medicion, int idHc)
        {
            return MedicionDePresionArterialLN.obtenerDetalleMedicionesPresionArterial(idHc, id_medicion,null,null,null,null,null,null,null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            String extremidad = null;
            String momentoDia = null;
            String posicion = null;
            String ubicacionExtremidad = null;
            String sitioMedicion = null;

            Extremidad extremidadSeleccionada = (Extremidad)cboExtremidad.SelectedItem;
            MomentoDia momentoDiaSeleccionado = (MomentoDia)cboMomentoDia.SelectedItem;
            Posicion posicionSeleccionada = (Posicion)cboPosicion.SelectedItem;
            UbicacionExtremidad ubicacionExtremidadSeleccionada = (UbicacionExtremidad)cboUbicacionExtremidad.SelectedItem;
            SitioMedicion sitioMedicionSeleccionado = (SitioMedicion)cboSitioMedicion.SelectedItem;


            if (!String.IsNullOrEmpty(mtbFechaDesde.Text))
                fechaDesde = DateTime.Parse(mtbFechaDesde.Text);

            if (!String.IsNullOrEmpty(mtbFechaHasta.Text))
                fechaHasta = DateTime.Parse(mtbFechaHasta.Text);
            if (!String.IsNullOrEmpty(extremidadSeleccionada.nombre))
                extremidad = extremidadSeleccionada.nombre;
            if (!String.IsNullOrEmpty(momentoDiaSeleccionado.nombre) && !momentoDiaSeleccionado.nombre.Equals("--Seleccionar--"))
                momentoDia = momentoDiaSeleccionado.nombre;
            if (!String.IsNullOrEmpty(posicionSeleccionada.nombre) && !posicionSeleccionada.nombre.Equals("--Seleccionar--"))
                posicion = posicionSeleccionada.nombre;
            if (!String.IsNullOrEmpty(ubicacionExtremidadSeleccionada.nombre) && !ubicacionExtremidadSeleccionada.nombre.Equals("--Seleccionar--"))
                ubicacionExtremidad = ubicacionExtremidadSeleccionada.nombre;
            if (!String.IsNullOrEmpty(sitioMedicionSeleccionado.nombre) && !sitioMedicionSeleccionado.nombre.Equals("--Seleccionar--"))
                sitioMedicion = sitioMedicionSeleccionado.nombre;

            DataTable dt= MedicionDePresionArterialLN.obtenerMedicionesPresionArterial(idHc, fechaDesde, fechaHasta, extremidad, momentoDia, posicion, ubicacionExtremidad, sitioMedicion);
            DataTable detalles= MedicionDePresionArterialLN.obtenerMedicionesConFiltro(idHc, fechaDesde, fechaHasta, extremidad, momentoDia, posicion, ubicacionExtremidad, sitioMedicion);
            dgvConsultarMediciones.DataSource = dt;

            chart1.Series.Remove(chart1.Series["Series1"]);
            chart1.Series.Remove(chart1.Series["Series2"]);
            chart1.Series.Remove(chart1.Series["Series3"]);

            graficar(detalles);

        }
        public void graficar(DataTable datatable)
        {
            chart1.Series.Add("Series1");
            chart1.Series.Add("Series2");
            chart1.Series.Add("Series3");

            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].IsValueShownAsLabel = true;
            chart1.Series["Series3"].IsValueShownAsLabel = true;

        

            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Series1"].LegendText = "Sistólica";
            chart1.Series["Series1"].XValueMember = "FechaHora";
            chart1.Series["Series1"].YValueMembers = "ValorMaximo";
            chart1.DataSource = datatable;

            chart1.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Series2"].LegendText = "Diastolica";
            chart1.Series["Series2"].XValueMember = "FechaHora";
            chart1.Series["Series2"].YValueMembers = "ValorMinimo";
            chart1.DataSource = datatable;

            chart1.Series["Series3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Series3"].LegendText = "Pulso";
            chart1.Series["Series3"].XValueMember = "FechaHora";
            chart1.Series["Series3"].YValueMembers = "Pulso";
            chart1.DataSource = datatable;


            //chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            // Series serie = chart1.Series.Add("Sistolica");
            //        serie= chart1.Series.Add("Diastolica");
            //        serie = chart1.Series.Add("Pulso");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            chart1.Series.Remove(chart1.Series["Series1"]);
            chart1.Series.Remove(chart1.Series["Series2"]);
            chart1.Series.Remove(chart1.Series["Series3"]);
            obtenerDatosYGraficar();
        }
    }
}
