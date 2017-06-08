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
    public class SustanciaAmbienteDAO
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
        * Método para obtener todas las columnas de la tabla SustanciaAmbiente.
        * No recibe datos como parámetro.
        * Retorna una lista de objetos SustanciaAmbiente.
        */
        public static List<SustaciaAmbiente> mostrarSustanciasDelAmbiente()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<SustaciaAmbiente> sustanciasDelAmbiente = new List<SustaciaAmbiente>();
            try
            {
                cn.Open();

                string consulta = "select * from SustanciaAmbiente";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sustanciasDelAmbiente.Add(new SustaciaAmbiente()
                    {
                        id_sustanciaAmbiente = (int)dr["id_sustanciaAmbiente"],
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
            return sustanciasDelAmbiente;
        }
    }
}
