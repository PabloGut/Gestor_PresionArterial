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
    public class ElementoDelTiempoDAO
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
         * Método para mostrar todos los atributos de los elementos del Tiempo.
         * No recibe valores como parámetros.
         * Retorna una lista de objetos ElementoDelTiempo.
         */
        public static List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            setCadenaConexion();
            List<ElementoDelTiempo> elementosDelTiempo = new List<ElementoDelTiempo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from ElementoDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    elementosDelTiempo.Add(new ElementoDelTiempo()
                                            {
                                                id_elementoDelTiempo=(int)dr["id_elementoDelTiempo"],
                                                nombre=dr["nombre"].ToString(),
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
            return elementosDelTiempo;
        }
    }
}
