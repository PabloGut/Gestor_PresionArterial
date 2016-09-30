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
    public class UnidadMedidaDAO
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
         * Método para registrar unidades de medida.
         * Recibe como parámetro un objeto UnidadMedida.
         * Valor de retorno void.
         */
        public static void registrarUnidadDeMedida(UnidadDeMedida unidadMedida)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());
            
            try
            {
                cn.Open();
                string consulta = @"insert into UnidadMedida(nombre,descripcion)
                                    values(@nombre,@descripcion)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", unidadMedida.nombre);
                cmd.Parameters.AddWithValue("@descripcion", unidadMedida.descripcion);
                
               

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
                cn.Close();
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
        }
        /*
       * Método para obtener todas las columnas de la tabla unidadMedida.
       * No recibe datos como parámetro.
       * Retorna una lista de objetos UnidadMedida.
       */
        public static List<UnidadDeMedida> mostrarUnidadesDeMedida()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<UnidadDeMedida> unidades = new List<UnidadDeMedida>();
            try
            {
                cn.Open();

                string consulta = "select * from UnidadMedida";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    unidades.Add(new UnidadDeMedida()
                    {
                        id_unidadMedida = (int)dr["id_unidadMedida"],
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
            return unidades;
        }

    }
}
