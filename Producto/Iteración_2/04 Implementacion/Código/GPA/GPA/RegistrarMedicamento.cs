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
using GPA.Manejadores;

namespace GPA
{
    public partial class RegistrarMedicamento : Form
    {
        public ManejadorActualizarMedicamento manejadorActualizarMedicamento;
        private int idUltimoMedicamentoIngresado;

        public RegistrarMedicamento()
        {
            InitializeComponent();
            manejadorActualizarMedicamento = new ManejadorActualizarMedicamento();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ActualizarUnidadMedida formActualizarUnidadMedida = new ActualizarUnidadMedida();
            formActualizarUnidadMedida.ShowDialog();
            presentarUnidadMedida(cboUnidadMedida, UnidadMedidaLN.mostrarUnidadesDeMedida(), "id_unidadMedida", "nombre");

        }

        private void btnAñadirPresentacionMedicamento_Click(object sender, EventArgs e)
        {
            ActualizarPresentacionMedicamento formActualizarPresentacionMedicamento = new ActualizarPresentacionMedicamento();
            formActualizarPresentacionMedicamento.ShowDialog();
            presentarPresentacionMedicamento(cboPresentacionMedicamento, PresentacionMedicamentoLN.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

        }

        private void btnAñadirFormaAdministracion_Click(object sender, EventArgs e)
        {
            ActualizarFormaAdministracionMedicamento formActualizarFormaAdministracionMedicamento = new ActualizarFormaAdministracionMedicamento();
            formActualizarFormaAdministracionMedicamento.ShowDialog();
            presentarFormaAdministracion(cboFormaAdministración, FormaAdministracionLN.mostrarFormasDeAdministracion(), "id_formaAdministracion", "nombre");
        }

        private void RegistrarMedicamento_Load(object sender, EventArgs e)
        {
            presentarUnidadMedida(cboUnidadMedida, manejadorActualizarMedicamento.mostrarUnidadesDeMedida(), "id_unidadMedida", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento, manejadorActualizarMedicamento.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarFormaAdministracion(cboFormaAdministración, manejadorActualizarMedicamento.mostrarFormasDeAdministracion(), "id_formaAdministracion", "nombre");

            cargarDataGridView();

            btnAgregarNuevasEspecificaciones.Enabled = false;
        }
        /*
       * Método para presentar unidades de medida en el combobox.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos UnidadMedida, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
      */
        public void presentarUnidadMedida(ComboBox combo, List<UnidadDeMedida> unidadesDeMedida, string valueMember, string displayMember)
        {
            cargarCombo(cboUnidadMedida, unidadesDeMedida, valueMember, displayMember);
        }
        /*
        * Método para presentar las formas de presentacion de medicamentos en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos PresentacionMedicamento, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
       */
        public void presentarPresentacionMedicamento(ComboBox combo, List<PresentacionMedicamento> presentacionMedicamento, string valueMember, string displayMember)
        {
            cargarCombo(combo, presentacionMedicamento, valueMember, displayMember);
        }
        /*
          * Método para presentar las formas de administración de medicamentos en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos FormaAdministracion, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
         */
        public void presentarFormaAdministracion(ComboBox combo, List<FormaAdministracion> formasAdministracion, string valueMember, string displayMember)
        {
            cargarCombo(combo, formasAdministracion, valueMember, displayMember);
        }

        /*
        * Método para cargar un ComboBox.
        * Recibe como parámetro una referencia de un ComboBox, una lista genérica,  un string del valueMember y un string del displayMember.
        * El valor de retorno es void.
        */
        public void cargarCombo<T>(ComboBox combo, List<T> lista, string valueMember, string displayMember)
        {
            combo.DataSource = lista;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
        }
        /*
          * Método para cargar el DatagridView de medicamentos.
          * No recibe parámetros
          * El valor de retorno es void.
        */
        public void cargarDataGridView()
        {
            dgvListaMedicamentos.DataSource = manejadorActualizarMedicamento.mostrarMedicamentos();
        }
        private void btnAgregarHabitoMedicamento_Click(object sender, EventArgs e)
        {
            registraMedicamento();
            btnAgregarMedicamento.Enabled = false;
            txtNombreGenerico.ReadOnly = true;
        }
        /*
          * Método para cargar la especificación de un nuevo medicamento.
          * No recibe parámetros
          * El valor de retorno es void.
        */
        public void registraMedicamento()
        {
            Medicamento medicamento = new Medicamento();

            medicamento.nombreGenerico = txtNombreGenerico.Text;

            NombreComercial nombreComercial = new NombreComercial();
            nombreComercial.nombre = txtNombreComercial.Text;

            manejadorActualizarMedicamento.registrarMedicamento(medicamento, nombreComercial);

            idUltimoMedicamentoIngresado = medicamento.id_medicamento;

            EspecificacionMedicamento especificación = new EspecificacionMedicamento();

            especificación.id_medicamento_fk = idUltimoMedicamentoIngresado;
            especificación.id_formaAdministracion =Convert.ToInt32(cboFormaAdministración.SelectedValue);
            especificación.concentracion = Convert.ToInt32(txtConcentracion.Text);
            especificación.id_unidadMedida_fk = Convert.ToInt32(cboUnidadMedida.SelectedValue);
            especificación.id_presentacionMedicamento = Convert.ToInt32(cboPresentacionMedicamento.SelectedValue);
            especificación.cantidadComprimidos = Convert.ToInt32(txtCantidadComprimidos.Text);

            manejadorActualizarMedicamento.registrarEspecificacionMedicamento(especificación);

            cargarDataGridView();
        }
        public void registrarNuevaEspecificacionDeUnMedicamento()
        {
            if(idUltimoMedicamentoIngresado >0)
            {
                EspecificacionMedicamento medicamentoConNuevasEspecificaciones = new EspecificacionMedicamento();

                medicamentoConNuevasEspecificaciones.id_formaAdministracion = Convert.ToInt32( cboFormaAdministración.SelectedValue);
                medicamentoConNuevasEspecificaciones.concentracion = Convert.ToInt32(txtConcentracion.Text);
                medicamentoConNuevasEspecificaciones.id_unidadMedida_fk = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                medicamentoConNuevasEspecificaciones.id_presentacionMedicamento = Convert.ToInt32(cboPresentacionMedicamento.SelectedValue);
                medicamentoConNuevasEspecificaciones.cantidadComprimidos = Convert.ToInt32(txtCantidadComprimidos.Text);

                medicamentoConNuevasEspecificaciones.id_medicamento_fk = idUltimoMedicamentoIngresado;

                Boolean existeNombreComercial= manejadorActualizarMedicamento.existeNombreComercial(txtNombreComercial.Text);
                Boolean existeEspecificacion= manejadorActualizarMedicamento.existeEspecificacion(medicamentoConNuevasEspecificaciones);
               
                if (existeEspecificacion == true)
                {
                    MessageBox.Show("Existe un medicamento con las especificaciones ingresadas!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (existeNombreComercial == false)
                {
                    NombreComercial nombreComercial = new NombreComercial();
                    nombreComercial.nombre = txtNombreComercial.Text;
                    nombreComercial.id_medicamento_fk = medicamentoConNuevasEspecificaciones.id_medicamento_fk;

                    manejadorActualizarMedicamento.registrarNombreComercialMedicamento(nombreComercial);
                }

                manejadorActualizarMedicamento.registrarEspecificacionMedicamento(medicamentoConNuevasEspecificaciones);
                cargarDataGridView();
                

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (idUltimoMedicamentoIngresado == 0)
            {
                idUltimoMedicamentoIngresado=(int)dgvListaMedicamentos.CurrentRow.Cells["id_medicamento_fk"].Value;
            }
            registrarNuevaEspecificacionDeUnMedicamento();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreGenerico.ReadOnly = false;
            txtNombreGenerico.Clear();
            txtNombreComercial.Clear();
            txtConcentracion.Clear();
            txtCantidadComprimidos.Clear();
            idUltimoMedicamentoIngresado = 0;
            btnAgregarMedicamento.Enabled = true;
            btnAgregarNuevasEspecificaciones.Enabled = false;
        }
        public void cargarDatosDeFilasDelDatagridViewAlFormulario()
        {
            txtNombreGenerico.Text = Convert.ToString(dgvListaMedicamentos.CurrentRow.Cells["Nombre genérico"].Value);
            txtNombreComercial.Text = Convert.ToString(dgvListaMedicamentos.CurrentRow.Cells["Nombre comercial"].Value);
            cboFormaAdministración.SelectedValue = (int)(dgvListaMedicamentos.CurrentRow.Cells["id_formaAdministracion_fk"].Value);
            cboPresentacionMedicamento.SelectedValue = (int)(dgvListaMedicamentos.CurrentRow.Cells["id_presentacionMedicamento_fk"].Value);
            cboUnidadMedida.SelectedValue = (int)(dgvListaMedicamentos.CurrentRow.Cells["id_unidadMedida_fk"].Value);
            txtConcentracion.Text = Convert.ToString(dgvListaMedicamentos.CurrentRow.Cells["Concentración"].Value);
            txtCantidadComprimidos.Text = Convert.ToString(dgvListaMedicamentos.CurrentRow.Cells["Cantidad de comprimidos"].Value);

            btnAgregarMedicamento.Enabled = false;
            btnAgregarNuevasEspecificaciones.Enabled = true;
            
        }
        private void dgvListaMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosDeFilasDelDatagridViewAlFormulario();
        }

    }
}
