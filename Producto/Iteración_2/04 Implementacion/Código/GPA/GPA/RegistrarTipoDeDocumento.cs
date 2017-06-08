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
    public partial class RegistrarTipoDeDocumento : Form
    {

        private ManejadorRegistrarTipoDeDocumento manejador;

        public RegistrarTipoDeDocumento()
        {
            InitializeComponent();
            opcionRegistrarTipoDeDocumento();
        }

        public void habilitarPantalla(){
            btnBorrar.Enabled = false;
            cmbTipoDocumento.Enabled = false;
        }

        public void opcionRegistrarTipoDeDocumento()
        {
            manejador = new ManejadorRegistrarTipoDeDocumento();
            habilitarPantalla();
            manejador.registrarTipoDeDocumento(this);
        }

        public void presentarTiposDocumento(List<TipoDocumento> tiposDoc)
        {
            cmbTipoDocumento.DataSource = tiposDoc;
            cmbTipoDocumento.ValueMember = "id_TipoDoc";
            cmbTipoDocumento.DisplayMember = "nombre";
            Utilidades.limpiarLosControles(this);
        }

        public void tomarNombreYDescripcion(int id, string nombre, string descripcion)
        {
            manejador.nombreYDescripcionIngresados(id, nombre, descripcion);
        }

        public void informarUsuarioFinCU(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            opcionRegistrarTipoDeDocumento();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            if (cmbTipoDocumento.Enabled)
            {
                TipoDocumento tipoDoc = (TipoDocumento)cmbTipoDocumento.Items[cmbTipoDocumento.SelectedIndex];
                id = tipoDoc.id_tipoDoc;
            }
            else {
                id = 0;
            }
            tomarNombreYDescripcion(id, txtNombre.Text, txtDescripcion.Text);
        }

        private void _cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDocumento tipoDoc=(TipoDocumento)cmbTipoDocumento.SelectedItem;
            txtNombre.Text = tipoDoc.nombre;
            txtDescripcion.Text = tipoDoc.descripcion;
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
            cmbTipoDocumento.Enabled = false;
            Utilidades.limpiarLosControles(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cmbTipoDocumento.Enabled = true;
            TipoDocumento tipoDoc = (TipoDocumento)cmbTipoDocumento.SelectedItem;
            txtNombre.Text = tipoDoc.nombre;
            txtDescripcion.Text = tipoDoc.descripcion;
            btnBorrar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            TipoDocumento tipoDoc = (TipoDocumento)cmbTipoDocumento.Items[cmbTipoDocumento.SelectedIndex];
            int id = tipoDoc.id_tipoDoc;
            manejador.borrarTipoDocumento(id);
        }

    }
}
