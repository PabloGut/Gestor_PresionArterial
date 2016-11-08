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

        List<Sintoma> listaSintoma;
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
            
            listaTerritoriosExaminados = null;
            listaSintoma = null;
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

        public void presentarAtencionEnConsultorio(List<Extremidad> extremidades, List<Posicion> posiciones, List<SitioMedicion> sitios, List<MomentoDia> momentos)
        {
            Utilidades.cargarCombo(cmbExtremidadPresionArterial, extremidades, "id_extremidad", "nombre");
            Utilidades.cargarCombo(cmbPosicionPresionArterial, posiciones, "id_posicion", "nombre");
            Utilidades.cargarCombo(cmbSitioMedicionPresionArterial, sitios, "id_sitioMedicion", "nombre");
            Utilidades.cargarCombo(cmbMomentoDiaPresionArterial, momentos, "idMomentoDia", "nombre");
            manejadorRegistrarAtencionMedicaEnConsultorio.buscarClasificacionesDePresionArterial();
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
            pacienteSeleccionado.id_hc=manejador.mostrarIdHc(pacienteSeleccionado.id_tipoDoc, pacienteSeleccionado.nroDoc);
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

            txtNroHistoriaClinica.Text = Convert.ToString(hc.nro_hc);
            mtbFechaCreacionHc.Text = Convert.ToString(hc.fecha);
            mtbHoraCreacionHc.Text = Convert.ToString(hc.hora.ToShortTimeString());
            mtbFechaInicioAntecionHc.Text = Convert.ToString(hc.fechaInicioAtencion);
            txtMotivoPrimeraConsulta.Text = hc.motivoConsulta;

           
        }

        private void btnEnfermedades_Click(object sender, EventArgs e)
        {
            DataTable dt= manejadorConsultarHc.mostrarAntecedentesMorbidosEnfermedades(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }
        private void btnTraumatismos_Click(object sender, EventArgs e)
        {
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesMorbidosTraumatismos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }

        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesMorbidosOperaciones(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesMorbidos);
        }
        private void btnEmbarazosAbortos_Click(object sender, EventArgs e)
        {
            DataTable dt = manejadorConsultarHc.mostrarAntecedentesGinecoObstetricos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAntecedentesGinecoObstetricos);
        }

        private void btnAbortos_Click(object sender, EventArgs e)
        {

        }

        private void btnAlergiaAlimentos_Click(object sender, EventArgs e)
        {
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
            DataTable dt = manejadorConsultarHc.mostrarAlergiasSustanciasAmbiente(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }

        private void btnAlergiaSustanciaContactoPiel_Click(object sender, EventArgs e)
        {
            DataTable dt = manejadorConsultarHc.mostrarAlergiasSustanciaContactoPiel(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }

        private void btnAlergiaInsectos_Click(object sender, EventArgs e)
        {
            DataTable dt = manejadorConsultarHc.mostrarAlergiasInsectos(hc.id_hc);
            Utilidades.presentarDatosEnDataGridView(dt, dgvAlergias);
        }

        private void btnAlergiaMedicamentos_Click(object sender, EventArgs e)
        {
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
            SistemaLinfatico sistemaLinfatico = new SistemaLinfatico();

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

            sistemaLinfatico.id_ubicacion=ubicacionSeleccionada.id_ubicacion;
            sistemaLinfatico.id_tamaño=tamañoSeleccionado.id_tamaño;
            sistemaLinfatico.aproximacionNumerica=aproximacionNumerica;
            sistemaLinfatico.id_consistencia=consistenciaSeleccionada.id_consistencia;
            sistemaLinfatico.descripcion=descripcion;
            sistemaLinfatico.sensiblePalpacion=sensiblePalpacion;
            sistemaLinfatico.sePalpaConLimitesPrecisos=limitesPrecisos;
            sistemaLinfatico.tiendeAConfluir=tiendeConfluir;
            sistemaLinfatico.sensiblePalpacion=sensiblePalpacion;
            sistemaLinfatico.sePalpaConLimitesPrecisos=limitesPrecisos;
            sistemaLinfatico.tiendeAConfluir=tiendeConfluir;
            sistemaLinfatico.sePuedeMovilizarConDedos=movilizaConDedos;
            sistemaLinfatico.adheridaPlanosProfundos=planosProfundos;
            sistemaLinfatico.procesoInflamatorioComprometeLaPiel=procesoInflamatorio;
            sistemaLinfatico.lesion=lesion;
            sistemaLinfatico.observaciones=observaciones;

            dgvRegionesEstudiadas.Rows.Add(ubicacion, tamaño, aproximacionNumerica, consistencia, descripcion, sensiblePalpacion, limitesPrecisos, tiendeConfluir,movilizaConDedos,planosProfundos, procesoInflamatorio, lesion, observaciones);
            listaTerritoriosExaminados.Add(sistemaLinfatico);
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

        private void btnRegistrarAtención_Click(object sender, EventArgs e)
        {
            //Metodo para registrar datos generales de la consulta que retorne el idConsulta.
            int idConsulta = 0;
            //Metodo para registrar Sintomas.
            registrarEnfermedadActual(idConsulta);
            //Metodo para registrar examen general que retorne el idExamen general. Solamente primera parte paso 1.
            int idExamenGeneral=0;
            //Método registrar sistema linfático.
            registrarSistemaLinfatico(idExamenGeneral);
            
        }
        private void registrarSistemaLinfatico(int idExamenGeneral)
        {
            if (listaTerritoriosExaminados != null && listaTerritoriosExaminados.Count > 0)
                manejadorRegistrarExamenGeneral.registrarSistemaLinfatico(listaTerritoriosExaminados, idExamenGeneral);
        }
        private void registrarEnfermedadActual(int idConsulta)
        {
            if (listaSintoma != null && listaSintoma.Count > 0)
                manejadorRegistrarAtencionMedicaEnConsultorio.registrarSintomas(listaSintoma, idConsulta);
        }
        private void registrarPulsoArterial(int idExamenGeneral)
        {
            PulsoArterial pulso = new PulsoArterial();

            if (String.IsNullOrEmpty(txtAuscultacionPulsos.Text) == true)
            {
                pulso.auscultacion = "No precisa";
            }
            else
            {
                pulso.auscultacion = txtAuscultacionPulsos.Text;
            }

            if (String.IsNullOrEmpty(txtObservaciones.Text) == true)
            {
                pulso.observaciones = "No precisa";
            }
            else
            {
                pulso.auscultacion = txtObservaciones.Text;
            }

            List<DetallePulsoArterial> detalles = new List<DetallePulsoArterial>();

            if (cboPulso1.SelectedIndex > 0)
            {
                DetallePulsoArterial detalle = new DetallePulsoArterial();
                
                Pulso pulsoSeleccionado=(Pulso) cboPulso1.SelectedItem;
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

        }

        private void cmbExtremidadPresionArterial_SelectedIndexChanged(object sender, EventArgs e)
        {
           manejadorRegistrarAtencionMedicaEnConsultorio.mostrarUbicacionesDeExtremidad(Convert.ToInt32(cmbExtremidadPresionArterial.SelectedValue));
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
                manejadorRegistrarAtencionMedicaEnConsultorio.registrarMedicion(DateTime.Today, DateTime.Now, posicion, ubicacion, sitio, momento);
            }

            dgvPresionArterial.Rows.Add(DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString(), extremidad.nombre, ubicacion.nombre, posicion.nombre, sitio.nombre, txtSistolicaPresionArterial.Text+"mmHg", txtDiastolicaPresionArterial.Text+"mmHg", txtPulsoPresionArterial.Text, momento.nombre);
            DetalleMedicionPresionArterial detalle = new DetalleMedicionPresionArterial();
            detalle.hora = DateTime.Now; detalle.pulso = Convert.ToInt32(txtPulsoPresionArterial.Text); detalle.valorMinimo = Convert.ToInt32(txtSistolicaPresionArterial.Text); detalle.valorMaximo = Convert.ToInt32(txtDiastolicaPresionArterial.Text);
            manejadorRegistrarAtencionMedicaEnConsultorio.registrarDetalleDeMedicion(detalle);
        }

        public void presentarCalculosPresionArterial(string promedio, string categoria, string rangoValorMaximo, string rangoValorMinimo)
        {
            lblPromedioPresionArterial.Text = promedio;
            lblCategoriaPresionArterial.Text = categoria;
            lblValorMaxPresionArterial.Text = rangoValorMaximo;
            lblValorMinPresionArterial.Text = rangoValorMinimo;
        }

    }
}
