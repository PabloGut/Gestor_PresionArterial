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
    public class NombreEstudioDAO
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
       * Método para obtener los nombres de estudios de diagnóstico por imagenes.
       * No recibe parámetros.
       * Retorna una lista de objetos NombreEstudio.
       */
        public static List<NombreEstudio> mostrarNombreEstudio()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<NombreEstudio> nombresEstudios = new List<NombreEstudio>();
            try
            {
                cn.Open();

                string consulta = "select * from NombreEstudio";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nombresEstudios.Add(new NombreEstudio()
                    {
                        id_nombreEstudio = (int)dr["id_nombreEstudio"],
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
            return nombresEstudios;
        }
        public static int obtenerIdNombreEstudio(string nombreEstudio)
        {
            setCadenaConexion();

            int idNombreEstudio = 0;

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"select id_nombreEstudio 
                                from NombreEstudio 
                                where nombre like @nombre";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombre", nombreEstudio);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    idNombreEstudio = (int)dr["id_nombreEstudio"];
                }

                cn.Close();

                return idNombreEstudio;

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    }
}
