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
        private int idMedicamento;
        private int idNombreComercial;

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
            btnAgregarNuevasEspecificaciones.Enabled = true;
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

            idMedicamento = medicamento.id_medicamento;

            EspecificacionMedicamento especificación = new EspecificacionMedicamento();

            especificación.id_nombreComercial = nombreComercial.id_nombreComercial;

            especificación.id_medicamento_fk = idMedicamento;
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
            if(idMedicamento >0)
            {
                EspecificacionMedicamento medicamentoConNuevasEspecificaciones = new EspecificacionMedicamento();

                medicamentoConNuevasEspecificaciones.id_formaAdministracion = Convert.ToInt32( cboFormaAdministración.SelectedValue);
                medicamentoConNuevasEspecificaciones.concentracion = Convert.ToInt32(txtConcentracion.Text);
                medicamentoConNuevasEspecificaciones.id_unidadMedida_fk = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                medicamentoConNuevasEspecificaciones.id_presentacionMedicamento = Convert.ToInt32(cboPresentacionMedicamento.SelectedValue);
                medicamentoConNuevasEspecificaciones.cantidadComprimidos = Convert.ToInt32(txtCantidadComprimidos.Text);

                medicamentoConNuevasEspecificaciones.id_medicamento_fk = idMedicamento;
                medicamentoConNuevasEspecificaciones.id_nombreComercial = idNombreComercial;

                Boolean existeNombreComercial= manejadorActualizarMedicamento.existeNombreComercial(txtNombreComercial.Text);
                if (existeNombreComercial == false)
                {
                    NombreComercial nombreComercial = new NombreComercial();
                    nombreComercial.nombre = txtNombreComercial.Text;
                    nombreComercial.id_medicamento_fk = medicamentoConNuevasEspecificaciones.id_medicamento_fk;

                    manejadorActualizarMedicamento.registrarNombreComercialMedicamento(nombreComercial);
                    medicamentoConNuevasEspecificaciones.id_nombreComercial = nombreComercial.id_nombreComercial;
                }
                else
                {
                    //Agregar busqueda de un nombre comercial obteniendo el id del mismo para asignarlo a la nueva especificacion.
                    medicamentoConNuevasEspecificaciones.id_nombreComercial = manejadorActualizarMedicamento.idNombreMedicamento(txtNombreComercial.Text);
                }
                Boolean existeEspecificacion= manejadorActualizarMedicamento.existeEspecificacion(medicamentoConNuevasEspecificaciones);
               
                if (existeEspecificacion == true)
                {
                    MessageBox.Show("Existe un medicamento con las especificaciones ingresadas!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                manejadorActualizarMedicamento.registrarEspecificacionMedicamento(medicamentoConNuevasEspecificaciones);
                cargarDataGridView();
                

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            registrarNuevaEspecificacionDeUnMedicamento();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreGenerico.ReadOnly = false;
            txtNombreGenerico.Clear();
            txtNombreComercial.Clear();
            txtConcentracion.Clear();
            txtCantidadComprimidos.Clear();
            idMedicamento = 0;
            idNombreComercial = 0;
            btnAgregarMedicamento.Enabled = true;
            btnAgregarNuevasEspecificaciones.Enabled = false;
            cargarDataGridView();
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

            idMedicamento = (int)dgvListaMedicamentos.CurrentRow.Cells["id_medicamento_fk"].Value;
            idNombreComercial = (int)dgvListaMedicamentos.CurrentRow.Cells["id_nombreComercial_fk"].Value;

            btnAgregarMedicamento.Enabled = false;
            btnAgregarNuevasEspecificaciones.Enabled = true;
            txtNombreGenerico.ReadOnly = true;
            
        }
        private void dgvListaMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosDeFilasDelDatagridViewAlFormulario();
        }

        private void btnEditarEspecificacion_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarEspecificacion_Click_1(object sender, EventArgs e)
        {
            editarEspecificacion();
        }
        public void editarEspecificacion()
        {
            EspecificacionMedicamento especificacion = new EspecificacionMedicamento();

            especificacion.id_formaAdministracion = Convert.ToInt32(cboFormaAdministración.SelectedValue);
            especificacion.concentracion = Convert.ToInt32(txtConcentracion.Text);
            especificacion.id_unidadMedida_fk = Convert.ToInt32(cboUnidadMedida.SelectedValue);
            especificacion.id_presentacionMedicamento = Convert.ToInt32(cboPresentacionMedicamento.SelectedValue);
            especificacion.cantidadComprimidos = Convert.ToInt32(txtCantidadComprimidos.Text);

            especificacion.id_medicamento_fk = idMedicamento;

            especificacion.id_nombreComercial = manejadorActualizarMedicamento.idNombreMedicamento(txtNombreComercial.Text);

            if (especificacion.id_nombreComercial != 0)
            {
                if (manejadorActualizarMedicamento.existeEspecificacion(especificacion) == false)
                {
                    manejadorActualizarMedicamento.actualizarEspecificacion(especificacion);
                }
                else
                {
                    MessageBox.Show("Ya existe la especificacion!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado= MessageBox.Show("Desea eliminar la especificación?","Atención",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (resultado == DialogResult.OK)
            {
                manejadorActualizarMedicamento.eliminarEspecificacion((int)dgvListaMedicamentos.CurrentRow.Cells["id_especificacion"].Value);
                cargarDataGridView();

            }
            else
            {
                return;
            }
            

            
        }

        private void btnBuscarEspecificacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreGenerico.Text) == false)
            {
                dgvListaMedicamentos.DataSource = manejadorActualizarMedicamento.mostrarEspecificacionMedicamento(txtNombreGenerico.Text);
            }
        }

        private void txtNombreGenerico_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNombreGenerico.Text) == false)
            {
                dgvListaMedicamentos.DataSource = manejadorActualizarMedicamento.mostrarEspecificacionMedicamento(txtNombreGenerico.Text);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
