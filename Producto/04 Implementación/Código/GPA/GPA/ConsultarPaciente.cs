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
            cboTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (cboTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento!", "Atención",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                cboTipoDoc.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text))
            {
                MessageBox.Show("Debe ingresar el número de documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroDoc.Focus();
                return;
            
            }
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
            if (cboTipoDoc.SelectedIndex==-1 || string.IsNullOrEmpty(txtNroDoc.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            RegistrarHistoriaClínica rhc = new RegistrarHistoriaClínica(referenciaAMenuPrincipal,this);
            int tipodoc = (int)cboTipoDoc.SelectedValue;
            long nrodoc = long.Parse(txtNroDoc.Text);
            string nom = txtNombre.Text;
            string apellido = txtApellido.Text;
            
            rhc.obtenerPaciente(tipodoc, nrodoc, nom, apellido);
            rhc.medicoLogueado(medico);
            pasarPacienteSeleccionado(tipodoc,nrodoc,nom,apellido);
            rhc.ShowDialog();
            this.Show();
            
            
            
        }
        public void pasarPacienteSeleccionado(int tipodoc,long nrodoc,string nom,string apellido)
        {
            if (pacienteSeleccionado == null)
            {
                pacienteSeleccionado = new Paciente();
                pacienteSeleccionado.id_tipoDoc = tipodoc;
                pacienteSeleccionado.nroDoc = nrodoc;
                pacienteSeleccionado.nombre = nom;
                pacienteSeleccionado.apellido = apellido;
                referenciaAMenuPrincipal.pacienteSeleccionado = pacienteSeleccionado;

            }
            else
            {
                
                pacienteSeleccionado.id_tipoDoc = tipodoc;
                pacienteSeleccionado.nroDoc = nrodoc;
                pacienteSeleccionado.nombre =nom;
                pacienteSeleccionado.apellido = apellido;
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
            if (cboTipoDoc.SelectedIndex == -1 || string.IsNullOrEmpty(txtNroDoc.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            int tipodoc = (int)cboTipoDoc.SelectedValue;
            long nrodoc = long.Parse(txtNroDoc.Text);
            string nom = txtNombre.Text;
            string apellido = txtApellido.Text;

            pasarPacienteSeleccionado(tipodoc,nrodoc,nom,apellido);
            referenciaAMenuPrincipal.Show();
            this.Hide();
            
            
        }
        public void soloLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo letras", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }
        public void soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ingresar solo números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloLetras(e);
        }
       
    }
}
