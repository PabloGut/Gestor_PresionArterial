using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConsultarHistoriaClinica_Click(object sender, EventArgs e)
        {
            usuarioLogueado();
        }

        protected void CargaManual_Click(object sender, EventArgs e)
        {
            usuarioLogueado();
        }

        protected void CargaAutomatica_Click(object sender, EventArgs e)
        {
            usuarioLogueado();
        }
        public void usuarioLogueado()
        {
            if (Session["UsuarioLogueado"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}