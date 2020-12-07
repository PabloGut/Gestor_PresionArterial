using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class PrincipalLogueado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Inicio.aspx");
        }
    }
}