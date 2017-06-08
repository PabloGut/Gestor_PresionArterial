using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPA;

namespace GPA
{
    public partial class ConsultarEstudio : Form
    {
        public ConsultarEstudio()
        {
            InitializeComponent();
        }
        private void ConsultarEstudio_Load(object sender, EventArgs e)
        {
        }
        public void presentarDatosEstudio(string nombre, DateTime fecha, string doctor, string informe)
        {
            txtNombreEstudio.Text = nombre;
            mtbFecha.Text = Convert.ToString(fecha);
            txtDoctor.Text = doctor;
            txtInforme.Text = informe;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
