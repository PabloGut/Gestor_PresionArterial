using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
namespace WebApplication1
{
    public partial class CargaAutomatica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropDownList(ddlExtremidad, ExtremidadLN.mostrarExtremidades(), "id_extremidad", "nombre");
                cargarDropDownList(ddlPosicion, PosicionLN.mostrarPosiciones(), "id_posicion", "nombre");
                cargarDropDownList(ddlSitioMedicion, SitioMedicionLN.mostrarSitiosDeMedicion(), "id_sitioMedicion", "nombre");
                cargarDropDownList(ddlMomentoDelDia, MomentoDiaLN.mostrarMomentosDelDia(), "idMomentoDia", "nombre");
                cargarDropDownList(ddlUbicación, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(ddlExtremidad.SelectedValue)), "id_ubicacionExtremidad", "nombre");
            }
        }
        public void cargarDropDownList<T>(DropDownList ddl, List<T> lista, string valueField, string textField)
        {
            ddl.DataSource = lista;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        protected void ddlUbicación_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void ddlExtremidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idExtremidad"] = Convert.ToInt32(ddlExtremidad.SelectedValue);
            if (Session["idExtremidad"] != null)
            {
                int id = (int)Session["idExtremidad"];
                cargarDropDownList(ddlUbicación, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(id), "id_ubicacionExtremidad", "nombre");
            }
        }
    }
}