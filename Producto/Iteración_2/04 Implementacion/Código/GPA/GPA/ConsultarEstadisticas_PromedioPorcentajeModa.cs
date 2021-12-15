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
    public partial class ConsultarEstadisticas_PromedioPorcentajeModa : Form
    {
        List<EstadisticaCantidadPorSexo> listaEstadisticaCantidadFemenino;
        List<EstadisticaCantidadPorSexo> listaEstadisticaCantidadMasculino;
        public ConsultarEstadisticas_PromedioPorcentajeModa()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarEstadisticas_PromedioPorcentajeModa_Load(object sender, EventArgs e)
        {
            try
            {
                Boolean existe = EstadisticasLN.ExisteCantidadPacientesPorSexo();
                if(existe==false)
                    EstadisticasLN.InsertarEstadisticas();

                MostrarEstadisticaPromedioEdad();
                MostrarEstadisticaCantidadPacienteFemenino();
                MostrarEstadisticaCantidadPacienteMasculino();
                MostrarEstadisticaModaEdad();

                DataTable dtF = EstadisticasLN.MostrarEstadisticaCantidadFemeninoDataTable();
                DataTable dtM = EstadisticasLN.MostrarEstadisticaCantidadMasculinoDataTable();

                DataTable dtPorcentajePacientesPorSexo = EstadisticasLN.MostrarEstadisticaPorcentajePacientesPorSexo();

                //listaEstadisticaCantidadFemenino = EstadisticasLN.MostrarCantidadFemenino();
                //listaEstadisticaCantidadMasculino = EstadisticasLN.MostrarCantidadMasculino();

                //graficoBarra(listaEstadisticaCantidadFemenino, listaEstadisticaCantidadMasculino);
                GraficoBarra(dtPorcentajePacientesPorSexo);
                GraficoTorta(dtPorcentajePacientesPorSexo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
}
        public void MostrarEstadisticaPromedioEdad()
        {
            try
            {
                List<EstadisticaPromedioEdad> listaEstadisticaPromedio = EstadisticasLN.MostrarEstadisticaEdadPromedio();

                if (listaEstadisticaPromedio != null && listaEstadisticaPromedio.Count > 0)
                {
                    foreach (var item in listaEstadisticaPromedio)
                    {
                        txtEdadPromedio.Text = item.promedioEdad.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
            
        }
        public void MostrarEstadisticaCantidadPacienteFemenino()
        {
            try
            {
                listaEstadisticaCantidadFemenino = EstadisticasLN.MostrarCantidadFemenino();

                if (listaEstadisticaCantidadFemenino != null && listaEstadisticaCantidadFemenino.Count > 0)
                {
                    foreach (var item in listaEstadisticaCantidadFemenino)
                    {
                        txtCantidadMujeres.Text = item.CantidadPacientes.ToString();
                        txtPorcentajeMujeres.Text = item.porcentajePorSexo.ToString();
                        txtTotalPacientes.Text = item.totalPacientes.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        public void MostrarEstadisticaCantidadPacienteMasculino()
        {
            try
            {
                listaEstadisticaCantidadMasculino = EstadisticasLN.MostrarCantidadMasculino();

                if (listaEstadisticaCantidadMasculino != null && listaEstadisticaCantidadMasculino.Count > 0)
                {
                    foreach (var item in listaEstadisticaCantidadMasculino)
                    {
                        txtCantidadVarones.Text = item.CantidadPacientes.ToString();
                        txtPorcetajeVarones.Text = item.porcentajePorSexo.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
            
        }
        public void MostrarEstadisticaModaEdad()
        {
            try
            {
                List<EstadisticaModaEdad> listaEstadisticaEdadModa = EstadisticasLN.MostrarEstadisticaEdadModa();

                if (listaEstadisticaEdadModa != null && listaEstadisticaEdadModa.Count > 0)
                {
                    for (int i = 0; i < listaEstadisticaEdadModa.Count; i++)
                    {
                        if (i == listaEstadisticaCantidadMasculino.Count - 1)
                            txtModaEdad.Text += listaEstadisticaEdadModa[i].modaEdad.ToString();
                        else
                            txtModaEdad.Text += listaEstadisticaEdadModa[i].modaEdad.ToString() + ", ";
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        public void GraficoBarra(List<EstadisticaCantidadPorSexo> listaF, List<EstadisticaCantidadPorSexo> listaM)
        {
            for(int i=0;i< listaF.Count;  i ++)
            {
                Series serie = chart1.Series.Add(listaF[i].sexo);
                serie.Label = listaF[i].CantidadPacientes.ToString();
                serie.Points.Add(listaF[i].CantidadPacientes);
            }

            for (int i = 0; i < listaM.Count; i++)
            {
                Series serie = chart1.Series.Add(listaM[i].sexo);
                serie.Label = listaM[i].CantidadPacientes.ToString();
                serie.Points.Add(listaM[i].CantidadPacientes);
            }
 
        }
        public void GraficoBarra(DataTable dt)
        {
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Series1"].LegendText = "sexo";
            chart1.Series["Series1"].XValueMember = "sexo";
            chart1.Series["Series1"].YValueMembers = "cantidadPacientesPorSexo";
            chart1.DataSource = dt;

            //chart1.Series.Add("Series2");
            //chart1.Series["Series2"].IsValueShownAsLabel = true;
            //chart1.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //chart1.Series["Series2"].LegendText = "sexo";
            //chart1.Series["Series2"].XValueMember = "sexo";
            //chart1.Series["Series2"].YValueMembers = "cantidadPacientesPorSexo";
            //chart1.DataSource = cantidadMasculino;
        }
        public void GraficoTorta(DataTable dtPorcentajePacientesPorSexo)
        {
            Series serie = new Series("PorcentajeFemenino")
            {
                ChartType = SeriesChartType.Pie,
                XValueMember = "sexo",
                YValueMembers = "Porcentaje",
                IsValueShownAsLabel = true
            };
            chart2.Series.Add(serie);
            chart2.DataSource = dtPorcentajePacientesPorSexo;

        }
    }
}
