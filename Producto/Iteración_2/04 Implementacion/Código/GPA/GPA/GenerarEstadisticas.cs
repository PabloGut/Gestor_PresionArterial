using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DAO;
using GPA.Reportes;
using System.Windows.Forms;
using System.Data.SqlClient;
using LogicaNegocio;

namespace GPA
{
    public partial class GenerarEstadisticas : Form
    {
        public GenerarEstadisticas()
        {
            InitializeComponent();
        }

        private void btnGenerarEstadisticas_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            try
            {
                //Evitar el registro de estadisticas si en el dia ya se registraron.

                mensaje = "Error al registrar estadísticas";
                //EstadisticasLN.InsertarEstadisticas();

                mensaje = "Error al generar reporte";
                dsEstadisticas dsEstadistica = MostrarEstadisticaPromedio();
                ReportDocument reportes = new ReportDocument();
              
                reportes.Load(Application.StartupPath.Replace("bin\\Debug", "") + "Reportes\\crEstadisticas_1.rpt");
                if (dsEstadistica != null && dsEstadistica.Tables["Estadistica_EdadPromedio"].Rows.Count > 0 && dsEstadistica.Tables["EstadisticaCantidadSexoF"].Rows.Count > 0 && dsEstadistica.Tables["EstadisticaCantidadSexoM"].Rows.Count > 0)
                {
                    //reportes.Subreports["crTratamientoMedicamento.rpt"].SetDataSource(dsEstadistica);
                    reportes.SetDataSource(dsEstadistica);
                }
                crystalReportViewer1.ReportSource = reportes;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsEstadisticas MostrarEstadisticaPromedio()
        {
            EstadisticasDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(EstadisticasDAO.getCadenaConexion());
            dsEstadisticas dsEstadistica;

            SqlDataAdapter da = null;
            string consulta = @"select top 1 id, fecha_registro,promedioEdad from Estadistica_EdadPromedio
                                where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                order by id desc";

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@fechaActual", DateTime.Now);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsEstadistica = new dsEstadisticas();
                da.Fill(dsEstadistica, "Estadistica_EdadPromedio");

                consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Masculino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = cn;
                cmd2.CommandText = consulta;
                cmd2.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd2);
                da.Fill(dsEstadistica, "EstadisticaCantidadSexoM");

                consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Femenino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = cn;
                cmd3.CommandText = consulta;
                cmd3.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd3);
                da.Fill(dsEstadistica, "EstadisticaCantidadSexoF");


                consulta = @"select id, fecha_registro,moda_edad
                            from Estadistica_EdadModa
                            where  convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                            order by id desc";
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = cn;
                cmd4.CommandText = consulta;
                cmd4.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd4);
                da.Fill(dsEstadistica, "Estadistica_EdadModa");


                consulta = @"select top 1 id, fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                from cantidadPacientesPorSexo
                                where sexo ='Masculino'
                                and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                UNION
                                select top 1 id, fecha_registro,id_sexo,sexo,ISNULL(cantidadPacientesPorSexo,'N/A') as 'cantidadPacientesPorSexo',cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                from cantidadPacientesPorSexo
                                where sexo ='Femenino'
                                and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)";

                SqlCommand cmd5 = new SqlCommand();
                cmd5.Connection = cn;
                cmd5.CommandText = consulta;
                cmd5.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd5);
                da.Fill(dsEstadistica, "EstadisticaGrafico_Cantidad_Porcentaje");

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsEstadistica;
        }
        public dsEstadisticas MostrarEstadisticaCantidadPorSexo()
        {
            EstadisticasDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(EstadisticasDAO.getCadenaConexion());
            dsEstadisticas dsEstadistica;

            SqlDataAdapter da = null;
            string consulta = @"select top 1 id, fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                from cantidadPacientesPorSexo
                                where sexo ='Masculino'
                                order by id desc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                //cmd.Parameters.AddWithValue("@fechaActual", DateTime.Now);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dsEstadistica = new dsEstadisticas();
                da.Fill(dsEstadistica, "Estadistica_EdadPromedio");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsEstadistica;
        }
        private void GenerarEstadisticas_Load(object sender, EventArgs e)
        {

        }
    }
}
