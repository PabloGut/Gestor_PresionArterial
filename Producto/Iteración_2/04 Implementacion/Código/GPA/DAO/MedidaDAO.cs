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
    public class MedidaDAO
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
         * Método para obtener todas las columnas de la tabla Medida.
         * No recibe datos como parámetro.
         * Retorna una lista de objetos Medida.
         */
        public static List<Medida> mostrarMedidasDeBebidasAlcoholicas()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<Medida> medidas = new List<Medida>();
            try
            {
                cn.Open();

                string consulta = "select * from Medida";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medidas.Add(new Medida()
                    {
                        id_medida = (int)dr["id_medida"],
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString()
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
            return medidas;
        }
    }
}
