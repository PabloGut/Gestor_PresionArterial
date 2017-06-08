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
    public class IntensidadActividadFisicaDAO
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
       * Método para obtener la clasificación de la intensidad de una actividad física.
       * No recibe parámetros.
       * Retorna una lista de objetos IntensidadActividadFisica.
       */
        public static List<IntensidadActividadFisica> mostrarIntensidadActividadFisica()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<IntensidadActividadFisica> intensidades = new List<IntensidadActividadFisica>();
            try
            {
                cn.Open();

                string consulta = "select * from IntensidadActividadFisica";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    intensidades.Add(new IntensidadActividadFisica()
                    {
                        id_intensidad = (int)dr["id_intensidad"],
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
            return intensidades;
        }
    }
}
