using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;

namespace DAO
{
    public class ParteDelCuerpoDAO
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
         * Método para buscar las partes del cuerpo humano.
         * No recibe parámetros.
         * Retorna una lista de objetos ParteDelCuerpo.
         */
        public static List<ParteDelCuerpo> mostrarPartesDelCuerpoHumano()
        {
            setCadenaConexion();
            List<ParteDelCuerpo> partesCuerpo = new List<ParteDelCuerpo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta= "select * from ParteDelCuerpo";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    partesCuerpo.Add(new ParteDelCuerpo()
                                        {
                                            id_parteCuerpo = (int)dr["id_parteDelCuerpo"],
                                            nombre=dr["nombre"].ToString()
                                        });
                }

            }
            catch(Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return partesCuerpo;
            
        }
    }
}
