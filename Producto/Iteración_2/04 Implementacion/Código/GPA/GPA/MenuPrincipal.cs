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

        public MenuPrincipal(ProfesionaMedico pmLogueado)
        {
            InitializeComponent();
            medicoLogueado=pmLogueado;
            manejadorConsultarPaciente = new ManejadorConsultarPaciente();
            manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();
            manejadorConsultarHc = null;
            manejadorRegistrarEnfermedadActual = new ManejadorRegistrarEnfermedadActual();
            manejadorRegistrarExamenGeneral = new ManejadorRegistrarExamenGeneral();
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
            //manejadorRegistrarAtencionMedicaEnConsultorio.registrarAtencionMedicaEnConsultorio(this);

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

        public void presentarAtencionEnConsultorio(List<CaracterDelDolor> caracteres)
        {
            Utilidades.deshabilitarLosControles(tabPage4);
            Utilidades.cargarCombo(cboCaracterDolor, caracteres, "id_caracterDelDolor", "nombre");
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
        
        
        
    }
}
