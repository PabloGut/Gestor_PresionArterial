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

        RazonamientoDiagnostico razonamiento;
        List<HipotesisInicial> hipotesis;
        List<Diagnostico> diagnosticos;
        List<EstudioDiagnosticoPorImagen> listaEstudios;
        List<PruebasDeLaboratorio> listaPrubasLaboratorio;

        List<Sintoma> listaSintoma;
        Consulta consulta;
        ExamenGeneral examen;
        List<SistemaLinfatico> listaTerritoriosExaminados;

        public MenuPrincipal(ProfesionaMedico pmLogueado)
        {
            InitializeComponent();
            medicoLogueado=pmLogueado;
            manejadorConsultarPaciente = new ManejadorConsultarPaciente();
            manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();
            manejadorConsultarHc = null;
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
            manejadorRegistrarExamenGeneral = new ManejadorRegistrarExamenGeneral();

            consulta = null;
            examen = null;
            razonamiento = null;
            listaTerritoriosExaminados = null;
            listaSintoma = null;
            listaTerritoriosExaminados = null;
            hipotesis = null;
            diagnosticos = null;
            listaEstudios = null;
            listaPrubasLaboratorio = null;
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

            cargarComboTipoDocumento();
            //dgvPacientesDelProfesionalLogueado.DataSource= manejadorConsultarPaciente.mostrarPacientesDeMedicoLogueado(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc);
            cargarDataGridPacientesDelProfesional();
            dgvPacientesDelProfesionalLogueado.Columns["id_tipoDoc_fk"].Visible = false;
            TextBoxSoloLectura(true);
            manejadorRegistrarAtencionMedicaEnConsultorio.registrarAtencionMedicaEnConsultorio(this);
            manejadorRegistrarExamenGeneral.registrarExamenGeneral(this);

            presentarTipoSintomas();
            presentarParteDelCuerpo();
            presentarCaracterDolor();
            presentarElementoTiempoEnfermedadActual();
            presentarDescripcionTiempo();
            presentarComoModificaSintoma();
            presentarElementoModificacion();
            presentarUbicacionGanglio();
            presentarTamañosGanglio();
            presentarAproximacionNúmericaDeTamaño();
            presentarEscalaPulso();
            presentarTiposDePulso();
            presentarConsistencia();

            agregarColumnasSistemaLinfatico();
            agregarColumnasExamenesARealizar();

            presentarEstudiosYAnalisis();

            



        }
        private void presentarTipoSintomas()
        {
            Utilidades.cargarCombo(cboQueSienteElPaciente, manejadorRegistrarEnfermedadActual.mostrarTiposSintomas(), "id_TipoSintoma", "nombre");
        }
        private void presentarParteDelCuerpo()
        {
            Utilidades.cargarCombo(cboParteCuerpo, manejadorRegistrarEnfermedadActual.mostrarPartesDelCuerpoHumano(), "id_parteCuerpo", "nombre");
        }
        private void presentarCaracterDolor()
        {
            Utilidades.cargarCombo(cboCaracterDolor, manejadorRegistrarEnfermedadActual.mostrarCaracterDelDolor(), "id_caracterDelDolor", "nombre");
        }
        private void presentarElementoTiempoEnfermedadActual()
        {
            Utilidades.cargarCombo(cboElementoTiempo, manejadorRegistrarEnfermedadActual.mostrarElementosDelTiempo(), "id_elementoDelTiempo", "nombre");
        }
        private void presentarDescripcionTiempo()
        {
            Utilidades.cargarCombo(cboCuandoComenzo, manejadorRegistrarEnfermedadActual.mostrarDescripcionesDelTiempo(), "id_descripcionDelTiempo", "nombre");
        }
        private void presentarComoModificaSintoma()
        {
            Utilidades.cargarCombo(cboComoModificaSintoma, manejadorRegistrarEnfermedadActual.mostrarModificacionesDelSintoma(), "id_modificacionSintoma", "nombre");
        }
        private void presentarElementoModificacion()
        {
            Utilidades.cargarCombo(cboElementoModificacion, manejadorRegistrarEnfermedadActual.mostrarElementosDeModificacion(), "id_elementoDeModificacion", "nombre");
        }
        public void presentarUbicacionGanglio()
        {
            Utilidades.cargarCombo(cboUbicacionGanglio, manejadorRegistrarExamenGeneral.mostrarUbicaciones(), "id_ubicacion", "nombre");
        }
        public void presentarTamañosGanglio()
        {
            Utilidades.cargarCombo(cboTamañoGanglio, manejadorRegistrarExamenGeneral.mostrarTamañoGanglio(), "id_tamaño", "nombre");
        }
        public void presentarConsistencia()
        {
            Utilidades.cargarCombo(cboConsistencia, manejadorRegistrarExamenGeneral.mostrarConsistencia(), "id_consistencia", "nombre");
        }
        public void presentarAproximacionNúmericaDeTamaño()
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
        public void presentarEscalaPulso()
        {
            Utilidades.cargarCombo(cboPI1, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD1, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI2, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD2, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI3, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD3, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI4, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD4, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI5, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD5, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI6, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD6, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI7, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD7, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPI8, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
            Utilidades.cargarCombo(cboPD8, manejadorRegistrarExamenGeneral.mostrarEscalaPulso(), "id_escalaPulso", "nombre");
        }
        public void presentarTiposDePulso()
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
        public void presentarEstudiosYAnalisis()
        {
            Utilidades.cargarCombo(cboEstudioARealizar, manejadorRegistrarExamenGeneral.mostrarNombreEstudios(), "id_nombreEstudio", "nombre");
            Utilidades.cargarCombo(cboAnalisiLaboratorioARealizar, manejadorRegistrarExamenGeneral.mostrarAnalisisLaboratorio(), "id_analisis", "nombre");

        }
        public void presentarFechaYHoraActual()
        {
            mtbFechaConsulta.Text = manejadorRegistrarAtencionMedicaEnConsultorio.mostrarFechaActual();
            mtbHoraConsulta.Text = manejadorRegistrarAtencionMedicaEnConsultorio.mostrarHoraActual();
        }
        /*
         * Método para cargar el ComboBox del tipo de documento.
         * Llama al método mostrarTiposDocumentos del manejador consultar paciente.
         * No recibe parámetros.
         */
        public void cargarComboTipoDocumento()
        {
            cboTipoDocPaciente.DataSource = manejadorConsultarPaciente.mostrarTiposDocumentos();
            cboTipoDocPaciente.ValueMember = "id_tipoDoc";
            cboTipoDocPaciente.DisplayMember = "nombre";
        }
        private void cargarDataGridPacientesDelProfesional()
        {
            dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.mostrarPacientesDeMedicoLogueado(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc);
        }
        private void crearHistoriaClínicaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            if (string.IsNullOrEmpty(txtNroDocPaciente.Text) == false)
            {
                dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.mostrarPacienteBuscadoDelProfesional(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc, (int)cboTipoDocPaciente.SelectedValue, Convert.ToInt64(txtNroDocPaciente.Text), txtNombreApellidoPaciente.Text);
            }
            else
            {
                dgvPacientesDelProfesionalLogueado.DataSource = manejadorConsultarPaciente.mostrarPacienteBuscadoDelProfesional(medicoLogueado.id_tipoDoc, medicoLogueado.nroDoc, txtNombreApellidoPaciente.Text);
            }
        }

        private void btnSeleccionaPaciente_Click(object sender, EventArgs e)
        {
            presentarPaciente();

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
            cargarDataGridPacientesDelProfesional();
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
            manejadorConsultarHc = new ManejadorConsultarHC();
            hc = manejadorConsultarHc.mostrarHistoriaClinica(pacienteSeleccionado);
            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            

            txtNroHistoriaClinica.Text = Convert.ToString(hc.nro_hc);
            mtbFechaCreacionHc.Text = Convert.ToString(hc.fecha);
            mtbHoraCreacionHc.Text = Convert.ToString(hc.hora.ToShortTimeString());
            mtbFechaInicioAntecionHc.Text = Convert.ToString(hc.fechaInicioAtencion);
            txtMotivoPrimeraConsulta.Text = hc.motivoConsulta;

           
        }
        public void generarNuevaConsulta()
        {
            if (pacienteSeleccionado != null && hc != null)
            {
                txtNroConsulta.Text = Convert.ToString(manejadorRegistrarAtencionMedicaEnConsultorio.calcularNroConsulta(hc.id_hc));
                presentarFechaYHoraActual();

            }
            else
            {
                MessageBox.Show("No seleccionó ningún paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnEnfermedades_Click(object sender, EventArgs e)
        {
            presentarEnfermedades();
        }
        private void presentarEnfermedades()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesMorbidosEnfermedades(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }
        private void btnTraumatismos_Click(object sender, EventArgs e)
        {
            presentarTraumatismos();
        }
        private void presentarTraumatismos()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesMorbidosTraumatismos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }
        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            presentarOperaciones();
        }
        private void presentarOperaciones()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesMorbidosOperaciones(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }
        private void btnEmbarazosAbortos_Click(object sender, EventArgs e)
        {
            presentarEmbarazos();
        }
        private void presentarEmbarazos()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesGinecoObstetricos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesGinecoObstetricos);
        }
        private void btnAbortos_Click(object sender, EventArgs e)
        {

        }

        private void btnAlergiaAlimentos_Click(object sender, EventArgs e)
        {
            presentarAlergiaAlimentos();
        }
        private void presentarAlergiaAlimentos()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAlergiasAlimentos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }
        private void dgvAntecedentesMorbidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            presentarInformacionAntecedentesMorbidos(dgvAntecedentesMorbidos);
        }
        private void presentarInformacionAlergias(DataGridView dgv)
        {
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
            DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
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
            DateTime fecha = Convert.ToDateTime(dgv.CurrentRow.Cells["Fecha de registro"].Value);
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
           presentarInformacionAlergias(dgvAlergias);
        }

        private void btnAlergiaSustanciaAmbiente_Click(object sender, EventArgs e)
        {
            presentarAlergiaSustanciaAmbiente();
        }
        private void presentarAlergiaSustanciaAmbiente()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAlergiasSustanciasAmbiente(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }
        private void btnAlergiaSustanciaContactoPiel_Click(object sender, EventArgs e)
        {
            presentarAlergiaSustanciaContactoPiel();
        }
        private void presentarAlergiaSustanciaContactoPiel()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAlergiasSustanciaContactoPiel(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }
        private void btnAlergiaInsectos_Click(object sender, EventArgs e)
        {
            presentarAlergiaInsectos();
        }
        private void presentarAlergiaInsectos()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAlergiasInsectos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }
        private void btnAlergiaMedicamentos_Click(object sender, EventArgs e)
        {
            presentarAlergiaMedicamentos();
        }
        private void presentarAlergiaMedicamentos()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = manejadorConsultarHc.mostrarAlergiasMedicamentos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }
        private void dgvAntecedentesMorbidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAntecedentesGinecoObstetricos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            presentarInformacionAntecedentesGinecoObstetricos(dgvAntecedentesGinecoObstetricos);
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
        /*private void cargarDatosDataGridViewSistemaLinfatico()
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

            SistemaLinfatico nuevoExamenLinfatico=manejadorRegistrarExamenGeneral.crearSistemaLinfaticoPaso2(ubicacion,tamaño,aproximacionNumerica,consistencia,descripcion,sensiblePalpacion,,tiendeConfluir,movilizaConDedos,planosProfundos,procesoInflamatorio,lesion,observaciones);
            
            listaTerritoriosExaminados.Add(nuevoExamenLinfatico);
            
            dgvRegionesEstudiadas.Rows.Add(ubicacion, tamaño, aproximacionNumerica, consistencia, descripcion, sensiblePalpacion, limitesPrecisos, tiendeConfluir,movilizaConDedos,planosProfundos, procesoInflamatorio, lesion, observaciones);
        }*/

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

        private void btnRegistrarAtención_Click(object sender, EventArgs e)
        {
            registrarExamenGeneralYConsulta();

            /*int idRazonamientoDiagnostico = registrarRazonamientoDiagnostico();
            
            int idExamenGeneral = registrarExamenGeneral(idRazonamientoDiagnostico);

            registrarSistemaLinfatico(idExamenGeneral);
            
            registrarPulsoArterial(idExamenGeneral);

            registrarConsulta(idExamenGeneral);*/


        }
        public void crearRazonamientoDiagnostico()
        {
            razonamiento = new RazonamientoDiagnostico();

            if (string.IsNullOrEmpty(txtConceptoInicial.Text) == false)
            {
                razonamiento.conceptoInicial = txtConceptoInicial.Text;
            }

            if (hipotesis != null && hipotesis.Count > 0)
                razonamiento.hipotesis = hipotesis;

            if (diagnosticos != null && diagnosticos.Count > 0)
                razonamiento.diagnosticos = diagnosticos;

            if (listaEstudios != null && listaEstudios.Count > 0)
                razonamiento.estudios = listaEstudios;

            if (listaPrubasLaboratorio != null && listaPrubasLaboratorio.Count > 0)
                razonamiento.pruebas = listaPrubasLaboratorio;

            //int id=manejadorRegistrarExamenGeneral.registrarRazonamientoDiagnostico(razonamiento);

            //return id;
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

            SistemaLinfatico nuevoExamenLinfatico=manejadorRegistrarExamenGeneral.crearSistemaLinfaticoPaso2(ubicacion,tamaño,aproximacionNumerica,consistencia,descripcion,sensiblePalpacion,,tiendeConfluir,movilizaConDedos,planosProfundos,procesoInflamatorio,lesion,observaciones);
            
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
        * Crear el objeto Temperatura
        * Llama al manejador Registrar Examen General.
        * Retorna un objeto Temperatura.
        */
        public Temperatura crearMedicionTemperatura()
        {
            int id_sitio;
            float valorTemperatura;
            string resultado;

            if (cboSitionMedición1.SelectedIndex > 0 && !string.IsNullOrEmpty(txtValorTemperatura1.Text) && !string.IsNullOrEmpty(txtResultadoTemperatura1.Text))
            {
                SitioMedicion sitio = (SitioMedicion)cboSitionMedición1.SelectedItem;
                id_sitio = sitio.id_sitioMedicion;

                valorTemperatura = float.Parse(txtValorTemperatura1.Text);

                resultado = txtResultadoTemperatura1.Text;

                return manejadorRegistrarExamenGeneral.crearTemperaturaPaso4(id_sitio, resultado, valorTemperatura);
            }
            else
            {
                return null;
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
            manejadorRegistrarExamenGeneral.mostrarUbicacionesDeExtremidad(Convert.ToInt32(cmbExtremidadPresionArterial.SelectedValue));
        }

        public void presentarUbicacionesExtremidadDeExtremidad(List<UbicacionExtremidad> ubicaciones)
        {
            Utilidades.cargarCombo(cmbUbicacionPresionArterial, ubicaciones, "id_ubicacionExtremidad", "nombre");
        }

        /*Agrega una medición de presión arterial a la grilla*/
        private void btnAgregarPresionArterial_Click(object sender, EventArgs e)
        {
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
                manejadorRegistrarExamenGeneral.registrarMedicion(DateTime.Today, DateTime.Now, posicion, ubicacion, sitio, momento);
            }

            dgvPresionArterial.Rows.Add(DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString(), extremidad.nombre, ubicacion.nombre, posicion.nombre, sitio.nombre, txtSistolicaPresionArterial.Text + "mmHg", txtDiastolicaPresionArterial.Text + "mmHg", txtPulsoPresionArterial.Text, momento.nombre);
            DateTime hora = DateTime.Now; int pulso = Convert.ToInt32(txtPulsoPresionArterial.Text); int valorMinimo = Convert.ToInt32(txtSistolicaPresionArterial.Text); int valorMaximo = Convert.ToInt32(txtDiastolicaPresionArterial.Text);
            manejadorRegistrarExamenGeneral.registrarDetalleDeMedicion(hora, pulso, valorMinimo, valorMaximo);
        }

        public void presentarCalculosPresionArterial(string promedio, string categoria, string rangoValorMaximo, string rangoValorMinimo)
        {
            lblPromedioPresionArterial.Text = promedio;
            lblCategoriaPresionArterial.Text = categoria;
            lblValorMaxPresionArterial.Text = rangoValorMaximo;
            lblValorMinPresionArterial.Text = rangoValorMinimo;
        }

        private void AgregarHipotesisInicial_Click(object sender, EventArgs e)
        {
            
        }
        private void cargarDatosDgvHipotesisInicial()
        {
            if (string.IsNullOrEmpty(txtHipotesisInicial.Text) == false)
            {
                if (hipotesis == null)
                    hipotesis = new List<HipotesisInicial>();

                HipotesisInicial hi = new HipotesisInicial();

                dgvHipotesis.Rows.Add(txtHipotesisInicial.Text);
                hi.descripcion = txtHipotesisInicial.Text;
                hi.id_estadoH = manejadorRegistrarExamenGeneral.mostrarIdEstadoHipotesis("No rechazada");
                hipotesis.Add(hi);
                txtHipotesisInicial.Clear();
            }
        }
        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            cargarDatosDgvDiagnosticos();
        }
        private void cargarDatosDgvDiagnosticos()
        {
            if (string.IsNullOrEmpty(txtDiagnostico.Text) == false)
            {
                if (diagnosticos == null)
                    diagnosticos = new List<Diagnostico>();

                Diagnostico di = new Diagnostico();

                dgvDiagnosticos.Rows.Add(txtDiagnostico.Text);
                di.descripcion = txtDiagnostico.Text;
                diagnosticos.Add(di);
                txtDiagnostico.Clear();
            }
        }
        private void btnEstudioARealizar_Click(object sender, EventArgs e)
        {
            cargarDatosDgvEstudioARealizar();
        }
        private void cargarDatosDgvEstudioARealizar()
        {
            string estudio;
            string indicaciones = "No precisa";
            if (cboEstudioARealizar.SelectedIndex > 0)
            {
                NombreEstudio nombreSeleccionado = (NombreEstudio)cboEstudioARealizar.SelectedItem;
                estudio = nombreSeleccionado.nombre;

                if (string.IsNullOrEmpty(txtIndicacionesEstudioARealizar.Text) == false)
                {
                    indicaciones = txtIndicacionesEstudioARealizar.Text;
                }

                if (listaEstudios == null)
                    listaEstudios = new List<EstudioDiagnosticoPorImagen>();

                EstudioDiagnosticoPorImagen estudioD = new EstudioDiagnosticoPorImagen();

                estudioD.id_nombreEstudio = nombreSeleccionado.id_nombreEstudio;
                estudioD.indicaciones = indicaciones;
                listaEstudios.Add(estudioD);

                dgvExamenesARealizar.Rows.Add(estudio, indicaciones);
            }
        }
        private void btnAnalisisLaboratorioARealizar_Click(object sender, EventArgs e)
        {
            cargarDatosDgvAnalisisLaboratorioARealizar();
        }
        private void cargarDatosDgvAnalisisLaboratorioARealizar()
        {
            string analisis;
            string indicaciones = "No precisa";
            if (cboEstudioARealizar.SelectedIndex > 0)
            {
                AnalisisLaboratorio analisisSeleccionado = (AnalisisLaboratorio)cboAnalisiLaboratorioARealizar.SelectedItem;
                analisis = analisisSeleccionado.nombre;

                if (string.IsNullOrEmpty(txtIndicacionesEstudioARealizar.Text) == false)
                {
                    indicaciones = txtIndicacionesEstudioARealizar.Text;
                }

                if (listaPrubasLaboratorio == null)
                    listaPrubasLaboratorio = new List<PruebasDeLaboratorio>();

                PruebasDeLaboratorio prueba = new PruebasDeLaboratorio();

                prueba.id_analisis = analisisSeleccionado.id_analisis;
                prueba.indicaciones = indicaciones;

                listaPrubasLaboratorio.Add(prueba);
                dgvExamenesARealizar.Rows.Add(analisis, indicaciones);
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

            cboUbicacionGanglio.SelectedIndex = 1;
            cboTamañoGanglio.SelectedIndex = 1;
            cboTamañoGanglio.SelectedIndex = 2;
            cboConsistencia.SelectedIndex = 1;
            chbSensiblePalpacion.Checked = true;
            chbProcesoInflamatorio.Checked = true;
            rbLimitesPrecisos.Checked = true;
            rbPlanosProfundos.Checked = true;
            cboAproximacionNumerica.SelectedIndex = 2;

            cboPulso1.SelectedIndex = 1;
            cboPI1.SelectedIndex = 3;
            cboPD1.SelectedIndex = 3;

            cboPulso2.SelectedIndex = 2;
            cboPI2.SelectedIndex = 3;
            cboPD2.SelectedIndex = 3;



            cboQueSienteElPaciente.SelectedIndex = 1;
            txtDescQueSientePaciente.Text = "Dolor de cabeza";
            cboParteCuerpo.SelectedIndex = 1;
            rbSiDolor.Checked = true;
            cboCaracterDolor.SelectedIndex = 1;
            txtCantTiempoInicioSintoma.Text = "5";
            cboElementoTiempo.SelectedIndex = 1;


            txtConceptoInicial.Text = "Paciente con valores elevados de presión arterial en el consultorio y en un exámen de rutina";
            txtHipotesisInicial.Text = "Hipertensión arterial escencial";
        }
        public void registrarExamenGeneralYConsulta()
        {
            //Codigo para registrar exámen general y consulta con una sola transacción en DAO.
            crearRazonamientoDiagnostico();

            examen=crearExamenGeneral();//Crea ObjetoExamenGeneral.

            examen.examenPiel= crearExamenPiel();//Agrega el análisis de la piel al examen general.

            if (examen!=null && listaTerritoriosExaminados != null && listaTerritoriosExaminados.Count > 0)
                examen.territoriosExaminados = listaTerritoriosExaminados; //Agrega el análisis del sistema linfático al examen

            examen.pulso=crearPulsoArterial();//Crea ObjetoPulsoArterial

            if (examen != null && manejadorRegistrarExamenGeneral.medicion.mediciones != null && manejadorRegistrarExamenGeneral.medicion.mediciones.Count > 0)
                examen.medicion = manejadorRegistrarExamenGeneral.medicion;

            examen.razonamiento = razonamiento;

            consulta=CrearConsulta();

            consulta.examen = examen;

            manejadorRegistrarAtencionMedicaEnConsultorio.registrarConsultaYExamenGeneral(consulta);

        }

        private void btnAgregarSintoma_Click(object sender, EventArgs e)
        {
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

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            presentarConsultas();
        }
        public void presentarConsultas()
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No seleccionó un paciente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (hc == null)
            {
                MessageBox.Show("El paciente no tiene historia clínica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = manejadorConsultarHc.mostrarConsultasAnteriores(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvConsultas);
        }

        private void btnRegistrarMedicacion_Click(object sender, EventArgs e)
        {

        }

        private void nuevoTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarTratamiento rt = new RegistrarTratamiento();
            rt.ShowDialog();
        }
    }
}
