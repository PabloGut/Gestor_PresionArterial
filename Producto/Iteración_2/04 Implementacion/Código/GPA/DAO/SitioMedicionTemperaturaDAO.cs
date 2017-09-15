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
    public class SitioMedicionTemperaturaDAO
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
        public static List<SitioMedicionTemperatura> mostrarSitioMedicionTemperatura()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<SitioMedicionTemperatura> sitios = new List<SitioMedicionTemperatura>();
            try
            {
                cn.Open();

                string consulta = "select * from SitioMedicionTemperatura";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sitios.Add(new SitioMedicionTemperatura()
                    {
                        id_sitioMedicion = (int)dr["id_sitioMedicionTemperatura"],
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
