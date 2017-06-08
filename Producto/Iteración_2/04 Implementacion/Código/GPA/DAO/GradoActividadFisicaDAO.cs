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
    public class GradoActividadFisicaDAO
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
       * Método para obtener los nombres de los grados de actividad física.
       * No recibe parámetros.
       * Retorna una lista de objetos GradoActividadFisica.
       */
        public static List<GradoActividadFisica> mostrarGradosActividadFisica()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<GradoActividadFisica> gradosActividadFisica = new List<GradoActividadFisica>();
            try
            {
                cn.Open();

                string consulta = "select * from GradoActividad";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gradosActividadFisica.Add(new GradoActividadFisica()
                    {
                        id_gradoActividadFisica = (int)dr["id_gradoActividad"],
                        nombre = dr["nombre"].ToString(),
                        descripcion=dr["descripcion"].ToString()
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
            return gradosActividadFisica;
        }
    }
}
