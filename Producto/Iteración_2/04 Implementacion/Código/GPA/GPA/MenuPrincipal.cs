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
using LogicaNegocio;
using GPA.Reportes;
using DAO;
using System.Data.SqlClient;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportAppServer;
using System.Text.RegularExpressions;
namespace GPA
{
    public partial class MenuPrincipal : Form
    {
        public ProfesionaMedico medicoLogueado{set;get;}
        public Paciente pacienteSeleccionado{set;get;}
        public HistoriaClinica hc { set; get; }
        

        ManejadorConsultarPaciente manejadorConsultarPaciente;
        ManejadorRegistrarAtencionMedicaEnConsultorio manejadorRegistrarAtencionMedicaEnConsultorio;
        ManejadorConsultarHC manejadorConsultarHc;
        ManejadorRegistrarEnfermedadActual manejadorRegistrarEnfermedadActual;
        ManejadorRegistrarExamenGeneral manejadorRegistrarExamenGeneral;
        ManejadorModificarEstadoDiagnostico manejadorModificarEstadoDiagnostico;

        List<RazonamientoDiagnostico> listaDiagnosticos;
        List<EstudioDiagnosticoPorImagen> listaEstudios;
        List<Laboratorio> listaLaboratorio;
        List<PracticaComplementaria> listaPracticasComplementarias;
        List<Tratamiento> listaTratamiento;
        List<Temperatura> listaTemperaturas;
        List<Sintoma> listaSintoma;

        List<Laboratorio> listaLaboratorioConInforme;
        List<EstudioDiagnosticoPorImagen> listaEstudioDiagnosticoImagenConInforme;
        List<PracticaComplementaria> listaPracticasConInforme;
        List<Tratamiento> tratamientosACancelar;

        private Consulta consulta;
        private Boolean consultaGenerada;
        private ExamenGeneral examen;
        private List<SistemaLinfatico> listaTerritoriosExaminados;
        private Boolean medicionesAutomaticaConExamenGeneral { set; get; }
        public RazonamientoDiagnostico diagnosticoSeleccionado { set; get; }
        private int idDiagnosticoSeleccionado { set; get; }

        private RazonamientoDiagnostico razonamientoDiagnosticoExistente;
        private List<EvolucionDiagnostico> listaEvolucionDiagnostico;

        private Boolean cambioEstadoDiagnostico;
        private EstadoDiagnostico estadoInicial;

        private Boolean verGinecooptetricos=false;
        private Boolean verenfermedades=false;
        private Boolean verTraumatismos=false;
        private Boolean verOperaciones=false;
        private Boolean verAntecedentesFamiliares = false;
        private Boolean verAntecedentesPersonales = false;

        private Boolean verHabitosDrogaIlicita = false;
        private Boolean verHabitosTabaquismo = false;
        private Boolean verHabitosAlcoholismo = false;
        private Boolean verHabitosMedicamentos = false;
        private Boolean verHabitosActividadFisica = false;

        private Boolean existeDiagnosticoSeleccionado;
        public MenuPrincipal(ProfesionaMedico pmLogueado)
        {
            InitializeComponent();
            medicoLogueado=pmLogueado;
            manejadorConsultarPaciente = new ManejadorConsultarPaciente();
            manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();
            manejadorConsultarHc = null;
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
            manejadorRegistrarExamenGeneral = new ManejadorRegistrarExamenGeneral();
            medicionesAutomaticaConExamenGeneral = false;

            consulta = null;
            consultaGenerada = false;
            examen = null;
            listaTerritoriosExaminados = null;
            listaSintoma = null;
            listaTerritoriosExaminados = null;
            listaDiagnosticos = null;
            listaEstudios = null;
            listaLaboratorio = null;
            listaPracticasComplementarias=null;
            listaTratamiento = null;
            listaTemperaturas = null;

        }
        public MenuPrincipal()
        {
            InitializeComponent();
            

        }
        private void historiaClínicasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                CargarComboTipoDocumento();
                //dgvPacientesDelProfesionalLogueado.DataSource= manejadorConsultarPaciente.mostrarPacientesDeMedicoLogueado(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc);
                CargarDataGridPacientesDelProfesional();
                dgvPacientesDelProfesionalLogueado.Columns["id_tipoDoc_fk"].Visible = false;
                dgvPacientesDelProfesionalLogueado.Columns["Nombre"].Width = 200;
                dgvPacientesDelProfesionalLogueado.Columns["Apellido"].Width = 200;
                dgvPacientesDelProfesionalLogueado.Columns["Calle"].Width = 250;
                TextBoxSoloLectura(true);
                manejadorRegistrarAtencionMedicaEnConsultorio.registrarAtencionMedicaEnConsultorio(this);
                manejadorRegistrarExamenGeneral.RegistrarExamenGeneral(this);

         
                PresentarTipoSintomas();
                PresentarParteDelCuerpo();
                PresentarCaracterDolor();
                PresentarElementoTiempoEnfermedadActual();
                PresentarDescripcionTiempo();
                PresentarComoModificaSintoma();
                PresentarElementoModificacion();
                PresentarUbicacionGanglio();
                PresentarTamañosGanglio();
                PresentarAproximacionNúmericaDeTamaño();
                PresentarEscalaPulso();
                PresentarTiposDePulso();
                PresentarSitioMedicionTemperatura();
                PresentarConsistencia();
                PresentarTemperaturaPiel();
                presentarEstadosDiagnostico();
                PresentarEstudiosYAnalisis();

                agregarColumnasSistemaLinfatico();
                agregarColumnasExamenesARealizar();

