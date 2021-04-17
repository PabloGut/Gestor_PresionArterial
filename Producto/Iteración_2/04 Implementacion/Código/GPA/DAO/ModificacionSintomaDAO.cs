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
    public class ModificacionSintomaDAO
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
       * Método para mostrar todos los atributos de la forma de modificacion de un sintoma.
       * No recibe valores como parámetros.
       * Retorna una lista de objetos ModificacionSintoma.
       */
        public static List<ModificacionSintoma> mostrarModificacionesDelSintoma()
        {
            setCadenaConexion();
            List<ModificacionSintoma> modificacionesSintoma = new List<ModificacionSintoma>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from ModificacionSintoma";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    modificacionesSintoma.Add(new ModificacionSintoma()
                    {
                        id_modificacionSintoma = (int)dr["id_modificacionesSintoma"],
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
            return modificacionesSintoma;

        }
        public static void InsertModificacionSintoma(ModificacionSintoma Modificacion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into ModificacionSintoma(nombre)
                                values(@nombre)";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Modificacion.nombre);

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
        public static void DeleteModificacionSintoma(ModificacionSintoma Modificacion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"delete from ModificacionSintoma
                                where id_modificacionesSintoma=@idModificacionSintoma";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@idModificacionSintoma", Modificacion.id_modificacionSintoma);

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
        public static void UpdateModificacionSintoma(ModificacionSintoma Modificacion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"update ModificacionSintoma
                                set nombre=@nombre
                                where id_modificacionesSintoma=@idModificacionSintoma";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Modificacion.nombre);
                cmd.Parameters.AddWithValue("@idModificacionSintoma", Modificacion.id_modificacionSintoma);

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
