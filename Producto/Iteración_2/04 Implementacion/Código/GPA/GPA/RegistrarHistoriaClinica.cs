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
        ManejadorRegistrarAntecedentesPatologicosPersonales manejadorRegistrarAntecedentesPatologicosPersonales;
        ManejadorRegistrarAlergias manejadorRegistrarAlergias;
        ManejadorRegistrarHabitosTabaquismo manejadorRegistrarHabitosTabaquismo;
        ManejadorRegistrarHabitoAlcoholismo manejadorRegistrarHabitosAlcoholismo;
        ManejadorRegistrarHabitosDrogasIlicitas manejadorRegistrarHabitosDrogasIlicitas;
        ManejadorRegistrarDrogasLicitas manejadorRegistrarDrogasLicitas;
        ManejadorRegistrarHabitosActividadFisica manejadorRegistrarHabitosActividadFisica;

        List<Sintoma> listaSintomas;

        List<AntecedenteMorbido> listaAntecedentesMorbidos;
        AntecedenteGinecoObstetrico antecedenteGinecoObtetrico;

        List<AntecedenteFamiliar> listaAntecedentesFamiliares;

        List<AlergiaAlimento> listaAlergiasAlimento;
        List<AlergiaSustanciaAmbiente> listaAlergiasSustanciaAmbiente;
        List<AlergiaSustanciaContactoPiel> listaAlergiaSustanciaContactoPiel;
        List<AlergiaInsecto> listaAlergiaInsectos;
        List<AlergiaMedicamento> listaAlergiaMedicamento;

        List<HabitoTabaquismo> listaHabitosTabaquismo;
        List<HabitoAlcoholismo> listaHabitosAlcoholismo;
        List<HabitoDrogasIlicitas> listaHabitosDrogasIlicitas;
        List<HabitoMedicamento> listaHabitosMedicamentos;
        List<HabitoActividadFisica> listaHabitosActividadFisica;

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
            manejadorRegistrarHabitosDrogasIlicitas = new ManejadorRegistrarHabitosDrogasIlicitas();
            manejadorRegistrarDrogasLicitas = new ManejadorRegistrarDrogasLicitas();
            manejadorRegistrarHabitosActividadFisica = new ManejadorRegistrarHabitosActividadFisica();

            listaSintomas = new List<Sintoma>();
            listaAntecedentesMorbidos = null;
            antecedenteGinecoObtetrico = null;
            listaAntecedentesFamiliares = null;
            listaAlergiasAlimento = null;
            listaAlergiasSustanciaAmbiente = null;
            listaAlergiaSustanciaContactoPiel = null;
            listaAlergiaInsectos = null;
            listaAlergiaMedicamento = null;
            listaHabitosTabaquismo = null;
            listaHabitosAlcoholismo = null;
            listaHabitosDrogasIlicitas = null;
            listaHabitosMedicamentos = null;
            listaHabitosActividadFisica = null;
        }
        private void RegistrarHistoriaClínica_Load(object sender, EventArgs e)
        {
            habilitarDeshabilitarTabPageYBotones(false);
            
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
          

            presentarAlimentos(cboAlimentos, manejadorRegistrarAlergias.mostrarAlimentos(), "id_alimento", "nombre");

            presentarSustanciasDelAmbiente(cboSustanciaAmbiente, manejadorRegistrarAlergias.mostrarSustanciasDelAmbiente(), "id_sustanciaAmbiente", "nombre");

            presentarSustanciasContactoPiel(cboSustanciaContactoPiel, manejadorRegistrarAlergias.mostrarSustanciasContactoPiel(), "id_sustanciaContactoPiel", "nombre");

            presentarInsectos(cboInsectos, manejadorRegistrarAlergias.mostrarInsectos(), "id_insecto", "nombre");

            presentarNombreMedicamentosQueProducenAlergia(cboMedicamentosAlergia, manejadorRegistrarAlergias.mostrarMedicamentosQueProducenAlergias(), "idMedicamentoAlergia", "nombre");

            presentarNombreElementosQueFuma(cboElementoQueFuma, manejadorRegistrarHabitosTabaquismo.mostrarNombreElementoQueFuma(), "id_elementoQueFuma", "nombre");

            presentarNombreElementosQueFuma(cboElementoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarNombreElementoQueFuma(), "id_elementoQueFuma", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoFuma, manejadorRegistrarHabitosTabaquismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarDescripcionesDelTiempo(cboDescripcionDelTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarDescripcionesDelTiempo(), "id_descripcionDelTiempo", "nombre");

            presentarElementosDelTiempo(cboElementosDelTiempoFumaba, manejadorRegistrarHabitosTabaquismo.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarTiposBebidas(cboTipoBebida, manejadorRegistrarHabitosAlcoholismo.mostrarTiposDeBebidas(), "id_tipoBebida", "nombre");

            presentarComponentesDelTiempo(cboComponenteTiempoAlcoholismo, manejadorRegistrarHabitosAlcoholismo.mostrarComponentesDelTiempo(), "id_componenteTiempo", "nombre");

            presentarMedidasBebidasAlcoholicas(cboMedidaConsumeAlcohol, manejadorRegistrarHabitosAlcoholismo.mostrarMedidasBebidasAlcoholicas(), "id_medida", "nombre");

            presentarSustanciasDrogasIlicitas(cboSustanciaDrogaIlicita, manejadorRegistrarHabitosDrogasIlicitas.mostrarSustanciasDrogasIlicitas(), "id_sustancia", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoDrogasIlicitas, manejadorRegistrarHabitosDrogasIlicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarMedicamento(cboNombreGenerico, manejadorRegistrarDrogasLicitas.mostrarNombresMedicamento(),"id_medicamento", "nombreGenerico");

            presentarMomentosDelDia(cboMomentoDia1, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarMomentosDelDia(cboMomentoDia2, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarMomentosDelDia(cboMomentoDia3, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento1, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento2, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento3, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoMedicamento, manejadorRegistrarDrogasLicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoCancelacionMedicamento, manejadorRegistrarDrogasLicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");
            

            presentarFrecuenciasDeConsumo(cboFrecuencia, manejadorRegistrarDrogasLicitas.mostrarFrecuencias(), "id_frecuencia", "nombre");

            presentarActividadFisica(cboActividadFisica, manejadorRegistrarHabitosActividadFisica.mostrarActividadFisica(), "id_actividadFisica", "nombre");

            presentarGradosActividadFisica(cboGradoActividadFisica, manejadorRegistrarHabitosActividadFisica.mostrarGradosActividadFisica(), "id_gradoActividadFisica", "nombre");

            presentarIntensidadesActividadFisica(cboIntensidad, manejadorRegistrarHabitosActividadFisica.mostrarIntensidadActividadFisica(), "id_intensidad", "nombre");

            agregarColumnasSintomas();
            agregarColumnaAntecedentes();
            agregarColumnaAlergias();
            agregarColumnaHabitos();

            inicializarComponentes();
        }
        public void inicializarComponentes()
        {
         
            rbNoDolor.Checked = true;

            rbNoPresentaAntecedentesMorbidos.Checked = true;
            rbNoTieneEmbarazos.Checked = true;
            rbNoTieneAbortos.Checked = true;

            rbSiViveFamiliar.Checked = true;
            rbNoOtraEnfermedad.Checked = true;
            txtDescripcionOtraEnfermedad.Enabled = false;
            txtCausaMuerte.Enabled = false;

            rbNoAlergicoAlimentos.Checked = true;
            rbNoAlergiaSustanciaAmbiente.Checked = true;
            rbNoAlergiaSustanciaContactoPiel.Checked = true;
            rbNoAlergiaInsecto.Checked = true;
            rbNoAlergiaMedicamento.Checked = true;

            rbNoFuma.Checked = true;
            rbNoConsumeAlcohol.Checked = true;
            rbNoConsumeDrogas.Checked = true;
            rbNoConsumeMedicamentos.Checked = true;
            rbMedicamentoActual.Checked = true;
            rbNoActividadFisica.Checked = true;
            
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
        public void presentarNombreMedicamentosQueProducenAlergia(ComboBox combo, List<MedicamentoAlergia> medicamentosAlergia, string valueMember, string displayMember)
        {
            cargarCombo(combo, medicamentosAlergia, valueMember, displayMember);
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
        /*
        * Método para mostrar los nombres de medicamentos,  en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos Medicamento, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
        */
        public void presentarMedicamento(ComboBox combo, List<Medicamento> medicamento, string valueMember, string displayMember)
        {
            cargarCombo(combo, medicamento, valueMember, displayMember);
        }
        /*
          * Método para mostrar los nombres comerciales de los medicamentos,  en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos NombreComercial, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
          */
        public void presentarNombresComerciales(ComboBox combo, List<NombreComercial> nombresComerciales, string valueMember, string displayMember)
        {
            cargarCombo(combo, nombresComerciales, valueMember, displayMember);
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
         * Método para presentar FormasAdministracion en el combobox.
         * Recibe como parámetro la referencia del ComboBox, una lista de objetos FormaAdministracion, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
         * El valor de retorno es void.
         * Llama al método cargarCombo.
        */
        public void presentarFormaAdministracion(ComboBox combo, List<FormaAdministracion> formasAdministracion, string valueMember, string displayMember)
        {
            cargarCombo(combo, formasAdministracion, valueMember, displayMember);
        }
        /*
        * Método para presentar presentaciones de medicamentos en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos PresentacionMedicamento, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
       */
        public void presentarPresentacionMedicamento(ComboBox combo, List<PresentacionMedicamento> presentacionesMedicamento, string valueMember, string displayMember)
        {
            cargarCombo(combo, presentacionesMedicamento, valueMember, displayMember);
        }
        /*
           * Método para presentar presentaciones momentos del dia en el combobox.
           * Recibe como parámetro la referencia del ComboBox, una lista de objetos MomentoDia, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
           * El valor de retorno es void.
           * Llama al método cargarCombo.
          */
        public void presentarMomentosDelDia(ComboBox combo, List<MomentoDia> momentoDia, string valueMember, string displayMember)
        {
            cargarCombo(combo, momentoDia, valueMember, displayMember);
        }
        /*
           * Método para presentar frecuencias de consumo de medicamento en el combobox.
           * Recibe como parámetro la referencia del ComboBox, una lista de objetos Frecuencia, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
           * El valor de retorno es void.
           * Llama al método cargarCombo.
          */
        public void presentarFrecuenciasDeConsumo(ComboBox combo, List<Frecuencia> frecuencias, string valueMember, string displayMember)
        {
            cargarCombo(combo, frecuencias, valueMember, displayMember);
        }
        /*
          * Método para presentar las actividades física en el combobox.
          * Recibe como parámetro la referencia del ComboBox, una lista de objetos ActividadFisica, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
          * El valor de retorno es void.
          * Llama al método cargarCombo.
         */
        public void presentarActividadFisica(ComboBox combo, List<ActividadFisica> actividades, string valueMember, string displayMember)
        {
            cargarCombo(combo, actividades, valueMember, displayMember);
        }
        /*
        * Método para presentar los grados de actividad física en el combobox.
        * Recibe como parámetro la referencia del ComboBox, una lista de objetos GradoActividadFisica, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
        * El valor de retorno es void.
        * Llama al método cargarCombo.
       */
        public void presentarGradosActividadFisica(ComboBox combo, List<GradoActividadFisica> grados, string valueMember, string displayMember)
        {
            cargarCombo(combo, grados, valueMember, displayMember);
        }
        /*
       * Método para presentar intensidades de la actividad física en el combobox.
       * Recibe como parámetro la referencia del ComboBox, una lista de objetos IntensidadActividadFisica, la cadena de caracteres valueMember y la cadena de caracteres displayMember.
       * El valor de retorno es void.
       * Llama al método cargarCombo.
      */
        public void presentarIntensidadesActividadFisica(ComboBox combo, List<IntensidadActividadFisica> intensidades, string valueMember, string displayMember)
        {
            cargarCombo(combo, intensidades, valueMember, displayMember);
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
            registrarHistoriaClinica();
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

        private void cboMedidaConsumeAlcohol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Medida medida= (Medida)cboMedidaConsumeAlcohol.SelectedItem;
            txtDescripcionMedida.Text = medida.descripcion;
        }

        private void txtDescripcionMedida_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboNombreComercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentarDatosDeLaEspecificacion();
        }
        public void presentarDatosDeLaEspecificacion()
        {
            int idMedicamento;
            int idNombreComercial;
            Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
            Int32.TryParse(cboNombreComercial.SelectedValue.ToString(), out idNombreComercial);

            presentarUnidadMedida(cboUnidadMedida, manejadorRegistrarDrogasLicitas.mostrarUnidadMedidaParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_unidadMedida", "nombre");

            presentarFormaAdministracion(cboFormaAdministración, manejadorRegistrarDrogasLicitas.mostrarFormasAdministracionParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_formaAdministracion", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento, manejadorRegistrarDrogasLicitas.mostrarPresentacionMedicamentoParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_presentacionMedicamento", "nombre");

            UnidadDeMedida unidad= (UnidadDeMedida) cboUnidadMedida.SelectedItem;
            PresentacionMedicamento presentacion= (PresentacionMedicamento) cboPresentacionMedicamento.SelectedItem;
            FormaAdministracion formaAdministracion= (FormaAdministracion) cboFormaAdministración.SelectedItem;

            cboConcentracion.DataSource = manejadorRegistrarDrogasLicitas.mostrarConcentracionMedicamento(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
            cboCantidadComprimidos.DataSource = manejadorRegistrarDrogasLicitas.mostrarCantidadComrpimidos(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
        }

        private void cboGradoActividadFisica_SelectedIndexChanged(object sender, EventArgs e)
        {
            GradoActividadFisica grado = (GradoActividadFisica)cboGradoActividadFisica.SelectedItem;
            txtDescripcionGradoActividadFisica.Text = grado.descripcion;
        }

        private void btnAgregarSintoma_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewSintomas();
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los sintomas.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewSintomas()
        {
            Sintoma sintoma = new Sintoma();

            string descripcionQueSiente = "No precisa";
            string caracterDolor = "No precisa";
            string haciaDondeIrradia = "No precisa";
            string fechaInicio = "No precisa";
            string cantidadTiempoDeComienzo = "No precisa";
            string cuandoComenzo = "No precisa";
            string comoModificaSintoma = "No precisa";
            string elementoModificacionSintoma = "No precisa";
            string observaciones = "No precisa";

            TipoSintoma nombreSintoma = (TipoSintoma)cboQueSienteElPaciente.SelectedItem;
            sintoma.id_tipoSintoma = nombreSintoma.id_tipoSintoma;

            ParteDelCuerpo parteCuerpo = (ParteDelCuerpo)cboParteCuerpo.SelectedItem;
            sintoma.id_parteCuerpo = parteCuerpo.id_parteCuerpo;
            
            if (string.IsNullOrEmpty(txtDescQueSientePaciente.Text) == false)
            {
                descripcionQueSiente = txtDescQueSientePaciente.Text;
            }
            sintoma.descripcion = descripcionQueSiente;

            if (rbSiDolor.Checked == true && cboCaracterDolor.SelectedIndex>0)
            {
                CaracterDelDolor caracter = (CaracterDelDolor)cboCaracterDolor.SelectedItem;
                caracterDolor = caracter.nombre;
                sintoma.id_caracterDolor = caracter.id_caracterDelDolor;
            }

            if (string.IsNullOrEmpty(txtHaciaDondeIrradia.Text) == false)
            {
                haciaDondeIrradia = txtHaciaDondeIrradia.Text;
            }
            sintoma.haciaDondeIrradia = haciaDondeIrradia;

            if (mtbFechaComienzoSintoma.MaskFull==true)
            {
                fechaInicio = mtbFechaComienzoSintoma.Text;
                sintoma.fechaInicioSintoma = Convert.ToDateTime(mtbFechaComienzoSintoma.Text);
            }
            
            if (string.IsNullOrEmpty(txtCantTiempoInicioSintoma.Text) == false && cboElementoTiempo.SelectedIndex>0)
            {
                ElementoDelTiempo elementoTiempo = (ElementoDelTiempo)cboElementoTiempo.SelectedItem;
                sintoma.cantidadTiempo = Convert.ToInt32(txtCantTiempoInicioSintoma.Text);
                sintoma.id_elementoTiempo = elementoTiempo.id_elementoDelTiempo;
            }
            if (cboCuandoComenzo.SelectedIndex > 0)
            {
                DescripcionDelTiempo descripcion= (DescripcionDelTiempo) cboCuandoComenzo.SelectedItem;
                cuandoComenzo = descripcion.nombre;
                sintoma.id_descripcionDelTiempo = descripcion.id_descripcionDelTiempo;
            }
            if (cboComoModificaSintoma.SelectedIndex > 0)
            {
                ModificacionSintoma modificacion = (ModificacionSintoma)cboComoModificaSintoma.SelectedItem;
                comoModificaSintoma = modificacion.nombre;
                sintoma.id_modificacionSintoma = modificacion.id_modificacionSintoma;
            }
            if (cboElementoModificacion.SelectedIndex > 0)
            {
                ElementoDeModificacion elementoModificacion = (ElementoDeModificacion)cboElementoModificacion.SelectedItem;
                elementoModificacionSintoma = elementoModificacion.nombre;
                sintoma.id_elementoModificacion = elementoModificacion.id_elementoDeModificacion;
            }
            if (string.IsNullOrEmpty(txtObservaciones.Text) == false)
            {
                observaciones = txtObservaciones.Text;
            }
            sintoma.observaciones = observaciones;
            sintoma.fechaRegistro =Convert.ToDateTime(mtbFechaActual.Text);

            listaSintomas.Add(sintoma);

            dgvListaSintoma.Rows.Add(nombreSintoma.nombre,descripcionQueSiente,parteCuerpo.nombre,caracterDolor,haciaDondeIrradia,fechaInicio,cantidadTiempoDeComienzo,cuandoComenzo,comoModificaSintoma,elementoModificacionSintoma,observaciones);
            
            
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Antecedentes Mórbidos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAntecedentesMorbidos()
        {
            if (rbPresentaAntecedentesMorbidos.Checked == true)
            {
                AntecedenteMorbido antecedenteMorbido = new AntecedenteMorbido();
                if (listaAntecedentesMorbidos == null)
                    listaAntecedentesMorbidos = new List<AntecedenteMorbido>();

                string tipoAntecedente = "No precisa";
                string nombreDelTipoDeAntecedente = "No precisa";
                string tratamiento = "No precisa";
                string evolución = "No precisa";
                string tiempo = "No precisa";

                antecedenteMorbido.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);

                if (cboTipoAntecedenteMorbido.SelectedIndex > -1)
                {
                    TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
                    tipoAntecedente = tipo.nombre;
                    antecedenteMorbido.id_tipoAntecedenteMorbido = tipo.id_tipoAntecedenteMorbido;
                    switch (tipo.nombre)
                    {
                        case "Enfermedad":
                            Enfermedad enfermedadSeleccionada = (Enfermedad)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                            nombreDelTipoDeAntecedente = enfermedadSeleccionada.nombre;
                            antecedenteMorbido.id_enfermedad = enfermedadSeleccionada.id_enfermedad;
                            break;
                        case "Operación":
                            Operacion operacionSeleccionada = (Operacion)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                            nombreDelTipoDeAntecedente = operacionSeleccionada.nombre;
                            antecedenteMorbido.id_operacion = operacionSeleccionada.id_operacion;
                            break;
                        case "Traumatismo":
                            Traumatismo traumatismoSeleccionado = (Traumatismo)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                            nombreDelTipoDeAntecedente = traumatismoSeleccionado.nombre;
                            antecedenteMorbido.id_traumatismo = traumatismoSeleccionado.id_traumatismo;
                            break;
                        default:
                            break;
                    }
                }

                if (string.IsNullOrEmpty(txtTratamientoAntecedenteMorbido.Text) == false)
                {
                    tratamiento = txtTratamientoAntecedenteMorbido.Text;
                }
                antecedenteMorbido.tratamiento = tratamiento;

                if (string.IsNullOrEmpty(txtEvoluciónAntecedenteMorbido.Text) == false)
                {
                    evolución = txtEvoluciónAntecedenteMorbido.Text;
                }
                antecedenteMorbido.evolución = evolución;

                if (string.IsNullOrEmpty(txtCantTiempoAntecedenteMorbido.Text) == false)
                {
                    ElementoDelTiempo componente = (ElementoDelTiempo)cboTiempoOcurridoAntMorbido.SelectedItem;
                    tiempo = txtCantTiempoAntecedenteMorbido.Text + " " + componente.nombre;
                    antecedenteMorbido.id_elementoTiempo = componente.id_elementoDelTiempo;
                    antecedenteMorbido.cantidadTiempo = Convert.ToInt32(txtCantTiempoAntecedenteMorbido.Text);
                }

                listaAntecedentesMorbidos.Add(antecedenteMorbido);
                dgvAntecedentesMorbidos.Rows.Add(tipoAntecedente, nombreDelTipoDeAntecedente, tratamiento, evolución, tiempo);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Antecedentes Patológicos Familiares.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAntecedentesPatologicosFamiliares()
        {
            if (cboFamiliar.SelectedIndex > 0)
            {
                AntecedenteFamiliar antecedente = new AntecedenteFamiliar();
                if (listaAntecedentesFamiliares == null)
                    listaAntecedentesFamiliares = new List<AntecedenteFamiliar>();

                string nombreFamiliar = "No precisa";
                string viveFamiliar = "No precisa";
                string enfermedades = "";
                string otraEnfermedad = "No precisa";
                string causaMuerte = "No precisa";
                string descripcionOtraEnfermedad = "No precisa";
                string observaciones = "No precisa";
                
                Familiar familiar = (Familiar)cboFamiliar.SelectedItem;
                nombreFamiliar = familiar.nombre;
                antecedente.id_familiar = familiar.id_familiar;

                if (rbSiViveFamiliar.Checked == true)
                {
                    viveFamiliar = "Si";
                }
                else
                {
                    viveFamiliar = "No";
                }
                antecedente.familiarVive = viveFamiliar;

                if (chbAsma.Checked == true)
                {
                    enfermedades = "Asma"; 
                }
                if (chbDiabetes.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Diabetes";
                }
                if (chbHipertensión.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Hipertensión";
                }
                if (chbAnemias.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Anemias";  
                }
                if (chbTuberculosis.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Tuberculosis";
                }
                if (chbLepra.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Lepra"; 
                }
                if (chbHepatitis.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Hepatitis";
                }
                if (chbParasitismo.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Parasitismo"; 
                }
                if (chbTranstornosNutricionales.Checked == true)
                {
                    if (string.IsNullOrEmpty(enfermedades) == false)
                    {
                        enfermedades += ", ";
                    }
                    enfermedades += "Trastornos nutricionales";
                }
                if (string.IsNullOrEmpty(enfermedades) == true)
                {
                    enfermedades = "No precisa";
                }
                antecedente.enfermedades = enfermedades;

                if (rbSiOtraEnfermedad.Checked == true)
                {
                    otraEnfermedad = "Si";
                }
                else
                {
                    otraEnfermedad = "No";
                }
                if (string.IsNullOrEmpty(txtDescripcionOtraEnfermedad.Text) == false)
                {
                    descripcionOtraEnfermedad = txtDescripcionOtraEnfermedad.Text;    
                }
                antecedente.descripcionOtrasEnfermedades = descripcionOtraEnfermedad;

                if (string.IsNullOrEmpty(txtCausaMuerte.Text) == false)
                {
                    causaMuerte = txtCausaMuerte.Text;
                }
                antecedente.causaMuerte = causaMuerte;

                if (string.IsNullOrEmpty(txtObservacionesAntecedentesPatologicosFamiliares.Text) == false)
                {
                    observaciones = txtObservacionesAntecedentesPatologicosFamiliares.Text;
                }
                antecedente.observaciones = observaciones;
                antecedente.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                listaAntecedentesFamiliares.Add(antecedente);
                dgvAntecedentesPatologicosFamiliares.Rows.Add(nombreFamiliar, viveFamiliar, enfermedades, otraEnfermedad, descripcionOtraEnfermedad, causaMuerte, observaciones);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Alimentos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaAlimentos()
        {
            
            if (rbSiAlergicoAlimentos.Checked == true && cboAlimentos.SelectedIndex > 0 )
            {   
                if(listaAlergiasAlimento==null)
                listaAlergiasAlimento = new List<AlergiaAlimento>();

                AlergiaAlimento alergia = new AlergiaAlimento();

                string alergiaAlimento = "";
                string alimento = "";
                string efectos = "No precisa";

                if (rbSiAlergicoAlimentos.Checked == true)
                {
                    alergiaAlimento = "Si";
                }
                else
                {
                    alergiaAlimento = "No";
                }
                Alimento alimentoSeleccionado = (Alimento)cboAlimentos.SelectedItem;
                alimento = alimentoSeleccionado.nombre;
                

                if (string.IsNullOrEmpty(txtEfectosAlergiaAlimentos.Text) == false)
                {
                    efectos = txtEfectosAlergiaAlimentos.Text;
                }

                alergia.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                alergia.id_alimento = alimentoSeleccionado.id_alimento;
                alergia.efectos = efectos;

                listaAlergiasAlimento.Add(alergia);
                dgvAlergiasAlimentos.Rows.Add(alergiaAlimento, alimento, efectos);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a las sustancias del ambiente que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaSustanciaAmbiente()
        {
            if (rbSiAlergiaSustanciaAmbiente.Checked == true && cboSustanciaAmbiente.SelectedIndex > 0)
            {
                AlergiaSustanciaAmbiente alergia = new AlergiaSustanciaAmbiente();

                if (listaAlergiasSustanciaAmbiente == null)
                    listaAlergiasSustanciaAmbiente = new List<AlergiaSustanciaAmbiente>();

                string alergiaSustanciaAmbiente = "";
                string sustancia = "";
                string efectos = "No precisa";

                if (rbSiAlergiaSustanciaAmbiente.Checked == true)
                {
                    alergiaSustanciaAmbiente = "Si";
                }
                else
                {
                    alergiaSustanciaAmbiente = "No";
                }
                SustaciaAmbiente sustanciaAmbiente = (SustaciaAmbiente)cboSustanciaAmbiente.SelectedItem;
                sustancia = sustanciaAmbiente.nombre;

                if (string.IsNullOrEmpty(txtEfectosAlergiaSustanciaAmbiente.Text) == false)
                {
                    efectos = txtEfectosAlergiaSustanciaAmbiente.Text;
                }
                alergia.fechaRegistro =Convert.ToDateTime(mtbFechaActual.Text);
                alergia.id_sustanciaAmbiente = sustanciaAmbiente.id_sustanciaAmbiente;
                alergia.efectos = efectos;

                listaAlergiasSustanciaAmbiente.Add(alergia);
                dgvAlergiasSustanciaAmbiente.Rows.Add(alergiaSustanciaAmbiente, sustancia, efectos);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a las sustancias o meteriales que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaSustanciaContactoPiel()
        {
            if (rbSiAlergiaSustanciaContactoPiel.Checked == true && cboSustanciaContactoPiel.SelectedIndex > 0)
            {
                AlergiaSustanciaContactoPiel alergia = new AlergiaSustanciaContactoPiel();

                if (listaAlergiaSustanciaContactoPiel == null)
                    listaAlergiaSustanciaContactoPiel = new List<AlergiaSustanciaContactoPiel>();

                string alergiaSustanciaContactoPiel = "";
                string sustancia = "";
                string efectos = "No precisa";

                alergiaSustanciaContactoPiel = "Si";
                
            
                SustanciaContactoPiel sustanciaContactoPiel = (SustanciaContactoPiel)cboSustanciaContactoPiel.SelectedItem;
                sustancia = sustanciaContactoPiel.nombre;

                if (string.IsNullOrEmpty(txtEfectosAlergiaSustanciaContactoPiel.Text) == false)
                {
                    efectos = txtEfectosAlergiaSustanciaContactoPiel.Text;
                }
                alergia.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                alergia.id_sustanciaContactoPiel = sustanciaContactoPiel.id_sustanciaContactoPiel;
                alergia.efectos = efectos;

                listaAlergiaSustanciaContactoPiel.Add(alergia);
                dgvAlergiasSustanciasContactoPiel.Rows.Add(alergiaSustanciaContactoPiel, sustancia, efectos);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los insectos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaInsectos()
        {
            if (rbSiAlergiaInsecto.Checked == true && cboInsectos.SelectedIndex > 0)
            {
                AlergiaInsecto alergia = new AlergiaInsecto();

                if (listaAlergiaInsectos == null)
                    listaAlergiaInsectos = new List<AlergiaInsecto>();

                string alergiaInsectos = "";
                string insecto = "";
                string efectos = "No precisa";

                if (rbSiAlergiaInsecto.Checked == true)
                {
                    alergiaInsectos = "Si";
                }
                else
                {
                    alergiaInsectos = "No";
                }
                Insecto insectoSeleccionado = (Insecto)cboInsectos.SelectedItem;
                insecto = insectoSeleccionado.nombre;

                if (string.IsNullOrEmpty(txtEfectosAlergiaInsecto.Text) == false)
                {
                    efectos = txtEfectosAlergiaInsecto.Text;
                }

                alergia.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                alergia.id_insecto = insectoSeleccionado.id_insecto;
                alergia.efectos = efectos;

                listaAlergiaInsectos.Add(alergia);
                dgvAlergiasInsectos.Rows.Add(alergiaInsectos, insecto, efectos);
            }
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a medicamentos que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaMedicamentos()
        {
            if (rbSiAlergiaMedicamento.Checked == true && cboMedicamentosAlergia.SelectedIndex > 0)
            {
                AlergiaMedicamento alergia = new AlergiaMedicamento();

                if (listaAlergiaMedicamento == null)
                    listaAlergiaMedicamento = new List<AlergiaMedicamento>();

                string alergiaMedicamento = "";
                string medicamento = "";
                string efectos = "No precisa";

                if (rbSiAlergiaMedicamento.Checked == true)
                {
                    alergiaMedicamento = "Si";
                }
                else
                {
                    alergiaMedicamento = "No";
                }
                MedicamentoAlergia medicamentoSeleccionado = (MedicamentoAlergia)cboMedicamentosAlergia.SelectedItem;
                medicamento = medicamentoSeleccionado.nombre;

                if (string.IsNullOrEmpty(txtEfectosAlergiasMedicamentos.Text) == false)
                {
                    efectos = txtEfectosAlergiasMedicamentos.Text;
                }
                alergia.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                alergia.id_MedicamentoAlergia = medicamentoSeleccionado.idMedicamentoAlergia;
                alergia.efectos = efectos;

                listaAlergiaMedicamento.Add(alergia);
                dgvAlergiasMedicamentos.Rows.Add(alergiaMedicamento, medicamento, efectos);
            }
        }
        /*
       * Método para cargar filas al DatagridView correspondiente a los hábitos de tabaquismo.
       * No recibe valores por parámetro.
       * El valor de retorno es void.
      */
        public void cargarDatosDataGridViewHabitoTabaquismo()
        {
            string fuma = "";
            string cantidad = "No precisa";
            string elemento = "No precisa";
            string componente = "No precisa";
            string añosFumando = "No precisa";
            string dejoFumar = "No precisa";
            string cantTiempoDejoFumar = "No precisa";
            string descripcionTiempoFumaba = "No precisa";
            string elementoFumaba = "No precisa";
            string componenteTiempoFumaba = "No precisa";
            string cantidadFumaba = "No precisa";

            if (listaHabitosTabaquismo == null)
                listaHabitosTabaquismo = new List<HabitoTabaquismo>();

            HabitoTabaquismo habitoTabaquismo = new HabitoTabaquismo();
            DejoDeFumar dejoDeFumar = null;

            if (rbSiFuma.Checked == true)
            {
                fuma = "Si";
                
                if (string.IsNullOrEmpty(txtCantidadQueFuma.Text) == false)
                {
                    ElementoQueFuma elementoSeleccionado = (ElementoQueFuma)cboElementoQueFuma.SelectedItem;
                    elemento = elementoSeleccionado.nombre;

                    habitoTabaquismo.cantidad = Convert.ToInt32(txtCantidadQueFuma.Text);
                    habitoTabaquismo.id_elementoQueFuma = elementoSeleccionado.id_elementoQueFuma;

                    ComponenteDelTiempo componenteSeleccionado = (ComponenteDelTiempo)cboComponenteTiempoFuma.SelectedItem;
                    componente = componenteSeleccionado.nombre;

                    habitoTabaquismo.id_componenteTiempo = componenteSeleccionado.id_componenteTiempo;

                    cantidad = txtCantidadQueFuma.Text + " " + elemento + " X " + " " + componente;
                }

                if (string.IsNullOrEmpty(txtCantidadAñosFumando.Text) == false)
                {
                    añosFumando = txtCantidadAñosFumando.Text;
                    habitoTabaquismo.añosFumando = Convert.ToInt32(txtCantidadAñosFumando.Text);
                }
                habitoTabaquismo.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
            }
            else
            {
                fuma = "No";

                if (cbDejoFumar.Checked == true)
                {
                    dejoFumar = "Si";
                    dejoDeFumar = new DejoDeFumar();

                    if (string.IsNullOrEmpty(txtCantiTiempoDejoFumar.Text) == false)
                    {
                        ElementoDelTiempo elementoSeleccionado = (ElementoDelTiempo)cboElementosDelTiempoFumaba.SelectedItem;
                        dejoDeFumar.cantidad = Convert.ToInt32(txtCantiTiempoDejoFumar.Text);
                        dejoDeFumar.id_elementoTiempo = elementoSeleccionado.id_elementoDelTiempo;
                        cantTiempoDejoFumar = txtCantiTiempoDejoFumar.Text + " " + elementoSeleccionado.nombre;
                    }

                    if (cboDescripcionDelTiempoFumaba.SelectedIndex > 0)
                    {
                        DescripcionDelTiempo descripcion = (DescripcionDelTiempo)cboDescripcionDelTiempoFumaba.SelectedItem;
                        dejoDeFumar.id_descripcionTiempo = descripcion.id_descripcionDelTiempo;
                        descripcionTiempoFumaba = descripcion.nombre;
                    }

                    if (string.IsNullOrEmpty(txtCantidadFumaba.Text) == false)
                    {
                        ElementoQueFuma elementoSeleccionadoFumaba = (ElementoQueFuma)cboElementoFumaba.SelectedItem;
                        elementoFumaba = elementoSeleccionadoFumaba.nombre;
                        dejoDeFumar.cantidadFumaba = Convert.ToInt32(txtCantidadFumaba.Text);
                        dejoDeFumar.id_elementoQueFuma = elementoSeleccionadoFumaba.id_elementoQueFuma;

                        ComponenteDelTiempo componenteSeleccionadoFumaba = (ComponenteDelTiempo)cboComponenteTiempoFumaba.SelectedItem;
                        componenteTiempoFumaba = componenteSeleccionadoFumaba.nombre;
                        dejoDeFumar.id_componenteTiempo = componenteSeleccionadoFumaba.id_componenteTiempo;

                        cantidadFumaba = txtCantidadFumaba.Text + " " + elementoFumaba + " X " + " " + componenteSeleccionadoFumaba.nombre;
                    }
                    habitoTabaquismo.dejoDeFumar = dejoDeFumar;
                }
                habitoTabaquismo.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
            }

            listaHabitosTabaquismo.Add(habitoTabaquismo);
            dgvHabitosFumar.Rows.Add(fuma, cantidad, añosFumando, dejoFumar, cantTiempoDejoFumar, descripcionTiempoFumaba, cantidadFumaba);
        }
        /*
      * Método para cargar filas al DatagridView correspondiente a los hábitos de alcoholismo.
      * No recibe valores por parámetro.
      * El valor de retorno es void.
     */
        public void cargarDatosDataGridViewHabitoAlcoholismo()
        {
            if (rbSiConsumeAlcohol.Checked == true)
            {
                if (listaHabitosAlcoholismo == null)
                    listaHabitosAlcoholismo = new List<HabitoAlcoholismo>();

                HabitoAlcoholismo habitoAlcoholismo = new HabitoAlcoholismo();

                string consumeAlcohol = "No";
                string bebida = "";
                string estimacionCantidad = "";
                string descripcion = "";
                if (rbSiConsumeAlcohol.Checked == true)
                {
                    consumeAlcohol = "Si";
                }

                TipoBebida bebidaSeleccionada = (TipoBebida)cboTipoBebida.SelectedItem;
                bebida = bebidaSeleccionada.nombre;
                habitoAlcoholismo.id_tipoBebida = bebidaSeleccionada.id_tipoBebida;

                if (string.IsNullOrEmpty(txtCantidadConsume.Text) == false)
                {
                    Medida medidaSeleccionada = (Medida)cboMedidaConsumeAlcohol.SelectedItem;
                    habitoAlcoholismo.id_medida = medidaSeleccionada.id_medida;
                    ComponenteDelTiempo componenteSeleccionado = (ComponenteDelTiempo)cboComponenteTiempoAlcoholismo.SelectedItem;
                    habitoAlcoholismo.id_componenteTiempo = componenteSeleccionado.id_componenteTiempo;
                    habitoAlcoholismo.cantidad = Convert.ToInt32(txtCantidadConsume.Text);

                    estimacionCantidad = txtCantidadConsume.Text + " " + medidaSeleccionada.nombre + " X " + componenteSeleccionado.nombre;
                }

                if (string.IsNullOrEmpty(txtDescripcionMedida.Text) == false)
                {
                    descripcion = txtDescripcionMedida.Text;
                }
                habitoAlcoholismo.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                listaHabitosAlcoholismo.Add(habitoAlcoholismo);
                dgvHabitosAlcoholismo.Rows.Add(consumeAlcohol, bebida, estimacionCantidad, descripcion);
            }
        }
        /*
      * Método para cargar filas al DatagridView correspondiente a los hábitos de drogas Ilicitas.
      * No recibe valores por parámetro.
      * El valor de retorno es void.
     */
        public void cargarDatosDataGridViewHabitosDrogasIlicitas()
        {
            if (rbSiConsumeDrogas.Checked == true)
            {
                if (listaHabitosDrogasIlicitas == null)
                    listaHabitosDrogasIlicitas = new List<HabitoDrogasIlicitas>();

                HabitoDrogasIlicitas habitoDrogasIlicitas = new HabitoDrogasIlicitas();

                string consumeDrogas = "No";
                string sustancia = "";
                string tiempoConsumiento = "";


                if (rbSiConsumeDrogas.Checked == true)
                {
                    consumeDrogas = "Si";
                }
                SustanciaDrogaIlicita sustanciaSelecciona = (SustanciaDrogaIlicita)cboSustanciaDrogaIlicita.SelectedItem;
                habitoDrogasIlicitas.id_sustancia = sustanciaSelecciona.id_sustancia;
                sustancia = sustanciaSelecciona.nombre;

                if (string.IsNullOrEmpty(txtCantidadTiempoConsumiendo.Text) == false)
                {
                    ElementoDelTiempo elementoSeleccionado = (ElementoDelTiempo)cboElementoTiempoDrogasIlicitas.SelectedItem;
                    habitoDrogasIlicitas.tiempoConsumiendo = Convert.ToInt32(txtCantidadTiempoConsumiendo.Text);
                    habitoDrogasIlicitas.id_elementoTiempo = elementoSeleccionado.id_elementoDelTiempo;

                    tiempoConsumiento = txtCantidadTiempoConsumiendo.Text + " " + elementoSeleccionado.nombre;
                }
                habitoDrogasIlicitas.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);

                listaHabitosDrogasIlicitas.Add(habitoDrogasIlicitas);
                dgvHabitosDrogasIlicitas.Rows.Add(consumeDrogas, sustancia, tiempoConsumiento);
            }
        }
        /*
         * Método para crear y cargar los objetos HabitoActividadFisica a una lista.
         * No recibe valores por parámetro.
         * El valor de retorno es void.
        */
        public void cargarDatosHabitosDrogasLicitas()
        {
            if (rbSiConsumeMedicamentos.Checked == true)
            {
                if (listaHabitosMedicamentos == null)
                    listaHabitosMedicamentos = new List<HabitoMedicamento>();

                HabitoMedicamento habitoMedicamento = new HabitoMedicamento();
                ProgramacionMedicamento programacion= new ProgramacionMedicamento();

                EspecificacionMedicamento especificacion = new EspecificacionMedicamento();

                Medicamento medicamentoSeleccionado = (Medicamento)cboNombreGenerico.SelectedItem;
                especificacion.id_medicamento_fk = medicamentoSeleccionado.id_medicamento;

                NombreComercial nombreComercialSeleccionado = (NombreComercial)cboNombreComercial.SelectedItem;
                especificacion.id_nombreComercial = nombreComercialSeleccionado.id_nombreComercial;

                int concentracionSeleccionada = (int)cboConcentracion.SelectedItem;
                especificacion.concentracion = concentracionSeleccionada;
                UnidadDeMedida unidadMedidaSeleccionada = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
                especificacion.id_unidadMedida_fk = unidadMedidaSeleccionada.id_unidadMedida;

                PresentacionMedicamento presentacionSeleccionada = (PresentacionMedicamento)cboPresentacionMedicamento.SelectedItem;
                especificacion.id_presentacionMedicamento = presentacionSeleccionada.id_presentacionMedicamento;

                FormaAdministracion formaAdmSeleccionada = (FormaAdministracion)cboFormaAdministración.SelectedItem;
                especificacion.id_formaAdministracion = formaAdmSeleccionada.id_formaAdministracion;

                int cantidadComprimidosSeleccionada = (int)cboCantidadComprimidos.SelectedItem;
                especificacion.cantidadComprimidos = cantidadComprimidosSeleccionada;

                manejadorRegistrarDrogasLicitas.buscarIdEspecificacion(especificacion);

                programacion.id_especificacionMedicamento = especificacion.id_especificacion;
                programacion.id_medicamento = especificacion.id_medicamento_fk;

                Frecuencia frecuenciaSeleccionada = (Frecuencia)cboFrecuencia.SelectedItem;
                programacion.id_frecuencia = frecuenciaSeleccionada.id_Frecuencia;
                

                if(cboMomentoDia1.SelectedIndex > 0)
                {
                    MomentoDia momentoDia1 = (MomentoDia)cboMomentoDia1.SelectedItem;
                    programacion.id_momentoDia1 = momentoDia1.idMomentoDia;

                    programacion.cantidad1Numerador = Convert.ToInt32(txtNumeradorCantidad1.Text);

                    if (string.IsNullOrEmpty(txtDenominadorCantidad1.Text) == false)
                    {
                        programacion.cantidad1Denominador = Convert.ToInt32(txtDenominadorCantidad1.Text);
                    }

                    PresentacionMedicamento presentacionSeleccionada1 = (PresentacionMedicamento)cboPresentacionMedicamento1.SelectedItem;
                    programacion.id_presentacionMedicamento1 = presentacionSeleccionada1.id_presentacionMedicamento;

                    programacion.hora1 = Convert.ToDateTime(mtbHora1.Text);
                }

                if (cboMomentoDia2.SelectedIndex > 0)
                {
                    MomentoDia momentoDia2 = (MomentoDia)cboMomentoDia2.SelectedItem;
                    programacion.id_momentoDia2 = momentoDia2.idMomentoDia;

                    programacion.cantidad2Numerador = Convert.ToInt32(txtNumeradorCantidad2.Text);

                    if (string.IsNullOrEmpty(txtDenominadorCantidad2.Text) == false)
                    {
                        programacion.cantidad2Denominador = Convert.ToInt32(txtDenominadorCantidad2.Text);
                    }

                    PresentacionMedicamento presentacionSeleccionada2 = (PresentacionMedicamento)cboPresentacionMedicamento2.SelectedItem;
                    programacion.id_presentacionMedicamento2 = presentacionSeleccionada2.id_presentacionMedicamento;

                    programacion.hora2 = Convert.ToDateTime(mtbHora2.Text);
                }

                if (cboMomentoDia3.SelectedIndex > 0)
                {
                    MomentoDia momentoDia3 = (MomentoDia)cboMomentoDia3.SelectedItem;
                    programacion.id_momentoDia3 = momentoDia3.idMomentoDia;

                    programacion.cantidad3Numerador = Convert.ToInt32(txtNumeradorCantidad3.Text);

                    if (string.IsNullOrEmpty(txtDenominadorCantidad3.Text) == false)
                        programacion.cantidad3Denominador = Convert.ToInt32(txtDenominadorCantidad3.Text);
                    

                    PresentacionMedicamento presentacionSeleccionada3 = (PresentacionMedicamento)cboPresentacionMedicamento3.SelectedItem;
                    programacion.id_presentacionMedicamento3 = presentacionSeleccionada3.id_presentacionMedicamento;

                    programacion.hora3 = Convert.ToDateTime(mtbHora3.Text);
                }

                if (string.IsNullOrEmpty(txtMotivoConsumo.Text) == false)
                    programacion.motivoConsumo = txtMotivoConsumo.Text;

                if (rbMedicamentoActual.Checked == true)
                {
                    programacion.cantidadTiempoConsumo = Convert.ToInt32(txtCantidadTiempoConsumoMedicamento.Text);
                    ElementoDelTiempo elementoTiempoConsumo = (ElementoDelTiempo)cboElementoTiempoMedicamento.SelectedItem;
                    programacion.id_elementoTiempo1 = elementoTiempoConsumo.id_elementoDelTiempo;

                    programacion.id_estado = manejadorRegistrarDrogasLicitas.buscarIdEstado("Activa");
                }

                if (rbMedicamentoAnterior.Checked == true)
                {
                    programacion.motivoCancelacion = txtMotivoCancelacion.Text;

                    programacion.cantidadCancelacion =Convert.ToInt32(txtCantTiempoCancelacionMedicamento.Text);
                    ElementoDelTiempo elementoTiempoCancelacion = (ElementoDelTiempo)cboElementoTiempoCancelacionMedicamento.SelectedItem;
                    programacion.id_elementoTiempo2 = elementoTiempoCancelacion.id_elementoDelTiempo;

                }
                if (chbAutomedicado.Checked == true)
                {
                    programacion.automedicamento = "Si";
                }
                else
                {
                    programacion.automedicamento = "No";
                }
                habitoMedicamento.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);
                habitoMedicamento.programacion = programacion;
                listaHabitosMedicamentos.Add(habitoMedicamento);
            }
        }
        /*
      * Método para cargar filas al DatagridView correspondiente a los hábitos de Actividad física.
      * No recibe valores por parámetro.
      * El valor de retorno es void.
     */
        public void cargarDatosDataGridViewHabitosActividadFisica()
        {
            string actividad = "";
            string grado = "";
            string intensidad = "";
            string descripcion = "";

            if (rbSiActividadFisica.Checked == true)
            {   
                
                if (cboActividadFisica.SelectedIndex > -1)
                {
                    if (listaHabitosActividadFisica == null)
                        listaHabitosActividadFisica = new List<HabitoActividadFisica>();

                    HabitoActividadFisica habito = new HabitoActividadFisica();

                    ActividadFisica actividadFisica = (ActividadFisica)cboActividadFisica.SelectedItem;
                    actividad = actividadFisica.nombre;
                    habito.id_actividadFisica = actividadFisica.id_actividadFisica;

                    GradoActividadFisica gradoActividad = (GradoActividadFisica)cboGradoActividadFisica.SelectedItem;
                    grado = gradoActividad.nombre;
                    habito.id_gradoActividadFisica = gradoActividad.id_gradoActividadFisica;

                    IntensidadActividadFisica intensidadActividad = (IntensidadActividadFisica)cboIntensidad.SelectedItem;
                    intensidad = intensidadActividad.nombre;
                    habito.id_intensidad = intensidadActividad.id_intensidad;

                    if (string.IsNullOrEmpty(txtDescripcionGradoActividadFisica.Text) == false)
                    {
                        descripcion = txtDescripcionGradoActividadFisica.Text;
                    }
                    habito.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);

                    listaHabitosActividadFisica.Add(habito);
                    dgvHabitosActividadFisica.Rows.Add(actividad, grado, descripcion, intensidad);
                }
            }

        }
        /*
         * Método para cargar las columnas del DatagridView correspondiente a los sintomas.
         * No recibe valores por parámetro.
         * El valor de retorno es void.
        */
        public void agregarColumnasSintomas()
        {
            string[] nombreColumnasSintomas = new string[11] { "Que siente el paciente", "Descripción de lo que siente","Parte del cuerpo donde siente la molestia","Caracter del dolor",
                                                              "Hacia donde se irradia","Fecha de inicio síntoma","Cantidad de tiempo desde que comenzó","Descripción tiempo","Como se modifica", "Elemento que lo modifica","Observaciones"};

            for (int i = 0; i < nombreColumnasSintomas.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasSintomas[i];
                columna.Width = 200;
                dgvListaSintoma.Columns.Add(columna);
            }
        }
        /*
        * Método para cargar las columnas de los DatagridView correspondiente a los antecedentes mórbidos y patológicos familiares.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void agregarColumnaAntecedentes()
        {
            string[] nombreColumnasAntecedenteMorbido = new string[5] { "Tipo", "Nombre", "Tratamiento", "Evolución", "Cuando ocurrio" };


            for (int i = 0; i < nombreColumnasAntecedenteMorbido.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAntecedenteMorbido[i];
                columna.Width = 200;
                dgvAntecedentesMorbidos.Columns.Add(columna);
            }

            string[] nombreColumnasAntecedentesPatologicosFamiliares = new string[7] { "Familiar", "Vive Si/No", "Enfermedades que padece o padeció", "Otras enfermedades","Descripción", "Causa de muerte", "Observaciones" };


            for (int i = 0; i < nombreColumnasAntecedentesPatologicosFamiliares.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAntecedentesPatologicosFamiliares[i];
                columna.Width = 200;
                dgvAntecedentesPatologicosFamiliares.Columns.Add(columna);
            }
        }
        /*
        * Método para cargar las columnas de los DatagridView correspondiente a las alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void agregarColumnaAlergias()
        {
            string[] nombreColumnasAlergiasAlimento = new string[3] { "Es alergico Si/No", "Alimento", "Efectos"};


            for (int i = 0; i < nombreColumnasAlergiasAlimento.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAlergiasAlimento[i];
                columna.Width = 200;
                dgvAlergiasAlimentos.Columns.Add(columna);
            }

            string[] nombreColumnasAlergiasSustanciaDelAmbiente= new string[3] { "Es alergico Si/No", "Sustancia", "Efectos" };

            for (int i = 0; i < nombreColumnasAlergiasSustanciaDelAmbiente.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAlergiasAlimento[i];
                columna.Width = 200;
                dgvAlergiasSustanciaAmbiente.Columns.Add(columna);
            }

            string[] nombreColumnasAlergiasSustanciaMaterialesContactoPiel = new string[3] { "Es alergico Si/No", "Sustancia o material", "Efectos" };

            for (int i = 0; i < nombreColumnasAlergiasSustanciaMaterialesContactoPiel.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAlergiasSustanciaMaterialesContactoPiel[i];
                columna.Width = 200;
                dgvAlergiasSustanciasContactoPiel.Columns.Add(columna);
            }

            string[] nombreColumnasAlergiasPicaduraInsectos = new string[3] { "Es alergico Si/No", "Insecto", "Efectos" };

            for (int i = 0; i < nombreColumnasAlergiasPicaduraInsectos.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAlergiasPicaduraInsectos[i];
                columna.Width = 200;
                dgvAlergiasInsectos.Columns.Add(columna);
            }

            string[] nombreColumnasAlergiasMedicamentos = new string[3] { "Es alergico Si/No", "Medicamento", "Efectos" };

            for (int i = 0; i < nombreColumnasAlergiasMedicamentos.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAlergiasMedicamentos[i];
                columna.Width = 200;
                dgvAlergiasMedicamentos.Columns.Add(columna);
            }


        }
        /*
         * Método para cargar las columnas de los DatagridView correspondiente a los hábitos.
         * No recibe valores por parámetro.
         * El valor de retorno es void.
        */
        public void agregarColumnaHabitos()
        {
            string[] nombreColumnasHabitoTabaquismo = new string[7] { "Fuma Si/No", "Cantidad", "Años fumando", "Dejó de fumar Si/No","Cantidad de tiempo que dejó de fumar",
                                                                      "Descripción del tiempo", "Cantidad que fumaba"};

            for (int i = 0; i < nombreColumnasHabitoTabaquismo.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasHabitoTabaquismo[i];
                columna.Width = 200;
                dgvHabitosFumar.Columns.Add(columna);
            }

            string[] nombreColumnasHabitoBebidasAlcoholicas = new string[4] { "Consume alcohol Si/No", "Bebida", "Estimación de la cantidad de alcohol","Descripcion de la medida" };

            for (int i = 0; i < nombreColumnasHabitoBebidasAlcoholicas.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasHabitoBebidasAlcoholicas[i];
                columna.Width = 200;
                dgvHabitosAlcoholismo.Columns.Add(columna);
            }

            string[] nombreColumnasHabitoDrogasIlicitas = new string[3] { "Consume drogas Si/No", "Sustancia","Cantidad de tiempo consumiento"};

            for (int i = 0; i < nombreColumnasHabitoDrogasIlicitas.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasHabitoDrogasIlicitas[i];
                columna.Width = 200;
                dgvHabitosDrogasIlicitas.Columns.Add(columna);
            }
            string[] nombreColumnasHabitoActividadFisica = new string[4] { "Deporte o actividad", "Grado de la actividad ","Descripción", "Intensidad"};

            for (int i = 0; i < nombreColumnasHabitoActividadFisica.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasHabitoActividadFisica[i];
                columna.Width = 200;
                dgvHabitosActividadFisica.Columns.Add(columna);
            }
        }
        /*
         * Método para registrar la creación de la historia clínica del paciente. Registrar enfermedad actual, antecedentes y hábitos.
         * No recibe valores por parámetro.
         * El valor de retorno es void.
        */
        public void registrarHistoriaClinica()
        {
            HistoriaClinica hc = new HistoriaClinica();

            int idHc = 0;

            hc.idtipodoc_paciente = paciente.id_tipoDoc;
            hc.nrodoc_paciente = paciente.nroDoc;
            hc.idtipodoc = paciente.id_tipodoc_medico;
            hc.nrodoc = paciente.nrodoc_medico;

            hc.nro_hc = manejadorRegistrarHC.calcularSiguienteNroHc();

            hc.fecha =Convert.ToDateTime(mtbFechaActual.Text);
            hc.hora = Convert.ToDateTime(mtbHoraActual.Text);
            hc.fechaInicioAtencion = Convert.ToDateTime(mtbFechaActual.Text);

            hc.motivoConsulta = txtmotivoConsulta.Text;

            idHc=manejadorRegistrarHC.registrarHistoriaClinica(hc);

            registrarEnfermedadActual(idHc);

            registrarAntecedentesMorbidos(idHc);

            registrarAntecedentesGinecoObstetricos(idHc);

            registrarAntecedentesPatologicosFamiliares(idHc);

            registrarAntecedentesPatológicosPersonales(idHc);

            registrarAlergiaAlimentos(idHc);

            registrarAlergiaSustanciaAmbiente(idHc);

            registrarAlergiaSustanciasContactoPiel(idHc);

            registrarAlergiaInsectos(idHc);

            registrarAlergiaMedicamentos(idHc);

            registrarHabitosTabaquismo(idHc);

            registrarHabitosAlcoholismo(idHc);

            registrarHabitoDrogasIlicitas(idHc);

            registrarHabitosDrogasLicitas(idHc);

            registrarHabitosActividadFisica(idHc);

            manejadorRegistrarHC.asignarHCAPaciente(paciente.id_tipoDoc, paciente.nroDoc, idHc);

            MessageBox.Show("La historia clínica se registró correctamente!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);



           
        }
        private void registrarEnfermedadActual(int idHc)
        {   
            if(listaSintomas!=null && listaSintomas.Count>0)
            manejadorRegistrarEnfermedadActual.registrarSintomas(listaSintomas, idHc);
        }
        private void registrarAntecedentesMorbidos(int idHc)
        {
            if (listaAntecedentesMorbidos!=null && listaAntecedentesMorbidos.Count > 0)
            manejadorRegistrarAntecedentesMorbidos.registrarAntecedentesMorbidos(listaAntecedentesMorbidos,idHc);
        }
        /*
         * Método para crear los objetos AntecedenteGinecoObstetrico y Aborto.
         * No recibe parámetros.
         * El valor de retorno es void.
         */
        private void AgregarAntecedenteGinecoObstetricos()
        {
            string problemasEmbarazo = "No precisa";
            if (rbSiTieneEmbarazos.Checked == true)
            {
                antecedenteGinecoObtetrico = new AntecedenteGinecoObstetrico();

                antecedenteGinecoObtetrico.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);

                if(string.IsNullOrEmpty(txtCantidadEmbarazos.Text)==false)
                antecedenteGinecoObtetrico.cantidadEmbarazos = Convert.ToInt32(txtCantidadEmbarazos.Text);
                

                if(string.IsNullOrEmpty(txtCantidadEmbarazosPrematuro.Text)==false)
                antecedenteGinecoObtetrico.cantidadEmbarazosPrematuros = Convert.ToInt32(txtCantidadEmbarazosPrematuro.Text);

                if (cboTipoPartoPretermino.SelectedIndex > 0)
                {
                    TipoParto tipoParto1Seleccionado = (TipoParto)cboTipoPartoPretermino.SelectedItem;
                    antecedenteGinecoObtetrico.id_tipoPartoPrematuro = tipoParto1Seleccionado.id_tipoParto;
                }

                if(string.IsNullOrEmpty(txtCantidadEmbarazosATermino.Text)==false)
                antecedenteGinecoObtetrico.cantidadEmbarazosATermino = Convert.ToInt32(txtCantidadEmbarazosATermino.Text);

                if (cboTipoPartoATermino.SelectedIndex > 0)
                {
                    TipoParto tipoParto2Seleccionado = (TipoParto)cboTipoPartoATermino.SelectedItem;
                    antecedenteGinecoObtetrico.id_tipoPartoATermino = tipoParto2Seleccionado.id_tipoParto;
                }

                if(string.IsNullOrEmpty(txtCantidadEmbarazosPosTermino.Text)==false)
                antecedenteGinecoObtetrico.cantidadEmbarazosPosTermino = Convert.ToInt32(txtCantidadEmbarazosPosTermino.Text);

                if (cboTipoPartoPostermino.SelectedIndex > 0)
                {
                    TipoParto tipoParto3Seleccionado = (TipoParto)cboTipoPartoPostermino.SelectedItem;
                    antecedenteGinecoObtetrico.id_tipoPartoPosTermino = tipoParto3Seleccionado.id_tipoParto;
                }

                if (rbSiTieneAbortos.Checked == true)
                {
                    Aborto aborto = new Aborto();

                    aborto.cantidadTotal = Convert.ToInt32(txtCantidadAbortos.Text);

                    if (string.IsNullOrEmpty(txtCantidadTipoAborto1.Text) == false)
                    {
                        aborto.cantidadAbortoTipo1 = Convert.ToInt32(txtCantidadTipoAborto1.Text);
                        TipoAborto tipo1Seleccionado = (TipoAborto)cboTipoAborto1.SelectedItem;
                        aborto.id_tipoAborto1 = tipo1Seleccionado.id_tipoAborto;
                    }
                    if (string.IsNullOrEmpty(txtCantidadTipoAborto2.Text) == false)
                    {
                        TipoAborto tipo2Seleccionado = (TipoAborto)cboTipoAborto2.SelectedItem;
                        aborto.id_tipoAborto2 = tipo2Seleccionado.id_tipoAborto;
                        aborto.cantidadAbortoTipo2 = Convert.ToInt32(txtCantidadTipoAborto2.Text);
                    }

                    aborto.nroHijosVivos = Convert.ToInt32(txtCantidadHijosVivos.Text);
                    
                    if(string.IsNullOrEmpty(txtProblemasEmbarazo.Text)==false)
                    aborto.problemasEmbarazo = txtProblemasEmbarazo.Text;

                    antecedenteGinecoObtetrico.aborto = aborto;
                }
            }
            else
            {
                if (rbSiTieneAbortos.Checked == true)
                {

                    antecedenteGinecoObtetrico = new AntecedenteGinecoObstetrico();
                    antecedenteGinecoObtetrico.fechaRegistro = Convert.ToDateTime(mtbFechaActual.Text);

                    Aborto aborto = new Aborto();

                    aborto.cantidadTotal = Convert.ToInt32(txtCantidadAbortos.Text);

                    aborto.cantidadAbortoTipo1 = Convert.ToInt32(txtCantidadTipoAborto1.Text);
                    TipoAborto tipo1Seleccionado = (TipoAborto)cboTipoAborto1.SelectedItem;
                    aborto.id_tipoAborto1 = tipo1Seleccionado.id_tipoAborto;

                    TipoAborto tipo2Seleccionado = (TipoAborto)cboTipoAborto2.SelectedItem;
                    aborto.id_tipoAborto2 = tipo2Seleccionado.id_tipoAborto;
                    aborto.cantidadAbortoTipo2 = Convert.ToInt32(txtCantidadTipoAborto2.Text);

                    aborto.nroHijosVivos = Convert.ToInt32(txtCantidadHijosVivos.Text);

                    if(string.IsNullOrEmpty( txtProblemasEmbarazo.Text)==false)
                        aborto.problemasEmbarazo = txtProblemasEmbarazo.Text;

                    antecedenteGinecoObtetrico.aborto = aborto;
                }
            }
           
            
        }
        /*
         * Método para registrar los antecedentes ginecoObstetricos y aborto.
         * Recibe como parámetro al idHc.
         * Llama método registrarAntecedentesGinecoObstetricos del manejador registrar antecedentes ginecoObstetricos.
         * El valor de retorno es void.
         */
        private void registrarAntecedentesGinecoObstetricos(int idHc)
        {
            if (antecedenteGinecoObtetrico != null)
            {
                antecedenteGinecoObtetrico.id_hc = idHc;
                manejadorRegistrarAntecedentesGinecoObstetricos.registrarAntecedentesGinecoObstetricos(antecedenteGinecoObtetrico);
            }
        }
        /*
        * Método para registrar los antecedentes patologicos familiares.
        * Recibe como parámetro al idHc.
        * Llama método registrarAntecedentesFamiliares del manejador antecedentes patologicos familiares.
        * El valor de retorno es void.
        */
        private void registrarAntecedentesPatologicosFamiliares(int idHc)
        {
            if (listaAntecedentesFamiliares!=null && listaAntecedentesFamiliares.Count > 0)
            {
                manejadorRegistrarAntecedentesPatologicosFamiliares.registrarAntecedentesFamiliares(listaAntecedentesFamiliares, idHc);
            }
        }
        public void registrarAntecedentesPatológicosPersonales(int idHc)
        {
            
            string listaEnfermedades = "";
            string descripcionOtrasEnfermedades = "No precisa";
            List<String> enfermedades = new List<String>();

            if (cbTosFerina.Checked == true)
                enfermedades.Add(" Tos Ferina");
            if (cbNeumonia.Checked == true)
                 enfermedades.Add(" Neumonía");
            if (cbBronconeumonia.Checked == true)
                 enfermedades.Add(" Bronconeumonía ");
            if (cbAmigdalitis.Checked == true)
                 enfermedades.Add(" Amigdalitis ");
            if (cbFiebreTifoidea.Checked == true)
                 enfermedades.Add(" Fiebre Tifoidea ");
            if (cbDiarrea.Checked == true)
                 enfermedades.Add(" Diarrea ");
            if (cbBronquitis.Checked == true)
                enfermedades.Add(" Bronquitis ");
            if (cbSinusitis.Checked == true)
                 enfermedades.Add(" Sinusitis ");
            if (cbDifteria.Checked == true)
                 enfermedades.Add(" Difteria ");
            if (cbParoditis.Checked == true)
                 enfermedades.Add(" Parotiditis ");
            if (cbVaricela.Checked == true)
                 enfermedades.Add(" Varicela ");
            if (cbITS.Checked == true)
                 enfermedades.Add(" ITS ");
            if (cbDengue.Checked == true)
                 enfermedades.Add(" Dengue ");
            if (cbRubeola.Checked == true)
                 enfermedades.Add(" Rubeola ");
            if (cbSarampion.Checked == true)
                enfermedades.Add(" Sarampión ");
            if (cbCefalea.Checked == true)
                 enfermedades.Add( " Cefalea ");
            if (cbArtrosis.Checked == true)
                 enfermedades.Add( " Artrosis ");
            if (cbGastritis.Checked == true)
                 enfermedades.Add( " Gastritis ");
            if (cbAsmaBronquial.Checked == true)
                 enfermedades.Add(" Asma Bronquial ");
            if (cbFiebreReumatica.Checked == true)
                 enfermedades.Add( " Fiebre Reumática ");
            if (cbInfartoAgudoMiocardio.Checked == true)
                 enfermedades.Add(" Infarto Agudo de Miocardio ");
            if (cbArtritis.Checked == true)
                 enfermedades.Add( " Artritis ");

            if (string.IsNullOrEmpty(txtDescOtrasEnfermedadesPP.Text) == false)
            {
                descripcionOtrasEnfermedades = txtDescOtrasEnfermedadesPP.Text;
            }

            manejadorRegistrarAntecedentesPatologicosPersonales = new ManejadorRegistrarAntecedentesPatologicosPersonales();

            DateTime fechaRegistro= Convert.ToDateTime(mtbFechaActual.Text);

            manejadorRegistrarAntecedentesPatologicosPersonales.registrarAntecedentesPatologicosPersonales(fechaRegistro, enfermedades, descripcionOtrasEnfermedades, idHc);
        }
        /*
        * Método para registrar las alergias a los alimentos.
        * Recibe como parámetro al idHc.
        * Llama método registrarAntecedentesAlergiaAlimento del manejador registrarAlergias.
        * El valor de retorno es void.
        */
        private void registrarAlergiaAlimentos(int idHc)
        {
            if (listaAlergiasAlimento != null && listaAlergiasAlimento.Count > 0)
            {
                manejadorRegistrarAlergias.registrarAlergiasAlimento(listaAlergiasAlimento, idHc);
            }
        }
        /*
       * Método para registrar las alergias a las sustancias del ambiente.
       * Recibe como parámetro al idHc.
       * Llama método registrarAlergiaSustanciaDelAmbiente del manejador registrarAlergias.
       * El valor de retorno es void.
       */
        private void registrarAlergiaSustanciaAmbiente(int idHc)
        {
            if (listaAlergiasSustanciaAmbiente != null && listaAlergiasSustanciaAmbiente.Count > 0)
            {
                manejadorRegistrarAlergias.registrarAlergiaSustanciaDelAmbiente(listaAlergiasSustanciaAmbiente, idHc);
            }
        }
        /*
         * Método para registrar las alergias a las sustancias o materiales.
         * Recibe como parámetro al idHc.
         * Llama método registrarAlergiaSustanciaDelAmbiente del manejador registrarAlergias.
         * El valor de retorno es void.
        */
        private void registrarAlergiaSustanciasContactoPiel(int idHc)
        {
            if (listaAlergiaSustanciaContactoPiel != null && listaAlergiaSustanciaContactoPiel.Count > 0)
            {
                manejadorRegistrarAlergias.registrarAlergiaSustanciaContactoPiel(listaAlergiaSustanciaContactoPiel, idHc);
            }
        }
        /*
        * Método para registrar las alergias a insectos.
        * Recibe como parámetro al idHc.
        * Llama método registrarAlergiaInsectos del manejador registrarAlergias.
        * El valor de retorno es void.
       */
        private void registrarAlergiaInsectos(int idHc)
        {
            if (listaAlergiaInsectos != null && listaAlergiaInsectos.Count > 0)
            {
                manejadorRegistrarAlergias.registrarAlergiaInsectos(listaAlergiaInsectos, idHc);
            }
        }
        /*
       * Método para registrar las alergias a medicamentos.
       * Recibe como parámetro al idHc.
       * Llama método registrarAlergiaMedicamento del manejador registrarAlergias.
       * El valor de retorno es void.
        */
        private void registrarAlergiaMedicamentos(int idHc)
        {
            if (listaAlergiaMedicamento != null && listaAlergiaMedicamento.Count > 0)
            {
                manejadorRegistrarAlergias.registrarAlergiaMedicamento(listaAlergiaMedicamento, idHc);
            }
        }
        private void registrarHabitosTabaquismo(int idHc)
        {
            if (listaHabitosTabaquismo != null && listaHabitosTabaquismo.Count > 0)
                manejadorRegistrarHabitosTabaquismo.registrarHabitosTabaquismo(listaHabitosTabaquismo, idHc);
        }
        private void registrarHabitosAlcoholismo(int idHc)
        {
            if (listaHabitosAlcoholismo != null && listaHabitosAlcoholismo.Count > 0)
                manejadorRegistrarHabitosAlcoholismo.registrarHabitosAlcoholismo(listaHabitosAlcoholismo, idHc);
        }
        private void registrarHabitoDrogasIlicitas(int idHc)
        {
            if (listaHabitosDrogasIlicitas != null && listaHabitosDrogasIlicitas.Count > 0)
                manejadorRegistrarHabitosDrogasIlicitas.registrarHabitoDrogasIlicitas(listaHabitosDrogasIlicitas, idHc);
        }
        private void registrarHabitosDrogasLicitas(int idHc)
        {
            if (listaHabitosMedicamentos != null && listaHabitosMedicamentos.Count > 0)
                manejadorRegistrarDrogasLicitas.registrarHabitosDrogasLicitas(listaHabitosMedicamentos, idHc); 
        }
        private void registrarHabitosActividadFisica(int idHc)
        {
            if (listaHabitosActividadFisica != null && listaHabitosActividadFisica.Count > 0)
                manejadorRegistrarHabitosActividadFisica.registrarHabitosActividadFisica(listaHabitosActividadFisica, idHc);
        }
        private void btnAgregarAntecedenteMorbido_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAntecedentesMorbidos();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAntecedentesPatologicosFamiliares();
        }

        private void btnAgregarAlergiaAlimentos_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAlergiaAlimentos();
        }

        private void btnAgregarSustanciaContactoPiel_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAlergiaSustanciaContactoPiel();
        }

        private void btnAgregarSustanciaAmbiente_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAlergiaSustanciaAmbiente();
        }

        private void btnAgregarAlergiaInsecto_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAlergiaInsectos();
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewAlergiaMedicamentos();
        }

        private void btnAgregarHabitoTabaquismo_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewHabitoTabaquismo();
        }

        private void txtCantidadConsume_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarHabitoDrogaIlicita_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewHabitosDrogasIlicitas();
        }

        private void btnAgregarHabitoActividadFisica_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewHabitosActividadFisica();
        }

        private void btnAgregarAntecedenteGinecoObstetrico_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarAntecedenteGinecoObstetrico_Click_1(object sender, EventArgs e)
        {
            AgregarAntecedenteGinecoObstetricos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarHabitoAlcoholismo_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewHabitoAlcoholismo();
        }

        private void btnAgregarHabitoMedicamento_Click(object sender, EventArgs e)
        {
            cargarDatosHabitosDrogasLicitas();
        }

        private void cboPresentacionMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAñadirSustanciaAmbiente_Click(object sender, EventArgs e)
        {

        }

        private void rbNoPresentaAntecedentesMorbidos_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbPresentaAntecedentesMorbidos_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void cboUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcentracion.SelectedIndex < 0)
            {
                int idMedicamento;
                int idNombreComercial;
                Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
                Int32.TryParse(cboNombreComercial.SelectedValue.ToString(), out idNombreComercial);

                UnidadDeMedida unidad = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
                PresentacionMedicamento presentacion = (PresentacionMedicamento)cboPresentacionMedicamento.SelectedItem;
                FormaAdministracion formaAdministracion = (FormaAdministracion)cboFormaAdministración.SelectedItem;
                
                if (unidad != null && presentacion != null && formaAdministracion != null)
                {
                    cboConcentracion.DataSource = manejadorRegistrarDrogasLicitas.mostrarConcentracionMedicamento(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
                    cboCantidadComprimidos.DataSource = manejadorRegistrarDrogasLicitas.mostrarCantidadComrpimidos(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
                }
            }

        }

        private void cboFormaAdministración_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcentracion.SelectedIndex < 0)
            {
                int idMedicamento;
                int idNombreComercial;
                Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
                Int32.TryParse(cboNombreComercial.SelectedValue.ToString(), out idNombreComercial);

                UnidadDeMedida unidad = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
                PresentacionMedicamento presentacion = (PresentacionMedicamento)cboPresentacionMedicamento.SelectedItem;
                FormaAdministracion formaAdministracion = (FormaAdministracion)cboFormaAdministración.SelectedItem;

                if (unidad != null && presentacion != null && formaAdministracion != null)
                {
                    cboConcentracion.DataSource = manejadorRegistrarDrogasLicitas.mostrarConcentracionMedicamento(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
                    cboCantidadComprimidos.DataSource = manejadorRegistrarDrogasLicitas.mostrarCantidadComrpimidos(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
                }
            }
        }

        private void cboNombrePorTipoAntecedenteMorbido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }


       
    }
}
