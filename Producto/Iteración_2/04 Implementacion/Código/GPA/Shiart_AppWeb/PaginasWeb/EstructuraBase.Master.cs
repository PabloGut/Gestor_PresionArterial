using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class EstructuraBase : System.Web.UI.MasterPage
    {
        public string nombrePaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] != null)
            {
                nombrePaciente = @HttpContext.Current.Session["usuarioLogueado"].ToString();
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Inicio.aspx");
        }
    }
}