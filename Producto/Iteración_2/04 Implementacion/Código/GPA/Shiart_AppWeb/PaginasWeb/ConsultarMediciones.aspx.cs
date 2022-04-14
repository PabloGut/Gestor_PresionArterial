using Entidades.Clases;
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

        DateTime? fechaDesde = null;
        DateTime? fechaHasta = null;

        String extremidad = null;
        String momentoDiaSeleccionado = null;
        String posicionSeleccionada = null;
        String ubicacionExtremidadSeleccionada = null;
        String sitioMedicionSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["idHc"];
            if (!IsPostBack)
            {
                cargarCombos();
                if (cookie != null)
                {
                    //mediciones = MedicionDePresionArterialLN.ObtenerDetalleMedicionesPresionArterial(Convert.ToInt32(cookie.Value), null, null, null, null, null, null, null);
                    //mediciones = MedicionDePresionArterialLN.ObtenerMedicionesConFiltro(Convert.ToInt32(cookie.Value), null, null, null, null, null, null, null);
                    mediciones = MedicionDePresionArterialLN.ObtenerMedicionesPresionArterial(Convert.ToInt32(cookie.Value), null, null, null, null, null, null, null);
                    RepeaterMediciones.DataSource = mediciones;
                    RepeaterMediciones.DataBind();
                }
            }
            //else
            //{
            //    if (!String.IsNullOrEmpty(txtFechaDesde.Text))
            //        fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            //    if (!String.IsNullOrEmpty(txtFechaHasta.Text))
            //        fechaHasta = DateTime.Parse(txtFechaHasta.Text);
            //    if (!String.IsNullOrEmpty(ddlFiltroExtremidad.SelectedItem.Text) && !ddlFiltroExtremidad.SelectedItem.Text.Equals("--Seleccionar--"))
            //        extremidad = ddlFiltroExtremidad.SelectedItem.Text;
            //    if (!String.IsNullOrEmpty(ddlFiltroMomentoDia.SelectedItem.Text) && !ddlFiltroMomentoDia.SelectedItem.Text.Equals("--Seleccionar--"))
            //        momentoDiaSeleccionado = ddlFiltroMomentoDia.SelectedItem.Text;
            //    if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
            //        posicionSeleccionada = ddlFiltroPosicion.SelectedItem.Text;
            //    if (!String.IsNullOrEmpty(ddlFiltroUbicacion.SelectedItem.Text) && !ddlFiltroUbicacion.SelectedItem.Text.Equals("--Seleccionar--"))
            //        ubicacionExtremidadSeleccionada = ddlFiltroUbicacion.SelectedItem.Text;
            //    if (!String.IsNullOrEmpty(ddlFiltroSitioMedicion.SelectedItem.Text) && !ddlFiltroSitioMedicion.SelectedItem.Text.Equals("--Seleccionar--"))
            //        sitioMedicionSeleccionado = ddlFiltroSitioMedicion.SelectedItem.Text;

            //    mediciones = MedicionDePresionArterialLN.obtenerMedicionesPresionArterial(Convert.ToInt32(cookie.Value), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);
            //    mediciones = MedicionDePresionArterialLN.obtenerMedicionesConFiltro(Convert.ToInt32(cookie.Value), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);
            //    RepeaterMediciones.DataSource = mediciones;
            //    RepeaterMediciones.DataBind();
            //}

        }

        protected void RepeaterMediciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            string idMedicion = ((System.Data.DataRowView)(e.Item.DataItem)).Row["id_medicion"].ToString();

            HttpCookie cookie = Request.Cookies["idHc"];

            if (!String.IsNullOrEmpty(txtFechaDesde.Text))
                fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            if (!String.IsNullOrEmpty(txtFechaHasta.Text))
                fechaHasta = DateTime.Parse(txtFechaHasta.Text);
            if (!String.IsNullOrEmpty(ddlFiltroExtremidad.SelectedItem.Text) && !ddlFiltroExtremidad.SelectedItem.Text.Equals("--Seleccionar--"))
                extremidad = ddlFiltroExtremidad.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroMomentoDia.SelectedItem.Text) && !ddlFiltroMomentoDia.SelectedItem.Text.Equals("--Seleccionar--"))
                momentoDiaSeleccionado = ddlFiltroMomentoDia.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
                posicionSeleccionada = ddlFiltroPosicion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroUbicacion.SelectedItem.Text) && !ddlFiltroUbicacion.SelectedItem.Text.Equals("--Seleccionar--"))
                ubicacionExtremidadSeleccionada = ddlFiltroUbicacion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroSitioMedicion.SelectedItem.Text) && !ddlFiltroSitioMedicion.SelectedItem.Text.Equals("--Seleccionar--"))
                sitioMedicionSeleccionado = ddlFiltroSitioMedicion.SelectedItem.Text;

            if(!IsPostBack)
                detalleMediciones = MedicionDePresionArterialLN.ObtenerDetalleMedicionesPresionArterial(Convert.ToInt32(cookie.Value), Convert.ToInt32(idMedicion),null,null,null,null,null,null,null);
            else
                detalleMediciones = MedicionDePresionArterialLN.ObtenerDetalleMedicionesPresionArterial(Convert.ToInt32(cookie.Value), Convert.ToInt32(idMedicion), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);


            System.Web.UI.WebControls.GridView gvDetalleMediciones = (e.Item.FindControl("gvDetalleMediciones") as System.Web.UI.WebControls.GridView);
            gvDetalleMediciones.DataSource = detalleMediciones;
            gvDetalleMediciones.DataBind();

            Session["detalleMediciones"] = detalleMediciones;

        }
        protected string graficar()
        {
            HttpCookie cookie = Request.Cookies["idHc"];

            if (!String.IsNullOrEmpty(txtFechaDesde.Text))
                fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            if (!String.IsNullOrEmpty(txtFechaHasta.Text))
                fechaHasta = DateTime.Parse(txtFechaHasta.Text);
            if (!String.IsNullOrEmpty(ddlFiltroExtremidad.SelectedItem.Text) && !ddlFiltroExtremidad.SelectedItem.Text.Equals("--Seleccionar--"))
                extremidad = ddlFiltroExtremidad.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroMomentoDia.SelectedItem.Text) && !ddlFiltroMomentoDia.SelectedItem.Text.Equals("--Seleccionar--"))
                momentoDiaSeleccionado = ddlFiltroMomentoDia.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
                posicionSeleccionada = ddlFiltroPosicion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroUbicacion.SelectedItem.Text) && !ddlFiltroUbicacion.SelectedItem.Text.Equals("--Seleccionar--"))
                ubicacionExtremidadSeleccionada = ddlFiltroUbicacion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroSitioMedicion.SelectedItem.Text) && !ddlFiltroSitioMedicion.SelectedItem.Text.Equals("--Seleccionar--"))
                sitioMedicionSeleccionado = ddlFiltroSitioMedicion.SelectedItem.Text;

            if(!IsPostBack)
                detalleMedicionesConFiltro = MedicionDePresionArterialLN.ObtenerMedicionesConFiltro(Convert.ToInt32(cookie.Value),null,null,null,null,null,null,null);
            else
                detalleMedicionesConFiltro = MedicionDePresionArterialLN.ObtenerMedicionesConFiltro(Convert.ToInt32(cookie.Value), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);


            if (detalleMedicionesConFiltro.Rows.Count == 0)
                return null;

            //detalleMedicionesConFiltro = MedicionDePresionArterialLN.obtenerDetalleMedicionesConFiltro(Convert.ToInt32(cookie.Value));

            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Hora", typeof(string)));
            datos.Columns.Add(new DataColumn("Sistólica", typeof(string)));
            datos.Columns.Add(new DataColumn("Diastólica", typeof(string)));

            for (int i = 0; i < detalleMedicionesConFiltro.Rows.Count; i++)
            {
                datos.Rows.Add(new Object[] { detalleMedicionesConFiltro.Rows[i]["Fecha"].ToString(), detalleMedicionesConFiltro.Rows[i]["ValorMaximo"].ToString(), detalleMedicionesConFiltro.Rows[i]["ValorMinimo"].ToString() });
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
        public void cargarCombos()
        {

            cargarCombo(ddlFiltroExtremidad, ExtremidadLN.MostrarExtremidades(), "id_extremidad", "nombre");
            cargarCombo(ddlFiltroPosicion, PosicionLN.MostrarPosiciones(), "id_posicion", "nombre");
            cargarCombo(ddlFiltroMomentoDia, MomentoDiaLN.MostrarMomentosDelDia(), "idmomentoDia", "nombre");
            cargarCombo(ddlFiltroSitioMedicion, SitioMedicionLN.MostrarSitiosDeMedicion(), "id_sitioMedicion", "nombre");

            if (Convert.ToInt32(ddlFiltroExtremidad.SelectedItem.Value) == 1)
            {
                cargarCombo(ddlFiltroUbicacion, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(ddlFiltroExtremidad.SelectedItem.Value)), "id_ubicacionExtremidad", "nombre");
            }
        }
        public static void cargarCombo<T>(DropDownList combo, List<T> lista, string valueMember, string displayMember)
        {
            combo.DataSource = lista;
            combo.DataTextField = displayMember;
            combo.DataValueField = valueMember;
            combo.DataBind();
        }

        protected void ddlFiltroExtremidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCombo(ddlFiltroUbicacion, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(ddlFiltroExtremidad.SelectedItem.Value)), "id_ubicacionExtremidad", "nombre");
        }

        protected void btnBuscarMediciones_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(txtFechaDesde.Text))
            //    fechaDesde =DateTime.Parse(txtFechaDesde.Text);
            //if (!String.IsNullOrEmpty(txtFechaHasta.Text))
            //    fechaHasta = DateTime.Parse(txtFechaHasta.Text);
            //if(!String.IsNullOrEmpty(ddlFiltroExtremidad.SelectedItem.Text) && !ddlFiltroExtremidad.SelectedItem.Text.Equals("--Seleccionar--"))
            //    extremidad = ddlFiltroExtremidad.SelectedItem.Text;
            //if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
            //    momentoDiaSeleccionado = ddlFiltroMomentoDia.SelectedItem.Text;
            //if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
            //    posicionSeleccionada = ddlFiltroPosicion.SelectedItem.Text;
            //if (!String.IsNullOrEmpty(ddlFiltroUbicacion.SelectedItem.Text) && !ddlFiltroUbicacion.SelectedItem.Text.Equals("--Seleccionar--"))
            //    ubicacionExtremidadSeleccionada = ddlFiltroUbicacion.SelectedItem.Text;
            //if (!String.IsNullOrEmpty(ddlFiltroSitioMedicion.SelectedItem.Text) && !ddlFiltroSitioMedicion.SelectedItem.Text.Equals("--Seleccionar--"))
            //    sitioMedicionSeleccionado = ddlFiltroSitioMedicion.SelectedItem.Text;

            //HttpCookie cookie = Request.Cookies["idHc"];

            //DataTable mediciones = MedicionDePresionArterialLN.obtenerDetalleMedicionesPresionArterial(Convert.ToInt32(cookie.Value),)

            HttpCookie cookie = Request.Cookies["idHc"];
            if (!String.IsNullOrEmpty(txtFechaDesde.Text))
                fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            if (!String.IsNullOrEmpty(txtFechaHasta.Text))
                fechaHasta = DateTime.Parse(txtFechaHasta.Text);
            if (!String.IsNullOrEmpty(ddlFiltroExtremidad.SelectedItem.Text) && !ddlFiltroExtremidad.SelectedItem.Text.Equals("--Seleccionar--"))
                extremidad = ddlFiltroExtremidad.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroMomentoDia.SelectedItem.Text) && !ddlFiltroMomentoDia.SelectedItem.Text.Equals("--Seleccionar--"))
                momentoDiaSeleccionado = ddlFiltroMomentoDia.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroPosicion.SelectedItem.Text) && !ddlFiltroPosicion.SelectedItem.Text.Equals("--Seleccionar--"))
                posicionSeleccionada = ddlFiltroPosicion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroUbicacion.SelectedItem.Text) && !ddlFiltroUbicacion.SelectedItem.Text.Equals("--Seleccionar--"))
                ubicacionExtremidadSeleccionada = ddlFiltroUbicacion.SelectedItem.Text;
            if (!String.IsNullOrEmpty(ddlFiltroSitioMedicion.SelectedItem.Text) && !ddlFiltroSitioMedicion.SelectedItem.Text.Equals("--Seleccionar--"))
                sitioMedicionSeleccionado = ddlFiltroSitioMedicion.SelectedItem.Text;

            //mediciones = MedicionDePresionArterialLN.obtenerMedicionesPresionArterial(Convert.ToInt32(cookie.Value), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);
            mediciones = MedicionDePresionArterialLN.ObtenerMedicionesConFiltro(Convert.ToInt32(cookie.Value), fechaDesde, fechaHasta, extremidad, momentoDiaSeleccionado, posicionSeleccionada, ubicacionExtremidadSeleccionada, sitioMedicionSeleccionado);
            RepeaterMediciones.DataSource = mediciones;
            RepeaterMediciones.DataBind();

        }
    }
}