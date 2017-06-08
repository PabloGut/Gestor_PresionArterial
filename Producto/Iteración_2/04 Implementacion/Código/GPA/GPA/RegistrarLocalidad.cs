using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPA.Manejadores;
using Entidades.Clases;

namespace GPA
{
    public partial class RegistrarLocalidad : Form
    {
        private ManejadorRegistrarLocalidad manejador;
        
        public RegistrarLocalidad()
        {
            InitializeComponent();
            opcionRegistrarLocalidad();
        }

        public void habilitarPantalla()
        {
            btnBorrar.Enabled = false;
            cmbLocalidad.Enabled = false;
        }
        
        public void opcionRegistrarLocalidad()
        {
            manejador = new ManejadorRegistrarLocalidad();
            habilitarPantalla();
            manejador.registrarLocalidad(this);
        }

        public void presentarLocalidades(List<Localidad> localidades)
        {
            cmbLocalidad.DataSource = localidades;
            cmbLocalidad.ValueMember = "id_localidad";
            cmbLocalidad.DisplayMember = "nombre";
            Utilidades.limpiarLosControles(this);
        }

        public void tomarNombre(int id, string nombre)
        {
            manejador.nombreIngresado(id, nombre);
        }

        public void informarUsuarioFinCU(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            opcionRegistrarLocalidad();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            if (cmbLocalidad.Enabled)
            {
                Localidad localidad = (Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex];
                id = localidad.id_localidad;
            }
            else
            {
                id = 0;
            }
            tomarNombre(id, txtNombre.Text);
        }

        private void _cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Localidad localidad = (Localidad)cmbLocalidad.SelectedItem;
            txtNombre.Text = localidad.nombre;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cancelarCU();
        }

        public void cancelarCU()
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBorrar.Enabled = false;
            cmbLocalidad.Enabled = false;
            Utilidades.limpiarLosControles(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cmbLocalidad.Enabled = true;
            Localidad localidad = (Localidad)cmbLocalidad.SelectedItem;
            txtNombre.Text = localidad.nombre;
            btnBorrar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Localidad localidad = (Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex];
            int id = localidad.id_localidad;
            manejador.borrarLocalidad(id);
        }
    }
}
