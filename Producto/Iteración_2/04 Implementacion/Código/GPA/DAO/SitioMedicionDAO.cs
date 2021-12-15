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
    public class SitioMedicionDAO
    {
        private static string cadenaConexion;

        public static void SetCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string GetCadenaConexion()
        {
            return cadenaConexion;
        }
        /*
* Método para obtener los nombres de sitios de mediciones.
* No recibe parámetros.
* Retorna una lista de objetos SitioMedicion.
*/
        public static List<SitioMedicion> MostrarSitiosDeMedicion()
        {
            SqlConnection cn = null;
            List<SitioMedicion> sitios = new List<SitioMedicion>();
            try
            {
                SetCadenaConexion();
                cn = new SqlConnection(GetCadenaConexion());
                cn.Open();

                string consulta = "select * from SitioMedicion";
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    CommandText = consulta
                };

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sitios.Add(new SitioMedicion()
                    {
                        id_sitioMedicion = (int)dr["id_sitioMedicion"],
                        nombre = dr["nombre"].ToString()
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
            return sitios;
        }
    }
}
