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
    public class DescripcionDelTiempoDAO
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
        * Método para mostrar todos los atributos de las descripciones del tiempo.
        * No recibe valores como parámetros.
        * Retorna una lista de objetos DescripcionDelTiempo.
        */
        public static List<DescripcionDelTiempo> mostrarDescripcionesDelTiempo()
        {
            setCadenaConexion();
            List<DescripcionDelTiempo> descripcionesDelTiempo = new List<DescripcionDelTiempo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from DescripcionDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    descripcionesDelTiempo.Add(new DescripcionDelTiempo()
                    {
                        id_descripcionDelTiempo = (int)dr["id_descripcionDelTiempo"],
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
            return descripcionesDelTiempo;
        }
    }
}
