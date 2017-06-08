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
    public class TipoSintomaDAO
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
         * Método para buscar los tipos de síntomas.
         * No recibe parámetros.
         * Retorna una lista de objetos TiposSintoma.
         */
        public static List<TipoSintoma> mostrarTiposSintomas()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<TipoSintoma> tiposSintoma = new List<TipoSintoma>();
            try
            {
                cn.Open();

                string consulta = "select * from TipoSintoma";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposSintoma.Add(new TipoSintoma()
                                        {
                                           id_tipoSintoma=(int)dr["id_TipoSintoma"],
                                           nombre=dr["nombre"].ToString()
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
            return tiposSintoma;
        }
    }
}
