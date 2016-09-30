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
    public class FormaAdministracionDAO
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
         * Método para registrar formas de administracion de medicamentos.
         * Recibe como parámetro un objeto FormaAdministracion.
         * Valor de retorno void.
         */
        public static void registrarFormaDeAdministracion(FormaAdministracion formaAdministracion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                string consulta = @"insert into FormaAdministracion(nombre)
                                    values(@nombre)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", formaAdministracion.nombre);

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
        * Método para obtener todas las columnas de la tabla FormaAdministracion.
        * No recibe datos como parámetro.
        * Retorna una lista de objetos FormaAdministracion.
        */
        public static List<FormaAdministracion> mostrarFormasDeAdministracion()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<FormaAdministracion> formasAdministracion = new List<FormaAdministracion>();
            try
            {
                cn.Open();

                string consulta = "select * from FormaAdministracion";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    formasAdministracion.Add(new FormaAdministracion()
                    {
                        id_formaAdministracion = (int)dr["id_formaAdministracion"],
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
            return formasAdministracion;
        }

    }
}
