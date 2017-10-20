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
    public class TerapiaDAO
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
        public static List<Terapia> mostrarTerapias()
        {
            setCadenaConexion();
            string consulta = @"select id_terapia, nombre from Terapia";
            List<Terapia> terapias = new List<Terapia>();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    terapias.Add(new Terapia()
                    {
                        id_terapia=(int)dr["id_terapia"],
                        nombre=dr["nombre"].ToString()

                    });
                }
                cn.Close();
            }
            catch (Exception)
            {

            }

            return terapias;
        }
    }
}
