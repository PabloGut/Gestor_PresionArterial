using Entidades.Clases;
using LogicaNegocio;
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

namespace GPA
{
    public partial class Consultar_EstadisticasMedicionesPromedio : Form
    {
        List<EstadisticaCategoriaSitio> ListaEstadisticaCategoriaSitio;
        List<EstadisticaCategoriaSitio> ListaEstadisticaPromedioConSinExamen;
        public Consultar_EstadisticasMedicionesPromedio()
        {
            InitializeComponent();
        }
        private void Consultar_EstadisticasMedicionesPromedio_Load(object sender, EventArgs e)
        {
            try
            {
                Boolean existe = EstadisticasLN.ExisteMedicionesPorCategoria();

                if (existe == false)
                    EstadisticasLN.InsertarEstadisticasMedicionesPromedioCategoria();

                MostrarCantidadPacientesPorCategoría();
                MostrarEstadisticaPromedioMedicionesConYSinExamen();

                DataTable dtPorcentajePorCategoriaConExamen = EstadisticasLN.MostrarEstadisticaPacientesPorCategoriaDataTableConExamen();
                GraficoTortaConExamen(dtPorcentajePorCategoriaConExamen);
                GraficoBarras(dtPorcentajePorCategoriaConExamen, true);

                DataTable dtPorcentajePorCategoriaSinExamen = EstadisticasLN.MostrarEstadisticaPacientesPorCategoriaDataTableSinExamen();
                GraficoTortaSinExamen(dtPorcentajePorCategoriaSinExamen);
                GraficoBarras(dtPorcentajePorCategoriaSinExamen, false);
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
            
        }
        public void MostrarCantidadPacientesPorCategoría()
        {
            try
            {
                ListaEstadisticaCategoriaSitio = EstadisticasLN.MostrarEstadisticaPacientesPorCategoria();
          

                if (ListaEstadisticaCategoriaSitio != null && ListaEstadisticaCategoriaSitio.Count > 0)
                {
                    foreach (var item in ListaEstadisticaCategoriaSitio)
                    {
                        if(item.ConExamen.Equals("SinExamen"))
                        {
                            if(item.Categoria.Equals("Hipotensión"))
                            {
                                txtCantidadHipotensionSinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeHipotensionSinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("Normal"))
                            {
                                txtCantidadNormalSinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcetajeNormalSinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("Limítrofe"))
                            {
                                txtCantidadLimitrofeSinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeLimitrofeSinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 1"))
                            {
                                txtCantidadNivel1SinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel1SinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 2"))
                            {
                                txtCantidadNivel2SinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel2SinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 3"))
                            {
                                txtCantidadNivel3SinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel3SinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA sistólica o aislada"))
                            {
                                txtCantidadAisladaSinExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeAisladaSinExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                        }
                        if (item.ConExamen.Equals("ConExamen"))
                        {
                            if (item.Categoria.Equals("Hipotensión"))
                            {
                                txtCantidadHipotensionConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeHipotensionConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("Normal"))
                            {
                                txtCantidadNormalConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNormalConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("Limítrofe"))
                            {
                                txtCantidadLimitrofeConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeLimitrofeConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 1"))
                            {
                                txtCantidadNivel1ConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel1ConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 2"))
                            {
                                txtCantidadNivel2ConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel2ConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA grado o nivel 3"))
                            {
                                txtCantidadNivel3ConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeNivel3ConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                            if (item.Categoria.Equals("HTA sistólica o aislada"))
                            {
                                txtCantidadAisladaConExamen.Text = Convert.ToString(item.CantidadPacientes);
                                txtPorcentajeAisladaConExamen.Text = Convert.ToString((item.CantidadPacientes * 100) / item.TotalPacientes);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //  graficoBarras(ListaEstadisticaCategoriaSitio);

        }
        public void MostrarEstadisticaPromedioMedicionesConYSinExamen()
        {
            try
            {
                ListaEstadisticaPromedioConSinExamen = EstadisticasLN.MostrarPromedioMedicionesConYSinExamen();
                if (ListaEstadisticaPromedioConSinExamen != null && ListaEstadisticaPromedioConSinExamen.Count > 0)
                {
                    foreach (var item in ListaEstadisticaPromedioConSinExamen)
                    {
                        if (item.ConExamen.Equals("SinExamen"))
                        {
                            txtPromedioSistolicaSinExamen.Text = Convert.ToString(item.PromedioSistolica);
                            txtPromedioDiastolicaSinExamen.Text = Convert.ToString(item.PromedioDiastolica);
                        }
                        if (item.ConExamen.Equals("ConExamen"))
                        {
                            txtPromedioSistolicaConExamen.Text = Convert.ToString(item.PromedioSistolica);
                            txtPromedioDiastolicaConExamen.Text = Convert.ToString(item.PromedioDiastolica);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(" Error: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void GraficoBarras(DataTable datatable,Boolean conExamen)
        {
                if (conExamen == true)
                {
                    chart1.Series.Add("Series1");
                    chart1.Series["Series1"].IsValueShownAsLabel = true;
                    chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.Series["Series1"].LegendText = "categoria";
                    chart1.Series["Series1"].XValueMember = "categoria";
                    chart1.Series["Series1"].YValueMembers = "cantidadPacientes";
                    chart1.DataSource = datatable;
                }
                else
                {
                    chart3.Series.Add("Series2");
                    chart3.Series["Series2"].IsValueShownAsLabel = true;
                    chart3.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart3.Series["Series2"].LegendText = "categoria";
                    chart3.Series["Series2"].XValueMember = "categoria";
                    chart3.Series["Series2"].YValueMembers = "cantidadPacientes";
                    chart3.DataSource = datatable;
                }
        }
        public void GraficoTortaConExamen(DataTable dtPorcentajePorCategoriaConExamen)
        {
            Series serie = new Series("CantidadCategoriaConExamen")
            {
                ChartType = SeriesChartType.Pie,
                XValueMember = "categoria",
                YValueMembers = "porcentaje",
                IsValueShownAsLabel = true
            };
            chart2.Series.Add(serie);
            chart2.DataSource = dtPorcentajePorCategoriaConExamen;
        }
        public void GraficoTortaSinExamen(DataTable dtPorcentajePorCategoriaSinExamen)
        {
            Series serie = new Series("CantidadCategoriaSinExamen")
            {
                ChartType = SeriesChartType.Pie,
                XValueMember = "categoria",
                YValueMembers = "porcentaje",
                IsValueShownAsLabel = true
            };
            chart4.Series.Add(serie);
            chart4.DataSource = dtPorcentajePorCategoriaSinExamen;
        }
    }
}
