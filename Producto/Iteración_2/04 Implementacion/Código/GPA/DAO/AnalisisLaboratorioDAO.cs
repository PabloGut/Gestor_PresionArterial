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
    public class AnalisisLaboratorioDAO
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
      * Método para obtener los nombres de pruebas de laboratorio.
      * No recibe parámetros.
      * Retorna una lista de objetos AnalisisLaboratorio.
      */
        public static List<AnalisisLaboratorio> mostrarAnalisisLaboratorio()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<AnalisisLaboratorio> analisis = new List<AnalisisLaboratorio>();
            try
            {
                cn.Open();

                string consulta = "select * from AnalisisLaboratorio";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    analisis.Add(new AnalisisLaboratorio()
                    {
                        id_analisis = (int)dr["id_analisis"],
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
            return analisis;
        }
    }
}
