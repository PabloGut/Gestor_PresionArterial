using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA
{
    public partial class ActualizarFormaAdministracionMedicamento : Form
    {
        public ActualizarFormaAdministracionMedicamento()
        {
            InitializeComponent();
        }

        private void btnRegistrarFormaAdministracion_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFormaAdministracion.Text)==true)
            {
                MessageBox.Show("Faltan datos por ingresar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormaAdministracion formaAdministracion = new FormaAdministracion();
            formaAdministracion.nombre = txtFormaAdministracion.Text;
            FormaAdministracionLN.registrarFormaDeAdministracionMedicamento(formaAdministracion);
        }

        private void ActualizarFormaAdministracionMedicamento_Load(object sender, EventArgs e)
        {

        }
    }
}
