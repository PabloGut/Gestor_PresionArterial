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
    public class PosicionDAO
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
* Método para obtener los nombres de posiciones.
* No recibe parámetros.
* Retorna una lista de objetos Posicion.
*/
        public static List<Posicion> MostrarPosiciones()
        {
            SqlConnection cn = null;
            List<Posicion> posiciones = new List<Posicion>();
            try
            {
                SetCadenaConexion();
                cn = new SqlConnection(GetCadenaConexion());
                cn.Open();

                string consulta = "select * from Posicion";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    posiciones.Add(new Posicion()
                    {
                        id_posicion = (int)dr["id_posicion"],
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
            return posiciones;
        }
    }
}
