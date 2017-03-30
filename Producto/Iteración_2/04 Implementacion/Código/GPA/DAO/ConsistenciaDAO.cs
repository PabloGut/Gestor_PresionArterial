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
    public class ConsistenciaDAO
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
       * Método para obtener la consistencia de los gánglios.
       * No recibe parámetros.
       * Retorna una lista de objetos Consistencia.
       */
        public static List<Consistencia> mostrarConsistencia()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<Consistencia> consistencia = new List<Consistencia>();
            try
            {
                cn.Open();

                string consulta = "select * from Consistencia";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    consistencia.Add(new Consistencia()
                    {
                        id_consistencia = (int)dr["id_consistencia"],
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
            return consistencia;
        }
    }
}
