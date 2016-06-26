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
        }
        public void presentarDatosHc()
        {
            
            Paciente paciente = refMenuPrincipal.getPacienteSeleccionado();
            if (paciente != null)
            {
                HistoriaClinica hcpaciente = manejadorConsultarHC.mostrarHistoriaClinica(paciente);
                if (hcpaciente != null)
                {
                    setHistoriaClinica(hcpaciente);
                    txtNroHc.Text = Convert.ToString(hcpaciente.nro_hc);
                    txtNombreApellidoPaciente.Text = paciente.apellido + " ";
                    txtNombreApellidoPaciente.Text += paciente.nombre;
                    mtbFechaCreacionHC.Text = Convert.ToString(hcpaciente.fecha);
                    mtbFechaInicioTratamiento.Text = Convert.ToString(hcpaciente.fechaInicioAtencion);
                    txtAntecedentes.Text = hcpaciente.antecedentes;
                    txtDiagnostico.Text = hcpaciente.diagnostico;

                    presentarEstudiosDeHc(hcpaciente.id_hc);
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
                dgvEstudios.Columns["doctorACargo"].HeaderText = "Doctor encargado del estudio";
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
            //dgPedidos.CurrentRow.Cells("nropedido").Value
            //factura.dgvArticulos.Rows.Add(nPed, dom, fecha, nomb, ape, total)
        }
    }
}
