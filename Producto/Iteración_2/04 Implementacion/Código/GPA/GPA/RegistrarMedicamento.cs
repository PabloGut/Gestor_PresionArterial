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
    public partial class RegistrarMedicamento : Form
    {
        public RegistrarMedicamento()
        {
            InitializeComponent();
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
            presentarUnidadMedida(cboUnidadMedida, UnidadMedidaLN.mostrarUnidadesDeMedida(), "id_unidadMedida", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento, PresentacionMedicamentoLN.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarFormaAdministracion(cboFormaAdministración, FormaAdministracionLN.mostrarFormasDeAdministracion(), "id_formaAdministracion", "nombre");
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

        private void btnAgregarHabitoMedicamento_Click(object sender, EventArgs e)
        {
           
        }
        public void registraMedicamento()
        {
            Medicamento medicamento = new Medicamento();

            medicamento.nombreGenerico = txtNombreGenerico.Text;
            medicamento.id_formaAdministración =Convert.ToInt32(cboFormaAdministración.SelectedValue);
            medicamento.concentracion = Convert.ToInt32(txtConcentracion.Text);
            medicamento.id_unidadMedida = Convert.ToInt32(cboUnidadMedida);
            medicamento.id_presentacion = Convert.ToInt32(cboPresentacionMedicamento);
            medicamento.cantidadComprimidos = Convert.ToInt32(txtCantidadComprimidos.Text);

            NombreComercial nombreComercial = new NombreComercial();
            nombreComercial.nombre = txtNombreComercial.Text;

            MedicamentoLN.registrarMedicamento(medicamento, nombreComercial);
        }
    }
}
