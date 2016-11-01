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

        ManejadorConsultarPaciente manejadorConsultarPaciente;
        ManejadorRegistrarAtencionMedicaEnConsultorio manejadorRegistrarAtencionMedicaEnConsultorio;
        ManejadorConsultarHC manejadorConsultarHc;

        public MenuPrincipal(ProfesionaMedico pmLogueado)
        {
            InitializeComponent();
            medicoLogueado=pmLogueado;
            manejadorConsultarPaciente = new ManejadorConsultarPaciente();
            manejadorRegistrarAtencionMedicaEnConsultorio = new ManejadorRegistrarAtencionMedicaEnConsultorio();
            manejadorConsultarHc = null;
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
            Utilidades.cargarCombo(comboBox3, caracteres, "id_caracterDelDolor", "nombre");
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
            
            DataSet ds = manejadorConsultarHc.mostrarHistoriaClinica(pacienteSeleccionado);
            DataTable dtHc = ds.Tables["HistoriaClinica"];

            if (dtHc.Rows.Count > 0)
            {
                txtNroHistoriaClinica.Text = dtHc.Rows[0]["nro_hc"].ToString();
                mtbFechaCreacionHc.Text = dtHc.Rows[0]["fecha_creación"].ToString();
                mtbHoraCreacionHc.Text = dtHc.Rows[0]["hora_creacion"].ToString();
                mtbFechaInicioAntecionHc.Text = dtHc.Rows[0]["fecha_inicio_atencion_con_profesional"].ToString();
                if (string.IsNullOrEmpty(dtHc.Rows[0]["principalProblema"].ToString()) == false)
                {
                    txtMotivoPrimeraConsulta.Text = dtHc.Rows[0]["principalProblema"].ToString();
                }
                else
                {
                    txtMotivoPrimeraConsulta.Text = "No precisa";
                }
               
            }
            
            DataTable dtAntecedentesMorbidos = ds.Tables["AntecedentesMorbidos"];

            if (dtAntecedentesMorbidos.Rows.Count > 0)
            {
                dgvAntecedentesMorbidos.DataSource = dtAntecedentesMorbidos;
                dgvAntecedentesMorbidos.Columns["id_tipoAntecedenteMorbido_fk"].Visible = false;
                dgvAntecedentesMorbidos.Columns["Nombre de la enfermedad"].Width = 300;

            }
            else
            {
                DataGridViewColumn columna = new DataGridViewTextBoxColumn();
                columna.Width = 500; 
                dgvAntecedentesMorbidos.Columns.Add(columna);

                DataGridViewRow fila = new DataGridViewRow();

                dgvAntecedentesMorbidos.Rows.Add(fila);

                dgvAntecedentesMorbidos.Rows[0].Cells[0].Value = "No se encontraron resultados";
            }
            dgvAntecedentesMorbidos.AllowUserToAddRows = false;
        }
    }
}
