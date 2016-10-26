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
    public class EstadoProgramacionDAO
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
        public static int buscarIdEstado(string nombre)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            int idEstado=0;
            try
            {

                cn.Open();

                string consulta = @"select id_estadoProgramacion from EstadoProgramacion
                                   where nombre like @nombre";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", nombre);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        idEstado = (int)dr["id_estadoProgramacion"];
                    }
                }

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            cn.Close();
            return idEstado;
        }
    }
}
