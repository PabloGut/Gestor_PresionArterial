using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPA;
using Entidades.Clases;
namespace GPA
{
    public partial class InicioSesión : Form
    {
        private ManejadorInicioSesion manejador;

        public InicioSesión()
        {
            InitializeComponent();
            manejador = new ManejadorInicioSesion();

        }
        /**
         * Método de inicio de sesión.
         * Invoca al método buscarUsuario del ManejadorInicioSesion.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Falta ingresar usuario o contraseña","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;

            }

            List<Usuario> usuario = manejador.buscarUsuario(txtUsuario.Text, txtPass.Text);

            if (usuario.Count > 0)
            {
                ProfesionaMedico pm = manejador.buscarMedicoDelUsuario(usuario[0].id_usuario);

                MenuPrincipal mp = new MenuPrincipal(pm);
                mp.Show();
                this.Hide();
                

            }
            else
            {
                MessageBox.Show("Usuario no existe!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
            }

            

            
        }

        private void InicioSesión_Load(object sender, EventArgs e)
        {

        }

        private void InicioSesión_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
