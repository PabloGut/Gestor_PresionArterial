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
namespace GPA
{
    public partial class MenuPrincipal : Form
    {
        ProfesionaMedico medicoLogueado;
        public Paciente pacienteSeleccionado{set;get;}
        
        public MenuPrincipal(ProfesionaMedico pmLogueado)
        {
            InitializeComponent();
            medicoLogueado=pmLogueado;

        }
        
        private void historiaClínicasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void crearHistoriaClínicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void buscarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarPaciente cp = new ConsultarPaciente(this);
            cp.obtenerProfesionalLogueado(medicoLogueado);
            cp.ShowDialog();
        }
        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe seleccionar el paciente que recibe atención médica", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ConsultarPaciente cp = new ConsultarPaciente(this);
                cp.ShowDialog();
                //this.Hide();

            }
            else
            {
                RegistrarEstudio re = new RegistrarEstudio(this);
                re.IdHCPaciente(pacienteSeleccionado.id_hc);
                re.ShowDialog();
                //this.Hide();
            }
        }
        public void obtenerIdHC(int idHC)
        {
            pacienteSeleccionado.id_hc = idHC;
        }
        public void obtenerPaciente(Paciente paciente)
        {
            pacienteSeleccionado = paciente;
        }
    }
}
