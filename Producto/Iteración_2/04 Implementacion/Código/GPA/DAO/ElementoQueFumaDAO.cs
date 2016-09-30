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
    public class ElementoQueFumaDAO
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
         * Método para obtener el nombre de ElementoQueFuma.
         * No recibe parámetros.
         * Retorna una lista de objetos ElementoQueFuma.
         */
        public static List<ElementoQueFuma> mostrarNombreElementosQueFuma()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<ElementoQueFuma> elementos = new List<ElementoQueFuma>();
            try
            {
                cn.Open();

                string consulta = "select * from ElementoQueFuma";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    elementos.Add(new ElementoQueFuma()
                    {
                        id_elementoQueFuma = (int)dr["id_elemento"],
                        nombre  = dr["nombre"].ToString()
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
            return elementos;
        }
    }
}
