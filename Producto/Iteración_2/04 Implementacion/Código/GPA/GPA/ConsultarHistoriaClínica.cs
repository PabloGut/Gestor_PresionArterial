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
