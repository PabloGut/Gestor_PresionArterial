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
    public partial class RegistrarEspecialidad : Form
    {

        private ManejadorRegistrarEspecialidad manejador;

        public RegistrarEspecialidad()
        {
            InitializeComponent();
            opcionRegistrarEspecialidad();
        }

        public void habilitarPantalla()
        {
            btnBorrar.Enabled = false;
            cmbEspecialidad.Enabled = false;
        }

        public void opcionRegistrarEspecialidad()
        {
            manejador = new ManejadorRegistrarEspecialidad();
            habilitarPantalla();
            manejador.registrarEspecialidad(this);
        }

        public void presentarEspecialidades(List<Especialidad> especialidades)
        {
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.ValueMember = "id_especialidad";
            cmbEspecialidad.DisplayMember = "nombre";
            Utilidades.limpiarLosControles(this);
        }

        public void tomarNombreYDescripcion(int id, string nombre, string descripcion)
        {
            manejador.nombreYDescripcionIngresados(id, nombre, descripcion);
        }

        public void informarUsuarioFinCU(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            opcionRegistrarEspecialidad();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            if (cmbEspecialidad.Enabled)
            {
                Especialidad especialidad = (Especialidad)cmbEspecialidad.Items[cmbEspecialidad.SelectedIndex];
                id = especialidad.id_especialidad;
            }
            else
            {
                id = 0;
            }
            tomarNombreYDescripcion(id, txtNombre.Text, txtDescripcion.Text);
        }

        private void _cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad especialidad = (Especialidad)cmbEspecialidad.SelectedItem;
            txtNombre.Text = especialidad.nombre;
            txtDescripcion.Text = especialidad.descripcion;
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
            cmbEspecialidad.Enabled = false;
            Utilidades.limpiarLosControles(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cmbEspecialidad.Enabled = true;
            Especialidad especialidad = (Especialidad)cmbEspecialidad.SelectedItem;
            txtNombre.Text = especialidad.nombre;
            txtDescripcion.Text = especialidad.descripcion;
            btnBorrar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = (Especialidad)cmbEspecialidad.Items[cmbEspecialidad.SelectedIndex];
            int id = especialidad.id_especialidad;
            manejador.borrarEspecialidad(id);
        }


    }
}
