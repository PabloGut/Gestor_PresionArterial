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
        private int tipodoc;
        private long nro;
        private ProfesionaMedico medico{get;set;}
        private ManejadorRegistrarHC manejador;
        private MenuPrincipal referenciaMenuPrincipal;
        private ConsultarPaciente referenciaConsultarPaciente;

        public RegistrarHistoriaClínica()
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarHC();

        }
        public RegistrarHistoriaClínica(MenuPrincipal mp,ConsultarPaciente cp )
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarHC();
            referenciaMenuPrincipal = mp;
            referenciaConsultarPaciente = cp;
        }
        public RegistrarHistoriaClínica(MenuPrincipal mp)
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarHC();
            referenciaMenuPrincipal = mp;

            if (referenciaMenuPrincipal.getPacienteSeleccionado() != null)
            {
                tipodoc=referenciaMenuPrincipal.getPacienteSeleccionado().id_tipoDoc;
                nro = referenciaMenuPrincipal.getPacienteSeleccionado().nroDoc;
            }
        }

        private void RegistrarHistoriaClínica_Load(object sender, EventArgs e)
        {
            deshabilitarHabilitarComponentes(false);
            btnVerificarHC.Focus();
            mtbFechaActual.Text = DateTime.Today.ToString();
            cargarComboTipoDocumento();
            presentarDatosProfesionalMedico();

        }
        public void presentarDatosProfesionalMedico()
        {
            cboTipoDocumento.SelectedValue = medico.id_tipoDoc;
            txtNroDocumento.Text =Convert.ToString(medico.nroDoc);

            manejador.buscarProfesionaMedico(medico);
            txtNombreDoctor.Text = medico.nombre;
            txtApellidoDoctor.Text = medico.apellido;

        }
        public void cargarComboTipoDocumento()
        {
            cboTipoDocumento.DataSource = TipoDocumentoDAO.buscarTiposDoc();
            cboTipoDocumento.ValueMember = "id_TipoDoc";
            cboTipoDocumento.DisplayMember = "nombre";
        }
        public void obtenerPaciente(int id_tipoDoc,long nroDoc,string nombre,string apellido)
        {
            txtNombrePaciente.Text = nombre;
            txtApellidoPaciente.Text = apellido;
            tipodoc = id_tipoDoc;
            nro = nroDoc;
        }
        public void medicoLogueado(ProfesionaMedico medicoLogueado)
        {
            medico=medicoLogueado;
        }
        private void btnVerificarHC_Click(object sender, EventArgs e)
        {
            if (PacienteDAO.ExisteHC(tipodoc, nro) == true)
            {
                MessageBox.Show("El paciente ya tiene historia clínica!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
                referenciaConsultarPaciente.Show();
                return;
            }
            else
            {
                MessageBox.Show("El paciente no posee historia clínica!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deshabilitarHabilitarComponentes(true);
            }

        }
        public void deshabilitarHabilitarComponentes(Boolean valor)
        {
            mtbFechaActual.Enabled=valor;
            txtDiagnostico.Enabled = valor;
            txtAntecedentes.Enabled = valor;
            cboTipoDocumento.Enabled = valor;
            txtNroDocumento.Enabled = valor;
            txtNombreDoctor.Enabled = valor;
            txtApellidoDoctor.Enabled = valor;
            btnAceptar.Enabled = valor;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int nroHc = manejador.buscarNroHc();
            int nvoNroHC;
            if (nroHc == -1)
            {
                return;     
            }
            nvoNroHC=generarNroHC(nroHc);
            
            HistoriaClinica hc= new HistoriaClinica();
            hc.nro_hc=nvoNroHC;
            hc.fecha=Convert.ToDateTime(mtbFechaActual.Text);
            hc.antecedentes= txtAntecedentes.Text;
            hc.diagnostico= txtDiagnostico.Text;
            hc.fechaInicioAtencion=DateTime.Today;
            hc.idtipodoc = medico.id_tipoDoc;
            hc.nrodoc = medico.nroDoc;
            hc.idtipodoc_paciente = tipodoc;
            hc.nrodoc_paciente = nro;


            int idhc=manejador.registrarNvaHC(hc);

            manejador.asignarHCAPaciente(tipodoc, nro,idhc);
            referenciaMenuPrincipal.obtenerIdHC(idhc);
            referenciaMenuPrincipal.Show();
            this.Hide();

        }
        public int generarNroHC(int ultimoNroHC)
        {
            return ultimoNroHC=ultimoNroHC + 1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            referenciaMenuPrincipal.Show();
            this.Close();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            referenciaMenuPrincipal.Show();
            this.Hide();
        }
    }
}
