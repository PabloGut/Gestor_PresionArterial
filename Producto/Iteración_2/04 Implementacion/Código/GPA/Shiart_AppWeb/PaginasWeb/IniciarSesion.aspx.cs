using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Clases;
using LogicaNegocio;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string nombreUsuario=logInicioSesion.UserName;
            string pass =logInicioSesion.Password;

            int idUsuario=UsuarioLN.buscarUnUsuario(nombreUsuario, pass);

            Paciente paciente = PacienteLN.buscarUnPaciente(idUsuario);

            HttpCookie pacienteCookie = new HttpCookie("Paciente");
            pacienteCookie["Nombre"]=paciente.nombre;
            pacienteCookie["Apellido"] = paciente.apellido;

            Response.Cookies.Add(pacienteCookie);
            Response.Redirect("HistoriaClinica.aspx");

        }
    }
}