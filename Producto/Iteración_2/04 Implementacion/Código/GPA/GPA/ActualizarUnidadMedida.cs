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
    public partial class ActualizarUnidadMedida : Form
    {
        public ActualizarUnidadMedida()
        {
            InitializeComponent();
        }

        private void btnRegistrarUnidadMedida_Click(object sender, EventArgs e)
        {
            UnidadDeMedida unidadDeMedida = new UnidadDeMedida();
           
            if (string.IsNullOrEmpty(txtNombreUnidadMedida.Text) == true)
            {
                MessageBox.Show("Falta ingresar las siglas de la unidad de medida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            unidadDeMedida.nombre = txtNombreUnidadMedida.Text;

            if (string.IsNullOrEmpty(txtDescripcionUnidadMedida.Text) == false)
            {
                unidadDeMedida.descripcion = txtDescripcionUnidadMedida.Text;
            }
            else
            {
                unidadDeMedida.descripcion = "No especifica";
            }
            
            UnidadMedidaLN.registrarUnidadDeMedida(unidadDeMedida);
        }
    }
}
