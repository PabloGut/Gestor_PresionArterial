using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class HistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.Cookies["Paciente"] == null)
            {
                lblPacienteLogueado.Text = "Ingresar un usuario para ver su hitoria clínica";
            }
            else
            {
                lblPacienteLogueado.Text = Request.Cookies["Paciente"]["Nombre"] + " " + Request.Cookies["Paciente"]["Apellido"];
            }
        }
    }
}