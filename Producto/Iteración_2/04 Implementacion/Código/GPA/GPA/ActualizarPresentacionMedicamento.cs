using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades.Clases;

namespace GPA
{
    public partial class ActualizarPresentacionMedicamento : Form
    {
        public ActualizarPresentacionMedicamento()
        {
            InitializeComponent();
        }

        private void btnFormaPresentacion_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtFormaPresentacion.Text) == true)
            {
                MessageBox.Show("Faltan datos por ingresar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PresentacionMedicamento presentacion = new PresentacionMedicamento();
            presentacion.nombre = txtFormaPresentacion.Text;
            PresentacionMedicamentoLN.registrarPresentacionMedicamento(presentacion);
        }
    }
}
