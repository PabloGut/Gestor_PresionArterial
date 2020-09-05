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
    public partial class Registrar_Análisis_de_Laboratorio : Form
    {
        public Registrar_Análisis_de_Laboratorio()
        {
            InitializeComponent();
        }

        private void Registrar_Análisis_de_Laboratorio_Load(object sender, EventArgs e)
        {
           // gbDetallesValoresDeReferencia.Hide();
        }

        private void cbAgregarDetalles_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (cbAgregarDetalles.Checked)
            {
                lblValoresReferencia.Hide();
                lblDesde.Hide();
                lblHasta.Hide();
                txtDesde.Hide();
                txtHasta.Hide();

                gbDetallesValoresDeReferencia.Show();

            }
            else
            {
                lblValoresReferencia.Show();
                lblDesde.Show();
                lblHasta.Show();
                txtDesde.Show();
                txtHasta.Show();

                gbDetallesValoresDeReferencia.Hide();
 
            }
           */
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La institución no se registró correctamente! \n Se cancela el registro del estudio de laboratorio.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            MessageBox.Show("El estudio de laboratorio se registró correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
