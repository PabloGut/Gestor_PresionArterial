using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class TipoSintomaDAO
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
         * Método para buscar los tipos de síntomas.
         * No recibe parámetros.
         * Retorna una lista de objetos TiposSintoma.
         */
        public static List<TipoSintoma> mostrarTiposSintomas()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<TipoSintoma> tiposSintoma = new List<TipoSintoma>();
            try
            {
                cn.Open();

                string consulta = "select * from TipoSintoma";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposSintoma.Add(new TipoSintoma()
                                        {
                                           id_tipoSintoma=(int)dr["id_TipoSintoma"],
                                           nombre=dr["nombre"].ToString()
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
            return tiposSintoma;
        }
        public static List<TipoSintoma> presentarTiposSintomas()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<TipoSintoma> tiposSintoma = new List<TipoSintoma>();
            try
            {
                cn.Open();

                string consulta = @"select * from TipoSintoma 
                                    where nombre not like '--Seleccionar--'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposSintoma.Add(new TipoSintoma()
                    {
                        id_tipoSintoma = (int)dr["id_TipoSintoma"],
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
            return tiposSintoma;
        }
        public static void insertTipoSintoma(TipoSintoma tipo)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into TipoSintoma(nombre)
                                values(@nombre)";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre",tipo.nombre);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en insert:" + e.Message);
            }
        }
        public static void updateTipoSintoma(TipoSintoma tipo)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"update TipoSintoma
                                set nombre=@nombre
                                where id_TipoSintoma=@idTipoSintoma";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", tipo.nombre);
                cmd.Parameters.AddWithValue("@idTipoSintoma", tipo.id_tipoSintoma);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en update:" + e.Message);
            }
        }
        public static void deleteTipoSintoma(TipoSintoma tipo)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"delete from TipoSintoma
                                where id_TipoSintoma=@idTipoSintoma";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@idTipoSintoma", tipo.id_tipoSintoma);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en delete:" + e.Message);
            }
        }
    }
}
