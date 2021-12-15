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

            if (paciente.id_hc != 0)
            {
                HttpCookie idHcCookie = new HttpCookie("idHc", Convert.ToString(paciente.id_hc));
                //pacienteCookie["idHc"]=Convert.ToString(paciente.id_hc);

                Response.Cookies.Add(idHcCookie);
                Session["idUsuario"] = idUsuario;
                Session["pacienteLogueado"] = paciente;
                Session["usuarioLogueado"] = paciente.nombre + ", " + paciente.apellido;
                Response.Redirect("InicioLogueado.aspx");
            }
           


            //Usar en html para leer valor de variable desde codebehind <%=nombrePaciente %>
        }
    }
}