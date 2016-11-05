using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class TamañoDAO
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
         * Método para mostrar la clasificación de tamaños para ganglios.
         * No recibe valores como parámetros.
         * Retorna una lista de objetos Tamaños.
         */
        public static List<Tamaño> mostrarTamañosGanglio()
        {
            setCadenaConexion();
            List<Tamaño> tamaños = new List<Tamaño>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from Tamaño";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tamaños.Add(new Tamaño()
                    {
                        id_tamaño = (int)dr["id_tamaño"],
                        nombre = dr["nombre"].ToString(),
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
            return tamaños;
        }
    }
}
