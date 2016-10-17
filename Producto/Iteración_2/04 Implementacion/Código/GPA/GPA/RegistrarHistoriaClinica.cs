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
        ManejadorRegistrarHabitosActividadFisica manejadorRegistrarHabitosActividadFisica;

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
            manejadorRegistrarHabitosActividadFisica = new ManejadorRegistrarHabitosActividadFisica();

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

            presentarSustanciasDrogasIlicitas(cboSustanciaDrogaIlicita, manajadorRegistrarHabitosDrogasIlicitas.mostrarSustanciasDrogasIlicitas(), "id_sustancia", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoDrogasIlicitas, manajadorRegistrarHabitosDrogasIlicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarMedicamento(cboNombreGenerico, manejadorRegistrarDrogasLicitas.mostrarNombresMedicamento(),"id_medicamento", "nombreGenerico");

            presentarMomentosDelDia(cboMomentoDia1, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarMomentosDelDia(cboMomentoDia2, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarMomentosDelDia(cboMomentoDia3, manejadorRegistrarDrogasLicitas.mostrarMomentosDelDia(), "idMomentoDia", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento1, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento2, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarPresentacionMedicamento(cboPresentacionMedicamento3, manejadorRegistrarDrogasLicitas.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoMedicamento, manejadorRegistrarDrogasLicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");

            presentarElementosDelTiempo(cboElementoTiempoCancelacionMedicamento, manejadorRegistrarDrogasLicitas.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");
            rbMedicamentoActual.Checked = true;

            presentarFrecuenciasDeConsumo(cboFrecuencia, manejadorRegistrarDrogasLicitas.mostrarFrecuencias(), "id_frecuencia", "nombre");

            presentarActividadFisica(cboActividadFisica, manejadorRegistrarHabitosActividadFisica.mostrarActividadFisica(), "id_actividadFisica", "nombre");

            presentarGradosActividadFisica(cboGradoActividadFisica, manejadorRegistrarHabitosActividadFisica.mostrarGradosActividadFisica(), "id_gradoActividadFisica", "nombre");

            presentarIntensidadesActividadFisica(cboIntensidad, manejadorRegistrarHabitosActividadFisica.mostrarIntensidadActividadFisica(), "id_intensidad", "nombre");

            agregarColumnasSintomas();
            agregarColumnaAntecedentes();
            agregarColumnaAlergias();
            agregarColumnaHabitos();
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
            string caracterDolor = "No precisa";
            string haciaDondeIrradia = "No precisa";
            string fechaInicio = "No precisa";
            string cantidadTiempoDeComienzo = "No precisa";
            string cuandoComenzo = "No precisa";
            string comoModificaSintoma = "No precisa";
            string elementoModificacionSintoma = "No precisa";
            string observaciones = "No precisa";

            TipoSintoma nombreSintoma= (TipoSintoma) cboQueSienteElPaciente.SelectedItem;
            ParteDelCuerpo parteCuerpo= (ParteDelCuerpo) cboParteCuerpo.SelectedItem;

            if (rbSiDolor.Checked == true)
            {
                CaracterDelDolor caracter = (CaracterDelDolor)cboCaracterDolor.SelectedItem;
                caracterDolor = caracter.nombre;
            }
            if (string.IsNullOrEmpty(txtHaciaDondeIrradia.Text) == false)
            {
                haciaDondeIrradia = txtHaciaDondeIrradia.Text;
            }
            if (string.IsNullOrEmpty(mtbFechaComienzoSintoma.ToString()) == false)
            {
                fechaInicio = mtbFechaComienzoSintoma.Text;
            }
            if (string.IsNullOrEmpty(txtCantTiempoInicioSintoma.Text) == false)
            {
                ElementoDelTiempo elementoTiempo = (ElementoDelTiempo)cboElementoTiempo.SelectedItem;
                cantidadTiempoDeComienzo = txtCantTiempoInicioSintoma.Text + " " +elementoTiempo.nombre;
            }
            if (cboCuandoComenzo.SelectedIndex > -1)
            {
                DescripcionDelTiempo descripcion= (DescripcionDelTiempo) cboCuandoComenzo.SelectedItem;
                cuandoComenzo = descripcion.nombre;
            }
            if (cboComoModificaSintoma.SelectedIndex > -1)
            {
                ModificacionSintoma modificacion = (ModificacionSintoma)cboComoModificaSintoma.SelectedItem;
                comoModificaSintoma = modificacion.nombre;
            }
            if (cboElementoModificacion.SelectedIndex > -1)
            {
                ElementoDeModificacion elementoModificacion = (ElementoDeModificacion)cboElementoModificacion.SelectedItem;
                elementoModificacionSintoma = elementoModificacion.nombre;
            }
            if (string.IsNullOrEmpty(txtObservaciones.Text) == false)
            {
                observaciones = txtObservaciones.Text;
            }
            dgvListaSintoma.Rows.Add(nombreSintoma.nombre,txtDescQueSientePaciente.Text,parteCuerpo.nombre,caracterDolor,haciaDondeIrradia,fechaInicio,cantidadTiempoDeComienzo,cuandoComenzo,comoModificaSintoma,elementoModificacionSintoma,observaciones);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Antecedentes Mórbidos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAntecedentesMorbidos()
        {
            string tipoAntecedente = "No precisa";
            string nombreDelTipoDeAntecedente = "No precisa";
            string tratamiento = "No precisa";
            string evolución = "No precisa";
            string tiempo = "No precisa";
            

            if (cboTipoAntecedenteMorbido.SelectedIndex > -1)
            {
                TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
                tipoAntecedente = tipo.nombre;
                switch (tipo.nombre)
                {
                    case "Enfermedad":
                        Enfermedad enfermedadSeleccionada = (Enfermedad)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                        nombreDelTipoDeAntecedente = enfermedadSeleccionada.nombre;
                        break;
                    case "Operación":
                        Operacion operacionSeleccionada = (Operacion)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                        nombreDelTipoDeAntecedente = operacionSeleccionada.nombre;
                        break;
                    case "Traumatismo":
                        Traumatismo traumatismoSeleccionado = (Traumatismo)cboNombrePorTipoAntecedenteMorbido.SelectedItem;
                        nombreDelTipoDeAntecedente = traumatismoSeleccionado.nombre;
                        break;
                    default:
                        break;
                }
            }

            if (string.IsNullOrEmpty(txtTratamientoAntecedenteMorbido.Text) == false)
            {
                tratamiento = txtTratamientoAntecedenteMorbido.Text;
            }
            if (string.IsNullOrEmpty(txtEvoluciónAntecedenteMorbido.Text) == false)
            {
                tratamiento = txtEvoluciónAntecedenteMorbido.Text;
            }
            if (string.IsNullOrEmpty(txtCantTiempoAntecedenteMorbido.Text) == false)
            {
                ElementoDelTiempo componente= (ElementoDelTiempo) cboTiempoOcurridoAntMorbido.SelectedItem;
                tiempo = txtCantTiempoAntecedenteMorbido.Text + " " + componente.nombre;
            }
            dgvAntecedentesMorbidos.Rows.Add(tipoAntecedente,nombreDelTipoDeAntecedente, tratamiento, evolución, tiempo);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Antecedentes Patológicos Familiares.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAntecedentesPatologicosFamiliares()
        {
            string nombreFamiliar = "No precisa";
            string viveFamiliar = "No precisa";
            string enfermedades="";
            string otraEnfermedad = "No precisa";
            string causaMuerte = "No precisa";
            string descripcionOtraEnfermedad="No precisa";
            string observaciones = "No precisa";

            List<string> listaEnfermedades = new List<string>();

            if (cboFamiliar.SelectedIndex > -1)
            {
                Familiar familiar = (Familiar)cboFamiliar.SelectedItem;
                nombreFamiliar = familiar.nombre;
            }

            if (rbSiViveFamiliar.Checked == true)
            {
                viveFamiliar = "Si";
            }
            else
            {
                viveFamiliar = "No";
            }

            if (chbAsma.Checked==true)
            {
                enfermedades = "Asma";
                listaEnfermedades.Add("Asma");
            }
            if (chbDiabetes.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Diabetes";
                listaEnfermedades.Add("Diabetes");
            }
            if (chbHipertensión.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Hipertensión" ;
                listaEnfermedades.Add("Hipertensión");
            }
            if (chbAnemias.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Anemias";
                listaEnfermedades.Add("Anemias");
            }
            if (chbTuberculosis.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Tuberculosis";
                listaEnfermedades.Add("Tuberculosis");
            }
            if (chbLepra.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Lepra";
                listaEnfermedades.Add("Lepra");
            }
            if (chbHepatitis.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Hepatitis";
                listaEnfermedades.Add("Hepatitis");
            }
            if (chbParasitismo.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Parasitismo";
                listaEnfermedades.Add("Parasitismo");
            }
            if (chbTranstornosNutricionales.Checked == true)
            {
                if (string.IsNullOrEmpty(enfermedades) == false)
                {
                    enfermedades += ", ";
                }
                enfermedades += "Trastornos nutricionales";
                listaEnfermedades.Add("Trastornos nutricionales");
            }

            if (string.IsNullOrEmpty(enfermedades) == true)
            {
                enfermedades = "No precisa";
            }
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
            if (string.IsNullOrEmpty(txtCausaMuerte.Text) == false)
            {
                causaMuerte = txtCausaMuerte.Text;
            }
            if (string.IsNullOrEmpty(txtObservacionesAntecedentesPatologicosFamiliares.Text) == false)
            {
                observaciones = txtObservacionesAntecedentesPatologicosFamiliares.Text;
            }
            dgvAntecedentesPatologicosFamiliares.Rows.Add(nombreFamiliar, viveFamiliar, enfermedades, otraEnfermedad, descripcionOtraEnfermedad,causaMuerte,observaciones);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los Alimentos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaAlimentos()
        {
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
            dgvAlergiasAlimentos.Rows.Add(alergiaAlimento, alimento, efectos);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a las sustancias del ambiente que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaSustanciaAmbiente()
        {
            string alergiaSustanciaAmbiente = "";
            string sustancia = "";
            string efectos = "No precisa";

            if (rbSiAlergicoAlimentos.Checked == true)
            {
                alergiaSustanciaAmbiente = "Si";
            }
            else
            {
                alergiaSustanciaAmbiente = "No";
            }
            SustaciaAmbiente sustanciaAmbiente = (SustaciaAmbiente)cboSustanciaAmbiente.SelectedItem;
            sustancia = sustanciaAmbiente.nombre;

            if (string.IsNullOrEmpty(txtEfectosAlergiaAlimentos.Text) == false)
            {
                efectos = txtEfectosAlergiaSustanciaAmbiente.Text;
            }
            dgvAlergiasSustanciaAmbiente.Rows.Add(alergiaSustanciaAmbiente, sustancia, efectos);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a las sustancias o meteriales que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaSustanciaContactoPiel()
        {
            string alergiaSustanciaContactoPiel = "";
            string sustancia = "";
            string efectos = "No precisa";

            if (rbSiAlergiaSustanciaContactoPiel.Checked == true)
            {
                alergiaSustanciaContactoPiel = "Si";
            }
            else
            {
                alergiaSustanciaContactoPiel = "No";
            }
            SustanciaContactoPiel sustanciaContactoPiel = (SustanciaContactoPiel)cboSustanciaContactoPiel.SelectedItem;
            sustancia = sustanciaContactoPiel.nombre;

            if (string.IsNullOrEmpty(txtEfectosAlergiaSustanciaContactoPiel.Text) == false)
            {
                efectos = txtEfectosAlergiaSustanciaContactoPiel.Text;
            }
            dgvAlergiasSustanciasContactoPiel.Rows.Add(alergiaSustanciaContactoPiel, sustancia, efectos);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a los insectos.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaInsectos()
        {
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
            dgvAlergiasInsectos.Rows.Add(alergiaInsectos, insecto, efectos);
        }
        /*
        * Método para cargar filas al DatagridView correspondiente a medicamentos que producen alergias.
        * No recibe valores por parámetro.
        * El valor de retorno es void.
       */
        public void cargarDatosDataGridViewAlergiaMedicamentos()
        {
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
            dgvAlergiasMedicamentos.Rows.Add(alergiaMedicamento, medicamento, efectos);
        }
        /*
       * Método para cargar filas al DatagridView correspondiente a los hábitos de tabaquismo.
       * No recibe valores por parámetro.
       * El valor de retorno es void.
      */
        public void cargarDatosDataGridViewHabitoTabaquismo()
        {
            string fuma = "";
            string cantidad = "";
            string elemento = "";
            string componente = "";
            string añosFumando = "No precisa";
            string dejoFumar = "No";
            string cantTiempoDejoFumar = "";
            string descripcionTiempoFumaba = "No precisa";
            string elementoFumaba = "";
            string componenteTiempoFumaba = "";
            string cantidadFumaba = "";
            if (rbSiFuma.Checked == true)
            {
                fuma = "Si";
            }
            else
            {
                fuma = "No";
            }
            if (string.IsNullOrEmpty(txtCantidadQueFuma.Text) == false)
            {
                ElementoQueFuma elementoSeleccionado = (ElementoQueFuma)cboElementoQueFuma.SelectedItem;
                elemento = elementoSeleccionado.nombre;

                ComponenteDelTiempo componenteSeleccionado = (ComponenteDelTiempo)cboComponenteTiempoFuma.SelectedItem;
                componente = componenteSeleccionado.nombre;

                cantidad = txtCantidadQueFuma.Text + " " + elemento + " X " + " " + componente;
            }

            if (string.IsNullOrEmpty(txtCantidadAñosFumando.Text) == false)
            {
                añosFumando = txtCantidadAñosFumando.Text;
            }
            if (cbDejoFumar.Checked == true)
            {
                dejoFumar = "Si";
            }

            if (string.IsNullOrEmpty(txtCantiTiempoDejoFumar.Text) == false)
            {
                ElementoDelTiempo elementoSeleccionado = (ElementoDelTiempo)cboElementoFumaba.SelectedItem;
                cantTiempoDejoFumar = txtCantiTiempoDejoFumar.Text + " " + elementoSeleccionado.nombre;
            }

            if (cboDescripcionDelTiempoFumaba.SelectedIndex > -1)
            {
                DescripcionDelTiempo descripcion=(DescripcionDelTiempo) cboDescripcionDelTiempoFumaba.SelectedItem;
                descripcionTiempoFumaba = descripcion.nombre;
            }

            if (string.IsNullOrEmpty(txtCantidadFumaba.Text) == false)
            {
                ElementoQueFuma elementoSeleccionadoFumaba = (ElementoQueFuma)cboElementoQueFuma.SelectedItem;
                elementoFumaba = elementoSeleccionadoFumaba.nombre;

                ComponenteDelTiempo componenteSeleccionadoFumaba = (ComponenteDelTiempo)cboComponenteTiempoFumaba.SelectedItem;
                componenteTiempoFumaba = componenteSeleccionadoFumaba.nombre;

                cantidadFumaba = txtCantidadFumaba.Text + " " + elementoFumaba + " X " + " " + componenteSeleccionadoFumaba;
            }
            dgvHabitosFumar.Rows.Add(fuma, cantidad, añosFumando,dejoFumar,cantTiempoDejoFumar,descripcionTiempoFumaba,cantidadFumaba);
        }
        /*
      * Método para cargar filas al DatagridView correspondiente a los hábitos de alcoholismo.
      * No recibe valores por parámetro.
      * El valor de retorno es void.
     */
        public void cargarDatosDataGridViewHabitoAlcoholismo()
        {
            string consumeAlcohol = "No";
            string bebida = "";
            string estimacionCantidad="";
            string descripcion = "";
            if (rbSiConsumeAlcohol.Checked == true)
            {
                consumeAlcohol = "Si";
            }

            TipoBebida bebidaSeleccionada = (TipoBebida)cboTipoBebida.SelectedItem;
            bebida = bebidaSeleccionada.nombre;

            if (string.IsNullOrEmpty(txtCantidadConsume.Text) == false)
            {
                Medida medidaSeleccionada = (Medida)cboMedidaConsumeAlcohol.SelectedItem;
                ComponenteDelTiempo componenteSeleccionado = (ComponenteDelTiempo)cboComponenteTiempoAlcoholismo.SelectedItem;

                estimacionCantidad = txtCantidadConsume.Text + " " + medidaSeleccionada.nombre + " " + componenteSeleccionado.nombre;
            }

            if (string.IsNullOrEmpty(txtDescripcionMedida.Text) == false)
            {
                descripcion = txtDescripcionMedida.Text;
            }

            dgvHabitosAlcoholismo.Rows.Add(consumeAlcohol, bebida, estimacionCantidad, descripcion);
        }
        /*
      * Método para cargar filas al DatagridView correspondiente a los hábitos de drogas Ilicitas.
      * No recibe valores por parámetro.
      * El valor de retorno es void.
     */
        public void cargarDatosDataGridViewHabitosDrogasIlicitas()
        {
            string consumeDrogas = "No";
            string sustancia = "";
            string tiempoConsumiento = "";
            string dejoConsumir = "No";
            string enTratamiento = "No";

            if (rbSiConsumeDrogas.Checked == true)
            {
                consumeDrogas = "Si";
            }

            SustanciaDrogaIlicita sustanciaSelecciona = (SustanciaDrogaIlicita)cboSustanciaDrogaIlicita.SelectedItem;
            sustancia = sustanciaSelecciona.nombre;

            if (string.IsNullOrEmpty(txtCantidadTiempoConsumiendo.Text) == false)
            {
                ElementoDelTiempo elementoSeleccionado = (ElementoDelTiempo)cboElementoTiempoDrogasIlicitas.SelectedItem;
                tiempoConsumiento = txtCantidadTiempoConsumiendo.Text + " " + elementoSeleccionado.nombre;
            }

            if (chbDejoConsumir.Checked == true)
            {
                dejoConsumir = "Si";
            }

            if (chbEnTratamiento.Checked == true)
            {
                enTratamiento = "Si";
            }

            dgvHabitosDrogasIlicitas.Rows.Add(consumeDrogas, sustancia, tiempoConsumiento, dejoConsumir);
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

            if (cboActividadFisica.SelectedIndex > -1)
            {
                ActividadFisica actividadFisica = (ActividadFisica)cboActividadFisica.SelectedItem;
                actividad = actividadFisica.nombre;

                GradoActividadFisica gradoActividad = (GradoActividadFisica)cboGradoActividadFisica.SelectedItem;
                grado = gradoActividad.nombre;

                IntensidadActividadFisica intensidadActividad = (IntensidadActividadFisica)cboIntensidad.SelectedItem;
                intensidad = intensidadActividad.nombre;

                if (string.IsNullOrEmpty(txtDescripcionGradoActividadFisica.Text) == false)
                {
                    descripcion = txtDescripcionGradoActividadFisica.Text;
                }

                dgvHabitosActividadFisica.Rows.Add(actividad, grado,descripcion,intensidad);
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

            string[] nombreColumnasHabitoDrogasIlicitas = new string[5] { "Consume drogas Si/No", "Sustancia", "Dejo de consumir Si/No", "En Tratamiento Si/No","Cantidad de tiempo consumiento"};

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

            hc.fecha =Convert.ToDateTime(mtbFechaActual);
            hc.hora = Convert.ToDateTime(mtbHoraActual);
            hc.fechaInicioAtencion = Convert.ToDateTime(mtbFechaActual);

            hc.motivoConsulta = txtmotivoConsulta.Text;

            idHc=manejadorRegistrarHC.registrarHistoriaClinica(hc);





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

    }
}
