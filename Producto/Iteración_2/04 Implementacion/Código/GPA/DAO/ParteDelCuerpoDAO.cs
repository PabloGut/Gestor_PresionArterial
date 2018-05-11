using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;

namespace DAO
{
    public class ParteDelCuerpoDAO
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
         * Método para buscar las partes del cuerpo humano.
         * No recibe parámetros.
         * Retorna una lista de objetos ParteDelCuerpo.
         */
        public static List<ParteDelCuerpo> mostrarPartesDelCuerpoHumano()
        {
            setCadenaConexion();
            List<ParteDelCuerpo> partesCuerpo = new List<ParteDelCuerpo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta= "select * from ParteDelCuerpo";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    partesCuerpo.Add(new ParteDelCuerpo()
                                        {
                                            id_parteCuerpo = (int)dr["id_parteDelCuerpo"],
                                            nombre=dr["nombre"].ToString()
                                        });
                }

            }
            catch(Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return partesCuerpo;
            
        }
        public static List<ParteDelCuerpo> presentarPartesDelCuerpo()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<ParteDelCuerpo> partesDelCuerpo = new List<ParteDelCuerpo>();
            try
            {
                cn.Open();

                string consulta = @"select * from ParteDelCuerpo 
                                    where nombre not like '--Seleccionar--'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    partesDelCuerpo.Add(new ParteDelCuerpo()
                    {
                        id_parteCuerpo = (int)dr["id_ParteDelCuerpo"],
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
            return partesDelCuerpo;
        }

        public static void insertPartesDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                string consulta = @"insert into ParteDelCuerpo(nombre)
                                    values(@nombre)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", parteDelCuerpo.nombre);

                cn.Open();
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
                throw new ApplicationException("Error en insert de parte del cuerpo:" + e.Message);
            }
        }
        public static void updatePartesDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                string consulta = @"update ParteDelCuerpo
                                    set nombre=@nombre
                                    where id_parteDelCuerpo=@idParteDelCuerpo";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", parteDelCuerpo.nombre);
                cmd.Parameters.AddWithValue("@idParteDelCuerpo", parteDelCuerpo.id_parteCuerpo);

                cn.Open();
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
                throw new ApplicationException("Error en update de parte del cuerpo:" + e.Message);
            }
        }
        public static void deletePartesDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                string consulta = @"delete from ParteDelCuerpo
                                    where id_parteDelCuerpo=@idParteDelCuerpo";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idParteDelCuerpo", parteDelCuerpo.id_parteCuerpo);

                cn.Open();
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
                throw new ApplicationException("Error en delete de parte del cuerpo:" + e.Message);
            }
        }

    }
}
