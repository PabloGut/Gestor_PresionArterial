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
    public class ActividadFisicaDAO
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
       * Método para obtener los nombres de actividades físicas.
       * No recibe parámetros.
       * Retorna una lista de objetos ActividadFisica.
       */
        public static List<ActividadFisica> mostrarActividadFisica()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<ActividadFisica> actividades = new List<ActividadFisica>();
            try
            {
                cn.Open();

                string consulta = "select * from ActividadFisica";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    actividades.Add(new ActividadFisica()
                    {
                        id_actividadFisica = (int)dr["id_actividadFisica"],
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
            return actividades;
        }
    }
}
