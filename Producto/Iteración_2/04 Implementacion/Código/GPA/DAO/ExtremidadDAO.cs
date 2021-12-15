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
    public class ExtremidadDAO
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
* Método para obtener los nombres de extremidades.
* No recibe parámetros.
* Retorna una lista de objetos Extremidad.
*/
        public static List<Extremidad> MostrarExtremidades()
        {

            SqlConnection cn = null;
            List<Extremidad> extremidades = new List<Extremidad>();
            try
            {
                SetCadenaConexion();
                cn = new SqlConnection(GetCadenaConexion());
                cn.Open();

                string consulta = "select * from Extremidad";
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    CommandText = consulta
                };

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    extremidades.Add(new Extremidad()
                    {
                        id_extremidad = (int)dr["id_extremidad"],
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
            return extremidades;
        }

    }
}
