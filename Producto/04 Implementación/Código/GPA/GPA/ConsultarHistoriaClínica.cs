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
using DAO;
using GPA.Manejadores;

namespace GPA
{
    public partial class ConsultarHistoriaClínica : Form
    {
        private MenuPrincipal refMenuPrincipal;
        private ManejadorConsultarHC manejadorConsultarHC;
        private HistoriaClinica hcPacienteSeleccionado;
        private Paciente pacienteSelec;

        public ConsultarHistoriaClínica(MenuPrincipal mp)
        {
            InitializeComponent();
            refMenuPrincipal = mp;
            manejadorConsultarHC = new ManejadorConsultarHC();
            
        }
        public ConsultarHistoriaClínica()
        {
            InitializeComponent();
        }
        public void setHistoriaClinica(HistoriaClinica hc)
        {
            hcPacienteSeleccionado = hc;
        }
        private void ConsultarHistoriaClínica_Load(object sender, EventArgs e)
        {
            presentarDatosHc();
            tbContenidoDeHC.Controls.Remove(tbContenidoDeHC.TabPages[1]);
            
        }
        public void presentarDatosHc()
        {
            
            pacienteSelec = refMenuPrincipal.getPacienteSeleccionado();
            if (pacienteSelec != null)
            {
                HistoriaClinica hcpaciente = manejadorConsultarHC.mostrarHistoriaClinica(pacienteSelec);
                if (hcpaciente != null)
                {
                    setHistoriaClinica(hcpaciente);
                    txtNroHc.Text = Convert.ToString(hcpaciente.nro_hc);
                    txtNombreApellidoPaciente.Text = pacienteSelec.apellido + " ";
                    txtNombreApellidoPaciente.Text += pacienteSelec.nombre;
                    mtbFechaCreacionHC.Text = Convert.ToString(hcpaciente.fecha);
                    mtbFechaInicioTratamiento.Text = Convert.ToString(hcpaciente.fechaInicioAtencion);
                    txtAntecedentes.Text = hcpaciente.antecedentes;
                    txtDiagnostico.Text = hcpaciente.diagnostico;

                    presentarEstudiosDeHc(hcpaciente.id_hc);
                }
                else
                {
                    MessageBox.Show("El paciente no tiene historia clínica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
         

        }
        public void presentarEstudiosDeHc(int id_hc)
        {
            dgvEstudios.DataSource= manejadorConsultarHC.mostrarEstudiosDeHcLista(id_hc);
            try
            {

                dgvEstudios.Columns["nombre"].HeaderText="Nombre";
                dgvEstudios.Columns["nombre"].Width = 150;
                dgvEstudios.Columns["fecha"].HeaderText = "Fecha";
                dgvEstudios.Columns["fecha"].Width = 150;
                dgvEstudios.Columns["doctorACargo"].HeaderText = "Doctor";
                dgvEstudios.Columns["doctorACargo"].Width = 150;
                dgvEstudios.Columns["informeEstudio"].HeaderText = "Informe";
                dgvEstudios.Columns["informeEstudio"].Width=200;

                dgvEstudios.Columns["id_estudio"].Visible = false;
                dgvEstudios.Columns["id_institucion"].Visible = false;
                dgvEstudios.Columns["id_hc"].Visible = false;
                
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error:" + e.Message);
            }
            
            //dgvEstudios.DataSource=manejadorConsultarHC.mostrarEstudiosDeHcDS(id_hc);
            //dgvEstudios.DataMember = "Estudio";


        }

        private void dgvEstudios_DoubleClick(object sender, EventArgs e)
        {
            tomarEstudioSeleccionado();


        }
        public void tomarEstudioSeleccionado()
        {
            //dgPedidos.CurrentRow.Cells("nropedido").Value
            //factura.dgvArticulos.Rows.Add(nPed, dom, fecha, nomb, ape, total)
            string nombre = dgvEstudios.CurrentRow.Cells["nombre"].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dgvEstudios.CurrentRow.Cells["fecha"].Value);
            string doctor = dgvEstudios.CurrentRow.Cells["doctorACargo"].Value.ToString();
            string informe = dgvEstudios.CurrentRow.Cells["InformeEstudio"].Value.ToString();

            ConsultarEstudio ce = new ConsultarEstudio();
            ce.presentarDatosEstudio(nombre, fecha, doctor, informe);
            ce.ShowDialog();
            this.Show();
            

                
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
