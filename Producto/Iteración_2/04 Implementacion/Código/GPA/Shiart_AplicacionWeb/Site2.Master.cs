using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AplicacionWeb
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbCerrarSesión_Click(object sender, EventArgs e)
        {
            Session["UsuarioLogueado"] = null;
            Session.Abandon();
            Response.Redirect("Principal.aspx");
        }
    }
}