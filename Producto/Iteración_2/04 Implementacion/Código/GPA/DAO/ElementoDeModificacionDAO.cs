using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Clases;
namespace DAO
{
    public class ElementoDeModificacionDAO
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
       * Método para mostrar todos los atributos de los elementos que modifican los sintomas.
       * No recibe valores como parámetros.
       * Retorna una lista de objetos ElementosDeModificacion.
       */
        public static List<ElementoDeModificacion> mostrarElementosDeModificacionesDelSintoma()
        {
            setCadenaConexion();
            List<ElementoDeModificacion> elementosDeModificacion = new List<ElementoDeModificacion>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from ElementoDeModificacion";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    elementosDeModificacion.Add(new ElementoDeModificacion()
                    {
                        id_elementoDeModificacion = (int)dr["id_elementoDeModificacion"],
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
            return elementosDeModificacion;

        }
        public static void InsertElementoModificacion(ElementoDeModificacion Elemento)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into ElementoDeModificacion(nombre)
                                values(@nombre)";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Elemento.nombre);

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
        public static void DeleteElementoModificacion(ElementoDeModificacion Elemento)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"delete from ElementoDeModificacion
                                where id_elementoDeModificacion=@idElementoModificacion";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@idElementoModificacion", Elemento.id_elementoDeModificacion);

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
        public static void UpdateElementoModificacion(ElementoDeModificacion Elemento)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"update ElementoDeModificacion
                                set nombre=@nombre
                                where id_elementoDeModificacion=@idElementoModificacion";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", Elemento.nombre);
                cmd.Parameters.AddWithValue("@idElementoModificacion", Elemento.id_elementoDeModificacion);

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