                cambioEstadoDiagnostico = false;
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        private void PresentarTipoSintomas()
        {
            Utilidades.cargarCombo(cboQueSienteElPaciente, manejadorRegistrarEnfermedadActual.mostrarTiposSintomas(), "id_TipoSintoma", "nombre");
        }
        private void PresentarParteDelCuerpo()
        {
            try
            {
                Utilidades.cargarCombo(cboParteCuerpo, manejadorRegistrarEnfermedadActual.mostrarPartesDelCuerpoHumano(), "id_parteCuerpo", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void PresentarCaracterDolor()
        {
            Utilidades.cargarCombo(cboCaracterDolor, manejadorRegistrarEnfermedadActual.mostrarCaracterDelDolor(), "id_caracterDelDolor", "nombre");
        }
        private void PresentarElementoTiempoEnfermedadActual()
        {
            Utilidades.cargarCombo(cboElementoTiempo, manejadorRegistrarEnfermedadActual.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");
        }
        private void PresentarDescripcionTiempo()
        {
            Utilidades.cargarCombo(cboCuandoComenzo, manejadorRegistrarEnfermedadActual.mostrarDescripcionesDelTiempo(), "id_descripcionDelTiempo", "nombre");
        }
        private void PresentarComoModificaSintoma()
        {
            Utilidades.cargarCombo(cboComoModificaSintoma, manejadorRegistrarEnfermedadActual.mostrarModificacionesDelSintoma(), "id_modificacionSintoma", "nombre");
        }
        private void PresentarElementoModificacion()
        {
            Utilidades.cargarCombo(cboElementoModificacion, manejadorRegistrarEnfermedadActual.mostrarElementosDeModificacion(), "id_elementoDeModificacion", "nombre");
        }
        public void PresentarUbicacionGanglio()
        {
            try
            {
                Utilidades.cargarCombo(cboUbicacionGanglio, manejadorRegistrarExamenGeneral.MostrarUbicaciones(), "id_ubicacion", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarTamañosGanglio()
        {
            Utilidades.cargarCombo(cboTamañoGanglio, manejadorRegistrarExamenGeneral.mostrarTamañoGanglio(), "id_tamaño", "nombre");
        }
        public void PresentarConsistencia()
        {
            try
            {
                Utilidades.cargarCombo(cboConsistencia, manejadorRegistrarExamenGeneral.MostrarConsistencia(), "id_consistencia", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarTemperaturaPiel()
        {
            try
            {
                Utilidades.cargarCombo(cboTemperaturaPiel, manejadorRegistrarExamenGeneral.ObtenerTemperaturasPiel(), "id_temperatura", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarAproximacionNúmericaDeTamaño()
        {
           
            int nro = 0;
            cboAproximacionNumerica.Items.Add("--Seleccionar--");
            for (int i = 0; i < 10; i++)
            {
                nro++;
                cboAproximacionNumerica.Items.Add(nro);
            }
            cboAproximacionNumerica.SelectedIndex = 0;
        }
        public void PresentarEscalaPulso()
        {
            try
            {
                Utilidades.cargarCombo(cboPI1, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD1, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI2, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD2, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI3, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD3, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI4, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD4, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI5, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD5, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI6, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD6, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI7, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD7, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPI8, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
                Utilidades.cargarCombo(cboPD8, manejadorRegistrarExamenGeneral.MostrarEscalaPulso(), "id_escalaPulso", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarTiposDePulso()
        {
            Utilidades.cargarCombo(cboPulso1, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso2, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso3, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso4, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso5, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso6, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso7, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
            Utilidades.cargarCombo(cboPulso8, manejadorRegistrarExamenGeneral.mostrarPulsos(), "id_Pulso", "nombre");
        }
        public void presentarEstadosDiagnostico()
        {
            try
            {
                Utilidades.cargarCombo(cboEstadoDiagnostico, manejadorRegistrarExamenGeneral.obtenerEstadoDiagnostico(), "id_estadoDiagnostico", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarEstudiosYAnalisis()
        {
            try
            {
                Utilidades.cargarCombo(cboEstudioARealizar, manejadorRegistrarExamenGeneral.MostrarNombreEstudios(), "id_nombreEstudio", "nombre");
                Utilidades.cargarCombo(cboAnalisiLaboratorioARealizar, manejadorRegistrarExamenGeneral.MostrarAnalisisLaboratorio(), "id_analisisLaboratorio", "nombre");
                Utilidades.cargarCombo(cboPracticasComplementariasARealizar, manejadorRegistrarExamenGeneral.MostrarTipoPracticaComplementaria(), "id_tipoPractica", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void PresentarSitioMedicionTemperatura()
        {
            try
            {
                Utilidades.cargarCombo(cboSitioMedicion1, manejadorRegistrarExamenGeneral.mostrarSitioMedicionTemperatura(), "id_sitioMedicionTemperatura", "nombre");
                Utilidades.cargarCombo(cboSitioMedicion2, manejadorRegistrarExamenGeneral.mostrarSitioMedicionTemperatura(), "id_sitioMedicionTemperatura", "nombre");
                Utilidades.cargarCombo(cboSitioMedicion3, manejadorRegistrarExamenGeneral.mostrarSitioMedicionTemperatura(), "id_sitioMedicionTemperatura", "nombre");
                Utilidades.cargarCombo(cboSitioMedicion4, manejadorRegistrarExamenGeneral.mostrarSitioMedicionTemperatura(), "id_sitioMedicionTemperatura", "nombre");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void presentarFechaYHoraActual()
        {
            mtbFechaConsulta.Text = manejadorRegistrarAtencionMedicaEnConsultorio.mostrarFechaActual();
            mtbHoraConsulta.Text = manejadorRegistrarAtencionMedicaEnConsultorio.mostrarHoraActual();
            mtbFechaDiagnostico.Text = manejadorRegistrarAtencionMedicaEnConsultorio.mostrarFechaActual();
        }
        /*
         * Método para cargar el ComboBox del tipo de documento.
         * Llama al método mostrarTiposDocumentos del manejador consultar paciente.
         * No recibe parámetros.
         */
        public void CargarComboTipoDocumento()
        {
            try
            {
                if (medicoLogueado != null)
                {
                    cboTipoDocPaciente.DataSource = manejadorConsultarPaciente.mostrarTiposDocumentos();
                    cboTipoDocPaciente.ValueMember = "id_tipoDoc";
                    cboTipoDocPaciente.DisplayMember = "nombre";
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        private void CargarDataGridPacientesDelProfesional()
        {
            try
            {
                dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.mostrarPacientesDeMedicoLogueado(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc);
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }
        private void CrearHistoriaClínicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarPaciente rp = new RegistrarPaciente(medicoLogueado);
            rp.ShowDialog();
        }

        private void buscarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public void obtenerIdHC(int idHC)
        {
            pacienteSeleccionado.id_hc = idHC;
        }
        public void obtenerPaciente(Paciente paciente)
        {
            pacienteSeleccionado = paciente;
        }
        public Paciente getPacienteSeleccionado()
        {
            if (pacienteSeleccionado != null)
            {
                return pacienteSeleccionado;
            }
            else
            {
                return null;
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void consultarHistoriaClinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarBarrio rb = new RegistrarBarrio();
            rb.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEspecialidad re = new RegistrarEspecialidad();
            re.ShowDialog();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarLocalidad rl = new RegistrarLocalidad();
            rl.ShowDialog();
        }

        private void tiposDeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarTipoDeDocumento rtd = new RegistrarTipoDeDocumento();
            rtd.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
         * Métodos para buscar el paciente de un médico que recibirá atención médica.
         */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNroDocPaciente.Text) == false)
                {
                    dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.MostrarPacienteBuscadoDelProfesional(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc, (int)cboTipoDocPaciente.SelectedValue, Convert.ToInt64(txtNroDocPaciente.Text), txtNombreApellidoPaciente.Text);
                }
                else
                {
                    dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.MostrarPacienteBuscadoDelProfesional(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc, txtNombreApellidoPaciente.Text);
                }
            }
            catch(Exception ex)
            {
                Utilidades.MensajeError(ex);
            }
        }

        private void btnSeleccionaPaciente_Click(object sender, EventArgs e)
        {
            hc = null;
            presentarPaciente();
            inicializar();
            Utilidades.limpiarLosControles(tabControl2);
            Utilidades.limpiarLosControles(tabPage4);

            MessageBox.Show("Paciente seleccionado correctamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /*
         * Método para tomar el tipo y número de documento del paciente seleccionado del datagridview, obtener el objeto correspondiente al paciente y llamar al método para mostrar los datos en el formulario.
         * Llama al método cargarDatosPacienteSeleccionado.
         * El valor de retorno es void.
         */
        public void presentarPaciente()
        {
            //int tipoDocPaciente = (int)dgvPacientesDelProfesionalLogueado.CurrentRow.Cells[4].Value;
            //long nroDocPaciente = Convert.ToInt64(dgvPacientesDelProfesionalLogueado.CurrentRow.Cells[3].Value);

            int tipoDocPaciente =(int) dgvPacientesDelProfesionalLogueado.CurrentRow.Cells["id_tipoDoc_fk"].Value;
            long nroDocPaciente=(int) dgvPacientesDelProfesionalLogueado.CurrentRow.Cells["Número de documento"].Value;

            pacienteSeleccionado = manejadorConsultarPaciente.mostrarPacienteBuscado(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc, tipoDocPaciente, nroDocPaciente);
            setDatosProfesionalLogueado(pacienteSeleccionado.medico);
            cargarDatosPacienteSeleccionado();
        }
        /*
         * Método para agregar datos al objeto Profesional Medico logueado.
         * Recibe como parámetro un objeto profesional médico.
         * No tiene valor de retorno.
         */
        public void setDatosProfesionalLogueado(ProfesionaMedico medico)
        {
            medicoLogueado.nombre = medico.nombre;
            medicoLogueado.apellido = medico.apellido;
            medicoLogueado.tipoDoc=medico.tipoDoc;
            medicoLogueado.especialidad = medico.especialidad;
            medicoLogueado.matricula = medico.matricula;
            medicoLogueado.mail = medico.mail;
            medicoLogueado.nroCelular = medico.nroCelular;


        }
        /*
         * Método para cargar los datos del paciente en los componentes del formulario.
         *El valor de retorno es void. 
         * 
         */
        public void cargarDatosPacienteSeleccionado()
        {
            txtTipoDocPaciente.Text = pacienteSeleccionado.tipoDoc.nombre;
            txtNroDocumentoPaciente.Text = Convert.ToString(pacienteSeleccionado.nroDoc);
            txtNombrePaciente.Text = pacienteSeleccionado.nombre;
            txtApellidoPaciente.Text = pacienteSeleccionado.apellido;
            txtTelefonoFijoPaciente.Text = pacienteSeleccionado.telefono.ToString();
            txtNroCelularPaciente.Text = pacienteSeleccionado.nroCelular.ToString();
            txtEmailPaciente.Text = pacienteSeleccionado.mail;
            mtbFechaNacimientoPaciente.Text = pacienteSeleccionado.fechaNacimiento.ToString();
            txtAlturaPaciente.Text = pacienteSeleccionado.altura.ToString();
            txtPesoPaciente.Text = pacienteSeleccionado.peso.ToString();

            txtCallePaciente.Text = pacienteSeleccionado.domicilio.calle.ToString();
            txtNroCallePaciente.Text = pacienteSeleccionado.domicilio.numero.ToString();
            if (pacienteSeleccionado.domicilio.piso == 0)
            {
                txtPisoPaciente.Text = "-";
            }
            else
            {
                txtPisoPaciente.Text = pacienteSeleccionado.domicilio.piso.ToString();
                
            }
            if (pacienteSeleccionado.domicilio.departamento == null)
            {
                txtDeptoPaciente.Text = "-";
            }
            else
            {
                txtDeptoPaciente.Text = pacienteSeleccionado.domicilio.departamento.ToString();
            }
            txtCodigoPostalPaciente.Text = pacienteSeleccionado.domicilio.codigoPostal.ToString();
            txtBarrioPaciente.Text = pacienteSeleccionado.domicilio.barrio.nombre.ToString();
            txtLocalidadPaciente.Text = pacienteSeleccionado.domicilio.barrio.localidad.nombre.ToString();

            txtNombreMedico.Text = pacienteSeleccionado.medico.nombre.ToString();
            txtApellidoMedico.Text = pacienteSeleccionado.medico.apellido.ToString();
            txtMatriculaMedico.Text = pacienteSeleccionado.medico.matricula.ToString();
            txtEspecialidadMedico.Text = pacienteSeleccionado.medico.especialidad.nombre.ToString();
            txtEmailMedico.Text = pacienteSeleccionado.medico.mail.ToString();
            txtNroCelularMedico.Text = pacienteSeleccionado.medico.nroCelular.ToString();

            

        }
        /*
         * Método para que los texbox sean de solo lectura.
         */ 
        public void TextBoxSoloLectura(Boolean valor)
        {
            if (valor == true)
            {
                txtTipoDocPaciente.ReadOnly = valor;
                txtNroDocumentoPaciente.ReadOnly = valor;
                txtNombrePaciente.ReadOnly = valor;
                txtApellidoPaciente.ReadOnly = valor;
                txtTelefonoFijoPaciente.ReadOnly = valor;
                txtNroCelularPaciente.ReadOnly = valor;
                txtEmailPaciente.ReadOnly = valor;
                mtbFechaNacimientoPaciente.ReadOnly = valor;
                txtAlturaPaciente.ReadOnly = valor;
                txtPesoPaciente.ReadOnly = valor;
                txtPisoPaciente.ReadOnly = valor;
                txtDeptoPaciente.ReadOnly = valor;

                txtCodigoPostalPaciente.ReadOnly = valor;
                txtBarrioPaciente.ReadOnly = valor;
                txtLocalidadPaciente.ReadOnly = valor;

                txtNombreMedico.ReadOnly = valor;
                txtApellidoMedico.ReadOnly = valor;
                txtMatriculaMedico.ReadOnly = valor;
                txtEspecialidadMedico.ReadOnly = valor;
                txtEmailMedico.ReadOnly = valor;
                txtNroCelularMedico.ReadOnly = valor;
            }
            else
            {
                txtTipoDocPaciente.ReadOnly = valor;
                txtNroDocumentoPaciente.ReadOnly = valor;
                txtNombrePaciente.ReadOnly = valor;
                txtApellidoPaciente.ReadOnly = valor;
                txtTelefonoFijoPaciente.ReadOnly = valor;
                txtNroCelularPaciente.ReadOnly = valor;
                txtEmailPaciente.ReadOnly = valor;
                mtbFechaNacimientoPaciente.ReadOnly = valor;
                txtAlturaPaciente.ReadOnly = valor;
                txtPesoPaciente.ReadOnly = valor;
                txtPisoPaciente.ReadOnly = valor;
                txtDeptoPaciente.ReadOnly = valor;

                txtCodigoPostalPaciente.Enabled = valor;
                txtBarrioPaciente.Enabled = valor;
                txtLocalidadPaciente.Enabled = valor;

                txtNombreMedico.Enabled = valor;
                txtApellidoMedico.Enabled = valor;
                txtMatriculaMedico.Enabled = valor;
                txtEspecialidadMedico.Enabled = valor;
                txtEmailMedico.Enabled = valor;
                txtNroCelularMedico.Enabled = valor;
            }
        }
        private void btnCrearHistoriaClinica_Click(object sender, EventArgs e)
        {

            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No se seleccionó el paciente que recibe atención médica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            RegistrarHistoriaClínica regHC = new RegistrarHistoriaClínica(medicoLogueado,pacienteSeleccionado);
            regHC.ShowDialog();
        }

        private void btnRegistraMedicamento_Click(object sender, EventArgs e)
        {
            RegistrarMedicamento formRegistrarMedicamento = new RegistrarMedicamento();
            formRegistrarMedicamento.ShowDialog();
            ManejadorRegistrarHC manejador = new ManejadorRegistrarHC();
            //pacienteSeleccionado.id_hc=manejador.mostrarIdHc(pacienteSeleccionado.id_tipoDoc, pacienteSeleccionado.nroDoc);
        }

        private void registrarProfesionalMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarProfesionalMedico rpm = new RegistrarProfesionalMedico();
            rpm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDataGridPacientesDelProfesional();
        }

        private void btnVerHistoriaClinica_Click(object sender, EventArgs e)
        {
            verHistoriaClinica();
           
            
        }
        private void verHistoriaClinica()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No se seleccionó el paciente que recibe atención médica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (hc == null)
            {
                hc = consultarHistoriaClinica(pacienteSeleccionado);
                
                if (hc == null)
                {
                    MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            txtNroHistoriaClinica.Text = Convert.ToString(hc.nro_hc);
            mtbFechaCreacionHc.Text = Convert.ToString(hc.fecha.ToShortDateString());
            mtbHoraCreacionHc.Text = Convert.ToString(hc.hora.ToShortTimeString());
            mtbFechaInicioAntecionHc.Text = Convert.ToString(hc.fechaInicioAtencion.ToShortDateString());
            txtMotivoPrimeraConsulta.Text = hc.motivoConsulta;

           
        }
        public HistoriaClinica consultarHistoriaClinica(Paciente paciente)
        {
                  
            if(manejadorConsultarHc==null)
                   manejadorConsultarHc = new ManejadorConsultarHC();

            return manejadorConsultarHc.mostrarHistoriaClinica(paciente);
        }
        public void generarNuevaConsulta()
        {
            int id = 0;
            if (pacienteSeleccionado != null)
            {
                if (hc ==null)
                {
                    if (manejadorConsultarHc == null)
                        manejadorConsultarHc = new ManejadorConsultarHC();

                    hc = manejadorConsultarHc.mostrarHistoriaClinica(pacienteSeleccionado);
                    id= manejadorRegistrarAtencionMedicaEnConsultorio.existeHc(pacienteSeleccionado.id_tipoDoc, pacienteSeleccionado.nroDoc);
                    if (id == -1)
                    {
                        MessageBox.Show("No se genera la consulta por falta de historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else 
                    {
                        txtNroConsulta.Text = Convert.ToString(manejadorRegistrarAtencionMedicaEnConsultorio.calcularNroConsulta(id));
                        presentarFechaYHoraActual();
                        consultaGenerada = true;
                    }
                }
                else
                {
                    txtNroConsulta.Text = Convert.ToString(manejadorRegistrarAtencionMedicaEnConsultorio.calcularNroConsulta(hc.id_hc));
                    presentarFechaYHoraActual();
                    consultaGenerada = true;
                }
            }
            else
            {
                MessageBox.Show("No seleccionó ningún paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnEnfermedades_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            presentarEnfermedades();
        }
        private void presentarEnfermedades()
        {
            crHistoriaClinicaEnfermedades crE = new crHistoriaClinicaEnfermedades();
            dsAntecedentesMorbidos dsAntecedenteMorbido = null;
            try
            {
                dsAntecedenteMorbido = MostrarAntecedentesMorbidosEnfermedadesDeHc(hc.id_hc);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al consultar antecedentes mórbidos: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if(dsAntecedenteMorbido!= null && dsAntecedenteMorbido.Tables[0].Rows.Count > 0)
                {
                    crE.SetDataSource(dsAntecedenteMorbido);
                    crystalReportViewer1.ReportSource = crE;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al generar el reporte: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsAntecedentesMorbidos MostrarAntecedentesMorbidosEnfermedadesDeHc(int idHc)
        {
            EnfermedadesDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-6DMIHKT\SQLEXPRESS;Initial Catalog=SHIART_DB_PRUEBA;Integrated Security=True;Pooling=False");
            SqlDataAdapter da = null;
            dsAntecedentesMorbidos ds = new dsAntecedentesMorbidos();
            try
            {

                cn.Open();

                string consulta = @"select am.fechaRegistro, am.evolucion, am.tratamiento,tam.nombre as 'tipo',hc.nro_hc,pa.nombre + ', '+pa.apellido as 'Paciente',prof.nombre +', '+prof.apellido as 'Profesional',hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion',td.nombre as 'TipoDocumento', pa.nro_documento as 'NrodDocumento', prof.matricula as 'Matricula'
                                     from  AntecedentesMorbidos am, TiposAntecedentesMorbidos tam,Historia_Clinica hc,Paciente pa,ProfesionalMedico prof, TipoDocumento td
                                    where am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                    and am.id_hc_fk=hc.id_hc
                                    and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                    and hc.id_nrodoc_paciente_fk=pa.nro_documento
                                    and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
                                    and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
                                    and pa.id_tipoDoc_fk=td.id_tipoDoc
                                    and am.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "AntecedentesMorbidos");
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            return ds;
        }
        public Boolean ValidarUsuarioYHc()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void dgvAntecedentesMorbidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {   

        }
        private void presentarInformacionAlergias(DataGridView dgv)
        {
            if (dgv.Columns.Count == 1 || dgv.CurrentRow == null)
            {
                return;
            }
            DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
            String cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
            cadena += "\r\nNombre del alérgeno: " + Convert.ToString(dgv.CurrentRow.Cells["Nombre del alérgeno"].Value);
            cadena += "\r\nEfectos de la alergia: " +Convert.ToString(dgv.CurrentRow.Cells["Efectos de la alergia"].Value);

            frmInformacionHistoriaClinica form = new frmInformacionHistoriaClinica(cadena);
            form.ShowDialog();
            form.Dispose();
        }
        private void presentarInformacionAntecedentesMorbidos(DataGridView dgv)
        {
            if(dgv.Columns.Count== 1 || dgv.CurrentRow == null)
            {
                return;
            }
            DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["fecha de registro"].Value);
            String cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
            cadena += "\r\nTipo de antecedente mórbido: " + Convert.ToString(dgv.CurrentRow.Cells["Tipo de Antecedente Mórbido"].Value);
            cadena += "\r\nNombre:" + Convert.ToString(dgv.CurrentRow.Cells["Nombre"].Value);
            cadena += "\r\nEvolución:" + Convert.ToString(dgv.CurrentRow.Cells["Evolución"].Value);
            cadena += "\r\nTratamiento:" + Convert.ToString(dgv.CurrentRow.Cells["Tratamiento"].Value);

            frmInformacionHistoriaClinica form = new frmInformacionHistoriaClinica(cadena);
            form.ShowDialog();
            form.Dispose();
        }
        private void presentarInformacionAntecedentesGinecoObstetricos(DataGridView dgv)
        {
            if (dgv.Columns.Count == 1 || dgv.CurrentRow == null)
            {
                return;
            }
            DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["fechaRegistro"].Value);
            String cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
            cadena += "\r\nCantidad de embarazos: " + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de embarazos"].Value);
            cadena += "\r\nCantidad de embarazos prematuros:" + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de embarazos prematuros"].Value);
            cadena += "\r\nCantidad de embarazos a término:" + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de embarazos a término"].Value);
            cadena += "\r\nCantidad de embarazos postérmino:" + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de embarazos postérmino"].Value);
            cadena += "\r\nCantidad de abortos:" + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de abortos"].Value);
            cadena += "\r\nAbortos provocados:" + Convert.ToString(dgv.CurrentRow.Cells["Abortos provocados"].Value);
            cadena += "\r\nAbortos espontaneos:" + Convert.ToString(dgv.CurrentRow.Cells["Abortos espontaneos"].Value);
            cadena += "\r\nNúmero de hijos vivos:" + Convert.ToString(dgv.CurrentRow.Cells["Número de hijos vivos"].Value);
            cadena += "\r\nProblemas asociados al embarazo:" + Convert.ToString(dgv.CurrentRow.Cells["Problemas asociados al embarazo"].Value);
            frmInformacionHistoriaClinica form = new frmInformacionHistoriaClinica(cadena);
            form.ShowDialog();
            form.Dispose();
        }
        private void dgvAlergias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          // presentarInformacionAlergias(dgvAlergias);
        }

        private void btnAlergiaSustanciaAmbiente_Click(object sender, EventArgs e)
        {
            //presentarAlergiaSustanciaAmbiente();
        }
      
        private void btnAlergiaSustanciaContactoPiel_Click(object sender, EventArgs e)
        {
            //presentarAlergiaSustanciaContactoPiel();
        }
       
        private void btnAlergiaInsectos_Click(object sender, EventArgs e)
        {
            //presentarAlergiaInsectos();
        }
     
        private void btnAlergiaMedicamentos_Click(object sender, EventArgs e)
        {
           //presentarAlergiaMedicamentos();
        }
     
        private void dgvAntecedentesMorbidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAntecedentesGinecoObstetricos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // presentarInformacionAntecedentesPatologicos(dgvAntecedentesPatologicos);
        }

        private void btnAgregarRegionEstudiada_Click(object sender, EventArgs e)
        {
            cargarDatosDataGridViewSistemaLinfatico();
            
        }
        private void agregarColumnasSistemaLinfatico()
        {
            List<String> nombreColumnas = new List<string>();
            nombreColumnas.Add("Ubicación");
            nombreColumnas.Add("Tamaño");
            nombreColumnas.Add("Aproximación numérica");
            nombreColumnas.Add("Consistencia");
            nombreColumnas.Add("Descripción");
            nombreColumnas.Add("Sensible a la palpación");
            nombreColumnas.Add("Se palpa con límites preciso");
            nombreColumnas.Add("Tiende a confluir");
            nombreColumnas.Add("Se puede movilizar con los dedos");
            nombreColumnas.Add("Adherida a planos profundos");
            nombreColumnas.Add("Se acompaña de un proceso inflamatorio que compromete la piel");
            nombreColumnas.Add("Lesión");
            nombreColumnas.Add("Observaciones");

            Utilidades.agregarColumnasDataGridView(dgvRegionesEstudiadas, nombreColumnas);
        }
        private void agregarColumnasExamenesARealizar()
        {
            List<string> nombresColumnas = new List<string>();

            nombresColumnas.Add("Examen a realizar");
            nombresColumnas.Add("Indicaciones");
            Utilidades.agregarColumnasDataGridView(dgvExamenesARealizar, nombresColumnas);

        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        public void cargarDatosDataGridViewSintomas()
        {
            Sintoma sintoma = new Sintoma();
            listaSintoma = new List<Sintoma>();

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

            if (rbSiDolor.Checked == true && cboCaracterDolor.SelectedIndex > 0)
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

            if (mtbFechaComienzoSintoma.MaskFull == true)
            {
                fechaInicio = mtbFechaComienzoSintoma.Text;
                sintoma.fechaInicioSintoma = Convert.ToDateTime(mtbFechaComienzoSintoma.Text);
            }

            if (string.IsNullOrEmpty(txtCantTiempoInicioSintoma.Text) == false && cboElementoTiempo.SelectedIndex > 0)
            {
                ElementoDelTiempo elementoTiempo = (ElementoDelTiempo)cboElementoTiempo.SelectedItem;
                cantidadTiempoDeComienzo = txtCantTiempoInicioSintoma.Text + " " + elementoTiempo.nombre;
                sintoma.cantidadTiempo = Convert.ToInt32(txtCantTiempoInicioSintoma.Text);
                sintoma.id_elementoTiempo = elementoTiempo.id_elementoDelTiempo;
            }
            if (cboCuandoComenzo.SelectedIndex > 0)
            {
                DescripcionDelTiempo descripcion = (DescripcionDelTiempo)cboCuandoComenzo.SelectedItem;
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
            sintoma.fechaRegistro = Convert.ToDateTime(mtbFechaConsulta.Text);

            listaSintoma.Add(sintoma);
        }
        public Boolean validarAntencionConsultorioTemperaturaPaso4()
        {
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura1))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl2.SelectedTab = tabPage9;
                tabPage9.Focus();
                txtValorTemperatura1.Focus();
                return false;

            }
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura2))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl2.SelectedTab = tabPage9;
                tabPage9.Focus();
                txtValorTemperatura2.Focus();
                return false;

            }
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura3))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl2.SelectedTab = tabPage9;
                tabPage9.Focus();
                txtValorTemperatura3.Focus();
                return false;

            }
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura4))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl2.SelectedTab = tabPage9;
                tabPage9.Focus();
                txtValorTemperatura4.Focus();
                return false;
            }
           
            return true;
        }
        private void btnRegistrarAtención_Click(object sender, EventArgs e)
        {
            //Aqui va la validación. Falta validación del examen general.
            if (consultaGenerada == false)
            {
                MessageBox.Show("Antes de registrar la atención en consultorio y el examen general\n debe generar una nueva consulta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(dgvDiagnosticos.Rows.Count > 0 && String.IsNullOrEmpty(Convert.ToString(dgvDiagnosticos.Rows[0].Cells[0].Value)) )
            {
                MessageBox.Show("Antes de registrar la atención en consultorio y el examen general debe agregar un diagnóstico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!validarAntencionConsultorioTemperaturaPaso4())
            {
                return;
            }

            if (chbNuevoDiagnostico.Checked == true)
            {
                try
                {
                    registrarExamenGeneralYConsulta();
                    MessageBox.Show("Consulta y Examen General registrado correctamente!!!", "Atención en consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar consulta. Error: " + ex.Message + " StackTrace: "+ ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            else
            {
                try
                {
                   registrarExamenGeneralYConsultaDiagnosticoExistente();
                    MessageBox.Show("Consulta y Examen General registrado correctamente!!!", "Atención en consultorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al registrar consulta. Error: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
               

            registrarAnálisisToolStripMenuItem.Enabled = true;
            btnAgregarPresionArterial.Enabled = true;
            medicionesAutomaticaConExamenGeneral = false;

            Utilidades.limpiarLosControles(tabControl2);
            Utilidades.limpiarLosControles(tabPage4);

            listaSintoma=null;
            manejadorRegistrarExamenGeneral = null;
            manejadorRegistrarAtencionMedicaEnConsultorio = null;
            listaTerritoriosExaminados = null;
            listaTemperaturas = null;
            listaTratamiento = null;
            listaEstudios = null;
            listaLaboratorio = null;
            listaPracticasComplementarias = null;
            consulta = null;
            cmbExtremidadPresionArterial.Enabled = true;
            cmbMomentoDiaPresionArterial.Enabled = true;
            cmbPosicionPresionArterial.Enabled = true;
            cmbSitioMedicionPresionArterial.Enabled = true;
            cmbUbicacionPresionArterial.Enabled = true;
        }
        public void registrarExamenGeneralYConsulta()
        {
            //Codigo para registrar exámen general y consulta con una sola transacción en DAO.

            examen = crearExamenGeneral();//Crea ObjetoExamenGeneral.

            examen.examenPiel = crearExamenPiel();//Agrega el análisis de la piel al examen general.

            if (examen != null && listaTerritoriosExaminados != null && listaTerritoriosExaminados.Count > 0)
                examen.territoriosExaminados = listaTerritoriosExaminados; //Agrega el análisis del sistema linfático al examen

            examen.pulso = crearPulsoArterial();//Crea ObjetoPulsoArterial

            Respiracion respiracion = crearRespiracion();//Agrega los datos de la respiración al examen
            examen.descripcionComoRespira = respiracion.descripcion;
            examen.observacionesRespiracion = respiracion.observaciones;

            //Agrega datos de temperatura al examen
            try
            {
                crearMedicionTemperatura();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener datos temperatura: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            if (examen != null && manejadorRegistrarExamenGeneral != null && listaTemperaturas != null && listaTemperaturas.Count > 0)
                examen.listaTemperaturas = listaTemperaturas;//Agrega la lista de temperaturas corporales al examen general.

            if (examen != null && manejadorRegistrarExamenGeneral.medicion!= null)
            {
               if(manejadorRegistrarExamenGeneral.medicion.mediciones != null && manejadorRegistrarExamenGeneral.medicion.mediciones.Count > 0 )
                    examen.medicion = manejadorRegistrarExamenGeneral.medicion;//Agrega las mediciones de presión arterial al examen
            }
               

            if (examen != null && manejadorRegistrarExamenGeneral != null && listaDiagnosticos != null && listaDiagnosticos.Count > 0)
                examen.listaDiagnosticos = listaDiagnosticos;//agrega al examen la lista de diagnosticos. Cada objeto de la lista ya contiene sus correspondientes tratamientos, exploraciones complementarias, programación de medicamentos.

            consulta = CrearConsulta();//Crea un objeto consulta y agrega una lista con los sintomas.

            consulta.examen = examen;//Agrega el examen general a la consulta

            try
            {
                manejadorRegistrarAtencionMedicaEnConsultorio.registrarConsultaYExamenGeneral(consulta);//Registra todo el examen general en la base de datos.
            }
            catch (Exception e)
            {
                throw e;
            }
            ////Falta agregar la "fecha desde" a la programación del medicamento. 
        }
        public void registrarExamenGeneralYConsultaDiagnosticoExistente()
        {
            //Codigo para registrar exámen general y consulta con una sola transacción en DAO.

            examen = crearExamenGeneral();//Crea ObjetoExamenGeneral.

            examen.examenPiel = crearExamenPiel();//Agrega el análisis de la piel al examen general.

            if (examen != null && listaTerritoriosExaminados != null && listaTerritoriosExaminados.Count > 0)
                examen.territoriosExaminados = listaTerritoriosExaminados; //Agrega el análisis del sistema linfático al examen

            examen.pulso = crearPulsoArterial();//Crea ObjetoPulsoArterial

            Respiracion respiracion = crearRespiracion();//Agrega los datos de la respiración al examen
            examen.descripcionComoRespira = respiracion.descripcion;
            examen.observacionesRespiracion = respiracion.observaciones;

            //Agrega datos de temperatura al examen
            crearMedicionTemperatura();
            if (examen != null && manejadorRegistrarExamenGeneral != null && listaTemperaturas != null && listaTemperaturas.Count > 0)
                examen.listaTemperaturas = listaTemperaturas;//Agrega la lista de temperaturas corporales al examen general.

            if (examen != null && manejadorRegistrarExamenGeneral != null && manejadorRegistrarExamenGeneral.medicion !=null && manejadorRegistrarExamenGeneral.medicion.mediciones != null && manejadorRegistrarExamenGeneral.medicion.mediciones.Count > 0)
                examen.medicion = manejadorRegistrarExamenGeneral.medicion;//Agrega las mediciones de presión arterial al examen

            //if (examen != null && manejadorRegistrarExamenGeneral != null && listaDiagnosticos != null && listaDiagnosticos.Count > 0)
            //    examen.listaDiagnosticos = listaDiagnosticos;//agrega al examen la lista de diagnosticos. Cada objeto de la lista ya contiene sus correspondientes tratamientos, exploraciones complementarias, programación de medicamentos.


            consulta = CrearConsulta();//Crea un objeto consulta y agrega una lista con los sintomas.

            consulta.examen = examen;//Agrega el examen general a la consulta

            try
            {
                manejadorRegistrarAtencionMedicaEnConsultorio.registrarConsultaYExamenGeneral(consulta,listaEvolucionDiagnostico);//Registra todo el examen general en la base de datos.
                ////Falta agregar la "fecha desde" a la programación del medicamento. 
            }
             catch (Exception e)
            {
                throw e;
            }
        }
        /*
        * Crea un objeto consulta.
        * Llama al manejador Registrar Ateción Médica en consultorio.
        * Retorna un objeto consulta.
        */
        public Consulta CrearConsulta()
        {
            int nroConsulta;
            DateTime fecha;
            DateTime hora;
            string motivoConsulta;
            int idhc;
            Consulta consulta;
            nroConsulta = Convert.ToInt32(txtNroConsulta.Text);
            fecha = Convert.ToDateTime(mtbFechaConsulta.Text);
            hora = Convert.ToDateTime(mtbHoraConsulta.Text);
            motivoConsulta = txtMotivoConsulta.Text;
            
            idhc = hc.id_hc;

            if(idhc==0)
            {
                HistoriaClinica hc = HistoriaClinicaLN.mostrarHistoriaClinica(pacienteSeleccionado);
                idhc = hc.id_hc;
            }

            if (listaSintoma != null && listaSintoma.Count > 0)
            {
                consulta = manejadorRegistrarAtencionMedicaEnConsultorio.crearObjetoConsulta(nroConsulta, fecha, hora, motivoConsulta, idhc, listaSintoma);
            }
            else
            {
                consulta = manejadorRegistrarAtencionMedicaEnConsultorio.crearObjetoConsulta(nroConsulta, fecha, hora, motivoConsulta, idhc);
            }

            return consulta;
        }
        /*Crear el objeto examen general.
         * Llama al manejador RegistrarExamenGeneral
         * Retorna un objeto Examen General.
         */
        public ExamenGeneral crearExamenGeneral()
        {
            string posicionYDecubito = "";
            string marchaDeambulacion = "";
            string facieExpresionFisonomia = "";
            string concienciaEstadoPsiquico = "";
            string constitucionEstadoNutritivo = "";
            int peso = 0;
            int talla = 0;


            if (string.IsNullOrEmpty(txtPosicionYDecubito.Text) == false)
            {
                posicionYDecubito = txtPosicionYDecubito.Text;
            }
            else
            {
                posicionYDecubito = "No precisa";
            }

            if (string.IsNullOrEmpty(txtMarchaYDeambulacion.Text) == false)
            {
                marchaDeambulacion = txtMarchaYDeambulacion.Text;
            }
            else
            {
                marchaDeambulacion = "No precisa";
            }

            if (string.IsNullOrEmpty(txtFacieOExpresióndeFisonomia.Text) == false)
            {
                facieExpresionFisonomia = txtFacieOExpresióndeFisonomia.Text;
            }
            else
            {
                facieExpresionFisonomia = "No precisa";
            }

            if (string.IsNullOrEmpty(txtConsistenciaYEstadoPsiquico.Text) == false)
            {
                concienciaEstadoPsiquico = txtConsistenciaYEstadoPsiquico.Text;
            }
            else
            {
                concienciaEstadoPsiquico = "No precisa";
            }

            if (string.IsNullOrEmpty(txtConstitucionYEstadoNutritivo.Text) == false)
            {
                constitucionEstadoNutritivo = txtConstitucionYEstadoNutritivo.Text;
            }
            else
            {
                constitucionEstadoNutritivo = "No precisa";
            }

            if (string.IsNullOrEmpty(txtPeso.Text) == false)
            {
                peso = Convert.ToInt32(txtPeso.Text);
            }

            if (string.IsNullOrEmpty(txtAltura.Text) == false)
            {
                talla = Convert.ToInt32(txtAltura.Text);
            }
            return manejadorRegistrarExamenGeneral.crearExamenGeneralPaso1(posicionYDecubito, marchaDeambulacion, facieExpresionFisonomia, concienciaEstadoPsiquico, constitucionEstadoNutritivo, peso, talla);
        }
       
        private void registrarSistemaLinfatico(int idExamenGeneral)
        {
            if (listaTerritoriosExaminados != null && listaTerritoriosExaminados.Count > 0)
                manejadorRegistrarExamenGeneral.registrarSistemaLinfatico(listaTerritoriosExaminados, idExamenGeneral);
        }
        /*
         * Crear el objeto correspondiente al exmanen de la piel.
         * Llama al Manejador Registrar Examen General.
         * Retorna un objeto Piel.
         */
        private Piel crearExamenPiel()
        {
            string colorPiel = "";
            string elasticidad = "";
            string humedad = "";
            string untuosidad = "";
            string turgor = "";
            string lesiones = "";
            TemperaturaPiel temperaturaPiel = null;

            if (string.IsNullOrEmpty(txtColorPiel.Text))
            {
                colorPiel = "No precisa";
            }
            else
            {
                colorPiel = txtColorPiel.Text;
            }

            if (string.IsNullOrEmpty(txtElasticidadPiel.Text))
            {
                elasticidad = "No precisa";
            }
            else
            {
                elasticidad = txtElasticidadPiel.Text;
            }

            if (string.IsNullOrEmpty(txtHumedadPiel.Text))
            {
                humedad = "No precisa";
            }
            else
            {
                humedad = txtHumedadPiel.Text;
            }

            if (string.IsNullOrEmpty(txtUntuosidadPiel.Text))
            {
                untuosidad = "No precisa";
            }
            else
            {
                untuosidad = txtUntuosidadPiel.Text;
            }

            if (string.IsNullOrEmpty(txtTurgorPiel.Text))
            {
                turgor = "No precisa";
            }
            else
            {
                turgor = txtTurgorPiel.Text;
            }

            if (string.IsNullOrEmpty(txtLesionesPiel.Text))
            {
                lesiones = "No precisa";
            }
            else
            {
                lesiones = txtLesionesPiel.Text;
            }

            if (cboTemperaturaPiel.SelectedIndex > 0)
            {
                temperaturaPiel = (TemperaturaPiel)cboTemperaturaPiel.SelectedItem;
            }
            return manejadorRegistrarExamenGeneral.crearExamenDePielPaso1(colorPiel, elasticidad, humedad, untuosidad, turgor, lesiones, temperaturaPiel);
        }
        /*
         * Agrega los territorios examinados del sistema linfático a la grilla, del paso dos.
         * Agrega los territorios examinados a la lista.
         * Llama al manejador Registrar Examine General.
         * Valor de retorno void.
         */
        private void cargarDatosDataGridViewSistemaLinfatico()
        {
            string ubicacion;
            string tamaño;
            int aproximacionNumerica;
            string consistencia;
            string descripcion = "No precisa";
            string sensiblePalpacion = "No";
            string limitesPrecisos="No";
            string tiendeConfluir="No";
            string movilizaConDedos="No";
            string planosProfundos="No";
            string procesoInflamatorio = "No";
            string lesion = "No precisa";
            string observaciones = "No precisa";

            listaTerritoriosExaminados = new List<SistemaLinfatico>();

            Ubicacion ubicacionSeleccionada = (Ubicacion)cboUbicacionGanglio.SelectedItem;
            ubicacion = ubicacionSeleccionada.nombre;

            Tamaño tamañoSeleccionado = (Tamaño)cboTamañoGanglio.SelectedItem;
            tamaño = tamañoSeleccionado.nombre;

            aproximacionNumerica = Convert.ToInt32(cboAproximacionNumerica.SelectedItem.ToString());

            Consistencia consistenciaSeleccionada = (Consistencia)cboConsistencia.SelectedItem;
            consistencia = consistenciaSeleccionada.nombre;

            if (string.IsNullOrEmpty(txtDescripcion.Text) == false)
            {
                descripcion = txtDescripcion.Text;
            }

            if (chbSensiblePalpacion.Checked == true)
            {
                sensiblePalpacion = "Si";
            }

            if (rbLimitesPrecisos.Checked == true)
            {
                limitesPrecisos = "Si";
            }
            else
            {
                if (rbTiendeConfluir.Checked == true)
                {
                    tiendeConfluir = "Si";
                }
            }

            if(rbMovilizarConDedos.Checked==true)
            {
                movilizaConDedos="Si";
            }
            else
            {
                if(rbPlanosProfundos.Checked==true)
                {
                    planosProfundos="Si";
                }
            }
            if (chbProcesoInflamatorio.Checked == true)
            {
                procesoInflamatorio = "Si";
            }

            if (String.IsNullOrEmpty(txtLesionCompromisoGangleo.Text) == false)
            {
                lesion = txtLesionCompromisoGangleo.Text;
            }

            if (String.IsNullOrEmpty(txtObservaciones.Text) == false)
            {
                observaciones = txtObservaciones.Text;
            }

            SistemaLinfatico nuevoExamenLinfatico=manejadorRegistrarExamenGeneral.crearSistemaLinfaticoPaso2(ubicacionSeleccionada.id_ubicacion,tamañoSeleccionado.id_tamaño,aproximacionNumerica,consistenciaSeleccionada.id_consistencia,descripcion,sensiblePalpacion,limitesPrecisos,tiendeConfluir,movilizaConDedos,planosProfundos,procesoInflamatorio,lesion,observaciones);
            
            listaTerritoriosExaminados.Add(nuevoExamenLinfatico);
            
            dgvRegionesEstudiadas.Rows.Add(ubicacion, tamaño, aproximacionNumerica, consistencia, descripcion, sensiblePalpacion, limitesPrecisos, tiendeConfluir,movilizaConDedos,planosProfundos, procesoInflamatorio, lesion, observaciones);
        }
        /*
        * Crear el objeto PulsoArterial.
        * Llama al manejador registrar Examen General.
        * Retorna un objeto PulsoArterial.
        */
        private PulsoArterial crearPulsoArterial()
        {
            string auscultacion = "";
            string observaciones = "";


            if (String.IsNullOrEmpty(txtAuscultacionPulsos.Text) == true)
            {
                auscultacion = "No precisa";
            }
            else
            {
                auscultacion = txtAuscultacionPulsos.Text;
            }

            if (String.IsNullOrEmpty(txtObservaciones.Text) == true)
            {
                observaciones = "No precisa";
            }
            else
            {
                auscultacion = txtObservaciones.Text;
            }

            List<DetallePulsoArterial> detalles = new List<DetallePulsoArterial>();

            if (cboPulso1.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso1.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI1.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD1.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso2.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso2.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI2.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD2.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso3.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso3.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI3.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD3.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso4.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso4.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI4.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD4.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso5.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso5.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI5.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD5.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso6.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso6.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI6.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD6.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso7.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso7.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI7.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD7.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            if (cboPulso8.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();

                Pulso pulsoSeleccionado = (Pulso)cboPulso8.SelectedItem;
                detalle.id_pulso = pulsoSeleccionado.id_pulso;

                EscalaPulso escalaSeleccionadaI = (EscalaPulso)cboPI8.SelectedItem;
                detalle.id_izquierda = escalaSeleccionadaI.id_escalaPulso;

                EscalaPulso escalaSeleccionadaD = (EscalaPulso)cboPD8.SelectedItem;
                detalle.id_derecha = escalaSeleccionadaD.id_escalaPulso;

                detalles.Add(detalle);
            }

            return manejadorRegistrarExamenGeneral.crearPulsoArterialPaso3(auscultacion, observaciones, detalles);
        }
        /*
         * Crear el objetoRespiracion.
         * Llama al manejador Registrar Examen General.
         * Retorna un objeto Respiracion.
         */
        public Respiracion crearRespiracion()
        {
            string descripcion = "";
            string observaciones = "";

            if (string.IsNullOrEmpty(txtDescripcionRespiracion.Text))
            {
                descripcion = "No precisa";
            }
            else
            {
                descripcion = txtDescripcionRespiracion.Text;
            }

            if (string.IsNullOrEmpty(txtObservaciones.Text))
            {
                observaciones = "No precisa";
            }
            else
            {
                observaciones = txtObservaciones.Text;
            }

            return manejadorRegistrarExamenGeneral.crearRespiracionPaso3(descripcion, observaciones);

        }
        /*
        * Crear la lista de mediciones de temperatura corporal y agrega los objetos Temperatura a la lista.
        * Llama al manejador Registrar Examen General.
        * Retorna void.
        */
        public void crearMedicionTemperatura()
        {
            int id_sitio;
            float valorTemperatura;
            string resultado;
            int idResultado;

            if (cboSitioMedicion1.SelectedIndex > 0 && !string.IsNullOrEmpty(txtValorTemperatura1.Text) && !string.IsNullOrEmpty(txtResultadoTemperatura1.Text))
            {
                SitioMedicionTemperatura sitio = (SitioMedicionTemperatura)cboSitioMedicion1.SelectedItem;
                id_sitio = sitio.id_sitioMedicion;

                valorTemperatura = float.Parse(txtValorTemperatura1.Text);

                resultado = txtResultadoTemperatura1.Text;

                try
                {
                    idResultado = TemperaturaLN.ObtenerIdResultadoTemperatura(resultado);
                }
                catch(Exception e)
                {
                    throw e;
                }

                Temperatura temperatura=manejadorRegistrarExamenGeneral.crearTemperaturaPaso4(id_sitio, resultado, valorTemperatura,idResultado);

                if (listaTemperaturas == null)
                    listaTemperaturas = manejadorRegistrarExamenGeneral.crearListaTemperatura();

                listaTemperaturas.Add(temperatura);
            }

            if (cboSitioMedicion2.SelectedIndex > 0 && !string.IsNullOrEmpty(txtValorTemperatura2.Text) && !string.IsNullOrEmpty(txtResultadoTemperatura2.Text))
            {
                SitioMedicionTemperatura sitio = (SitioMedicionTemperatura)cboSitioMedicion2.SelectedItem;
                id_sitio = sitio.id_sitioMedicion;

                valorTemperatura = float.Parse(txtValorTemperatura2.Text);

                resultado = txtResultadoTemperatura2.Text;

                try
                {
                    idResultado = TemperaturaLN.ObtenerIdResultadoTemperatura(resultado);
                }
                catch (Exception e)
                {
                    throw e;
                }

                Temperatura temperatura = manejadorRegistrarExamenGeneral.crearTemperaturaPaso4(id_sitio, resultado, valorTemperatura,idResultado);

                if (listaTemperaturas == null)
                    listaTemperaturas = manejadorRegistrarExamenGeneral.crearListaTemperatura();

                listaTemperaturas.Add(temperatura);
            }

            if (cboSitioMedicion3.SelectedIndex > 0 && !string.IsNullOrEmpty(txtValorTemperatura3.Text) && !string.IsNullOrEmpty(txtResultadoTemperatura3.Text))
            {
                SitioMedicionTemperatura sitio = (SitioMedicionTemperatura)cboSitioMedicion3.SelectedItem;
                id_sitio = sitio.id_sitioMedicion;

                valorTemperatura = float.Parse(txtValorTemperatura3.Text);

                resultado = txtResultadoTemperatura3.Text;

                try
                {
                    idResultado = TemperaturaLN.ObtenerIdResultadoTemperatura(resultado);
                }
                catch (Exception e)
                {
                    throw e;
                }

                Temperatura temperatura = manejadorRegistrarExamenGeneral.crearTemperaturaPaso4(id_sitio, resultado, valorTemperatura,idResultado);

                if (listaTemperaturas == null)
                    listaTemperaturas = manejadorRegistrarExamenGeneral.crearListaTemperatura();

                listaTemperaturas.Add(temperatura);
            }

            if (cboSitioMedicion4.SelectedIndex > 0 && !string.IsNullOrEmpty(txtValorTemperatura4.Text) && !string.IsNullOrEmpty(txtResultadoTemperatura4.Text))
            {
                SitioMedicionTemperatura sitio = (SitioMedicionTemperatura)cboSitioMedicion4.SelectedItem;
                id_sitio = sitio.id_sitioMedicion;

                valorTemperatura = float.Parse(txtValorTemperatura4.Text);

                resultado = txtResultadoTemperatura4.Text;

                try
                {
                    idResultado = TemperaturaLN.ObtenerIdResultadoTemperatura(resultado);
                }
                catch (Exception e)
                {
                    throw e;
                }

                Temperatura temperatura = manejadorRegistrarExamenGeneral.crearTemperaturaPaso4(id_sitio, resultado, valorTemperatura,idResultado);

                if (listaTemperaturas == null)
                    listaTemperaturas = manejadorRegistrarExamenGeneral.crearListaTemperatura();

                listaTemperaturas.Add(temperatura);
            }
        }
        public void presentarExamenGeneralPresionArterial(List<Extremidad> extremidades, List<Posicion> posiciones, List<SitioMedicion> sitios, List<MomentoDia> momentos)
        {
            Utilidades.cargarCombo(cmbExtremidadPresionArterial, extremidades, "id_extremidad", "nombre");
            Utilidades.cargarCombo(cmbPosicionPresionArterial, posiciones, "id_posicion", "nombre");
            Utilidades.cargarCombo(cmbSitioMedicionPresionArterial, sitios, "id_sitioMedicion", "nombre");
            Utilidades.cargarCombo(cmbMomentoDiaPresionArterial, momentos, "idMomentoDia", "nombre");
            manejadorRegistrarExamenGeneral.buscarClasificacionesDePresionArterial();
        }

        private void cmbExtremidadPresionArterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            manejadorRegistrarExamenGeneral.mostrarUbicacionesDeExtremidad(Convert.ToInt32(cmbExtremidadPresionArterial.SelectedValue),this);
        }

        public void presentarUbicacionesExtremidadDeExtremidad(List<UbicacionExtremidad> ubicaciones)
        {
            Utilidades.cargarCombo(cmbUbicacionPresionArterial, ubicaciones, "id_ubicacionExtremidad", "nombre");
        }

        /*Agrega una medición de presión arterial a la grilla*/
        private void btnAgregarPresionArterial_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiastolicaPresionArterial.Text) || String.IsNullOrEmpty(txtSistolicaPresionArterial.Text) || String.IsNullOrEmpty(txtPulsoPresionArterial.Text))
            {
                MessageBox.Show("Falta datos por ingresar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSistolicaPresionArterial.Focus();
                return;
            }
            if (!ValidarNumeroAtencionConsultorioPresionPaso4())
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Extremidad extremidad = (Extremidad)cmbExtremidadPresionArterial.SelectedItem;
            UbicacionExtremidad ubicacion = (UbicacionExtremidad)cmbUbicacionPresionArterial.SelectedItem;
            Posicion posicion = (Posicion)cmbPosicionPresionArterial.SelectedItem;
            SitioMedicion sitio = (SitioMedicion)cmbSitioMedicionPresionArterial.SelectedItem;
            MomentoDia momento = (MomentoDia)cmbMomentoDiaPresionArterial.SelectedItem;

            if (dgvPresionArterial.RowCount == 1)
            {
                cmbExtremidadPresionArterial.Enabled = false;
                cmbUbicacionPresionArterial.Enabled = false;
                cmbPosicionPresionArterial.Enabled = false;
                cmbSitioMedicionPresionArterial.Enabled = false;
                cmbMomentoDiaPresionArterial.Enabled = false;
                manejadorRegistrarExamenGeneral.registrarMedicion(DateTime.Today, DateTime.Now, posicion, ubicacion, sitio, momento, extremidad);
            }

            dgvPresionArterial.Rows.Add(DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString(), extremidad.nombre, ubicacion.nombre, posicion.nombre, sitio.nombre, txtSistolicaPresionArterial.Text + "mmHg", txtDiastolicaPresionArterial.Text + "mmHg", txtPulsoPresionArterial.Text, momento.nombre);
            DateTime hora = DateTime.Now; int pulso = Convert.ToInt32(txtPulsoPresionArterial.Text); int valorMinimo = Convert.ToInt32(txtDiastolicaPresionArterial.Text); int valorMaximo = Convert.ToInt32(txtSistolicaPresionArterial.Text);
            manejadorRegistrarExamenGeneral.registrarDetalleDeMedicion(hora, pulso, valorMinimo, valorMaximo);

            txtSistolicaPresionArterial.Clear();
            txtDiastolicaPresionArterial.Clear();
            txtPulsoPresionArterial.Clear();
            registrarAnálisisToolStripMenuItem.Enabled = false;
        }
        public Boolean ValidarNumeroAtencionConsultorioPresionPaso4()
        {
            if (!Utilidades.ValidarCampoNumerico(txtSistolicaPresionArterial))
            {
                txtSistolicaPresionArterial.Focus();
                return false;
            }
            if (!Utilidades.ValidarCampoNumerico(txtDiastolicaPresionArterial))
            {
                txtDiastolicaPresionArterial.Focus();
                return false;
            }
            if (!Utilidades.ValidarCampoNumerico(txtPulsoPresionArterial))
            {
                txtPulsoPresionArterial.Focus();
                return false;
            }

            return true;
        }
        public void presentarCalculosPresionArterial(string promedio, string categoria, string rangoValorMaximo, string rangoValorMinimo)
        {
            //lblPromedioPresionArterial.Text = promedio;
            //lblCategoriaPresionArterial.Text = categoria;
            //lblValorMaxPresionArterial.Text = rangoValorMaximo;
            //lblValorMinPresionArterial.Text = rangoValorMinimo;
        }

        private void AgregarHipotesisInicial_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            cargarDatosDgvDiagnosticos();
        }
        private void cargarDatosDgvDiagnosticos()
        {   
            string conceptoInicial;
            string descDiagnostico;
            int id_estado;
            string nombreEstado;
            DateTime fecha;
            string motivo;

            EstadoDiagnostico estadoSeleccionado = null;

            if (chbNuevoDiagnostico.Checked==true && cboEstadoDiagnostico.SelectedIndex>0 && string.IsNullOrEmpty(txtDiagnostico.Text) == false)
            {
                estadoSeleccionado = (EstadoDiagnostico) cboEstadoDiagnostico.SelectedItem;
                nombreEstado=estadoSeleccionado.nombre;
                id_estado=estadoSeleccionado.id_estado;
                
                conceptoInicial= txtConceptoInicial.Text;
                descDiagnostico=txtDiagnostico.Text;
                fecha=Convert.ToDateTime(mtbFechaDiagnostico.Text);
                motivo=txtMotivoDiagnostico.Text;

                if (listaDiagnosticos == null)
                listaDiagnosticos = manejadorRegistrarExamenGeneral.CrearListaDiagnosticos();

                EstadoDiagnostico estado= manejadorRegistrarExamenGeneral.crearEstadoDiagnostico(id_estado,nombreEstado);

                RazonamientoDiagnostico diagnostico = manejadorRegistrarExamenGeneral.crearRazonamientoDiagnostico(conceptoInicial, descDiagnostico, estado, motivo, fecha, listaLaboratorio, listaEstudios,listaPracticasComplementarias, listaTratamiento);
                //aqui agregar validacion y creacion de diagnostico existente!!!!

                DialogResult dr = MessageBox.Show("Desea registrar tratamientos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
                if (dr == DialogResult.Yes)
                {
                    RegistrarTratamiento rt = new RegistrarTratamiento(manejadorRegistrarExamenGeneral);
               
                    if (rt.ShowDialog() == DialogResult.OK)
                    {
                        listaTratamiento = rt.listaTratamientos;
                    }
                }

                if (listaTratamiento != null && listaTratamiento.Count > 0)
                {
                    diagnostico.tratamientos = listaTratamiento;
                }
                listaDiagnosticos.Add(diagnostico);

                dgvDiagnosticos.Rows.Add(txtDiagnostico.Text, nombreEstado);
            }
            else if(chbNuevoDiagnostico.Checked == false /*&& cboEstadoDiagnostico.SelectedIndex > 0*/)
            {
                if (listaEvolucionDiagnostico == null)
                    listaEvolucionDiagnostico = new List<EvolucionDiagnostico>();

                EvolucionDiagnostico evolucionDiagnostico = new EvolucionDiagnostico();

                evolucionDiagnostico.idHc = pacienteSeleccionado.id_hc;
                evolucionDiagnostico.idDiagnostico = Convert.ToInt32(dgvDiagnosticos.CurrentRow.Cells[5].Value);
                evolucionDiagnostico.fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                evolucionDiagnostico.idEstadoDiagnostico =Convert.ToInt32(dgvDiagnosticos.CurrentRow.Cells[3].Value);

                razonamientoDiagnosticoExistente = new RazonamientoDiagnostico();
                razonamientoDiagnosticoExistente.id_razonamiento = Convert.ToInt32(dgvDiagnosticos.CurrentRow.Cells[5].Value);
                razonamientoDiagnosticoExistente.analisis = listaLaboratorio;
                razonamientoDiagnosticoExistente.estudios = listaEstudios;
                razonamientoDiagnosticoExistente.practicas = listaPracticasComplementarias;

                

                DialogResult dr = MessageBox.Show("Desea registrar tratamientos?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    RegistrarTratamiento rt = new RegistrarTratamiento(manejadorRegistrarExamenGeneral);

                    if (rt.ShowDialog() == DialogResult.OK)
                    {
                        listaTratamiento = rt.listaTratamientos;
                    }
                }

                if (listaTratamiento != null && listaTratamiento.Count > 0)
                {
                    razonamientoDiagnosticoExistente.tratamientos = listaTratamiento;
                }
                evolucionDiagnostico.diagnostico = razonamientoDiagnosticoExistente;
                listaEvolucionDiagnostico.Add(evolucionDiagnostico);
                MessageBox.Show("Información del diagnostico agregada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void btnEstudioARealizar_Click(object sender, EventArgs e)
        {
            cargarDatosDgvEstudioARealizar();
        }
        /*
         * Crea la lista de estudios de diagnóstico por imagen seleccionados del combo box y las agrega a la grilla.
         */
        private void cargarDatosDgvEstudioARealizar()
        {
            string estudio;
            int id_estudio;
            string indicaciones = "";

            //if(chbNuevoDiagnostico.Checked == true)
            //{

            //}

            if (cboEstudioARealizar.SelectedIndex > 0)
            {
                NombreEstudio nombreSeleccionado = (NombreEstudio)cboEstudioARealizar.SelectedItem;
                estudio = nombreSeleccionado.nombre;
                id_estudio = (int)cboEstudioARealizar.SelectedValue;

                if (string.IsNullOrEmpty(txtIndicacionesEstudioARealizar.Text) == false)
                {
                    indicaciones = txtIndicacionesEstudioARealizar.Text;
                }

                EstudioDiagnosticoPorImagen estudioDiagnosticoImagen = manejadorRegistrarExamenGeneral.crearEstudioDiagnosticoPorImagen(indicaciones);

                if (listaEstudios == null)
                    listaEstudios = manejadorRegistrarExamenGeneral.crearListaEstudioDiagnosticoPorImagen();

                estudioDiagnosticoImagen.nombreEstudio = manejadorRegistrarExamenGeneral.crearNombreEstudio(id_estudio, estudio);
                estudioDiagnosticoImagen.fechaSolicitud = Convert.ToDateTime(mtbFechaDiagnostico.Text);
                listaEstudios.Add(estudioDiagnosticoImagen);

                dgvExamenesARealizar.Rows.Add(estudio, indicaciones);
            }
        }
        private void btnAnalisisLaboratorioARealizar_Click(object sender, EventArgs e)
        {
            cargarDatosDgvAnalisisLaboratorioARealizar();
        }
        /*
         * Crea la lista de analisis de laboratorios seleccionados del combo box y las agrega a la grilla.
         */
        private void cargarDatosDgvAnalisisLaboratorioARealizar()
        {
            string analisisLaboratorio;
            int id_analisisLaboratorio;
            string indicaciones = "";
            if (cboAnalisiLaboratorioARealizar.SelectedIndex > 0)
            {
                AnalisisLaboratorio analisisLaboratorioSeleccionado = (AnalisisLaboratorio)cboAnalisiLaboratorioARealizar.SelectedItem;
                
                analisisLaboratorio = analisisLaboratorioSeleccionado.nombre;
                id_analisisLaboratorio = analisisLaboratorioSeleccionado.id_analisis;

                if (string.IsNullOrEmpty(txtIndicacionesEstudioARealizar.Text) == false)
                {
                    indicaciones = txtIndicacionesEstudioARealizar.Text;
                }

                Laboratorio laboratorio = manejadorRegistrarExamenGeneral.crearLaboratorio(indicaciones);

                if (listaLaboratorio == null)
                    listaLaboratorio = manejadorRegistrarExamenGeneral.crearListaLaboratorio();

                laboratorio.analisis = manejadorRegistrarExamenGeneral.crearAnalisisLaboratorio(id_analisisLaboratorio, analisisLaboratorio);
                laboratorio.fechaSolicitud = Convert.ToDateTime(mtbFechaDiagnostico.Text);
                listaLaboratorio.Add(laboratorio);

                dgvExamenesARealizar.Rows.Add(analisisLaboratorio, indicaciones);
            }
        }
        private void generarNuevaConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            generarNuevaConsulta();
            cargarDatosDeEjemplo();
        }
        private void cargarDatosDeEjemplo()
        {
            txtMotivoConsulta.Text = "Consulta por valores elevados de presión arterial obtenidos en un examen médico de rutina realizado en una institución educativa";
            txtPosicionYDecubito.Text = "Posición activa, sin alteraciones";
            txtMarchaYDeambulacion.Text = "Deambulación normal";
            txtFacieOExpresióndeFisonomia.Text = "Facie no carcaterística";
            txtConsistenciaYEstadoPsiquico.Text = "Conciente, orientada en el tiempo y espacio";
            txtConstitucionYEstadoNutritivo.Text = "Constitución mesomorfa, pero impresiona que ha bajado de peso";
            txtPeso.Text = "47";
            txtAltura.Text = "175";

            txtColorPiel.Text = "Coloración normal";
            txtElasticidadPiel.Text = "Normal";
            txtHumedadPiel.Text = "Normal";
            txtUntuosidadPiel.Text = "Normal";
            txtTurgorPiel.Text = "Normal";
            txtLesionesPiel.Text = "Normal";
            cboTemperaturaPiel.SelectedIndex = 0;

            cboTemperaturaPiel.SelectedIndex = 1;
            cboUbicacionGanglio.SelectedIndex = 1;
            cboTamañoGanglio.SelectedIndex = 1;
            cboConsistencia.SelectedIndex = 1;
            cboAproximacionNumerica.SelectedIndex = 2;
            chbSensiblePalpacion.Checked = true;
            chbProcesoInflamatorio.Checked = true;
            rbLimitesPrecisos.Checked = true;
            rbPlanosProfundos.Checked = true;

            cboPulso1.SelectedIndex = 1;
            cboPI1.SelectedIndex = 3;
            cboPD1.SelectedIndex = 3;

            cboPulso2.SelectedIndex = 2;
            cboPI2.SelectedIndex = 3;
            cboPD2.SelectedIndex = 3;

            txtDescripcionRespiracion.Text = "Respiración normal";
            txtObservacionesRespiracion.Text = "Normal";
            txtValorTemperatura1.Text = "36";
            txtValorTemperatura2.Text = "36";

            cmbUbicacionPresionArterial.SelectedIndex = 1;
            cmbMomentoDiaPresionArterial.SelectedIndex = 2;
            cmbPosicionPresionArterial.SelectedIndex = 2;
            cmbSitioMedicionPresionArterial.SelectedIndex = 2;

            cboSitioMedicion1.SelectedIndex = 1;
            cboSitioMedicion2.SelectedIndex = 2;

            cboQueSienteElPaciente.SelectedIndex = 1;
            txtDescQueSientePaciente.Text = "Dolor de cabeza";
            //cboParteCuerpo.SelectedIndex = 1;
            rbSiDolor.Checked = true;
            cboCaracterDolor.SelectedIndex = 1;
            txtCantTiempoInicioSintoma.Text = "5";
            cboElementoTiempo.SelectedIndex = 1;


            txtConceptoInicial.Text = "Paciente con valores elevados de presión arterial en el consultorio y en un exámen de rutina";
            txtDiagnostico.Text = "Hipertensión arterial";
            txtMotivoDiagnostico.Text = "Valores elevados de presión arterial en consultorio";
        }
        private void btnAgregarSintoma_Click(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtCantTiempoInicioSintoma))
            {
                MessageBox.Show("Debe ingresar un valor numérico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cargarSintomas();
           
        }
        private void cargarSintomas()
        {
            Sintoma sintoma = new Sintoma();
            listaSintoma = new List<Sintoma>();

            string descripcionQueSiente = "No precisa";
            string caracterDolor = "No precisa";
            string haciaDondeIrradia = "No precisa";
            string fechaInicio = "No precisa";
            //string cantidadTiempoDeComienzo = "No precisa";
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

            if (rbSiDolor.Checked == true && cboCaracterDolor.SelectedIndex > 0)
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

            if (mtbFechaComienzoSintoma.MaskFull == true)
            {
                fechaInicio = mtbFechaComienzoSintoma.Text;
                sintoma.fechaInicioSintoma = Convert.ToDateTime(mtbFechaComienzoSintoma.Text);
            }

            if (string.IsNullOrEmpty(txtCantTiempoInicioSintoma.Text) == false && cboElementoTiempo.SelectedIndex > 0)
            {
                ElementoDelTiempo elementoTiempo = (ElementoDelTiempo)cboElementoTiempo.SelectedItem;
                sintoma.cantidadTiempo = Convert.ToInt32(txtCantTiempoInicioSintoma.Text);
                sintoma.id_elementoTiempo = elementoTiempo.id_elementoDelTiempo;
            }
            if (cboCuandoComenzo.SelectedIndex > 0)
            {
                DescripcionDelTiempo descripcion = (DescripcionDelTiempo)cboCuandoComenzo.SelectedItem;
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

            if(string.IsNullOrEmpty(mtbFechaConsulta.Text) == false)
                sintoma.fechaRegistro = Convert.ToDateTime(mtbFechaConsulta.Text);

            listaSintoma.Add(sintoma);

            MessageBox.Show("Síntoma agregado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            crHistoriaClinicaConsultas rhc = new crHistoriaClinicaConsultas();
            rhc.SetDataSource(ConsultaLN.MostrarConsultas(hc.id_hc));
            crystalReportViewer1.ReportSource = rhc;
            crystalReportViewer1.RefreshReport();
            //presentarConsultas();
        }
   

        private void btnRegistrarMedicacion_Click(object sender, EventArgs e)
        {

        }

        private void nuevoTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No ha seleccionado un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (hc == null)
                {
                    id = manejadorRegistrarAtencionMedicaEnConsultorio.existeHc(pacienteSeleccionado.id_tipoDoc, pacienteSeleccionado.nroDoc);
                    if (id == -1)
                    {
                        MessageBox.Show("El paciente no tiene historia clínica. No es posible registrar tratamientos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            if (consultaGenerada == false)
            {
                MessageBox.Show("Antes de registrar tratamientos debe generar una nueva consulta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            RegistrarTratamiento rt = new RegistrarTratamiento(manejadorRegistrarExamenGeneral);
            if (rt.ShowDialog() == DialogResult.OK)
            {
                listaTratamiento = rt.listaTratamientos;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatosDgvPracticasComplementariasARealizar();
        }
        /*
         * Crea la lista de practicas complementarias seleccionadas del combo box y las agrega a la grilla.
         */
        public void cargarDatosDgvPracticasComplementariasARealizar()
        {
            string nombre;
            int id_tipo;

            string indicaciones = "";

            if (cboPracticasComplementariasARealizar.SelectedIndex > 0)
            {
                TipoPracticaComplementaria nombreSeleccionado = (TipoPracticaComplementaria)cboPracticasComplementariasARealizar.SelectedItem;
                nombre = nombreSeleccionado.nombre;
                id_tipo = nombreSeleccionado.id_tipoPracticaComplementaria;

                if (string.IsNullOrEmpty(txtIndicacionesPracticasComplementarias.Text) == false)
                {
                    indicaciones = txtIndicacionesPracticasComplementarias.Text;
                }

                PracticaComplementaria practicaComplementaria = manejadorRegistrarExamenGeneral.crearPracticaComplementaria(indicaciones);

                if (listaPracticasComplementarias == null)
                    listaPracticasComplementarias = manejadorRegistrarExamenGeneral.crearListaPracticaComplementaria();

                practicaComplementaria.tipo = manejadorRegistrarExamenGeneral.crearTipoPracticaComplementaria(id_tipo, nombre);
                practicaComplementaria.fechaSolicitud = Convert.ToDateTime(mtbFechaDiagnostico.Text);
                listaPracticasComplementarias.Add(practicaComplementaria);

                dgvExamenesARealizar.Rows.Add(nombre, indicaciones);
            }
        }

        private void TxtValorTemperatura1_TextChanged(object sender, EventArgs e)
        {
            //Regex r = new Regex("[0-9]"); "\\d+(,\\d+)?"
            // Regex r = new Regex("^-?\\d+(?:,\\d+)?$");
            //if (!string.IsNullOrEmpty(txtValorTemperatura1.Text) && !r.IsMatch(txtValorTemperatura1.Text))
            //{
            //    MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura1))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorTemperatura1.Focus();
                return;
            }


            if (!string.IsNullOrEmpty(txtValorTemperatura1.Text))
            {
                float valor = float.Parse(txtValorTemperatura1.Text);
                txtResultadoTemperatura1.Text = Convert.ToString(manejadorRegistrarExamenGeneral.mostrarClasificacionTemperatura(valor));
            }
            
        }
       
        private void txtValorTemperatura2_TextChanged(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura2))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorTemperatura2.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtValorTemperatura2.Text))
            {
                float valor = float.Parse(txtValorTemperatura2.Text);
                txtResultadoTemperatura2.Text = Convert.ToString(manejadorRegistrarExamenGeneral.mostrarClasificacionTemperatura(valor));
            }
        }

        private void txtValorTemperatura3_TextChanged(object sender, EventArgs e)
        {

            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura3))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorTemperatura3.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtValorTemperatura3.Text))
            {
                float valor = float.Parse(txtValorTemperatura3.Text);
                txtResultadoTemperatura3.Text = Convert.ToString(manejadorRegistrarExamenGeneral.mostrarClasificacionTemperatura(valor));
            }
        }

        private void txtValorTemperatura4_TextChanged(object sender, EventArgs e)
        {

            if (!Utilidades.ValidarCampoNumerico(txtValorTemperatura4))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorTemperatura4.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtValorTemperatura4.Text))
            {
                float valor = float.Parse(txtValorTemperatura4.Text);
                txtResultadoTemperatura4.Text = Convert.ToString(manejadorRegistrarExamenGeneral.mostrarClasificacionTemperatura(valor));
            }
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelarAtencionEnConsultorio_Click(object sender, EventArgs e)
        {
            cancelarAtencionEnConsultorio();
        }
        public void cancelarAtencionEnConsultorio()
        {
            if (MessageBox.Show("Está seguro que desea cancelar la atención en consultorio?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                borrarDatosComponentesAtencionConsultorio();
            }
        }
        public void borrarDatosComponentesAtencionConsultorio()
        {
            txtNroConsulta.Clear();
            mtbFechaConsulta.Clear();
            mtbHoraConsulta.Clear();
            txtMotivoConsulta.Clear();
            cboQueSienteElPaciente.SelectedIndex = 0;
            txtDescQueSientePaciente.Clear();
            cboQueSienteElPaciente.SelectedIndex = 0;
            cboCaracterDolor.SelectedIndex = 0;
            txtHaciaDondeIrradia.Clear();
            cboCuandoComenzo.SelectedIndex = 0;
            cboComoModificaSintoma.SelectedIndex = 0;
            cboElementoModificacion.SelectedIndex = 0;
            mtbFechaComienzoSintoma.Clear();
            txtCantTiempoInicioSintoma.Clear();
            cboElementoTiempo.SelectedIndex = 0;
            txtObservacionesSintoma.Clear();

            txtPosicionYDecubito.Clear();
            txtMarchaYDeambulacion.Clear();
            txtFacieOExpresióndeFisonomia.Clear();
            txtConsistenciaYEstadoPsiquico.Clear();
            txtConstitucionYEstadoNutritivo.Clear();
            txtPeso.Clear();
            txtAltura.Clear();

            txtColorPiel.Clear();
            txtElasticidadPiel.Clear();
            txtHumedadPiel.Clear();
            txtUntuosidadPiel.Clear();
            txtTurgorPiel.Clear();
            txtLesionesPiel.Clear();
            cboTemperaturaPiel.SelectedIndex = 0;

            cboUbicacionGanglio.SelectedIndex = 0;
            cboTamañoGanglio.SelectedIndex = 0;
            cboAproximacionNumerica.SelectedIndex = 0;
            cboConsistencia.SelectedIndex = 0;
            txtDescripcion.Clear();
            chbSensiblePalpacion.Checked = false;
            chbProcesoInflamatorio.Checked = false;
            txtLesionCompromisoGangleo.Clear();
            txtObservaciones.Clear();
            dgvRegionesEstudiadas.Rows.Clear();

            cboPulso1.SelectedIndex = 0;
            cboPI1.SelectedIndex = 0;
            cboPD1.SelectedIndex = 0;

            cboPulso2.SelectedIndex = 0;
            cboPI2.SelectedIndex = 0;
            cboPD2.SelectedIndex = 0;

            cboPulso3.SelectedIndex = 0;
            cboPI3.SelectedIndex = 0;
            cboPD3.SelectedIndex = 0;

            cboPulso4.SelectedIndex = 0;
            cboPI4.SelectedIndex = 0;
            cboPD4.SelectedIndex = 0;

            cboPulso5.SelectedIndex = 0;
            cboPI5.SelectedIndex = 0;
            cboPD5.SelectedIndex = 0;

            cboPulso6.SelectedIndex = 0;
            cboPI6.SelectedIndex = 0;
            cboPD6.SelectedIndex = 0;

            cboPulso7.SelectedIndex = 0;
            cboPI7.SelectedIndex = 0;
            cboPD7.SelectedIndex = 0;

            cboPulso8.SelectedIndex = 0;
            cboPI8.SelectedIndex = 0;
            cboPD8.SelectedIndex = 0;

            txtAuscultacionPulsos.Clear();
            txtObservacionesPulsoArterial.Clear();

            txtDescripcionRespiracion.Clear();
            txtObservacionesRespiracion.Clear();

            cboSitioMedicion1.SelectedIndex = 0;
            txtValorTemperatura1.Clear();
            txtResultadoTemperatura1.Clear();

            cboSitioMedicion2.SelectedIndex = 0;
            txtValorTemperatura2.Clear();
            txtResultadoTemperatura2.Clear();

            cboSitioMedicion3.SelectedIndex = 0;
            txtValorTemperatura3.Clear();
            txtResultadoTemperatura3.Clear();

            cboSitioMedicion4.SelectedIndex = 0;
            txtValorTemperatura4.Clear();
            txtResultadoTemperatura4.Clear();

            cmbExtremidadPresionArterial.SelectedIndex = 0;
            cmbPosicionPresionArterial.SelectedIndex = 0;
            cmbSitioMedicionPresionArterial.SelectedIndex = 0;
            cmbUbicacionPresionArterial.SelectedIndex = 0;
            cmbMomentoDiaPresionArterial.SelectedIndex = 0;
            txtSistolicaPresionArterial.Clear();
            txtDiastolicaPresionArterial.Clear();
            txtPulsoPresionArterial.Clear();
            dgvPresionArterial.Rows.Clear();

            txtConceptoInicial.Clear();
            txtDiagnostico.Clear();
            cboEstadoDiagnostico.SelectedIndex = 0;
            mtbFechaDiagnostico.Clear();
            txtMotivoDiagnostico.Clear();
            cboEstudioARealizar.SelectedIndex = 0;
            txtIndicacionesEstudioARealizar.Clear();
            cboAnalisiLaboratorioARealizar.SelectedIndex = 0;
            txtIndicacionesAnalisisARealizar.Clear();
            cboPracticasComplementariasARealizar.SelectedIndex = 0;
            txtIndicacionesPracticasComplementarias.Clear();
            dgvExamenesARealizar.Rows.Clear();
            dgvDiagnosticos.Rows.Clear();



        }

        private void generarNuevaConsultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (manejadorRegistrarAtencionMedicaEnConsultorio == null)
                manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();

            if (manejadorRegistrarExamenGeneral == null)
                manejadorRegistrarExamenGeneral = new ManejadorRegistrarExamenGeneral();

            if (manejadorRegistrarAtencionMedicaEnConsultorio == null)
                manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();


            generarNuevaConsulta();
            cargarDatosDeEjemplo();
            medicionesAutomaticaConExamenGeneral = true;
 
            chbNuevoDiagnostico.Checked = true;
        }

        private void registrarAnálisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Análisis_de_Laboratorio formAnalisis = new Registrar_Análisis_de_Laboratorio();
            formAnalisis.ShowDialog();
        }

        private void btnBuscarPracticasPendientes_Click(object sender, EventArgs e)
        {
            Utilidades.limpiarGrilla(dgvDiagnosticosPaciente);
            Utilidades.limpiarGrilla(dgvEstudiosPendientes);
            Utilidades.limpiarGrilla(dgvPracticasPendientes);
            Utilidades.limpiarGrilla(dgvAnalisisLaboratorioPendientes);
            if (pacienteSeleccionado==null)
            {
                MessageBox.Show("Falta seleccionar un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                hc = consultarHistoriaClinica(pacienteSeleccionado);
               
                if (hc == null)
                {
                    MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            /*Primero Buscar los diagnosticos del paciente con estado Tentativo
             Segundo Mostrar en la grilla la lista de diagnosticos
             Tercero al seleccionar en la grilla de diagnósticos una fila, listar en las grillas los estudio, análisis y prácticas. Además completar los compos con los datos del diagnóstico.*/
            

            
            if(manejadorModificarEstadoDiagnostico==null)
                manejadorModificarEstadoDiagnostico = new ManejadorModificarEstadoDiagnostico();

            mtbFechaCambioEstadoDiagnostico.Text = DateTime.Now.ToShortDateString();

            List<RazonamientoDiagnostico> diagnosticos = manejadorModificarEstadoDiagnostico.presentarDiagnosticos(hc.id_hc);

            if (diagnosticos.Count == 0)
            {
                Utilidades.mostrarFilaNoSeEncontraronResultados(dgvDiagnosticosPaciente);
            }
            else
            {
                cargarGrillaDiagnosticos(diagnosticos);

                Utilidades.cargarCombo(cboEstadoDiagnosticoCambio, manejadorModificarEstadoDiagnostico.presentarEstadoDiagnostico(), "id_EstadoDiagnostico", "nombre");
                estadoInicial = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;
            }
        }
        private void cargarGrillaDiagnosticos(List<RazonamientoDiagnostico> diagnosticos)
        {
            Utilidades.limpiarGrilla(dgvDiagnosticosPaciente);
            dgvDiagnosticosPaciente.Columns.Clear();

            List<string> columnasDiagnosticos = new List<string>();
            if (dgvDiagnosticosPaciente.Columns.Count == 0)
            {
                columnasDiagnosticos.Add("Diagnóstico");
                columnasDiagnosticos.Add("idRazonamiento");
                columnasDiagnosticos.Add("idEstado");
                columnasDiagnosticos.Add("conceptoInicial");
                columnasDiagnosticos.Add("id_diagnostico");
                columnasDiagnosticos.Add("Estado");
            }
            Utilidades.agregarColumnasDataGridView(dgvDiagnosticosPaciente, columnasDiagnosticos);

            //Utilidades.AgregarColumnasDataGridViewColumnaCheck(dgvDiagnosticosPaciente, columnasDiagnosticos);

            if(dgvDiagnosticosPaciente.Columns.Count > 1)
            {
                dgvDiagnosticosPaciente.Columns[1].Visible = false;
                dgvDiagnosticosPaciente.Columns[2].Visible = false;
                dgvDiagnosticosPaciente.Columns[3].Visible = false;
                dgvDiagnosticosPaciente.Columns[4].Visible = false;

                for (int i = 0; i < diagnosticos.Count; i++)
                {
                    dgvDiagnosticosPaciente.Rows.Add(diagnosticos[i].diagnostico, diagnosticos[i].id_razonamiento, diagnosticos[i].id_estadoDiagnostico, diagnosticos[i].conceptoInicial, diagnosticos[i].id_razonamiento, diagnosticos[i].estado.nombre);
                }
            }
        }
        private void cargarGrillaDiagnosticos(List<RazonamientoDiagnostico> diagnosticos, DataGridView dgv)
        {

            List<string> columnasDiagnosticos = new List<string>();
            if (dgv.Columns.Count == 0)
            {
                //columnasDiagnosticos.Add("Seleccionado");
                columnasDiagnosticos.Add("Diagnóstico");
                columnasDiagnosticos.Add("Estado");
                columnasDiagnosticos.Add("idRazonamiento");
                columnasDiagnosticos.Add("idEstado");
                columnasDiagnosticos.Add("conceptoInicial");
                columnasDiagnosticos.Add("id_diagnostico");
                
            }
            Utilidades.agregarColumnasDataGridView(dgv, columnasDiagnosticos);
            //Utilidades.AgregarColumnasDataGridViewColumnaCheck(dgv, columnasDiagnosticos);

            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;

            for (int i = 0; i < diagnosticos.Count; i++)
            {
                dgv.Rows.Add(diagnosticos[i].diagnostico, diagnosticos[i].estado.nombre, diagnosticos[i].id_razonamiento, diagnosticos[i].id_estadoDiagnostico, diagnosticos[i].conceptoInicial, diagnosticos[i].id_razonamiento);
            }

        }
        private void cargarEnGrillaPracticasComplementarias<T>(List<T> lista)
        {
            if(lista.Count==0)
            {
                return;
            }
            string tipo = Convert.ToString(lista[0].GetType());
            switch (tipo)
            {
                case "Entidades.Clases.EstudioDiagnosticoPorImagen":
                    foreach (object obj in lista)
                    {
                        EstudioDiagnosticoPorImagen estudio = (EstudioDiagnosticoPorImagen)obj;
                        dgvEstudiosPendientes.Rows.Add(estudio.nombreEstudio.nombre, estudio.fechaSolicitud, estudio.indicaciones,estudio.id_estudioDiagnosticoPorImagen);
                    }
                    break;
                case "Entidades.Clases.PracticaComplementaria":
                    foreach (object obj in lista)
                    {
                        PracticaComplementaria practica = (PracticaComplementaria)obj;
                        dgvPracticasPendientes.Rows.Add(practica.tipo.nombre, practica.fechaSolicitud, practica.indicaciones,practica.id_PracticaComplementaria);
                    }
                    break;
                case "Entidades.Clases.Laboratorio":
                    foreach (object obj in lista)
                    {
                        Laboratorio laboratorio = (Laboratorio)obj;
                        dgvAnalisisLaboratorioPendientes.Rows.Add(laboratorio.analisis.nombre, laboratorio.fechaSolicitud, laboratorio.indicaciones, laboratorio.id_laboratorio);
                    }
                    break;
                case "Entidades.Clases.Tratamiento":
                    foreach (object obj in lista)
                    {
                        Tratamiento tratamiento = (Tratamiento)obj;
                        dgvTratamientosDiagnostico.Rows.Add(0,tratamiento.id_tratamiento, tratamiento.fechaInicio, tratamiento.indicaciones, tratamiento.terapia.id_terapia, tratamiento.terapia.nombre);
                    }
                    break;
            }
           
            
        }
        private void cargarColumnasGrillasTratamientos()
        {

            List<string> columnasEstudios = new List<string>();

            if (dgvTratamientosDiagnostico.Columns.Count == 0 )
            {
                columnasEstudios.Add("Cancelar");
                columnasEstudios.Add("IdTratamiento");
                columnasEstudios.Add("Fecha de Inicio");
                columnasEstudios.Add("Indicaciones");
                columnasEstudios.Add("idTerapia");
                columnasEstudios.Add("Terapia");
            }

          

            Utilidades.AgregarColumnasDataGridViewColumnaCheck(dgvTratamientosDiagnostico, columnasEstudios);

            dgvTratamientosDiagnostico.Columns[1].Visible = false;
            dgvTratamientosDiagnostico.Columns[4].Visible = false;
            dgvTratamientosDiagnostico.Columns[3].Width = 500;
            dgvTratamientosDiagnostico.Columns[5].Width = 500;
        }
        private void cargarColumnasGrillasPracticasDeDiagnostico()
        {
            
            List<string> columnasEstudios = new List<string>();

            if (dgvEstudiosPendientes.Columns.Count == 0 || dgvAnalisisLaboratorioPendientes.Columns.Count == 0 || dgvPracticasPendientes.Columns.Count == 0)
            {
                columnasEstudios.Add("Nombre del Estudio");
                columnasEstudios.Add("Fecha de Solicitud");
                columnasEstudios.Add("Indicaciones");
                columnasEstudios.Add("idEstudio");
            }

            Utilidades.agregarColumnasDataGridView(dgvEstudiosPendientes, columnasEstudios);

            Utilidades.agregarColumnasDataGridView(dgvAnalisisLaboratorioPendientes, columnasEstudios);

            Utilidades.agregarColumnasDataGridView(dgvPracticasPendientes, columnasEstudios);

            dgvEstudiosPendientes.Columns[3].Visible = false;
            dgvAnalisisLaboratorioPendientes.Columns[3].Visible = false;
        }

        private void dgvDiagnosticosPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Utilidades.limpiarGrilla(dgvEstudiosPendientes);
            Utilidades.limpiarGrilla(dgvAnalisisLaboratorioPendientes);
            Utilidades.limpiarGrilla(dgvPracticasPendientes);
            Utilidades.limpiarGrilla(dgvTratamientosDiagnostico);

            if (dgvDiagnosticosPaciente.CurrentRow.Cells[0].Value==null || string.IsNullOrEmpty(dgvDiagnosticosPaciente.CurrentRow.Cells[0].Value.ToString()))
                return;
            if (dgvDiagnosticosPaciente.ColumnCount <= 1)
                return;

            txtDiagnosticoCambiarEstado.Text = dgvDiagnosticosPaciente.CurrentRow.Cells[0].Value.ToString();
            cboEstadoDiagnosticoCambio.SelectedIndex =((int) dgvDiagnosticosPaciente.CurrentRow.Cells[2].Value) - 1;
            txtConceptoInicialExamen.Text = dgvDiagnosticosPaciente.CurrentRow.Cells[3].Value.ToString();

            if (manejadorModificarEstadoDiagnostico == null)
                manejadorModificarEstadoDiagnostico = new ManejadorModificarEstadoDiagnostico();

             cargarColumnasGrillasPracticasDeDiagnostico();
             cargarColumnasGrillasTratamientos();

             List<EstudioDiagnosticoPorImagen> estudios= manejadorModificarEstadoDiagnostico.presentarEstudiosDiagnosticoPorImagen((int)dgvDiagnosticosPaciente.CurrentRow.Cells[1].Value);
             cargarEnGrillaPracticasComplementarias(estudios);

             List<PracticaComplementaria> practicas = manejadorModificarEstadoDiagnostico.presentarPracticaComplementaria((int)dgvDiagnosticosPaciente.CurrentRow.Cells[1].Value);
             cargarEnGrillaPracticasComplementarias(practicas);

             List<Laboratorio> analisis = manejadorModificarEstadoDiagnostico.presentarAnalisisLaboratorio((int)dgvDiagnosticosPaciente.CurrentRow.Cells[1].Value);
             cargarEnGrillaPracticasComplementarias(analisis);

            try
            {
                List<Tratamiento> tratamientos = manejadorModificarEstadoDiagnostico.presentarTratamientos((int)dgvDiagnosticosPaciente.CurrentRow.Cells[1].Value);
                cargarEnGrillaPracticasComplementarias(tratamientos);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al consultar los tratamientos en la grilla. Error: " + ex.Message, "Tratamientos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if(estadoInicial == null)
            //    estadoInicial = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;
        }

        private void dgvEstudiosPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string nombreEstudio = (string)dgvEstudiosPendientes.CurrentRow.Cells[0].Value;
            DateTime fechaSolicitud = (DateTime)dgvEstudiosPendientes.CurrentRow.Cells[1].Value;
            string indicaciones = (string)dgvEstudiosPendientes.CurrentRow.Cells[2].Value;
            int idEstudio = (int)dgvEstudiosPendientes.CurrentRow.Cells[3].Value;

            NombreEstudio nombre = manejadorModificarEstadoDiagnostico.crearNombreEstudio(nombreEstudio);
            EstudioDiagnosticoPorImagen estudio = manejadorModificarEstadoDiagnostico.crearEstudio(nombre, fechaSolicitud, indicaciones, idEstudio);

            RegistrarEstudio re = new RegistrarEstudio(estudio);
            re.Text = "Registrar informe estudio de diagnóstico por imagen.";
            if (re.ShowDialog() == DialogResult.OK)
            {
                estudio = re.estudio;
                if (listaEstudioDiagnosticoImagenConInforme == null)
                    listaEstudioDiagnosticoImagenConInforme = new List<EstudioDiagnosticoPorImagen>();

                listaEstudioDiagnosticoImagenConInforme.Add(estudio);
            }
        }

        private void dgvPracticasPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = (string)dgvPracticasPendientes.CurrentRow.Cells[0].Value;
            TipoPracticaComplementaria tipo = manejadorModificarEstadoDiagnostico.crearTipoPracticaComplementaria(nombre);

            DateTime fechaSolicitud = (DateTime)dgvPracticasPendientes.CurrentRow.Cells[1].Value;
            string indicaciones = (string)dgvPracticasPendientes.CurrentRow.Cells[2].Value;
            int idPractica = (int)dgvPracticasPendientes.CurrentRow.Cells[3].Value;
            string observacopnes = txtObservaciones.Text;
            PracticaComplementaria practica = manejadorModificarEstadoDiagnostico.crearPracticaComplementaria(tipo, fechaSolicitud, indicaciones, idPractica, observacopnes);

            RegistrarEstudio re = new RegistrarEstudio(practica);

            re.Text = "Registrar informe de práctica complementaria.";
            if (re.ShowDialog() == DialogResult.OK)
            {
                practica = re.practica;
                if (listaPracticasConInforme == null)
                    listaPracticasConInforme = new List<PracticaComplementaria>();

                listaPracticasConInforme.Add(practica);
            }
        }

        private void dgvAnalisisLaboratorioPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            string analisis = (string)dgvAnalisisLaboratorioPendientes.CurrentRow.Cells[0].Value;
            DateTime fecha= (DateTime) dgvAnalisisLaboratorioPendientes.CurrentRow.Cells[1].Value;
            string indicaciones = (string)dgvAnalisisLaboratorioPendientes.CurrentRow.Cells[2].Value;
            int id = (int)dgvAnalisisLaboratorioPendientes.CurrentRow.Cells[3].Value;
            Laboratorio laboratorio = manejadorModificarEstadoDiagnostico.crearLaboratorio(id,analisis,fecha,indicaciones);
            
            RegistrarLaboratorio registroAnalisis = new RegistrarLaboratorio(laboratorio);

            if (registroAnalisis.ShowDialog() == DialogResult.OK)
            {
                laboratorio=registroAnalisis.laboratorio;
                if (listaLaboratorioConInforme == null)
                    listaLaboratorioConInforme = new List<Laboratorio>();

                listaLaboratorioConInforme.Add(laboratorio);
            }
        }

        private void btnAceptarDiagnostico_Click(object sender, EventArgs e)
        {   
            if(dgvDiagnosticosPaciente.Rows.Count == 0 && String.IsNullOrEmpty(txtConceptoInicialExamen.Text) && String.IsNullOrEmpty(txtDiagnosticoCambiarEstado.Text)
                && String.IsNullOrEmpty(txtMotivoCambioEstado.Text) && cboEstadoDiagnosticoCambio.SelectedIndex == -1 && dgvEstudiosPendientes.Rows.Count ==0
                && dgvAnalisisLaboratorioPendientes.Rows.Count ==0 && dgvPracticasPendientes.Rows.Count == 0 && dgvTratamientosDiagnostico.Rows.Count == 0
                || (dgvDiagnosticosPaciente.Rows.Count == 1 && string.IsNullOrEmpty(Convert.ToString(dgvDiagnosticosPaciente.Rows[0].Cells[0].Value))))
            {
                return;
            }
            EstadoDiagnostico estado = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;
            EvolucionDiagnostico evolucionDiagnostico = new EvolucionDiagnostico();

            diagnosticoSeleccionado = new RazonamientoDiagnostico();//Crear un objeto diagnostico a partir de los datos anteriores.
            diagnosticoSeleccionado.id_razonamiento = (int)dgvDiagnosticosPaciente.CurrentRow.Cells[1].Value;

            diagnosticoSeleccionado.id_estadoDiagnostico = estado.id_estado;

            if (cambioEstadoDiagnostico == false)
            {
                MessageBox.Show("No hay diagnósticos seleccionados. Para continuar seleccione uno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(RazonamientoDiagnosticoLN.ExisteEstadoRazonamiento(diagnosticoSeleccionado.id_razonamiento, estado.id_estado) && (listaEstudioDiagnosticoImagenConInforme == null || listaEstudioDiagnosticoImagenConInforme.Count == 0) && (listaLaboratorioConInforme == null || listaLaboratorioConInforme.Count == 0) && (listaPracticasConInforme == null || listaPracticasConInforme.Count == 0) && (tratamientosACancelar== null || tratamientosACancelar.Count == 0))
            {
                MessageBox.Show("El estado del diagnostico no modificó y no se agregaron estudios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
         
             
             switch (estado.nombre)
             {
                 case "Tentativo":
                     diagnosticoSeleccionado.motivoTentativo = txtMotivoCambioEstado.Text;
                     diagnosticoSeleccionado.fechaTentativo = Convert.ToDateTime(mtbFechaCambioEstadoDiagnostico.Text);
                     break;
                 case "Definitivo":
                     diagnosticoSeleccionado.motivoConfirmado = txtMotivoCambioEstado.Text;
                     diagnosticoSeleccionado.fechaConfirmado = Convert.ToDateTime(mtbFechaCambioEstadoDiagnostico.Text);
                     break;
                 case "Descartado":
                     diagnosticoSeleccionado.motivoDescartado = txtMotivoCambioEstado.Text;
                     diagnosticoSeleccionado.fechaDescartado = Convert.ToDateTime(mtbFechaCambioEstadoDiagnostico.Text);
                     break;
             }
             if(listaEstudioDiagnosticoImagenConInforme!=null && listaEstudioDiagnosticoImagenConInforme.Count>0)
                 diagnosticoSeleccionado.estudios = listaEstudioDiagnosticoImagenConInforme;

             if(listaLaboratorioConInforme!=null && listaLaboratorioConInforme.Count>0)
                 diagnosticoSeleccionado.analisis = listaLaboratorioConInforme;

             if(listaPracticasConInforme!=null && listaPracticasConInforme.Count>0)
                 diagnosticoSeleccionado.practicas = listaPracticasConInforme;

            if (tratamientosACancelar != null && tratamientosACancelar.Count > 0)
                diagnosticoSeleccionado.tratamientosACancelar = tratamientosACancelar;


            evolucionDiagnostico.diagnostico = diagnosticoSeleccionado;
            evolucionDiagnostico.idHc = hc.id_hc;

            try
            {
                EvolucionDiagnosticoLN.insertEvolucionDiagnostico(evolucionDiagnostico);
                Utilidades.limpiarGrilla(dgvDiagnosticosPaciente);
                Utilidades.limpiarGrilla(dgvEstudiosPendientes);
                Utilidades.limpiarGrilla(dgvPracticasPendientes);
                Utilidades.limpiarGrilla(dgvAnalisisLaboratorioPendientes);
                Utilidades.limpiarGrilla(dgvTratamientosDiagnostico);
                txtMotivoCambioEstado.Clear();
            }
            catch(Exception excepcion)
            {
                MessageBox.Show("Error al actualiza informacion del diagnóstico. Error: " + excepcion.Message, "Atención en consultorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }

        private void btnAñadirQueSientePaciente_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Actualizar tipo de síntoma";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarTipoSintomas();
            }
        }

        private void btnParteDelCuerpoSintoma_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Actualizar parte del cuerpo donde presenta el síntoma";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarParteDelCuerpo();
            }
        }

        private void registroDesdeTensiómetroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No se seleccionó el paciente que recibe atención médica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (medicionesAutomaticaConExamenGeneral==false)
            {
                if (hc == null)
                {
                    hc = consultarHistoriaClinica(pacienteSeleccionado);
                }

                if (hc != null)
                {
                    RegistrarMedicionesAutomaticamente rma = new RegistrarMedicionesAutomaticamente(hc.id_hc);
                    rma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El paciente no tiene historia clínica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                RegistrarMedicionesAutomaticamente rma = new RegistrarMedicionesAutomaticamente();
                if (rma.ShowDialog() == DialogResult.OK)
                {
                    manejadorRegistrarExamenGeneral.medicion = rma.getMedicion();
                    btnAgregarPresionArterial.Enabled = false;
                }
            }
              

        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void cboEstadoDiagnosticoCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cambioEstadoDiagnostico = true;
            //estadoInicial = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;
            //if (estadoInicial == null)
            //    estadoInicial = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;

            EstadoDiagnostico estado = (EstadoDiagnostico)cboEstadoDiagnosticoCambio.SelectedItem;
            if (estado.nombre.Equals("--Seleccionar--") || cboEstadoDiagnosticoCambio.SelectedIndex == 0)
            {
                cambioEstadoDiagnostico = false;
            }
            else
            {
                cambioEstadoDiagnostico = true;
            }
        }

        private void btnCancelarDiagnostico_Click(object sender, EventArgs e)
        {
            Utilidades.limpiarGrilla(dgvDiagnosticosPaciente);
            Utilidades.limpiarGrilla(dgvEstudiosPendientes);
            Utilidades.limpiarGrilla(dgvPracticasPendientes);
            Utilidades.limpiarGrilla(dgvAnalisisLaboratorioPendientes);
            Utilidades.limpiarGrilla(dgvTratamientosDiagnostico);
            txtMotivoCambioEstado.Clear();
        }

        private void txtConceptoInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbNuevoDiagnostico_CheckedChanged(object sender, EventArgs e)
        {
            List<RazonamientoDiagnostico> diagnosticos = null;

            if (hc == null)
                return;

            if (chbNuevoDiagnostico.Checked == false)
            {
                Utilidades.limpiarGrilla(dgvDiagnosticos);
                dgvDiagnosticos.Columns.Clear();

                cboEstadoDiagnostico.Enabled = false;

                if (manejadorModificarEstadoDiagnostico == null)
                    manejadorModificarEstadoDiagnostico = new ManejadorModificarEstadoDiagnostico();

                    diagnosticos = manejadorModificarEstadoDiagnostico.presentarDiagnosticos(hc.id_hc);

                if (diagnosticos.Count == 0)
                {
                    Utilidades.mostrarFilaNoSeEncontraronResultados(dgvDiagnosticos);
                }
                else
                {
                    cargarGrillaDiagnosticos(diagnosticos, dgvDiagnosticos);
                }
            }
            else
            {
               // Utilidades.limpiarGrilla(dgvDiagnosticos);
                dgvDiagnosticos.Columns.Clear();

                cboEstadoDiagnostico.Enabled = true;

                diagnosticos = null;
                List<String> columnasGrillaDiagnosticos = new List<string>();
                columnasGrillaDiagnosticos.Add("Diagnósticos");

                Utilidades.agregarColumnasDataGridView(dgvDiagnosticos, columnasGrillaDiagnosticos);
            }
        }

        private void actualizarAnalisisLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarAnalisisLaboratorio actualizarAnalisis = new ActualizarAnalisisLaboratorio();
            actualizarAnalisis.ShowDialog();
        }

        private void actualizarMétodoAnalisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarMetodoAnalisisLaboratorio actualizarMetodoAnalisis = new ActualizarMetodoAnalisisLaboratorio();
            actualizarMetodoAnalisis.ShowDialog();
        }

        private void dgvTratamientosDiagnostico_Click(object sender, EventArgs e)
        {
            //Tratamiento tratamientoACancelar = null;
            //List<Tratamiento> tratamientosACancelar = new List<Tratamiento>();
            //int id;
            ////Boolean estaSeleccionada=(bool)dgvTratamientosDiagnostico.Rows[e.].Cells[0].Value;

            //foreach (DataGridViewRow r in dgvTratamientosDiagnostico.Rows)
            //{
            //    id = dgvTratamientosDiagnostico.Rows.IndexOf(r);
            //    bool isChecked = Convert.ToBoolean(r.Cells["Cancelar"].Value);
            //    if (isChecked)
            //    {

            //        MotivoFinTratamiento re = new MotivoFinTratamiento();
            //       // re.Text = "Registrar informe estudio de diagnóstico por imagen.";
            //        if (re.ShowDialog() == DialogResult.OK)
            //        {
            //            tratamientoACancelar= re.tratamiento;
            //            tratamientoACancelar.id_tratamiento = Convert.ToInt32(dgvTratamientosDiagnostico.Rows[id].Cells[0].Value);
            //            tratamientosACancelar.Add(tratamientoACancelar);
            //        }
            //    }
            //}
        }

        private void dgvTratamientosDiagnostico_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTratamientosDiagnostico.IsCurrentCellDirty)
            {
                dgvTratamientosDiagnostico.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvTratamientosDiagnostico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)dgvDiagnosticos.Rows[e.RowIndex].Cells[0];

            Boolean isCellChecked = Convert.ToBoolean( dgvTratamientosDiagnostico.Rows[e.RowIndex].Cells[0].Value);
            Tratamiento tratamientoACancelar = null;
            if(tratamientosACancelar ==null)
                tratamientosACancelar = new List<Tratamiento>();

            if (isCellChecked)
            {
                //System.Diagnostics.Debug.WriteLine("Fila " + e.RowIndex + " seleccionada");
                MotivoFinTratamiento re = new MotivoFinTratamiento();
                // re.Text = "Registrar informe estudio de diagnóstico por imagen.";
                if (re.ShowDialog() == DialogResult.OK)
                {
                    tratamientoACancelar = re.tratamiento;
                    tratamientoACancelar.id_tratamiento = Convert.ToInt32(dgvTratamientosDiagnostico.Rows[e.RowIndex].Cells[1].Value);
                    tratamientosACancelar.Add(tratamientoACancelar);
                }
            }

            //Tratamiento tratamientoACancelar = null;
            //List<Tratamiento> tratamientosACancelar = new List<Tratamiento>();


            //foreach (DataGridViewRow r in dgvTratamientosDiagnostico.Rows)
            //{
            //    id = dgvTratamientosDiagnostico.Rows.IndexOf(r);
            //    bool isChecked = Convert.ToBoolean(r.Cells["Cancelar"].Value);
            //    if (isChecked)
            //    {

            //        MotivoFinTratamiento re = new MotivoFinTratamiento();
            //        // re.Text = "Registrar informe estudio de diagnóstico por imagen.";
            //        if (re.ShowDialog() == DialogResult.OK)
            //        {
            //            tratamientoACancelar = re.tratamiento;
            //            tratamientoACancelar.id_tratamiento = Convert.ToInt32(dgvTratamientosDiagnostico.Rows[id].Cells[0].Value);
            //            tratamientosACancelar.Add(tratamientoACancelar);
            //        }
            //    }
            //}
        }

        private void registrarMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMedicamento formRegistrarMedicamento = new RegistrarMedicamento();
            formRegistrarMedicamento.ShowDialog();
            ManejadorRegistrarHC manejador = new ManejadorRegistrarHC();
            //pacienteSeleccionado.id_hc=manejador.mostrarIdHc(pacienteSeleccionado.id_tipoDoc, pacienteSeleccionado.nroDoc);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Registrar_Análisis_de_Laboratorio formAnalisis = new Registrar_Análisis_de_Laboratorio();
            formAnalisis.ShowDialog();
        }

        private void btnRegistrarAnalisis_Click(object sender, EventArgs e)
        {
            Registrar_Análisis_de_Laboratorio formAnalisis = new Registrar_Análisis_de_Laboratorio();
            formAnalisis.ShowDialog();
        }
        private void btnAPPersonales_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;
            PresentarAntecedentesPatologicosPersonales();
        }
        public void PresentarAntecedentesPatologicosPersonales()
        {
             crAntecedentesPatologicosPersonales crPatologicosPersonales = new crAntecedentesPatologicosPersonales();
             dsAntecedentesPatologicosPersonales dsPatologicosPersonales = null;
             try
             {
                dsPatologicosPersonales = MostrarAntecedentesPatologicosPersonales(hc.id_hc);
             }
             catch (Exception e)
             {
                 MessageBox.Show("Error al consultar antecedentes patológicos personales: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             try
             {
                 if (dsPatologicosPersonales != null && dsPatologicosPersonales.Tables[0].Rows.Count > 0)
                 {
                    crPatologicosPersonales.SetDataSource(dsPatologicosPersonales);
                   crystalReportViewer1.ReportSource = crPatologicosPersonales;
                   crystalReportViewer1.RefreshReport();
                  }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
             catch (Exception e)
             {
                MessageBox.Show("Error al generar el reporte: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }
        public dsAntecedentesPatologicosPersonales MostrarAntecedentesPatologicosPersonales(int idHc)
        {
            AntecedentePatologicoPersonalDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(AntecedentePatologicoPersonalDAO.getCadenaConexion());
            dsAntecedentesPatologicosPersonales dsAntecedente = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select fechaRegistro as 'Fecha de registro',enfermedades as 'Enfermedades', ISNULL(descripcion_otrasEnfermedades,'N/A') as 'Otras Enfermedades',
                                    hc.nro_hc, pa.nombre+', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', pa.nro_documento as 'NroDocumento', prof.nombre+', '+prof.apellido as 'ProfesionalMedico', 
                                    prof.matricula as 'Matricula',hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion'
                                    from AntecedentesPatologicosPersonales app,Historia_Clinica hc, Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                    where app.id_hc_fk=hc.id_hc 
                                    and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                    and hc.id_nrodoc_paciente_fk=pa.nro_documento
                                    and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
                                    and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
                                    and pa.id_tipoDoc_fk=td.id_tipoDoc 
                                    and app.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsAntecedente = new dsAntecedentesPatologicosPersonales();
                da.Fill(dsAntecedente, "AntecedentesPatologicosPersonales");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsAntecedente;
        }
        private void btnAPFamiliares_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;
            PresentarAntecedentesPatologicosFamiliares();
        }
        public void PresentarAntecedentesPatologicosFamiliares()
        {
            crAntecedentesPatologicosFamiliares cra = new crAntecedentesPatologicosFamiliares();
            dsAntecedentesPatologicosFamiliares dsAntecedentesPatologicosFamiliares = null;
            try
            {
                dsAntecedentesPatologicosFamiliares = MostrarAntecedentesFamiliares(hc.id_hc);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al consultar antecedentes familiares: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dsAntecedentesPatologicosFamiliares.Tables[0].Rows.Count > 0)
            {
                try
                {
                    cra.SetDataSource(dsAntecedentesPatologicosFamiliares);
                    crystalReportViewer1.ReportSource = cra;
                    crystalReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsAntecedentesPatologicosFamiliares MostrarAntecedentesFamiliares(int idHc)
        {
            AntecedenteFamiliarDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(AntecedenteFamiliarDAO.getCadenaConexion());
            dsAntecedentesPatologicosFamiliares DsAntecedentesPatologicosFamiliares = new dsAntecedentesPatologicosFamiliares();
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select convert(date, af.fechaRegistro, 5) as 'fechaRegistro',f.nombre as 'Familiar',af.familiarVive 'Vive',af.enfermedades as 'Enfermedades',ISNULL(af.descripcionOtrasEnfermedades,'N/A') as 'Otras enfermedades',ISNULL(af.causaMuerte,'N/A') as 'Causa de muerte',ISNULL(af.observaciones,'N/A') as 'Observaciones', hc.nro_hc as 'NroHc',hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencionConProfesionalMedico', pa.nombre + ', ' + pa.apellido as 'Paciente', td.nombre as 'DniPaciente',hc.id_nrodoc_paciente_fk as 'NroDocumentoPaciente', prof.nombre + ', '+ prof.apellido as 'ProfesionalMedico', prof.matricula
                                    from AntecedentesFamiliares af,Familiar f,Historia_Clinica hc, Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                    where af.id_familiar_fk=f.id_familiar
                                    and af.id_hc_fk=hc.id_hc
                                    and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                    and hc.id_nrodoc_paciente_fk=pa.nro_documento
                                    and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
                                    and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
                                    and hc.id_tipodoc_paciente_fk=td.id_tipoDoc
                                    and af.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                da.Fill(DsAntecedentesPatologicosFamiliares, "AntecedentesFamiliares");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return DsAntecedentesPatologicosFamiliares;
        }
        private void btnTabaquismo_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc()==false)
                return;

            PresentarHabitosTabaquismo();
        }
        public void PresentarHabitosTabaquismo()
        {
            crHistoriaClinicaHabitosTabaquismo crHabitosTabaquismo = new crHistoriaClinicaHabitosTabaquismo();
            dsHistoriaClinicaHabitosTabaquismo dsHabitosTabaquismo = null;
            try
            {
                dsHabitosTabaquismo = MostrarHabitosTabaquismo(hc.id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar Habitos de Tabaquismo: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dsHabitosTabaquismo.Tables[0].Rows.Count > 0)
            {
                try
                {
                    crHabitosTabaquismo.SetDataSource(dsHabitosTabaquismo);
                    crystalReportViewer1.ReportSource = crHabitosTabaquismo;
                    crystalReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaHabitosTabaquismo MostrarHabitosTabaquismo(int idHc)
        {
            HabitoTabaquismoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(HabitoTabaquismoDAO.getCadenaConexion());
            dsHistoriaClinicaHabitosTabaquismo dsHabitoTabaquismo = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select  ht.fechaRegistro, COALESCE(NULL,CONVERT(varchar,ef2.nombre),'N/A') as 'ElementoQueFuma',
						  COALESCE(NULL,CONVERT(varchar,ht.cantidad),'N/A') as 'CantidadFuma',
						  COALESCE(NULL,CONVERT(varchar,ct2.nombre),'N/A')  as 'UnidadDeTiempoFuma',
						  COALESCE(NULL,CONVERT(varchar, ht.añosFumando),'N/A')  as 'TiempoFumando',
						  COALESCE(NULL,CONVERT(varchar, df.cantidadTiempo),'N/A') as 'TiempoDejoFumar' ,
						  COALESCE(NULL,CONVERT(varchar, et.nombre),'N/A') as 'ElementoTiempoDejoDeFumar',
						  COALESCE(NULL,CONVERT(varchar, df.cantidadFumaba),'N/A') as 'CantidadFumaba',
		                  COALESCE(NULL,CONVERT(varchar, ef.nombre),'N/A') as 'ElementoQueFumaba',
		                  COALESCE(NULL,CONVERT(varchar, ct.nombre),'N/A') as 'ComponenteTiempoFumaba',
						 hc.nro_hc,hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion', pa.nombre + ', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', pa.nro_documento as 'NroDocumento',
						prof.nombre+', '+prof.apellido as 'ProfesionalMedico', prof.matricula as 'Matricula'
                                    from HabitosTabaquismo ht full outer join DejoDeFumar df on ht.id_habitoFumar=df.id_habitoTabaquismo_fk
                                    full outer join ElementoDelTiempo et on df.id_elementoDelTiempo_fk=et.id_elementoDelTiempo
                                    full outer join ElementoQueFuma ef on df.id_elementoQueFuma_fk=ef.id_elemento
                                    full outer join ComponenteDelTiempo ct on df.id_componenteTiempo_fk=ct.id_componenteTiempo
                                    full outer join ElementoQueFuma ef2 on ht.id_elementoQueFuma_fk=ef2.id_elemento
                                    full outer join ComponenteDelTiempo ct2 on ht.id_ComponenteDelTiempo_fk=ct2.id_componenteTiempo
                                    join Historia_Clinica hc on ht.id_hc_fk=hc.id_hc
									join Paciente pa on hc.id_nrodoc_paciente_fk=pa.nro_documento and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                    join ProfesionalMedico prof on hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
								    join TipoDocumento td on pa.id_tipoDoc_fk=td.id_tipoDoc
									where ht.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsHabitoTabaquismo = new dsHistoriaClinicaHabitosTabaquismo();
                da.Fill(dsHabitoTabaquismo, "HabitosTabaquismo");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsHabitoTabaquismo;
        }

        private void btnAlcoholismo_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            PresentarHabitosAlcoholismo();
        }
        public void PresentarHabitosAlcoholismo()
        {
            crHistoriaClinicaHabitosAlcoholismo crHabitosAlcoholismo= new crHistoriaClinicaHabitosAlcoholismo();
            dsHistoriaClinicaHabitosAlcoholismo dsHabitosAlcoholismo = null;
            try
            {
                dsHabitosAlcoholismo = MostrarHabitosAlcoholismo(hc.id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar Habitos de Alcoholismo: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dsHabitosAlcoholismo.Tables[0].Rows.Count > 0)
            {
                try
                {
                    crHabitosAlcoholismo.SetDataSource(dsHabitosAlcoholismo);
                    crystalReportViewer1.ReportSource = crHabitosAlcoholismo;
                    crystalReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static dsHistoriaClinicaHabitosAlcoholismo MostrarHabitosAlcoholismo(int idHc)
        {
            HabitoAlcoholismoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(HabitoAlcoholismoDAO.getCadenaConexion());
            dsHistoriaClinicaHabitosAlcoholismo dsHabitoAlcoholismo = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select ha.fechaRegistro as 'Fecha de registro',tb.nombre as 'Nombre Bebida',m.nombre as 'Medida',m.descripcion as 'Descripcion', ct.nombre as 'Componente del tiempo', ha.cantidad
                                    from HabitosAlcoholismo ha, TipoBebida tb, Medida m, ComponenteDelTiempo ct,Historia_Clinica hc, Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                    where ha.id_hc_fk=hc.id_hc
									and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
									and hc.id_nrodoc_paciente_fk=pa.nro_documento
									and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
									and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
									and pa.id_tipoDoc_fk=td.id_tipoDoc  
									and ha.id_tipoBebida_fk=tb.id_tipoBebida
                                    and m.id_medida=ha.id_medida_fk
                                    and ha.id_componenteTiempo_fk=ct.id_componenteTiempo
                                    and ha.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsHabitoAlcoholismo = new dsHistoriaClinicaHabitosAlcoholismo();
                da.Fill(dsHabitoAlcoholismo, "HabitosAlcoholismo");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsHabitoAlcoholismo;
        }


        private void btnActividadFisica_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;
            PresentarHabitosActividadFisica();
        }
        public void PresentarHabitosActividadFisica()
        {
            crHistoriaClinicaHabitoActividadFisica crActividadFisica = new crHistoriaClinicaHabitoActividadFisica();
            dsHistoriaClinicaHabitoActividadFisica dsActividadFisica = null;
            try
            {
                dsActividadFisica = MostrarHabitosActividadFisica(hc.id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar Habitos de Actividad Física: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dsActividadFisica.Tables[0].Rows.Count > 0)
            {
                try
                {
                    crActividadFisica.SetDataSource(dsActividadFisica);
                    crystalReportViewer1.ReportSource = crActividadFisica;
                    crystalReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaHabitoActividadFisica MostrarHabitosActividadFisica(int idHc)
        {
            HabitoActividadFisicaDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(HabitoActividadFisicaDAO.getCadenaConexion());
            dsHistoriaClinicaHabitoActividadFisica dsActividadFisica = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select haf.fechaRegistro as 'Fecha registro',af.nombre 'Deporte/Actividad',ISNULL(af.descripcion,'N/A') as 'Descripción deporte o actividad',ga.nombre as 'Grado actividad',ga.descripcion as 'Descripcion grado actividad',iaf.nombre as 'Intesidad Actividad Física',
                                    hc.nro_hc, pa.nombre+', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', pa.nro_documento as 'NroDocumento', prof.nombre+', '+prof.apellido as 'ProfesionalMedico', 
                                    prof.matricula as 'Matricula',hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion'
                                    from HabitosActividadFisica haf, ActividadFisica af, GradoActividad ga, IntensidadActividadFisica iaf,Historia_Clinica hc, Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                    where haf.id_actividadFisica_fk=af.id_actividadFisica
                                    and haf.id_gradoActividadFisica_fk=ga.id_gradoActividad
                                    and haf.id_intensidad_fk=iaf.id_intensidad
                                    and haf.id_hc_fk=hc.id_hc
                                    and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                    and hc.id_nrodoc_paciente_fk=pa.nro_documento
                                    and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
                                    and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
                                    and pa.id_tipoDoc_fk=td.id_tipoDoc
                                    and haf.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsActividadFisica = new dsHistoriaClinicaHabitoActividadFisica();
                da.Fill(dsActividadFisica, "HabitosActividadFisica");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsActividadFisica;
        }
        private void dgvConsultas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // presentarConsulta(dgvConsultas);
        }
       
        private void presentarInformacionAntecedentesPatologicos(DataGridView dgv)
        {
            if (dgv.Columns.Count == 1 || dgv.CurrentRow == null)
            {
                return;
            }
            String cadena = null;
            if (verAntecedentesFamiliares ==true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nFamiliar: " + Convert.ToString(dgv.CurrentRow.Cells["Familiar"].Value);
                cadena += "\r\nVive:" + Convert.ToString(dgv.CurrentRow.Cells["Vive"].Value);
                cadena += "\r\nEnfermedades:" + Convert.ToString(dgv.CurrentRow.Cells["Enfermedades"].Value);
                cadena += "\r\nOtras enfermedades:" + Convert.ToString(dgv.CurrentRow.Cells["Otras enfermedades"].Value);
                cadena += "\r\nCausa de muerte:" + Convert.ToString(dgv.CurrentRow.Cells["Causa de muerte"].Value);
                cadena += "\r\nObservaciones:" + Convert.ToString(dgv.CurrentRow.Cells["Observaciones"].Value);
            }
            else if(verAntecedentesPersonales==true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nEnfermedades: " + Convert.ToString(dgv.CurrentRow.Cells["Enfermedades"].Value);
                cadena += "\r\nOtras Enfermedades:" + Convert.ToString(dgv.CurrentRow.Cells["Otras Enfermedades"].Value);
            }

            frmInformacionHistoriaClinica form = new frmInformacionHistoriaClinica(cadena);
            form.ShowDialog();
            form.Dispose();
        }

        private void DrogasIlicitas_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            presentarHabitosDrogasIlicitas();
        }
        private void presentarHabitosDrogasIlicitas()
        {
            crHabitoDrogasIlicitas crDrogasIlicitas = new crHabitoDrogasIlicitas();
            dsHistoriaClinicaHabitosDrogasIlicitas dsDrogasIlicitas = null;
            try
            {
                dsDrogasIlicitas = MostrarHabitosDrogasIlicitas(hc.id_hc);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar habitos drogas Ilícitas: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (dsDrogasIlicitas != null && dsDrogasIlicitas.Tables[0].Rows.Count > 0)
                {
                    crDrogasIlicitas.SetDataSource(dsDrogasIlicitas);
                    crystalReportViewer1.ReportSource = crDrogasIlicitas;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al generar el reporte: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public  dsHistoriaClinicaHabitosDrogasIlicitas MostrarHabitosDrogasIlicitas(int idHc)
        {
            HabitoDrogasIlicitasDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(HabitoDrogasIlicitasDAO.getCadenaConexion());
            dsHistoriaClinicaHabitosDrogasIlicitas dsHabitoDrogaIlicitas = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select hd.fechaRegistro as 'Fecha de registro',s.nombre as 'Sustancia',hd.tiempoConsumiendo as 'Tiempo Consumiendo',et.nombre as 'Unidad de tiempo',
		                            hc.nro_hc, pa.nombre+', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', pa.nro_documento as 'NroDocumento', prof.nombre+', '+prof.apellido as 'ProfesionalMedico', 
		                            prof.matricula as 'Matricula',hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion'
                                    from HabitosDrogasIlicitas hd, Sustancia s, ElementoDelTiempo et, Historia_Clinica hc,Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                    where hd.id_sustancia_fk=s.id_sustancia
                                    and hd.id_ElementoDelTiempo_fk=et.id_elementoDelTiempo
									and hc.id_hc=hd.id_hc_fk
									and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
									and hc.id_nrodoc_paciente_fk=pa.nro_documento
									and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
									and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
									and pa.id_tipoDoc_fk=td.id_tipoDoc
                                    and hc.id_hc=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsHabitoDrogaIlicitas = new dsHistoriaClinicaHabitosDrogasIlicitas();
                da.Fill(dsHabitoDrogaIlicitas, "HabitosDrogasIlicitas");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsHabitoDrogaIlicitas;
        }
        private void presentarInformacionHabitos(DataGridView dgv)
        {
            if (dgv.Columns.Count == 1 || dgv.CurrentRow == null)
            {
                return;
            }
            String cadena = null;
            if (verHabitosDrogaIlicita == true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nSustancia: " + Convert.ToString(dgv.CurrentRow.Cells["Sustancia"].Value);
                cadena += "\r\nTiempo Consumiendo:" + Convert.ToString(dgv.CurrentRow.Cells["Tiempo consumiendo"].Value);
                cadena += "\r\nUnidad de tiempo:" + Convert.ToString(dgv.CurrentRow.Cells["Unidad de tiempo"].Value);
            }
            else if (verHabitosTabaquismo == true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["fechaRegistro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nNombre: " + Convert.ToString(dgv.CurrentRow.Cells["nombre"].Value);
                cadena += "\r\nCantidad:" + Convert.ToString(dgv.CurrentRow.Cells["cantidad"].Value);
                cadena += "\r\nUnidad de tiempo:" + Convert.ToString(dgv.CurrentRow.Cells["Unidad de Tiempo"].Value);
                cadena += "\r\nAños Fumando:" + Convert.ToString(dgv.CurrentRow.Cells["añosFumando"].Value);
            }
            else if (verHabitosAlcoholismo==true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nNombre de la Bebida: " + Convert.ToString(dgv.CurrentRow.Cells["Nombre Bebida"].Value);
                cadena += "\r\nMedida:" + Convert.ToString(dgv.CurrentRow.Cells["Medida"].Value);
                cadena += "\r\nDescripción:" + Convert.ToString(dgv.CurrentRow.Cells["Descripcion"].Value);
                cadena += "\r\nComponente del Tiempo:" + Convert.ToString(dgv.CurrentRow.Cells["Componente del tiempo"].Value);
            }
            else if (verHabitosMedicamentos==true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nNombre Genérico:" + Convert.ToString(dgv.CurrentRow.Cells["Nombre generico"].Value);
                cadena += "\r\nConcentración:" + Convert.ToString(dgv.CurrentRow.Cells["Concentracion"].Value);
                cadena += "\r\nCantidad de comprimidos:" + Convert.ToString(dgv.CurrentRow.Cells["Cantidad de comprimidos"].Value);
                cadena += "\r\nFrecuencia:" + Convert.ToString(dgv.CurrentRow.Cells["Frecuencia"].Value);

                cadena += "\r\n\r\nDosis en el día";
                cadena += "\r\n--------------------------------------------------------------------------";
                cadena += "\r\nMomento del Día:" + Convert.ToString(dgv.CurrentRow.Cells["Momento del dia 1"].Value);
                cadena += "\r\nDosis:" + Convert.ToString(dgv.CurrentRow.Cells["Dosis 1"].Value);
                cadena += "\r\nPresentación Medicamento:" + Convert.ToString(dgv.CurrentRow.Cells["Presentacion medicamento 1"].Value);
                cadena += "\r\nHora:" + Convert.ToString(dgv.CurrentRow.Cells["Hora 1"].Value);
                cadena += "\r\n--------------------------------------------------------------------------";
                cadena += "\r\nMomento del Día:" + Convert.ToString(dgv.CurrentRow.Cells["Momento del dia 2"].Value);
                cadena += "\r\nDosis:" + Convert.ToString(dgv.CurrentRow.Cells["Dosis 2"].Value);
                cadena += "\r\nPresentación Medicamento:" + Convert.ToString(dgv.CurrentRow.Cells["Presentacion medicamento 2"].Value);
                cadena += "\r\nHora:" + Convert.ToString(dgv.CurrentRow.Cells["Hora 2"].Value);
                cadena += "\r\n--------------------------------------------------------------------------";
                cadena += "\r\nMomento del Día:" + Convert.ToString(dgv.CurrentRow.Cells["Momento del dia 3"].Value);
                cadena += "\r\nDosis:" + Convert.ToString(dgv.CurrentRow.Cells["Dosis 3"].Value);
                cadena += "\r\nPresentación Medicamento:" + Convert.ToString(dgv.CurrentRow.Cells["Presentacion medicamento 3"].Value);
                cadena += "\r\nHora:" + Convert.ToString(dgv.CurrentRow.Cells["Hora 3"].Value);
            }
            else if(verHabitosActividadFisica==true)
            {
                DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha registro"].Value);
                cadena = "Fecha de registro: " + Convert.ToString(fecha.ToShortDateString());
                cadena += "\r\nDeporte: " + Convert.ToString(dgv.CurrentRow.Cells["Deporte/Actividad"].Value);
                cadena += "\r\nDescripción: " + Convert.ToString(dgv.CurrentRow.Cells["Descripción deporte o actividad"].Value);
                cadena += "\r\nGrado de actividad:" + Convert.ToString(dgv.CurrentRow.Cells["Grado actividad"].Value);
                cadena += "\r\nDescripción grado de actividad:" + Convert.ToString(dgv.CurrentRow.Cells["Descripcion grado actividad"].Value);
                cadena += "\r\nIntensidad:" + Convert.ToString(dgv.CurrentRow.Cells["Intesidad Actividad Física"].Value);
            }
            frmInformacionHistoriaClinica form = new frmInformacionHistoriaClinica(cadena);
            form.ShowDialog();
            form.Dispose();
        }

        private void dgvHabitos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //presentarInformacionHabitos(dgvHabitos);
        }

        private void consultarMedicionesPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No se seleccionó el paciente que recibe atención médica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (hc == null)
            {
                hc = consultarHistoriaClinica(pacienteSeleccionado);
            }

            if (hc != null)
            {
                ConsultarMedicionesPaciente cmp = new ConsultarMedicionesPaciente(hc.id_hc);
                cmp.ShowDialog();
            }
            else
            {
                MessageBox.Show("El paciente no tiene historia clínica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



        }
        private void btnCaracterDelDolor_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Caracter del dolor";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarCaracterDolor();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Como se Modifica";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarComoModificaSintoma();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Comienzo Síntoma";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarDescripcionTiempo();
            }
        }

        private void btnElementoModificacion_Click(object sender, EventArgs e)
        {
            ActualizarCaracteristicas ac = new ActualizarCaracteristicas();
            ac.Text = "Elemento Modificacion";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                PresentarElementoModificacion();
            }
        }

        private void btnAlergiaMedicamentos_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVerHistoriaClinica_Click_1(object sender, EventArgs e)
        {
            verHistoriaClinica();
        }

        private void btnConsultas_Click_1(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            presentarConsultas();
        }
        public void presentarConsultas()
        {
            crHistoriaClinicaConsultas rhc = new crHistoriaClinicaConsultas();
            dsHistoriaClinicaConsultas dsConsulta = null;
            try
            {
                dsConsulta = MostrarConsultas(hc.id_hc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la información de las consultas: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                if (dsConsulta != null && dsConsulta.Tables[0].Rows.Count > 0)
                {
                    rhc.SetDataSource(dsConsulta);
                    crystalReportViewer1.ReportSource = rhc;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsHistoriaClinicaConsultas MostrarConsultas(int idHc)
        {
            ConsultaDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=DESKTOP-6DMIHKT\SQLEXPRESS;Initial Catalog=SHIART_DB_PRUEBA;Integrated Security=True;Pooling=False";

            dsHistoriaClinicaConsultas dsConsultas = new dsHistoriaClinicaConsultas();

            try
            {
                cn.Open();

                string consulta = @"select c.nroConsulta, c.fechaConsulta, c.horaConsulta,c.motivoConsulta
                                    from Consulta c, Historia_Clinica hc
                                    where hc.id_hc=c.id_hc_fk 
                                    and hc.id_hc=@idHc
                                    order by c.fechaConsulta desc";


                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(dsConsultas,"Consulta");


                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsConsultas;
        }

        private void btnEmbarazosAbortos_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;
            PresentarAntecedentesGineco();
        }
        public void PresentarAntecedentesGineco()
        {
            crHistoriaClinicaAntecedentesGinecoObstetricos crGineco = new crHistoriaClinicaAntecedentesGinecoObstetricos();
            dsAntecedentesGineco dsAntecedentesGineco = new dsAntecedentesGineco();
            try
            {
               dsAntecedentesGineco = MostrarAntecedenteGineco(hc.id_hc);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al consultar Antecedentes Gineco Obstétricos: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            if (dsAntecedentesGineco!=null && dsAntecedentesGineco.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos"].ToString()) == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos"] = "N/A";

                if (dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos prematuros"].ToString().Equals(" con parto de tipo ") == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos prematuros"] = "N/A";

                if (dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos a término"].ToString().Equals(" con parto de tipo ") == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos a término"] = "N/A";

                if (dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos postérmino"].ToString().Equals(" con parto de tipo ") == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de embarazos postérmino"] = "N/A";

                if (string.IsNullOrEmpty(dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de abortos"].ToString()) == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Cantidad de abortos"] = "N/A";

                if (dsAntecedentesGineco.Tables[0].Rows[0]["CantidadTipo1"].ToString().Equals(" Aborto/s ") ==true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["CantidadTipo1"] = "N/A";

                if (dsAntecedentesGineco.Tables[0].Rows[0]["CantidadTipo2"].ToString().Equals(" Aborto/s ") == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["CantidadTipo2"] = "N/A";

                if (string.IsNullOrEmpty(dsAntecedentesGineco.Tables[0].Rows[0]["Número de hijos vivos"].ToString())== true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Número de hijos vivos"] = "N/A";

                if (string.IsNullOrEmpty(dsAntecedentesGineco.Tables[0].Rows[0]["Problemas asociados al embarazo"].ToString()) == true)
                    dsAntecedentesGineco.Tables[0].Rows[0]["Problemas asociados al embarazo"] = "N/A";
                try
                {
                    crGineco.SetDataSource(dsAntecedentesGineco);
                    crystalReportViewer1.ReportSource = crGineco;
                    crystalReportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message + " StackTrace: " + ex.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsAntecedentesGineco MostrarAntecedenteGineco(int idHc)
        {
            AntecedentesGinecoObstetricosDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(AntecedentesGinecoObstetricosDAO.getCadenaConexion());
            SqlDataAdapter da = null;
            dsAntecedentesGineco dsAntecedentesGineco = new dsAntecedentesGineco();
            try
            {
                cn.Open();

                string consulta = @"select ag.fechaRegistro, ag.cantidadEmbarazos as 'Cantidad de embarazos',CONCAT(ag.cantidadEmbarazosPrematuros,' con parto de tipo ',tp1.nombre) as 'Cantidad de embarazos prematuros', CONCAT(ag.cantidadEmbarazosATermino,' con parto de tipo ',tp2.nombre) as 'Cantidad de embarazos a término',CONCAT(ag.cantidadEmbarazosPosTermino,' con parto de tipo ',tp3.nombre) as 'Cantidad de embarazos postérmino', ab.cantidadTotal as 'Cantidad de abortos',CONCAT(ab.cantidadAbortoTipo1,' Aborto/s ',ta2.nombre) as 'CantidadTipo1', CONCAT(ab.cantidadAbortoTipo2,' Aborto/s ',ta2.nombre) as 'CantidadTipo2', ab.nroHijosVivos as 'Número de hijos vivos',ab.problemasAsociadosAlEmbarazo as 'Problemas asociados al embarazo' ,
                                  pa.nombre +', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento',pa.nro_documento as 'NroDocumento',prof.nombre+', '+prof.apellido as 'ProfesionalMedico', prof.matricula as 'Matricula', hc.nro_hc, hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion'
                                  from Historia_Clinica hc full outer join AntecedentesGinecoObstetricos ag on  hc.id_hc=ag.id_hc_fk 
								  full outer join TipoParto tp1 on ag.id_TipoParto1_fk=tp1.id_TipoParto
								  full outer join TipoParto tp2 on ag.id_TipoParto2_fk=tp2.id_TipoParto
								  full outer join TipoParto tp3 on ag.id_TipoParto3_fk=tp3.id_TipoParto
								  full outer join Aborto ab     on ag.id_Aborto_fk=ab.id_aborto
								  full outer join TipoAborto ta1   on ab.id_TipoAborto1_fk=ta1.id_TipoAborto 
								  full outer join TipoAborto ta2   on ab.id_TipoAborto2_fk=ta2.id_TipoAborto
								  join Paciente pa on hc.id_nrodoc_paciente_fk=pa.nro_documento and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
                                  join ProfesionalMedico prof on hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
								  join TipoDocumento td on pa.id_tipoDoc_fk=td.id_tipoDoc
								  where hc.id_hc=@idHc";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                
                da.Fill(dsAntecedentesGineco, "AntecedentesGinecoObstetricos");

                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return dsAntecedentesGineco;
        }

        private void btnAlergias_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            PresentarAlergias();
        }
        private void PresentarAlergias()
        {
            crHistoriaClinicaAlergias crA = new crHistoriaClinicaAlergias();
            dsAlergias dsAlergia = null;
            try
            {
                dsAlergia = MostrarAlegias(hc.id_hc);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar antecedentes alergias: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (dsAlergia != null && dsAlergia.Tables[0].Rows.Count > 0)
                {
                    crA.SetDataSource(dsAlergia);
                    crystalReportViewer1.ReportSource = crA;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al generar el reporte: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public dsAlergias MostrarAlegias(int idHc)
        {
            AlergiaAlimentoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(AlergiaAlimentoDAO.getCadenaConexion());
            dsAlergias dsAlergia = new dsAlergias();
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @"select aa.fechaRegistro as 'Fecha de registro', a.nombre as 'Nombre del alérgeno', aa.efectos as 'Efectos de la alergia',
	                                hc.nro_hc,hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencion', pa.nombre + ', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', pa.nro_documento as 'NroDocumento',
	                                prof.nombre+', '+prof.apellido as 'ProfesionalMedico', prof.matricula as 'Matricula'
                                        from AlergiaAlimento aa,Alimento a, Historia_Clinica hc, Paciente pa, ProfesionalMedico prof, TipoDocumento td
                                        where aa.id_hc_fk=@idHc
                                        and aa.id_alimento_fk=a.id_alimento
										and aa.id_hc_fk=hc.id_hc
										and hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk
										and hc.id_nrodoc_paciente_fk=pa.nro_documento
										and hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk
										and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
										and pa.id_tipoDoc_fk=td.id_tipoDoc
                                        union all
                                        select ai.fechaRegistro as 'Fecha de registro', ins.nombre as 'Nombre del alérgeno', ai.efectos as 'Efectos de la alergia',
										null,null,null,null,null,null,null
                                        from AlergiaInsecto ai, Insecto ins
                                        where ai.id_hc_fk=@idHc
                                        and ai.id_insecto_fk=ins.id_insecto
                                        union all
                                        select am.fechaRegistro as 'Fecha de registro', ma.nombre as 'Nombre del alérgeno', am.efectos as 'Efectos de la alergia',
										null,null,null,null,null,null,null
                                        from AlergiaMedicamento am, MedicamentoAlergia ma
                                        where am.id_hc_fk=@idHc
                                        and am.id_medicamentoAlergia_fk=ma.id_medicamentoAlergia
                                        union all
                                        select asa.fechaRegistro as 'Fecha de registro', sa.nombre as 'Nombre del alérgeno', asa.efectos as 'Efectos de la alergia',
										null,null,null,null,null,null,null
                                        from AlergiaSustanciaAmbiente asa, SustanciaAmbiente sa
                                        where asa.id_hc_fk=@idHc
                                        and asa.id_sustanciaAmbiente_fk=sa.id_sustanciaAmbiente
                                        union all
                                        select ascp.fechaRegistro as 'Fecha de registro', scp.nombre as 'Nombre del alérgeno', ascp.efectos as 'Efectos de la alergia',
										null,null,null,null,null,null,null
                                        from AlergiaSustanciaContactoPiel ascp, SustanciaContactoPiel scp
                                        where ascp.id_hc_fk=@idHc
                                        and ascp.id_sustanciaContactoPiel_fk=scp.id_sustanciaContactoPiel";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                da = new SqlDataAdapter(cmd);

                da.Fill(dsAlergia, "Alergias");
                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dsAlergia;
        }

        private void btnDrogasLicitas_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioYHc() == false)
                return;

            PresentarHabitosMedicamentos();
        }
        private void PresentarHabitosMedicamentos()
        {
            crHistoriaClinicaHabitoMedicamento crHabitoMedicamento = new crHistoriaClinicaHabitoMedicamento();
            dsHistoriaClinicaHabitosMedicamentos dsHabitoMedicamento = null;
            try
            {
                dsHabitoMedicamento = MostrarHabitosMedicamentos(hc.id_hc);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar hábitos de medicamentos: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (dsHabitoMedicamento != null && dsHabitoMedicamento.Tables[0].Rows.Count > 0)
                {
                    crHabitoMedicamento.SetDataSource(dsHabitoMedicamento);
                    crystalReportViewer1.ReportSource = crHabitoMedicamento;
                    crystalReportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontró la información solicitada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al generar el reporte: " + e.Message + " StackTrace: " + e.StackTrace, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static dsHistoriaClinicaHabitosMedicamentos MostrarHabitosMedicamentos(int idHc)
        {
            HabitoMedicamentoDAO.setCadenaConexion();
            SqlConnection cn = new SqlConnection(HabitoMedicamentoDAO.getCadenaConexion());
            dsHistoriaClinicaHabitosMedicamentos dsHabitoMedicamento = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select  hm.id_hc_fk,hm.fechaRegistro as 'Fecha de registro',med.nombreGenerico as 'Nombre generico',em.concentracion as 'Concentracion',em.cantidadComprimidos as 'Cantidad de comprimidos',fe.nombre as 'Frecuencia',COALESCE(NULL,md1.nombre,'N/A') as 'Momento del dia 1',case when CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) END as 'Dosis 1',COALESCE(NULL,prem1.nombre,'N/A') as 'Presentacion medicamento 1',COALESCE(NULL,CONVERT(varchar,pm.hora1),'N/A') as 'Hora 1',COALESCE(NULL,md2.nombre,'N/A') as 'Momento del dia 2',case when CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) END as 'Dosis 2',COALESCE(NULL,prem2.nombre,'N/A') as 'Presentacion Medicamento 2',COALESCE(NULL,CONVERT(varchar,pm.hora2),'N/A') as 'Hora 2', case when CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) = '/' then 'N/A' else CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) END as 'Dosis 3',COALESCE(NULL,prem3.nombre,'N/A') as 'Presentacion Medicamento 3',COALESCE(NULL,CONVERT(varchar,pm.hora3),'N/A') as 'Hora 3',COALESCE(NULL,md3.nombre,'N/A') as 'Momento del Dia 3',unidadM.nombre as 'Unidad de Medica',COALESCE(NULL,pm.motivoConsumo,'N/A') as 'Motivo Consumo', COALESCE(NULL,pm.automedicado,'N/A') as 'Automedicado',COALESCE(NULL,pm.motivoCancelacionConsumo,'N/A') as 'Motivo Cancelación Consumo', hc.nro_hc as 'NroHistoriaClinica', pa.nombre +', '+pa.apellido as 'Paciente', td.nombre as 'TipoDocumento', 
                                    pa.nro_documento as 'NroDocumento', prof.nombre+', '+prof.apellido as 'ProfesionalMedico', prof.matricula, hc.fecha_inicio_atencion_con_profesional as 'FechaInicioAtencionProfesionalMedico'
                                    from HabitosMedicamento hm full outer join ProgramacionMedicamento pm on hm.id_programacionMedicamento_fk=pm.id_programacionMedicamento
                                    full outer join EspecificacionMedicamento em on pm.id_especificacionMedicamento_fk=em.id_especificacion
                                    full outer join Medicamento med on pm.id_medicamento_fk=med.id_medicamento
                                    full outer join Frecuencia fe on  pm.id_frecuencia_fk=fe.id_frecuencia
                                    full outer join MomentoDelDia md1 on  pm.id_momentoDia1_fk=md1.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem1 on pm.id_presentacionMedicamento1_fk=prem1.id_presentacionMedicamento
                                    full outer join MomentoDelDia md2 on  pm.id_momentoDia2_fk=md2.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem2 on pm.id_presentacionMedicamento2_fk=prem2.id_presentacionMedicamento
                                    full outer join MomentoDelDia md3 on  pm.id_momentoDia3_fk=md3.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem3 on pm.id_presentacionMedicamento3_fk=prem3.id_presentacionMedicamento
                                    full outer join UnidadMedida unidadM on  em.id_unidadMedida_fk=unidadM.id_unidadMedida
									join Historia_Clinica hc on hm.id_hc_fk=hc.id_hc
									join Paciente pa on hc.id_tipodoc_paciente_fk=pa.id_tipoDoc_fk and hc.id_nrodoc_paciente_fk=pa.nro_documento
									join TipoDocumento td on pa.id_tipoDoc_fk=td.id_tipoDoc
									join ProfesionalMedico prof on hc.id_tipodoc_profesionaMedico_fk=prof.id_tipodoc_fk and hc.id_nrodoc_profesionalMedico_fk=prof.nro_documento
                                    where hm.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dsHabitoMedicamento = new dsHistoriaClinicaHabitosMedicamentos();
                da.Fill(dsHabitoMedicamento, "HabitosMedicamento");
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dsHabitoMedicamento;
        }

        private void diagnosticosPorImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No se seleccionó el paciente!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (hc == null)
            {
                hc = consultarHistoriaClinica(pacienteSeleccionado);
            }

            if (hc != null)
            {
                ConsultarEstudios formConsultarEstudios = new ConsultarEstudios(hc.id_hc);
                formConsultarEstudios.ShowDialog();
            }
            else
            {
                MessageBox.Show("El paciente no tiene historia clínica!!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void consultarEstadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarEstadisticas_PromedioPorcentajeModa formEstadisticas = new ConsultarEstadisticas_PromedioPorcentajeModa();
            formEstadisticas.ShowDialog();
        }

        private void consultarPromedioPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_EstadisticasMedicionesPromedio formMedicionesPromedio = new Consultar_EstadisticasMedicionesPromedio();
            formMedicionesPromedio.ShowDialog();
        }

        private void consultarPromedioPorSitioMedicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarEstadistica_PromedioSitioMedicion PromedioSitioMedicion = new ConsultarEstadistica_PromedioSitioMedicion();
            PromedioSitioMedicion.ShowDialog();
        }
        public void inicializar()
        {
            //manejadorConsultarPaciente. = null; //new ManejadorConsultarPaciente();
            //manejadorRegistrarAtencionMedicaEnConsultorio = null; //new ManejadorRegistrarAtencionMedicaEnConsultorio();
            //manejadorConsultarHc = null;
            //manejadorRegistrarEnfermedadActual = null; //new ManejadorRegistrarEnfermedadActual();
            if(manejadorRegistrarExamenGeneral == null)
            {
                manejadorRegistrarExamenGeneral = new ManejadorRegistrarExamenGeneral();
            }
            manejadorRegistrarExamenGeneral.medicion = new MedicionDePresionArterial();
            //new ManejadorRegistrarExamenGeneral();

            medicionesAutomaticaConExamenGeneral = false;

            //consulta = null;
            //consultaGenerada = false;
            //examen = null;
            if(listaTerritoriosExaminados!=null)
                listaTerritoriosExaminados.Clear();
            //listaTerritoriosExaminados = null;
            if (listaSintoma != null)
                listaSintoma.Clear();
            //listaSintoma = null;
            if (listaTerritoriosExaminados != null)
                listaTerritoriosExaminados.Clear();
            //listaTerritoriosExaminados = null;
            if (listaDiagnosticos != null)
                listaDiagnosticos.Clear();
            //listaDiagnosticos = null;
            if (listaEstudios != null)
                listaEstudios.Clear();
            //listaEstudios = null;
            if (listaLaboratorio != null)
                listaLaboratorio.Clear();
            //listaLaboratorio = null;
            if (listaPracticasComplementarias != null)
                listaPracticasComplementarias.Clear();
            //listaPracticasComplementarias = null;
            if (listaTratamiento != null)
                listaTratamiento.Clear();
            //listaTratamiento = null;
            if (listaTemperaturas != null)
                listaTemperaturas.Clear();
            //listaTemperaturas = null;
        }

        private void dgvPacientesDelProfesionalLogueado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void promedioConFiltroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_EstadisticasMedicionesPromedioConFiltro PromedioSitioMedicion = new Consultar_EstadisticasMedicionesPromedioConFiltro();
            PromedioSitioMedicion.ShowDialog();
         
           
        }

        private void dgvDiagnosticos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDiagnosticos.CurrentRow.Cells[0].Value == null || string.IsNullOrEmpty(dgvDiagnosticos.CurrentRow.Cells[0].Value.ToString()))
                return;
            if (dgvDiagnosticos.ColumnCount <= 1)
                return;

            MessageBox.Show("Diagnóstico seleccionado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHumedadPiel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }
        public void validarCampos()
        {
           
        }

        private void txtPeso_Validating(object sender, CancelEventArgs e)
        {
        
        }

        private void txtPeso_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void TxtSistolicaPresionArterial_TextChanged(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtSistolicaPresionArterial))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSistolicaPresionArterial.Focus();
                return;
            }
        }

        private void TxtDiastolicaPresionArterial_TextChanged(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtDiastolicaPresionArterial))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiastolicaPresionArterial.Focus();
                return;
            }
        }

        private void TxtPulsoPresionArterial_TextChanged(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtDiastolicaPresionArterial))
            {
                MessageBox.Show("Debe ingresar un valor numérico", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiastolicaPresionArterial.Focus();
                return;
            }
        }

        private void TxtCantTiempoInicioSintoma_TextChanged(object sender, EventArgs e)
        {
            if (!Utilidades.ValidarCampoNumerico(txtCantTiempoInicioSintoma))
            {
                MessageBox.Show("Debe ingresar un valor numérico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        //public void presentarConsultas()
        //{
        //    if (pacienteSeleccionado == null)
        //    {
        //        MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    if (hc == null)
        //    {
        //        MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    DataTable dt = manejadorConsultarHc.mostrarConsultasAnteriores(hc.id_hc);
        //    Utilidades.presentarDatosEnDataGridView(dt, dgvConsultas);
        //}

    }
}
