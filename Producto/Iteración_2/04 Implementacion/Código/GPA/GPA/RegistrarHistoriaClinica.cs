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
        ManejadorRegistrarAntecedentesGinecoObstetricos manejadorRegistrarAntecedentesGinecoObstetricos;
        ManejadorRegistrarAntecedentesPatologicosFamiliares manejadorRegistrarAntecedentesPatologicosFamiliares;
        ManejadorRegistrarAlergias manejadorRegistrarAlergias;
        ManejadorRegistrarHabitosTabaquismo manejadorRegistrarHabitosTabaquismo;
        ManejadorRegistrarHabitoAlcoholismo manejadorRegistrarHabitosAlcoholismo;
        ManejadorRegistrarHabitosDrogasIlicitas manajadorRegistrarHabitosDrogasIlicitas;
        ManejadorRegistrarDrogasLicitas manejadorRegistrarDrogasLicitas;

        public RegistrarHistoriaClínica(ProfesionaMedico medicoLogueado,Paciente pacienteSeleccionado)
        {
            InitializeComponent();
            medico= medicoLogueado;
            paciente = pacienteSeleccionado;
            manejadorRegistrarHC = new ManejadorRegistrarHC();
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
            manejadorRegistrarAntecedentesMorbidos = new ManejadorRegistrarAntecedentesMorbidos();
            manejadorRegistrarAntecedentesGinecoObstetricos = new ManejadorRegistrarAntecedentesGinecoObstetricos();
            manejadorRegistrarAntecedentesPatologicosFamiliares = new ManejadorRegistrarAntecedentesPatologicosFamiliares();
            manejadorRegistrarAlergias = new ManejadorRegistrarAlergias();
            manejadorRegistrarHabitosTabaquismo = new ManejadorRegistrarHabitosTabaquismo();
            manejadorRegistrarHabitosAlcoholismo = new ManejadorRegistrarHabitoAlcoholismo();
            manajadorRegistrarHabitosDrogasIlicitas = new ManejadorRegistrarHabitosDrogasIlicitas();
            manejadorRegistrarDrogasLicitas = new ManejadorRegistrarDrogasLicitas();
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

            presentarElementosDelTiempo(cboTiempoOcurridoAntMorbido, manejadorRegistrarAntecedentesMorbidos.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarTiposDeParto(cboTipoPartoATermino, manejadorRegistrarAntecedentesGinecoObstetricos.mostrarTiposDeParto(), "id_tipoParto", "nombre");

            presentarTiposDeParto(cboTipoPartoPostermino, manejadorRegistrarAntecedentesGinecoObstetricos.mostrarTiposDeParto(), "id_tipoParto", "nombre");

            presentarTiposDeParto(cboTipoPartoPretermino, manejadorRegistrarAntecedentesGinecoObstetricos.mostrarTiposDeParto(), "id_tipoParto", "nombre");

            presentarTiposAborto(cboTipoAborto1, manejadorRegistrarAntecedentesGinecoObstetricos.mostrarTiposDeAbortos(), "id_tipoAborto", "nombre");

            presentarTiposAborto(cboTipoAborto2, manejadorRegistrarAntecedentesGinecoObstetricos.mostrarTiposDeAbortos(), "id_tipoAborto", "nombre");

            presentarFamiliares(cboFamiliar, manejadorRegistrarAntecedentesPatologicosFamiliares.mostrarFamiliares(), "id_familiar", "nombre");
            rbSiViveFamiliar.Checked = true;
            rbNoOtraEnfermedad.Checked = true;
            txtDescripcionOtraEnfermedad.Enabled=false;
            txtCausaMuerte.Enabled = false;

            presentarAlimentos(cboAlimentos, manejadorRegistrarAlergias.mostrarAlimentos(), "id_alimento", "nombre");

            presentarSustanciasDelAmbiente(cboSustanciaAmbiente, manejadorRegistrarAlergias.mostrarSustanciasDelAmbiente(), "id_sustanciaAmbiente", "nombre");

            presentarSustanciasContactoPiel(cboSustanciaContactoPiel, manejadorRegistrarAlergias.mostrarSustanciasContactoPiel(), "id_sustanciaContactoPiel", "nombre");

            presentarInsectos(cboInsectos, manejadorRegistrarAlergias.mostrarInsectos(), "id_insecto", "nombre");

            presentarNombreMedicamentos(cboMedicamentos, manejadorRegistrarAlergias.mostrarNombreMedicamentos(), "id_medicamento", "nombreGenerico");

            presentarNombreElementosQueFuma(cboElementoQueFuma, manejadorRegistrarHabitosTabaquismo.mostrarNombreElementoQueFuma(), "id_elementoQueFuma", "nombre");

            presentarNombreElementosQueFuma(cboElementoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarNombreElementoQueFuma(), "id_elementoQueFuma", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoFuma, manejadorRegistrarHabitosTabaquismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarDescripcionesDelTiempo(cboDescripcionDelTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarDescripcionesDelTiempo(), "id_descripcionDelTiempo", "nombre");

            presentarElementosDelTiempo(cboElementosDelTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarTiposBebidas(cboTipoBebida, manejadorRegistrarHabitosAlcoholismo.mostrarTiposDeBebidas(), "id_tipoBebida", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoAlcoholismo, manejadorRegistrarHabitosAlcoholismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarMedidasBebidasAlcoholicas(cboMedidaConsumeAlcohol, manejadorRegistrarHabitosAlcoholismo.mostrarMedidasBebidasAlcoholicas(), "id_medida", "nombre");

            presentarSustanciasDrogasIlicitas(cboSustanciaDrogaIlicita, manajadorRegistrarHabitosDrogasIlicitas.mostrarSustanciasDrogasIlicitas(), "id_sustancia", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoDrogasIlicitas, manajadorRegistrarHabitosDrogasIlicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarMedicamento(cboNombreGenerico, manejadorRegistrarDrogasLicitas.mostrarNombresMedicamento(),"id_medicamento", "nombreGenerico");
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
         * Recibe como parámetro la referencia del ComboBox, una lista de objetos TiposSintoma, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
         */
        public void presentarTipoSintomas(ComboBox combo, List<TipoSintoma> tiposSintomas, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposSintomas, valueMember, displayMember);
        }
        /*
       * Método para mostrar las del cuerpo humano en el combo box correspondiente.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos ParteDelCuerpo, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarPartesDelCuerpoHumano(ComboBox combo,List<ParteDelCuerpo> partesCuerpo,string valueMember,string displayMember)
        {
            cargarCombo(cboParteCuerpo,partesCuerpo,valueMember,displayMember);
        }
        /*
      * Método para mostrar los tipos de dolores(carácter del dolor).
      * Recibe como parámetro la referencia del ComboBox, una lista de objetos CaracterDelDolor, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
      * El valor de retorno es void.
      * Llama al método cargarCombo.
      */
        public void presentarCaracterDelDolor(ComboBox combo, List<CaracterDelDolor> caracterDelDolor, string valueMember,string displayMember)
        {
            cargarCombo(combo, caracterDelDolor, valueMember, displayMember);
        }
        /*
       * Método para mostrar los elementos del tiempo.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos ElementoDelTiempo, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarElementosDelTiempo(ComboBox combo,List<ElementoDelTiempo> elementosDelTiempo, string valueMember, string displayMember)
        {
            cargarCombo(combo,elementosDelTiempo, valueMember, displayMember);
        }
        /*
         * Método para mostrar las descripciones del tiempo
         * Recibe como parámetro la referencia del ComboBox, una lista de objetos DescripcionDelTiempo, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
         */
        public void presentarDescripcionesDelTiempo(ComboBox combo,List<DescripcionDelTiempo> descripcionesDelTiempo,string valueMember,string displayMember)
        {
            cargarCombo(combo, descripcionesDelTiempo, valueMember, displayMember);
        }
        /*
       * Método para mostrar las formas de modificaciones del los síntomas
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos ModificacionSintoma, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarModificacionesDelSintoma(ComboBox combo, List<ModificacionSintoma> modificacionesDelSintoma, string valueMember, string displayMember)
        {
            cargarCombo(cboComoModificaSintoma, modificacionesDelSintoma,valueMember,displayMember);
        }
        /*
       * Método para mostrar los elementos que modifican un síntoma.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos ElementoModificacion, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarElementosDeModificacionDelSintoma(ComboBox combo, List<ElementoDeModificacion> elementosDeModificacion, string valueMember, string displayMember)
        {
            cargarCombo(cboElementoModificacion, elementosDeModificacion, "id_elementoDeModificacion","nombre");
        }
        /*
         * Método para presentar los tipos de antecedentes mórbidos en el combobox.
         * Recibe como parámetro la referencia del ComboBox, una lista de objetos TipoAntecedenteMorbido, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
        */
        public void presentarTiposAntecedentesMorbidos(ComboBox combo, List<TipoAntecedenteMorbido> tiposAntecedentesMorbidos, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposAntecedentesMorbidos, "id_tipoAntecedenteMorbido", "nombre");
        }
        /*
       * Método para presentar las enfermedades en el combobox.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos Enfermedad, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarEnfermedades(ComboBox combo, List<Enfermedad> enfermedades, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, enfermedades, "id_enfermedad", "nombre");
        }
        /*
     * Método para presentar las operaciones en el combobox.
     * Recibe como parámetro la referencia del ComboBox, una lista de objetos Operación, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
     * El valor de retorno es void.
     * Llama al método cargarCombo.
      */
        public void presentarOperaciones(ComboBox combo,List<Operacion> operaciones, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, operaciones, "id_operacion", "nombre");
        }
        /*
       * Método para presentar los traumatismos en el combobox.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos Traumatismo, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
        */
        public void presentarTraumatismos(ComboBox combo, List<Traumatismo> traumatismos, string valueMember, string displayMember)
        {
            cargarCombo(cboNombrePorTipoAntecedenteMorbido, traumatismos, valueMember, displayMember);
        }
        /*
        * Método para presentar los tipos de parto en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos TipoParto, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
        */
        public void presentarTiposDeParto(ComboBox combo, List<TipoParto> tiposDeParto, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposDeParto, valueMember, displayMember);
        }
        /*
        * Método para presentar los tipos de abortos en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos TipoAborto, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
        */
        public void presentarTiposAborto(ComboBox combo, List<TipoAborto> tiposDeAbortos, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposDeAbortos, valueMember, displayMember);
        }
        /*
          * Método para mostrar los familiares o grado de parentezco en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos Familiar, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
        */
        public void presentarFamiliares(ComboBox combo, List<Familiar> familiares, string valueMember, string displayMember)
        {
            cargarCombo(combo, familiares, valueMember, displayMember);
        }
        /*
        * Método para mostrar los alimentos en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos Alimento, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
      */
        public void presentarAlimentos(ComboBox combo, List<Alimento> alimentos, string valueMember, string displayMember)
        {
            cargarCombo(combo, alimentos, valueMember, displayMember);
        }
        /*
        * Método para mostrar las sustancias del ambiente en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos SustanciaAmbiente, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
      */
        public void presentarSustanciasDelAmbiente(ComboBox combo, List<SustaciaAmbiente> sustanciasDelAmbiente, string valueMember, string displayMember)
        {
            cargarCombo(combo, sustanciasDelAmbiente, valueMember, displayMember);
        }
        /*
          * Método para mostrar, las sustancias que producen alergias en contacto con la piel, en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos SustanciaContactoPiel, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
        */
        public void presentarSustanciasContactoPiel(ComboBox combo, List<SustanciaContactoPiel> sustanciasContactoPiel, string valueMember, string displayMember)
        {
            cargarCombo(combo, sustanciasContactoPiel, valueMember, displayMember);
        }
        /*
           * Método para mostrar, los insectos que producen alergias,  en el combobox.
           * Recibe como parámetro la referencia del ComboBox, una lista de objetos Insecto, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
           * El valor de retorno es void.
           * Llama al método cargarCombo.
         */
        public void presentarInsectos(ComboBox combo, List<Insecto> insectos, string valueMember, string displayMember)
        {
            cargarCombo(combo, insectos, valueMember, displayMember);
        }
        /*
           * Método para mostrar, los nombres de medicamentos que producen alergias,  en el combobox.
           * Recibe como parámetro la referencia del ComboBox, una lista de objetos Medicamento, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
           * El valor de retorno es void.
           * Llama al método cargarCombo.
         */
        public void presentarNombreMedicamentos(ComboBox combo, List<Medicamento> medicamentos, string valueMember, string displayMember)
        {
            cargarCombo(combo, medicamentos, valueMember, displayMember);
        }
        /*
          * Método para mostrar, los nombres de elementos utilizados para fumar,  en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos ElementoQueFuma, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
        */
        public void presentarNombreElementosQueFuma(ComboBox combo, List<ElementoQueFuma> elementos, string valueMember, string displayMember)
        {
            cargarCombo(combo, elementos, valueMember, displayMember);
        }
        /*
          * Método para mostrar, los componentes del tiempo,  en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos ComponenteDelTiempo, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
        */
        public void presentarComponentesDelTiempo(ComboBox combo, List<ComponenteDelTiempo> componentes, string valueMember, string displayMember)
        {
            cargarCombo(combo, componentes, valueMember, displayMember);
        }
        /*
        * Método para mostrar, los tipos de bebidas,  en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos TiposBebida, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
      */
        public void presentarTiposBebidas(ComboBox combo, List<TipoBebida> tiposDeBebidas, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposDeBebidas, valueMember, displayMember);
        }
        /*
        * Método para mostrar, las medidas para bebidas alcoholicas,  en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos Medida, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
        */
        public void presentarMedidasBebidasAlcoholicas(ComboBox combo, List<Medida> medidas, string valueMember, string displayMember)
        {
            cargarCombo(combo, medidas, valueMember, displayMember);
            
        }
        
        /*
       * Método para mostrar, las sustancias que son drogas ilicitas,  en el combobox.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos SustanciaDrogaIlicita, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
       */
        public void presentarSustanciasDrogasIlicitas(ComboBox combo, List<SustanciaDrogaIlicita> sustancias, string valueMember, string displayMember)
        {
            cargarCombo(combo, sustancias, valueMember, displayMember);

        }
        public void presentarMedicamento(ComboBox combo, List<Medicamento> medicamento, string valueMember, string displayMember)
        {
            cargarCombo(combo, medicamento, valueMember, displayMember);
        }
        public void presentarNombresComerciales(ComboBox combo, List<NombreComercial> nombresComerciales, string valueMember, string displayMember)
        {
            cargarCombo(combo, nombresComerciales, valueMember, displayMember);
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
        /*
         * Método para verificar si el paciente seleccionado tiene historia clínica.
         */
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
        /*
         * Método para habilitar o deshabilitar los componentes TabPage y button.
         * Recibe como parámetro un valor boolean.
         * El valor de retorno es void.
         */
        public void habilitarDeshabilitarTabPageYBotones(Boolean valor)
        {
            btnAceptar.Enabled = valor;
            ((Control)tpEnfermedadActual).Enabled = valor;
            ((Control)tpAntecedentes).Enabled = valor;
            ((Control)tpAlergias).Enabled = valor;
            ((Control)tpHabitos).Enabled = valor;
        }
        /*
         * Método para habilitar o deshabilitar, en antecedentes patológicos familiares, el txtDescripcionOtraEnfermedad de acuerdo a la selección del rbSiOtraEnfermedad.
         * 
         */
        public void habilitarDeshabilitarTxtDescripcionOtraEnfermedadAntecedentesPatologicos()
        {
            if (rbNoOtraEnfermedad.Checked == true)
            {
                txtDescripcionOtraEnfermedad.Enabled = false;
            }
            else
            {
                txtDescripcionOtraEnfermedad.Enabled = true;
            }
        }
        /*
        * Método para habilitar o deshabilitar, en antecedentes patológicos familiares, el txtCausaMuerte de acuerdo a la selección del rbSiViveFamiliar.
        * 
        */
        public void habilitarDeshabilitarTxtCausaMuerteAntecedentesPatologicos()
        {
            if (rbSiViveFamiliar.Checked == true)
            {
                txtCausaMuerte.Enabled = false;
            }
            else
            {
                txtCausaMuerte.Enabled = true;
            }
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
        /*
         * Método para cargar enfermedades, operaciones o traumatismos según el tipo de antecedente mórbido seleccionado en el combobox cboTipoAntecedenteMorbido
         * El valor de retorno es void.
         */
        private void cboTipoAntecedenteMorbido_SelectedIndexChanged(object sender, EventArgs e)
        {
             TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
             switch (tipo.nombre)
             {
                 case "Enfermedad":
                     presentarEnfermedades(cboNombrePorTipoAntecedenteMorbido,manejadorRegistrarAntecedentesMorbidos.mostrarEnfermedades(tipo.id_tipoAntecedenteMorbido),"id_enfermedad","nombre");
                     break;
                 case "Operación":
                     presentarOperaciones(cboNombrePorTipoAntecedenteMorbido,manejadorRegistrarAntecedentesMorbidos.mostrarOperaciones(tipo.id_tipoAntecedenteMorbido),"id_operacion","nombre");
                     break;
                 case "Traumatismo":
                     presentarTraumatismos(cboNombrePorTipoAntecedenteMorbido,manejadorRegistrarAntecedentesMorbidos.mostrarTraumatismos(tipo.id_tipoAntecedenteMorbido),"id_Traumatismo","nombre");
                     break;
                 default:
                     break;
             }
            
                
            
            
        }

        private void rbSiOtraEnfermedad_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarTxtDescripcionOtraEnfermedadAntecedentesPatologicos();
        }

        private void rbSiViveFamiliar_CheckedChanged(object sender, EventArgs e)
        {
            habilitarDeshabilitarTxtCausaMuerteAntecedentesPatologicos();
        }

        private void label108_Click(object sender, EventArgs e)
        {

        }

        private void cboNombreGenerico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedicamento;
            Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
           presentarNombresComerciales(cboNombreComercial, manejadorRegistrarDrogasLicitas.mostrarNombresComercialDeMedicamento(idMedicamento),"id_nombreComercial","nombre");
        }
    }
}
