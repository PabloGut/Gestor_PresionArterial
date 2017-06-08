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
    public class UbicacionDAO
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
         * Método para mostrar las regiones donde se encuentran ganglios linfáticos.
         * No recibe valores como parámetros.
         * Retorna una lista de objetos Ubicación.
         */
        public static List<Ubicacion> mostrarUbicaciones()
        {
            setCadenaConexion();
            List<Ubicacion> ubicaciones = new List<Ubicacion>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from Ubicacion";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ubicaciones.Add(new Ubicacion()
                    {
                        id_ubicacion = (int)dr["id_ubicacion"],
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
            return ubicaciones;
        }
    }
}
