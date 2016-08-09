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
using GPA.Manejadores;

namespace GPA
{
    public partial class RegistrarPaciente : Form
    {
        private ManejadorRegistrarPaciente manejador;
        
        public RegistrarPaciente()
        {
            InitializeComponent();
            opcionRegistrarPaciente();
        }

        public void habilitarPantalla()
        {
            grbDocumento.Enabled = true;
            grbPersonales.Enabled = false;
            grbDomicilio.Enabled = false;
            grbAdicionales.Enabled = false;
            Utilidades.limpiarLosControles(this);
        }
        
        public void opcionRegistrarPaciente()
        {
            manejador = new ManejadorRegistrarPaciente();
            habilitarPantalla();
            manejador.registrarPaciente(this);
        }

        public void presentarTiposDocumento(List<TipoDocumento> tiposDoc)
        {
            cmbTipoDocumento.DataSource = tiposDoc;
            cmbTipoDocumento.ValueMember = "id_tipoDoc";
            cmbTipoDocumento.DisplayMember = "nombre";
        }

        public void tomarSeleccionTipoDocumento()
        {
            TipoDocumento tipoDoc = (TipoDocumento)cmbTipoDocumento.Items[cmbTipoDocumento.SelectedIndex];
            tomarNroDocumento(tipoDoc.id_tipoDoc);
        }

        public void tomarNroDocumento(int id_tipoDoc)
        {
            manejador.documentoIngresado(id_tipoDoc, Convert.ToInt32(txtNroDocumento.Text));
        }

        public void pedirDatos()
        {
            grbDocumento.Enabled = false;
            grbPersonales.Enabled = true;
            grbDomicilio.Enabled = true;
            grbAdicionales.Enabled = true;
            tomarDatos();
        }

        public void tomarDatos()
        {
            manejador.datosPaciente();
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
        }

        public void presentarUsuario(string nombre, string pass)
        {
            MessageBox.Show("Usuario: "+nombre+"\nContraseña: "+pass, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void informarUsuarioFinCU(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            opcionRegistrarPaciente();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (grbDocumento.Enabled)
            {
                tomarSeleccionTipoDocumento();
            }
            else
            {
                pedirConfirmacion();
            }
        }

        public void pedirConfirmacion()
        {
            DialogResult resultado=MessageBox.Show("¿Desea confirmar el registro del paciente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado==DialogResult.Yes)
            {
                TipoDocumento tipoDoc = (TipoDocumento)cmbTipoDocumento.Items[cmbTipoDocumento.SelectedIndex];
                int nro_documento=Convert.ToInt32(txtNroDocumento.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = Convert.ToInt32(txtTelefonoFijo.Text);
                int nroCelular = Convert.ToInt32(txtNroCelular.Text);
                string email = txtEmail.Text;
                string calle = txtCalle.Text;
                int numero = Convert.ToInt32(txtNroCalle.Text);
                int piso = Convert.ToInt32(txtPiso.Text);
                string departamento = txtDpto.Text;
                int codigo_postal = Convert.ToInt32(txtCodigoPostal.Text);
                Barrio barrio = (Barrio)cmbBarrio.Items[cmbBarrio.SelectedIndex];
                int edad=DateTime.Today.Year-Convert.ToDateTime(txtFechaNacimiento.Text).Year;
                double altura = Convert.ToDouble(txtAltura.Text);
                int peso = Convert.ToInt32(txtPeso.Text);
                confirmacionNuevoPaciente(tipoDoc.id_tipoDoc,nro_documento,nombre,apellido,telefono,nroCelular,email,calle,numero,piso,departamento,codigo_postal,barrio.id_barrio,edad,altura,peso);
            }
        }

        public void confirmacionNuevoPaciente(int id_tipoDoc,int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int edad, double altura, int peso)
        {
            manejador.altaPacienteConfirmada(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, calle, numero, piso, departamento, codigo_postal, id_barrio, edad, altura, peso);
        }

        private void _cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            tomarSeleccionLocalidad((Localidad)cmbLocalidad.Items[cmbLocalidad.SelectedIndex]);
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
            habilitarPantalla();
        }
    }
}
