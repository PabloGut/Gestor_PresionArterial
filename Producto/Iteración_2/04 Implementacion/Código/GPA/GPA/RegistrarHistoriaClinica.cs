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
        ManejadorRegistrarAntecedentesMorbidos manejadorRegistrarAntecedentesMorbidos;
        public RegistrarHistoriaClínica(ProfesionaMedico medicoLogueado,Paciente pacienteSeleccionado)
        {
            InitializeComponent();
            medico= medicoLogueado;
            paciente = pacienteSeleccionado;
            manejadorRegistrarHC = new ManejadorRegistrarHC();
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
            manejadorRegistrarAntecedentesMorbidos = new ManejadorRegistrarAntecedentesMorbidos();
        }
        private void RegistrarHistoriaClínica_Load(object sender, EventArgs e)
        {
            habilitarDeshabilitarTabPageYBotones(false);
            rbSiDolor.Checked = true;
            presentarDatosPacienteYMedico();

            presentarFechaYHoraActual();

            presentarTipoSintomas(cboQueSienteElPaciente, manejadorRegistrarEnfermedadActual.mostrarTiposSintomas(),"id_TipoSintoma","nombre");

            presentarPartesDelCuerpoHumano(cboParteCuerpo,manejadorRegistrarEnfermedadActual.mostrarPartesDelCuerpoHumano(),"id_parteCuerpo","nombre");

            presentarCaracterDelDolor(cboCaracterDolor,manejadorRegistrarEnfermedadActual.mostrarCaracterDelDolor(),"id_caracterDelDolor","nombre");

            presentarElementosDelTiempo(cboElementoTiempo,manejadorRegistrarEnfermedadActual.mostrarElementosDelTiempo(),"id_elementoDelTiempo","nombre");

            presentarDescripcionesDelTiempo(cboCuandoComenzo,  manejadorRegistrarEnfermedadActual.mostrarDescripcionesDelTiempo(),"id_descripcionDelTiempo","nombre");

            presentarModificacionesDelSintoma(cboComoModificaSintoma, manejadorRegistrarEnfermedadActual.mostrarModificacionesDelSintoma(), "id_modificacionSintoma", "nombre");

            presentarElementosDeModificacionDelSintoma(cboElementoModificacion, manejadorRegistrarEnfermedadActual.mostrarElementosDeModificacion(), "id_elementoDeModificacion", "nombre");

            presentarTiposAntecedentesMorbidos(cboTipoAntecedenteMorbido,manejadorRegistrarAntecedentesMorbidos.mostrarTiposAntecedentesMorbidos(), "id_tipoAntecedenteMorbido", "nombre");
           
        }
        /*
         * Método para cargar la fecha y hora actual en los textbox.
         * No recibe parámetros.
         * Llama a los métodos mostrarFechaActual y mostrarHoraActual de la capa de logica de negocio.
         * El valor de retorno es void.
         */
        public void presentarFechaYHoraActual()
        {
            mtbFechaActual.Text = manejadorRegistrarHC.mostrarFechaActual();
            mtbHoraActual.Text = manejadorRegistrarHC.mostrarHoraActual();
        }
        /*
         * Método para mostrar los tipos de síntomas en el combo box correspondiente.
         * Recibe como parámetro una lista de los tipos de sintomas.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
         */
        public void presentarTipoSintomas(ComboBox combo, List<TipoSintoma> tiposSintomas, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposSintomas, valueMember, displayMember);
        }
        /*
       * Método para mostrar las del cuerpo humano en el combo box correspondiente.
       * Recibe como parámetro una lista de las partes del cuerpo.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarPartesDelCuerpoHumano(ComboBox combo,List<ParteDelCuerpo> partesCuerpo,string valueMember,string displayMember)
        {
            cargarCombo(cboParteCuerpo,partesCuerpo,valueMember,displayMember);
        }
        /*
      * Método para mostrar los tipos de dolores(carácter del dolor).
      * Recibe como parámetro una lista de los tipos de dolores.
      * El valor de retorno es void.
      * Llama al método cargarCombo.
      */
        public void presentarCaracterDelDolor(ComboBox combo, List<CaracterDelDolor> caracterDelDolor, string valueMember,string displayMember)
        {
            cargarCombo(combo, caracterDelDolor, valueMember, displayMember);
        }
        /*
       * Método para mostrar los elementos del tiempo.
       * Recibe como parámetro una lista de objetos ElementoDelTiempo.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarElementosDelTiempo(ComboBox combo,List<ElementoDelTiempo> elementosDelTiempo, string valueMember, string displayMember)
        {
            cargarCombo(combo,elementosDelTiempo, valueMember, displayMember);
        }
        /*
         * Método para mostrar las descripciones del tiempo
         * Recibe como parámetro una lista de objetos DescripcionDelTiempo.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
         */
        public void presentarDescripcionesDelTiempo(ComboBox combo,List<DescripcionDelTiempo> descripcionesDelTiempo,string valueMember,string displayMember)
        {
            cargarCombo(combo, descripcionesDelTiempo, valueMember, displayMember);
        }
        /*
       * Método para mostrar las formas de modificaciones del los síntomas
       * Recibe como parámetro una lista de objetos ModificacionSintoma.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarModificacionesDelSintoma(ComboBox combo, List<ModificacionSintoma> modificacionesDelSintoma, string valueMember, string displayMember)
        {
            cargarCombo(cboComoModificaSintoma, modificacionesDelSintoma,valueMember,displayMember);
        }
        /*
       * Método para mostrar los elementos que modifican un síntoma.
       * Recibe como parámetro una lista de objetos ElementoDeModificacion.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarElementosDeModificacionDelSintoma(ComboBox combo, List<ElementoDeModificacion> elementosDeModificacion, string valueMember, string displayMember)
        {
            cargarCombo(cboElementoModificacion, elementosDeModificacion, "id_elementoDeModificacion","nombre");
        }
        /*
         * Método para presentar los tipos de antecedentes mórbidos en el combobox.
         * Recibe como parámetro una lista de objetos TipoAntecedenteMorbido.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
        */
        public void presentarTiposAntecedentesMorbidos(ComboBox combo, List<TipoAntecedenteMorbido> tiposAntecedentesMorbidos, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposAntecedentesMorbidos, "id_tipoAntecedenteMorbido", "nombre");
        }
        /*
       * Método para presentar las enfermedades en el combobox.
       * Recibe como parámetro una lista de objetos Enfermedad.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarEnfermedades(ComboBox combo, List<Enfermedad> enfermedades, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, enfermedades, "id_enfermedad", "nombre");
        }
        /*
     * Método para presentar las operaciones en el combobox.
     * Recibe como parámetro una lista de objetos Operacion.
     * El valor de retorno es void.
     * Llama al método cargarCombo.
      */
        public void presentarOperaciones(ComboBox combo,List<Operacion> operaciones, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, operaciones, "id_operacion", "nombre");
        }
        /*
       * Método para presentar los traumatismos en el combobox.
       * Recibe como parámetro una lista de objetos Traumatismo.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarTraumatismos(ComboBox combo, List<Traumatismo> traumatismos, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, traumatismos, valueMember, displayMember);
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
        public void cargarComboTipoDocumento()
        {
            /*cboTipoDocumento.DataSource = TipoDocumentoDAO.buscarTiposDoc();
            cboTipoDocumento.ValueMember = "id_TipoDoc";
            cboTipoDocumento.DisplayMember = "nombre";*/
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

        private void cboTipoAntecedenteMorbido_SelectedIndexChanged(object sender, EventArgs e)
        {
             TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
             switch (tipo.nombre)
             {
                 case "Enfermedad":
                     presentarEnfermedades(cboNombrePorTipoAntecedenteMorbido,   manejadorRegistrarAntecedentesMorbidos.mostrarEnfermedades(tipo.id_tipoAntecedenteMorbido),"id_enfermedad","nombre");
                     break;
                 case "Operación":
                     presentarOperaciones(cboNombrePorTipoAntecedenteMorbido,manejadorRegistrarAntecedentesMorbidos.mostrarOperaciones(tipo.id_tipoAntecedenteMorbido),"id_operacion","nombre");
                     break;
                 case "Traumatismo":
                     presentarTraumatismos( cboNombrePorTipoAntecedenteMorbido, manejadorRegistrarAntecedentesMorbidos.mostrarTraumatismos(tipo.id_tipoAntecedenteMorbido),"id_Traumatismo","nombre");
                     break;
                 default:
                     break;
             }
            
                
            
            
        }
    }
}
