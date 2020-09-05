using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Clases;
using LogicaNegocio;
namespace WebApplication1
{
    public partial class ConsultarHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PacienteLogueado"] != null)
                {
                    Paciente pacienteLogueado = (Paciente)Session["PacienteLogueado"];
                    ((Label)Master.FindControl("lblUsuarioLogueado")).Text = pacienteLogueado.nombre + ", " + pacienteLogueado.apellido;
                }
            }
        }
    }
}