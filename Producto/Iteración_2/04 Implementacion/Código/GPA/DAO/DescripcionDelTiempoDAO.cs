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
    public class DescripcionDelTiempoDAO
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
        * Método para mostrar todos los atributos de las descripciones del tiempo.
        * No recibe valores como parámetros.
        * Retorna una lista de objetos DescripcionDelTiempo.
        */
        public static List<DescripcionDelTiempo> MostrarDescripcionesDelTiempo()
        {
            setCadenaConexion();
            List<DescripcionDelTiempo> descripcionesDelTiempo = new List<DescripcionDelTiempo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from DescripcionDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    descripcionesDelTiempo.Add(new DescripcionDelTiempo()
                    {
                        id_descripcionDelTiempo = (int)dr["id_descripcionDelTiempo"],
                        nombre = dr["nombre"].ToString(),
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
            return descripcionesDelTiempo;
        }
        public static void InsertDescripcionTiempo(DescripcionDelTiempo Descripcion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into DescripcionDelTiempo(nombre)
                                values(@nombre)";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Descripcion.nombre);

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
        public static void DeleteDescripcionTiempo(DescripcionDelTiempo Descripcion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"delete from DescripcionDelTiempo
                                where id_descripcionDelTiempo=@idDescripcionTiempo";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@idDescripcionTiempo", Descripcion.id_descripcionDelTiempo);

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
        public static void UpdateDescripcionTiempo(DescripcionDelTiempo Descripcion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"update DescripcionDelTiempo
                                set nombre=@nombre
                                where id_descripcionDelTiempo=@idDescripcionTiempo";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Descripcion.nombre);
                cmd.Parameters.AddWithValue("@idDescripcionTiempo", Descripcion.id_descripcionDelTiempo);

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
    }
}
