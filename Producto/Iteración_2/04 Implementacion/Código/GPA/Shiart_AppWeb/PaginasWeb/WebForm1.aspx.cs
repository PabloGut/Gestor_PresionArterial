using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shiart_AppWeb.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using LogicaNegocio;
using System.Data;
using System.Data.SqlClient;
namespace Shiart_AppWeb.PaginasWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///////Funciona!!!
            //ReportDocument rd = new ReportDocument();
            ////rd.Load(Server.MapPath("~/Reportes/ReporteHistoriaClinica.rpt"));
            //rd.Load(Server.MapPath(@"~/Reportes/ReporteHistoriaClinica.rpt"));
            //rd.SetDataSource((Shiart_AppWeb.DatosDataset.DataSetHistoriaClinica)Session["dataset"]);
            //CrystalReportViewer1.ReportSource = rd;
            //CrystalReportViewer1.RefreshReport();
        }
    }
}