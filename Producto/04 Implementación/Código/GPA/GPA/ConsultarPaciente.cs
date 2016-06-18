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

namespace GPA
{
    public partial class ConsultarPaciente : Form
    {
        private Paciente pacienteSeleccionado;
        private MenuPrincipal referenciaAMenuPrincipal;
        private ProfesionaMedico medico;
        

        public ConsultarPaciente()
        {
            InitializeComponent();
            pacienteSeleccionado = new Paciente();

        }
        public ConsultarPaciente(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            referenciaAMenuPrincipal = menuPrincipal;
            pacienteSeleccionado = new Paciente();
        }
      
        private void ConsultarPaciente_Load(object sender, EventArgs e)
        {
            cargarComboTipoDocumento();
        }
        public void cargarComboTipoDocumento()
        {
            cboTipoDoc.DataSource = TipoDocumentoDAO.buscarTiposDoc();
            cboTipoDoc.ValueMember = "id_TipoDoc";
            cboTipoDoc.DisplayMember = "nombre";
        }

        public void obtenerProfesionalLogueado(ProfesionaMedico medicoLogueado)
        {
            medico=medicoLogueado;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Paciente>pacientes= PacienteDAO.buscarPaciente((int)cboTipoDoc.SelectedValue,long.Parse(txtNroDoc.Text));

            if(pacientes.Count > 0)
            {
                txtNombre.Text= pacientes[0].nombre;
                txtApellido.Text= pacientes[0].apellido;
                if (pacientes[0].id_hc != 0)
                {
                    pacienteSeleccionado.id_hc = pacientes[0].id_hc;
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RegistrarHistoriaClínica rhc = new RegistrarHistoriaClínica(referenciaAMenuPrincipal,this);
            this.Hide();
            rhc.obtenerPaciente((int)cboTipoDoc.SelectedValue, long.Parse(txtNroDoc.Text), txtNombre.Text, txtApellido.Text);
            rhc.medicoLogueado(medico);
            pasarPacienteSeleccionado();
            rhc.ShowDialog();
            
            
            
        }
        public void pasarPacienteSeleccionado()
        {
            if (pacienteSeleccionado == null)
            {
                pacienteSeleccionado = new Paciente();
                pacienteSeleccionado.id_tipoDoc = (int)cboTipoDoc.SelectedValue;
                pacienteSeleccionado.nroDoc = long.Parse(txtNroDoc.Text);
                pacienteSeleccionado.nombre = txtNombre.Text;
                pacienteSeleccionado.apellido = txtApellido.Text;
                referenciaAMenuPrincipal.pacienteSeleccionado = pacienteSeleccionado;

            }
            else
            {
                
                pacienteSeleccionado.id_tipoDoc = (int)cboTipoDoc.SelectedValue;
                pacienteSeleccionado.nroDoc = long.Parse(txtNroDoc.Text);
                pacienteSeleccionado.nombre = txtNombre.Text;
                pacienteSeleccionado.apellido = txtApellido.Text;
                referenciaAMenuPrincipal.pacienteSeleccionado = pacienteSeleccionado;

            }
        }
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
            //referenciaAMenuPrincipal.pacienteSeleccionado = pacienteSeleccionado;

           
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
            pasarPacienteSeleccionado();
            referenciaAMenuPrincipal.Show();
            this.Hide();
            
            
        }
    }
}
