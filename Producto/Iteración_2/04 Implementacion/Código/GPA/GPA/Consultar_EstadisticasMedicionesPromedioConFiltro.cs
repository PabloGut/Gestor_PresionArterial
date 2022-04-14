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
using LogicaNegocio;

namespace GPA
{
    public partial class Consultar_EstadisticasMedicionesPromedioConFiltro : Form
    {
        List<EstadisticaCategoriaSitio> ListaEstadisticaPromedioConExamen;
        List<EstadisticaCategoriaSitio> ListaEstadisticaCantPacientesXCategoria;

        public Consultar_EstadisticasMedicionesPromedioConFiltro()
        {
            InitializeComponent();
        }

        private void Consultar_EstadisticasMedicionesPromedioConFiltro_Load(object sender, EventArgs e)
        {
            mtbFechaDesde.Text = "18/12/2021";
            mtbFechaHasta.Text = "19/12/2021";
        }
        public void MostrarPromedioMedicionesConExamen()
        {
            if(String.IsNullOrEmpty(mtbFechaDesde.Text) ==true || String.IsNullOrEmpty(mtbFechaHasta.Text)==true)
            {
                Utilidades.MensajeError("Falta ingresar fecha desde o hasta");
                return;
            }

            if (dgvPromedioConExamen.Columns.Count == 0)
            {
                List<string> columnas = new List<string>();
                columnas.Add("Fecha de Registro");
                columnas.Add("Categoría");
                columnas.Add("Promedio Sistólica");
                columnas.Add("Promedio Diastólica");

                Utilidades.agregarColumnasDataGridView(dgvPromedioConExamen, columnas);
                Utilidades.agregarColumnasDataGridView(dgvPromedioSinExamen, columnas);
            }

            DateTime fechaDesde = Convert.ToDateTime(mtbFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(mtbFechaHasta.Text);
            ListaEstadisticaPromedioConExamen = EstadisticasLN.MostrarPromedioMedicionesConYSinExamen(fechaDesde, fechaHasta);

            foreach (var item in ListaEstadisticaPromedioConExamen)
            {
                if (item.ConExamen.Equals("ConExamen"))
                {
                    dgvPromedioConExamen.Rows.Add(item.FechaRegistro, item.ConExamen, item.PromedioSistolica, item.PromedioDiastolica);
                }
                else if (item.ConExamen.Equals("SinExamen"))
                {
                    dgvPromedioSinExamen.Rows.Add(item.FechaRegistro, item.ConExamen, item.PromedioSistolica, item.PromedioDiastolica);
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean existe = EstadisticasLN.ExisteMedicionesPorCategoria();

                if (existe == false)
                    EstadisticasLN.InsertarEstadisticasMedicionesPromedioCategoria();

                if(chBarraConExamen.Series.Count > 0)
                    BorrarSeries();

                

                MostrarPromedioMedicionesConExamen();


                List<String> columnas = new List<string>();
                columnas.Add("Fecha de Registro");
                columnas.Add("Categoría");
                columnas.Add("Promedio Sistólica");
                columnas.Add("Promedio Diastólica");

                GenerarDataTableYGraficar(columnas);

                MostrarCantidadPacientesXCategoriaConExamen();
            }
            catch (Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        public void GenerarDataTableYGraficar(List<String> columnas)
        {
            DataTable estadisticaConExamen = new DataTable();
            DataTable estadisticaSinExamen = new DataTable();
            DataRow fila;

            /*estadistica.Columns.Add("Fecha de Registro");
            estadistica.Columns.Add("Categoría");
            estadistica.Columns.Add("Promedio Sistólica");
            estadistica.Columns.Add("Promedio Diastólica");*/

            for (int i = 0; i < columnas.Count; i++)
            {
                estadisticaConExamen.Columns.Add(columnas[i]);
                estadisticaSinExamen.Columns.Add(columnas[i]);
            }

          

            if(ListaEstadisticaPromedioConExamen != null)
            {
                foreach (EstadisticaCategoriaSitio item in ListaEstadisticaPromedioConExamen)
                {

                    if (item.ConExamen.Equals("ConExamen"))
                    {
                        fila = estadisticaConExamen.NewRow();
                        fila["Fecha de Registro"] = item.FechaRegistro;
                        fila["Categoría"] = item.Categoria;
                        fila["Promedio Sistólica"] = item.PromedioSistolica;
                        fila["Promedio Diastólica"] = item.PromedioDiastolica;

                        estadisticaConExamen.Rows.Add(fila);
                    }
                    else if (item.ConExamen.Equals("SinExamen"))
                    {
                        fila = estadisticaSinExamen.NewRow();
                        fila["Fecha de Registro"] = item.FechaRegistro;
                        fila["Categoría"] = item.Categoria;
                        fila["Promedio Sistólica"] = item.PromedioSistolica;
                        fila["Promedio Diastólica"] = item.PromedioDiastolica;
                        estadisticaSinExamen.Rows.Add(fila);
                    }
   
                }
                GraficoBarraConExamen(estadisticaConExamen);
                GraficoBarraSinExamen(estadisticaSinExamen);

            }

        }
        public void AgregarScrollBar(Chart grafico)
        {
            ChartArea area = grafico.ChartAreas["ChartArea1"];
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 1000;
            area.CursorX.AutoScroll = true;

            area.AxisX.ScaleView.Zoomable = true;
            area.AxisX.ScaleView.SizeType = DateTimeIntervalType.Months;
            int position = 0;
            int size = 1;
            area.AxisX.ScaleView.Zoom(position, size, DateTimeIntervalType.Days);

            // area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            area.AxisX.ScaleView.SmallScrollSize = 1;
        }
        public void GraficoBarraConExamen(DataTable dt)
        {
            AgregarScrollBar(chBarraConExamen);
            chBarraConExamen.Series.Add("Series1");
            chBarraConExamen.Series["Series1"].IsValueShownAsLabel = true;
            chBarraConExamen.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chBarraConExamen.Series["Series1"].LegendText = "Promedio Sistólica";
            chBarraConExamen.Series["Series1"].XValueMember = "Fecha de Registro";
            chBarraConExamen.Series["Series1"].YValueMembers = "Promedio Sistólica";
            // chBarraConExamen.DataSource = dt;


            chBarraConExamen.Series.Add("Series2");
            chBarraConExamen.Series["Series2"].IsValueShownAsLabel = true;
            chBarraConExamen.Series["Series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chBarraConExamen.Series["Series2"].LegendText = "Promedio Diastolica";
            chBarraConExamen.Series["Series2"].XValueMember = "Fecha de Registro";
            chBarraConExamen.Series["Series2"].YValueMembers = "Promedio Diastólica";
            chBarraConExamen.DataSource = dt;


        }
        public void GraficoBarraSinExamen(DataTable dt)
        {
            AgregarScrollBar(chBarraSinExamen);
            chBarraSinExamen.Series.Add("Series3");
            chBarraSinExamen.Series["Series3"].IsValueShownAsLabel = true;
            chBarraSinExamen.Series["Series3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chBarraSinExamen.Series["Series3"].LegendText = "Promedio Sistólica";
            chBarraSinExamen.Series["Series3"].XValueMember = "Fecha de Registro";
            chBarraSinExamen.Series["Series3"].YValueMembers = "Promedio Sistólica";
            // chBarraConExamen.DataSource = dt;


            chBarraSinExamen.Series.Add("Series4");
            chBarraSinExamen.Series["Series4"].IsValueShownAsLabel = true;
            chBarraSinExamen.Series["Series4"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chBarraSinExamen.Series["Series4"].LegendText = "Promedio Diastolica";
            chBarraSinExamen.Series["Series4"].XValueMember = "Fecha de Registro";
            chBarraSinExamen.Series["Series4"].YValueMembers = "Promedio Diastólica";
            chBarraSinExamen.DataSource = dt;


        }
        public void MostrarCantidadPacientesXCategoriaConExamen()
        {
            if (String.IsNullOrEmpty(mtbFechaDesde.Text) == true || String.IsNullOrEmpty(mtbFechaHasta.Text) == true)
            {
                Utilidades.MensajeError("Falta ingresar fecha desde o hasta");
                return;
            }
            List<string> columnas = new List<string>();

            if (dgvCantCategoriaConExamen.Columns.Count == 0)
            {
                columnas.Add("Fecha de Registro");
                columnas.Add("Categoría");
                columnas.Add("Cantidad de Pacientes");
                columnas.Add("Total de Pacientes");
                columnas.Add("Tipo");//conExamen


                Utilidades.agregarColumnasDataGridView(dgvCantCategoriaConExamen, columnas);
                Utilidades.agregarColumnasDataGridView(dgvCantCategoriaSinExamen, columnas);
            }

           

            DateTime fechaDesde = Convert.ToDateTime(mtbFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(mtbFechaHasta.Text);

            try
            {
                ListaEstadisticaCantPacientesXCategoria = EstadisticasLN.MostrarEstadisticaPacientesPorCategoria(fechaDesde, fechaHasta);

                foreach (var item in ListaEstadisticaCantPacientesXCategoria)
                {
                    if (item.ConExamen.Equals("ConExamen"))
                    {
                        dgvCantCategoriaConExamen.Rows.Add(item.FechaRegistro, item.Categoria, item.CantidadPacientes, item.TotalPacientes, item.ConExamen);
                    }
                    else if (item.ConExamen.Equals("SinExamen"))
                    {
                        dgvCantCategoriaSinExamen.Rows.Add(item.FechaRegistro, item.Categoria, item.CantidadPacientes, item.TotalPacientes, item.ConExamen);
                    }

                }
                GenerarDataTableYGraficarCantPacienteCategoria();
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public void GenerarDataTableYGraficarCantPacienteCategoria()
        {
            DataTable estadisticaConExamen = new DataTable();
            DataTable estadisticaSinExamen = new DataTable();
            DataRow fila;

            /*estadistica.Columns.Add("Fecha de Registro");
            estadistica.Columns.Add("Categoría");
            estadistica.Columns.Add("Promedio Sistólica");
            estadistica.Columns.Add("Promedio Diastólica");*/
            List<String> columnas = new List<string>();
            columnas.Add("Fecha de Registro");
            columnas.Add("Categoría");
            columnas.Add("Cantidad de Pacientes");
            columnas.Add("Total de Pacientes");
            columnas.Add("Tipo");//conExamen

            for (int i = 0; i < columnas.Count; i++)
            {
                estadisticaConExamen.Columns.Add(columnas[i]);
                estadisticaSinExamen.Columns.Add(columnas[i]);
            }

            if (ListaEstadisticaCantPacientesXCategoria != null)
            {
                foreach (EstadisticaCategoriaSitio item in ListaEstadisticaCantPacientesXCategoria)
                {
                    if (item.ConExamen.Equals("ConExamen"))
                    {
                        fila = estadisticaConExamen.NewRow();
                        fila["Fecha de Registro"] = item.FechaRegistro;
                        fila["Categoría"] = item.Categoria;
                        fila["Cantidad de Pacientes"] = item.CantidadPacientes;
                        fila["Total de Pacientes"] = item.TotalPacientes;
                        fila["Tipo"] = item.ConExamen;

                        estadisticaConExamen.Rows.Add(fila);
                    }
                    else if (item.ConExamen.Equals("SinExamen"))
                    {
                        fila = estadisticaSinExamen.NewRow();
                        fila["Fecha de Registro"] = item.FechaRegistro;
                        fila["Categoría"] = item.Categoria;
                        fila["Cantidad de Pacientes"] = item.CantidadPacientes;
                        fila["Total de Pacientes"] = item.TotalPacientes;
                        fila["Tipo"] = item.ConExamen;

                        estadisticaSinExamen.Rows.Add(fila);
                    }

                }
                //GraficoBarraPrueba(estadisticaConExamen, chCantCategoriaConExamen);
                //GraficarPrueba3(estadisticaConExamen, chCantCategoriaConExamen);
               
                GraficarPorCategoriaCantPacientes(chCantCategoriaConExamen, estadisticaConExamen);
                GraficarPorCategoriaCantPacientes(chCantCategoriaSinExamen, estadisticaSinExamen);

            }

        }
        public void GraficarPrueba4(Chart grafico, DataTable dt)
        {
            try
            {
                string[] series = {"Hipotensión", "HTA grado o nivel 1", "HTA grado o nivel 2", "HTA grado o nivel 3",
                                    "HTA sistólica o aislada", "Limítrofe", "Normal" };

                int[] puntos = { 0, 0, 0, 0, 18, 0, 2};

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = grafico.Series.Add(series[i]);
                }


                grafico.Series["Hipotensión"].IsValueShownAsLabel = true;
                grafico.Series["HTA grado o nivel 1"].IsValueShownAsLabel = true;
                grafico.Series["HTA grado o nivel 2"].IsValueShownAsLabel = true;
                grafico.Series["HTA grado o nivel 3"].IsValueShownAsLabel = true;
                grafico.Series["HTA sistólica o aislada"].IsValueShownAsLabel = true;
                grafico.Series["Limítrofe"].IsValueShownAsLabel = true;
                grafico.Series["Normal"].IsValueShownAsLabel = true;


                grafico.Series["Hipotensión"].Points.AddXY("19/12/2021 ",0);
                grafico.Series["HTA grado o nivel 1"].Points.AddXY("19/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 2"].Points.AddXY("19/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 3"].Points.AddXY("19/12/2021 ", 0);
                grafico.Series["HTA sistólica o aislada"].Points.AddXY("19/12/2021 ", 18);
                grafico.Series["Limítrofe"].Points.AddXY("19/12/2021 ", 0);
                grafico.Series["Normal"].Points.AddXY("19/12/2021 ", 2);

                grafico.Series["Hipotensión"].Points.AddXY("20/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 1"].Points.AddXY("20/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 2"].Points.AddXY("20/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 3"].Points.AddXY("20/12/2021 ", 0);
                grafico.Series["HTA sistólica o aislada"].Points.AddXY("20/12/2021 ", 18);
                grafico.Series["Limítrofe"].Points.AddXY("20/12/2021 ", 0);
                grafico.Series["Normal"].Points.AddXY("20/12/2021 ", 2);


                grafico.Series["Hipotensión"].Points.AddXY("21/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 1"].Points.AddXY("21/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 2"].Points.AddXY("21/12/2021 ", 0);
                grafico.Series["HTA grado o nivel 3"].Points.AddXY("21/12/2021 ", 0);
                grafico.Series["HTA sistólica o aislada"].Points.AddXY("21/12/2021 ", 18);
                grafico.Series["Limítrofe"].Points.AddXY("21/12/2021 ", 0);
                grafico.Series["Normal"].Points.AddXY("21/12/2021 ", 2);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GraficarPorCategoriaCantPacientes(Chart grafico, DataTable dt)
        {
            try
            {
                string[] series = {"Hipotensión", "HTA grado o nivel 1", "HTA grado o nivel 2", "HTA grado o nivel 3",
                                    "HTA sistólica o aislada", "Limítrofe", "Normal" };

                int[] puntos = { 0, 0, 0, 0, 18, 0, 2 };

                AgregarScrollBar(grafico);
                //grafico.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
                //ChartArea area = grafico.ChartAreas["ChartArea1"];
                //area.AxisX.Minimum = 0;
                //area.AxisX.Maximum = 1000;
                //area.CursorX.AutoScroll = true;

                //area.AxisX.ScaleView.Zoomable = true;
                //area.AxisX.ScaleView.SizeType = DateTimeIntervalType.Months;
                //int position = 0;
                //int size = 1;
                //area.AxisX.ScaleView.Zoom(position, size, DateTimeIntervalType.Days);

                //area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                //area.AxisX.ScaleView.SmallScrollSize = 1;

                for (int i = 0; i < series.Length; i++)
                {
                    Series serie = grafico.Series.Add(series[i]);
                }


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < series.Length; j++)
                    {   
                        if(series[j].Equals(dt.Rows[i]["Categoría"].ToString()))
                        {
                            grafico.Series[series[j]].IsValueShownAsLabel = true;
                            grafico.Series[series[j]].Points.AddXY(dt.Rows[i]["Fecha de Registro"].ToString(), dt.Rows[i]["Cantidad de Pacientes"].ToString());
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BorrarSeries()
        {
            dgvCantCategoriaConExamen.Rows.Clear();
            dgvPromedioSinExamen.Rows.Clear();
            dgvPromedioConExamen.Rows.Clear();
            dgvCantCategoriaSinExamen.Rows.Clear();


            while (chBarraConExamen.Series.Count > 0)
            {
                chBarraConExamen.Series.Remove(chBarraConExamen.Series[chBarraConExamen.Series.Count - 1]);
            }

            while (chBarraSinExamen.Series.Count > 0)
            {
                chBarraSinExamen.Series.Remove(chBarraSinExamen.Series[chBarraSinExamen.Series.Count - 1]);
            }


            while (chCantCategoriaConExamen.Series.Count > 0)
            {
                chCantCategoriaConExamen.Series.Remove(chCantCategoriaConExamen.Series[chCantCategoriaConExamen.Series.Count - 1]);
            }


            while (chCantCategoriaSinExamen.Series.Count > 0)
            {
                chCantCategoriaSinExamen.Series.Remove(chCantCategoriaSinExamen.Series[chCantCategoriaSinExamen.Series.Count - 1]);
            }



            //for (int i=0; i< chCantCategoriaConExamen.Series.Count; i++) 
            //{
            //    chCantCategoriaConExamen.Series.Remove(chCantCategoriaConExamen.Series[i]);
            //}
            /*chart1.Series.Remove(chart1.Series["Series1"]);
            chart1.Series.Remove(chart1.Series["Series2"]);
            chart1.Series.Remove(chart1.Series["Series3"]);*/
        }
    }
}
