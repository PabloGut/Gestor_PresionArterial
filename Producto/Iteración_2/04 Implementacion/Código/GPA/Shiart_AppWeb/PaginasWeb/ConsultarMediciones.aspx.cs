using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class ConsultarMediciones : System.Web.UI.Page
    {
        public DataTable mediciones;
        public DataTable detalleMediciones;
        public DataTable detalleMedicionesConFiltro;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["idHc"];
            
            if(cookie !=null)
            {
                mediciones=MedicionDePresionArterialLN.obtenerMedicionesPresionArterial(Convert.ToInt32(cookie.Value));
                RepeaterMediciones.DataSource = mediciones;
                RepeaterMediciones.DataBind();
            }
        }

        protected void RepeaterMediciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {   
            
            string idMedicion = ((System.Data.DataRowView)(e.Item.DataItem)).Row["id_medicion"].ToString();

            HttpCookie cookie = Request.Cookies["idHc"];

            detalleMediciones = MedicionDePresionArterialLN.obtenerDetalleMedicionesPresionArterial(Convert.ToInt32(cookie.Value), Convert.ToInt32(idMedicion));

            System.Web.UI.WebControls.GridView gvDetalleMediciones = (e.Item.FindControl("gvDetalleMediciones") as System.Web.UI.WebControls.GridView);
            gvDetalleMediciones.DataSource = detalleMediciones;
            gvDetalleMediciones.DataBind();

            Session["detalleMediciones"] = detalleMediciones;

        }
        protected string graficar()
        {
            HttpCookie cookie = Request.Cookies["idHc"];

            detalleMedicionesConFiltro = MedicionDePresionArterialLN.obtenerDetalleMedicionesConFiltro(Convert.ToInt32(cookie.Value));

            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Hora", typeof(string)));
            datos.Columns.Add(new DataColumn("Sistólica", typeof(string)));
            datos.Columns.Add(new DataColumn("Diastólica", typeof(string)));

            for (int i = 0; i < detalleMedicionesConFiltro.Rows.Count; i++)
            {
                datos.Rows.Add(new Object[] { detalleMedicionesConFiltro.Rows[i]["Fecha"].ToString(), detalleMedicionesConFiltro.Rows[i]["Valor Máximo"].ToString(), detalleMedicionesConFiltro.Rows[i]["Valor Mínimo"].ToString() });
            }

            String cadenaDatos = "[['Hora', 'Sistolica', 'Diastólica'],";

            foreach (DataRow dr in datos.Rows)
            { 
               cadenaDatos = cadenaDatos + "[";
               cadenaDatos = cadenaDatos + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2];
               cadenaDatos = cadenaDatos + "],";
            }
            cadenaDatos = cadenaDatos + "]";
            return cadenaDatos;
        }

        protected void cFechaDesde_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaDesde.Text= this.cFechaDesde.SelectedDate.ToString();
        }

        protected void cFechaHasta_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaHasta.Text = this.cFechaHasta.SelectedDate.ToString();
        }
    }
}