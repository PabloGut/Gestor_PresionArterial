using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class InicioLogueado : System.Web.UI.Page
    {
        public string nombrePaciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] != null)
            {
                nombrePaciente = @HttpContext.Current.Session["usuarioLogueado"].ToString();
            }
        }
    }
}