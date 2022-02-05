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

namespace GPA
{
    public partial class ConsultarEstadistica_PromedioSitioMedicion : Form
    {
        List<EstadisticaCategoriaSitio> listaPromedioSitio;
        List<EstadisticaCategoriaSitio> listaPromedioSitioExtremidad;
        public ConsultarEstadistica_PromedioSitioMedicion()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConsultarEstadistica_PromedioSitioMedicion_Load(object sender, EventArgs e)
        {
            try
            {
                Boolean existe = false;
                existe = EstadisticasLN.ExistePromedioSitioMedicion();

                if (existe == false)
                    EstadisticasLN.InsertarEstadisticasSitioMedicionPromedio();
                MostrarPromedioMedicionesPorSitio();
                MostrarPromedioMedicionesPorSitioExtremidad();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void MostrarPromedioMedicionesPorSitio()
        {
            try
            {
                listaPromedioSitio = EstadisticasLN.MostrarEstadisticaPromedioSitio(null,null);

                foreach (var item in listaPromedioSitio)
                {
                    if (item.SitioMedicion.Equals("Consultorio") == true)
                    {
                        txtPromedioSistolicaConsultorio.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaConsultorio.Text = item.PromedioDiastolica.ToString();
                    }
                    if (item.SitioMedicion.Equals("Hogar") == true)
                    {
                        txtPromedioSistolicaHogar.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaHogar.Text = item.PromedioDiastolica.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        public void MostrarPromedioMedicionesPorSitioExtremidad()
        {
            try
            {
                listaPromedioSitioExtremidad = EstadisticasLN.MostrarEstadisticaPromedioSitioExtremidad(null,null);

                foreach (var item in listaPromedioSitioExtremidad)
                {
                    if (item.SitioMedicion.Equals("Consultorio") == true && item.Extremidad.Equals("Miembro Superior"))
                    {
                        txtPromedioSistolicaMSupConsultorio.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaMSupConsultorio.Text = item.PromedioDiastolica.ToString();
                    }
                    if (item.SitioMedicion.Equals("Consultorio") == true && item.Extremidad.Equals("Miembro Inferior"))
                    {
                        txtPromedioSistolicaMInfConsultorio.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaMInfConsultorio.Text = item.PromedioDiastolica.ToString();
                    }
                    if (item.SitioMedicion.Equals("Hogar") == true && item.Extremidad.Equals("Miembro Superior"))
                    {
                        txtPromedioSistolicaMSupHogar.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaMSupHogar.Text = item.PromedioDiastolica.ToString();
                    }
                    if (item.SitioMedicion.Equals("Hogar") == true && item.Extremidad.Equals("Miembro Inferior"))
                    {
                        txtPromedioSistolicaMInfHogar.Text = item.PromedioSistolica.ToString();
                        txtPromedioDiastolicaMInfHogar.Text = item.PromedioDiastolica.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }

    }
}
