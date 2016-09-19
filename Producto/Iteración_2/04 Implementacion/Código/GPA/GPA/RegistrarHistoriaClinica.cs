using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Entidades.Clases;
using GPA.Manejadores;

namespace GPA
{
    public partial class RegistrarHistoriaClínica : Form
    {

        ProfesionaMedico medico{set;get;}
        Paciente paciente {set; get;}
        ManejadorRegistrarHC manejadorRegistrarHC;
        ManejadorRegistrarEnfermedadActual manejadorRegistrarEnfermedadActual;
        public RegistrarHistoriaClínica(ProfesionaMedico medicoLogueado,Paciente pacienteSeleccionado)
        {
            InitializeComponent();
            medico= medicoLogueado;
            paciente = pacienteSeleccionado;
            manejadorRegistrarHC = new ManejadorRegistrarHC();
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
        }
        private void RegistrarHistoriaClínica_Load(object sender, EventArgs e)
        {
            habilitarDeshabilitarTabPageYBotones(false);
            rbSiDolor.Checked = true;
            presentarDatosPacienteYMedico();

            presentarFechaYHoraActual();

            presentarTipoSintomas(manejadorRegistrarEnfermedadActual.mostrarTiposSintomas());

            presentarPartesDelCuerpoHumano(manejadorRegistrarEnfermedadActual.mostrarPartesDelCuerpoHumano());

            presentarCaracterDelDolor(manejadorRegistrarEnfermedadActual.mostrarCaracterDelDolor());
           
        }
        public void presentarFechaYHoraActual()
        {
            mtbFechaActual.Text = manejadorRegistrarHC.mostrarFechaActual();
            mtbHoraActual.Text = manejadorRegistrarHC.mostrarHoraActual();
        }
        public void cargarComboTipoDocumento()
        {
            /*cboTipoDocumento.DataSource = TipoDocumentoDAO.buscarTiposDoc();
            cboTipoDocumento.ValueMember = "id_TipoDoc";
            cboTipoDocumento.DisplayMember = "nombre";*/
        }
        /*
         * Método para mostrar los tipos de síntomas en el combo box correspondiente.
         * Recibe como parámetro una lista de los tipos de sintomas.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
         */
        public void presentarTipoSintomas(List<TipoSintoma> tiposSintomas)
        {
            cargarCombo(cboQueSienteElPaciente, tiposSintomas, "id_tipoSintoma", "nombre");
        }
        /*
       * Método para mostrar las del cuerpo humano en el combo box correspondiente.
       * Recibe como parámetro una lista de las partes del cuerpo.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarPartesDelCuerpoHumano(List<ParteDelCuerpo> partesCuerpo)
        {
            cargarCombo(cboParteCuerpo,partesCuerpo,"id_parteCuerpo","nombre");
        }
        /*
      * Método para mostrar los tipos de dolores(carácter del dolor).
      * Recibe como parámetro una lista de los tipos de dolores.
      * El valor de retorno es void.
      * Llama al método cargarCombo.
      */
        public void presentarCaracterDelDolor(List<CaracterDelDolor> caracterDelDolor)
        {
            cargarCombo(cboCaracterDolor, caracterDelDolor, "id_caracterDelDolor", "nombre");
        }
       
        /*
         * Método para cargar un ComboBox.
         * Recibe como parámetro una referencia de un ComboBox, una lista genérica,  un string del valueMember y un string del displayMember.
         * El valor de retorno es void.
         */
        public void cargarCombo<T>(ComboBox combo,List<T> lista, string valueMember, string displayMember)
        {
            combo.DataSource = lista;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
        }
        
        /*
         * Método para presentar los datos del paciente y médico, en los textbox de la interfaz de usuario.
         * No tiene parámetros.
         * El valor de retorno es void.
         */
        public void presentarDatosPacienteYMedico()
        {
            txtNombrePaciente.Text = paciente.nombre;
            txtApellidoPaciente.Text = paciente.apellido;

            txtNombreDoctor.Text = medico.nombre;
            txtApellidoDoctor.Text = medico.apellido;
            txtTipoDocumentoDoctor.Text = medico.tipoDoc.nombre;
            txtNroDocumentoDoctor.Text = medico.nroDoc.ToString();


        }
       
        public void medicoLogueado(ProfesionaMedico medicoLogueado)
        {
           
        }
        private void btnVerificarHC_Click(object sender, EventArgs e)
        {
            if (manejadorRegistrarHC.existeHC(paciente.id_tipoDoc, paciente.nroDoc) == false)
            {
                MessageBox.Show("El paciente no posee historia clínica!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarDeshabilitarTabPageYBotones(true);
            }
            else
            {
                MessageBox.Show("El paciente ya tiene historia clínica!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }
        public void habilitarDeshabilitarTabPageYBotones(Boolean valor)
        {
            btnAceptar.Enabled = valor;
            ((Control)tpEnfermedadActual).Enabled = valor;
            ((Control)tpAntecedentes).Enabled = valor;
            ((Control)tpAlergias).Enabled = valor;
            ((Control)tpHabitos).Enabled = valor;
        }
        public void deshabilitarHabilitarComponentes(Boolean valor)
        {
            

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            

        }
        public int generarNroHC(int ultimoNroHC)
        {
            return ultimoNroHC=ultimoNroHC + 1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
          
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

        }

        private void rbSiDolor_CheckedChanged(object sender, EventArgs e)
        {
            cboCaracterDolor.Enabled = true;
        }

        private void rbNoDolor_CheckedChanged(object sender, EventArgs e)
        {
            cboCaracterDolor.Enabled = false;
        }
    }
}
