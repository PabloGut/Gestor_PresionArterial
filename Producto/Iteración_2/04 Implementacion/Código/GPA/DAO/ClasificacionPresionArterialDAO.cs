using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using System.Data.SqlClient;

namespace DAO
{
    public class ClasificacionPresionArterialDAO
    {
        private static string cadenaConexion;

        public static void setCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string getCadenaConexion()
        {
            return cadenaConexion;
        }

        /*
* Método para obtener las categorías de presión arterial.
* No recibe parámetros.
* Retorna una lista de objetos ClasificacionPresionArterial.
*/
        public static List<ClasificacionPresionArterial> mostrarClasificacionesDePresionArterial()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<ClasificacionPresionArterial> clasificaciones = new List<ClasificacionPresionArterial>();
            try
            {
                cn.Open();

                string consulta = "select * from ClasificacionPresionArterial";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clasificaciones.Add(new ClasificacionPresionArterial()
                    {
                        id_clasificacion = (int)dr["id_clasificacion"],
                        categoria = dr["categoria"].ToString(),
                        minimaDesde = (int)dr["minimaDesde"],
                        minimaHasta = (int)dr["minimaHasta"],
                        maximaDesde = (int)dr["maximaDesde"],
                        maximaHasta = (int)dr["maximaHasta"]
                    });
                }

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return clasificaciones;
        }
    }
}
