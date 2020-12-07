using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Clases;
using LogicaNegocio;
namespace Shiart_AplicacionWeb
{
    public partial class Login : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            buscarUsuario();
        }
        public void buscarUsuario()
        {
            Usuario usuarioLogueado = UsuarioLN.buscarUsuarioLogueado(txtUsuario.Text, txtContraseña.Text);

            if (usuarioLogueado != null)
            {   
                Paciente paciente = PacienteLN.buscarUnPaciente(usuarioLogueado.id_usuario);

                HistoriaClinica hc = HistoriaClinicaLN.mostrarHistoriaClinica(paciente);
                //Validar para el caso de no tener historia clínica
                Session["UsuarioLogueado"] = usuarioLogueado;
                Session["PacienteLogueado"] = paciente;
                Session["HcPacienteLogueado"] = hc;

                Response.Redirect("ConsultarHistoriaClinica.aspx");
            }
        }
    }
}