using Entidades.Clases;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnActualizarContrasena_Click(object sender, EventArgs e)
        {
            String resultado = validar();

            if (resultado.Equals("") == false)
            {
                generarAlerta(resultado);
                return;
            }
            try
            {
                if (Session["idUsuario"] != null)
                {
                    if (!string.IsNullOrEmpty(txtContrasenaActual.Text) && !string.IsNullOrEmpty(txtNuevaContraseña.Text) && !string.IsNullOrEmpty(txtConfirmarContraseña.Text))
                    {
                        Boolean esValido = UsuarioLN.VerificarPassContrasena((int)Session["idUsuario"], txtContrasenaActual.Text);
                        if(esValido==true)
                        {
                            if (!txtContrasenaActual.Text.Equals(txtNuevaContraseña.Text))
                            {
                                if (txtNuevaContraseña.Text.Equals(txtConfirmarContraseña.Text) == true)
                                {
                                    UsuarioLN.UpdateContrasena(Convert.ToInt32(@HttpContext.Current.Session["idUsuario"].ToString()), txtNuevaContraseña.Text);
                                    generarAlerta("Contraseña actualizada correctamente");
                                }
                                else
                                {
                                    generarAlerta("Las contraseñas no coinciden");
                                }
                            }
                            else
                            {
                                generarAlerta("Las nueva contraseña no debe ser igual a la actual.");
                            }
                        }
                        else
                        {
                            generarAlerta("La contraseñan ingresada no es correcta");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                generarAlerta("Error al actualizar. "+ ex.StackTrace);
            }
        }
        public void generarAlerta(String Mensaje)
        {
            String script = string.Format(@"<script type='text/javascript'>
                                    alert('{0}')
                                    </script>", Mensaje);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", script, false);
        }
        public String validar()
        {
            if (string.IsNullOrEmpty(txtNuevaContraseña.Text) || string.IsNullOrEmpty(txtConfirmarContraseña.Text))
            {
                return "Falta ingresar nueva contraseña ";
            }
            return "";
        }
    }
}