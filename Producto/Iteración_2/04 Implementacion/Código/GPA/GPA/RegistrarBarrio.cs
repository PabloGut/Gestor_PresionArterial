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
    public partial class RegistrarBarrio : Form
    {
        private ManejadorRegistrarBarrio manejador;

        public RegistrarBarrio()
        {
            InitializeComponent();
            opcionRegistrarBarrio();
        }

        public void opcionRegistrarBarrio()
        {
            manejador = new ManejadorRegistrarBarrio();
            habilitarPantalla();
            manejador.registrarBarrio(this);
        }

        public void habilitarPantalla()
        {
            btnBorrar.Enabled = false;
            cmbBarrio.Enabled = false;
        }

        public void presentarLocalidades(List<Localidad> localidades)
        {
            cmbLocalidad.DataSource = localidades;
            cmbLocalidad.ValueMember = "id_localidad";
            cmbLocalidad.DisplayMember = "nombre";
            tomarSeleccionLocalidad((Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex]);
        }

        public void tomarSeleccionLocalidad(Localidad localidad)
        {
            manejador.localidadSeleccionada(localidad);
        }

        public void presentarBarrios(List<Barrio> barrios)
        {
            cmbBarrio.DataSource = barrios;
            cmbBarrio.ValueMember = "id_barrio";
            cmbBarrio.DisplayMember = "nombre";
            if (!cmbBarrio.Enabled)
            {
                Utilidades.limpiarLosControles(this.groupBox1);
            }
        }

        public void tomarNombreYDescripcion(int id, int id_localidad, string nombre, string descripcion)
        {
            manejador.nombreYDescripcionIngresados(id, id_localidad, nombre, descripcion);
        }

        public void informarUsuarioFinCU(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            opcionRegistrarBarrio();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            if (cmbBarrio.Enabled)
            {
                Barrio barrio = (Barrio)cmbBarrio.Items[cmbBarrio.SelectedIndex];
                id = barrio.id_barrio;
            }
            else
            {
                id = 0;
            }
            Localidad localidad = (Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex];
            tomarNombreYDescripcion(id, localidad.id_localidad, txtNombre.Text,txtDescripcion.Text);
        }

        private void _cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            tomarSeleccionLocalidad((Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex]);
        }

        private void _cmbBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Barrio barrio = (Barrio)cmbBarrio.SelectedItem;
            txtNombre.Text = barrio.nombre;
            txtDescripcion.Text = barrio.descripcion;
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
            cmbBarrio.Enabled = false;
            Utilidades.limpiarLosControles(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cmbBarrio.Enabled = true;
            Barrio barrio = (Barrio)cmbBarrio.SelectedItem;
            txtNombre.Text = barrio.nombre;
            txtDescripcion.Text = barrio.descripcion;
            btnBorrar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Barrio barrio = (Barrio)cmbBarrio.Items[cmbBarrio.SelectedIndex];
            int id = barrio.id_barrio;
            manejador.borrarBarrio(id);
        }
    }
}
