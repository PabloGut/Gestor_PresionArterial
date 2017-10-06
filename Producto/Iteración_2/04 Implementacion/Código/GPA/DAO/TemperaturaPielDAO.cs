using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Clases;
namespace DAO
{
    public class TemperaturaPielDAO
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
        public static List<TemperaturaPiel> obtenerTemperaturaPiel()
        {
            string consulta = @"select * from TemperaturaPiel";

            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();
            List<TemperaturaPiel> temperaturas = new List<TemperaturaPiel>();
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temperaturas.Add(new TemperaturaPiel()
                    {
                        id_temperatura = (int)dr["id_temperatura"],
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
            return temperaturas;
        }
    }
}
