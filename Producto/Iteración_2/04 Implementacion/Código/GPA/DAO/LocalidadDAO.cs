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
    public class LocalidadDAO
    {
        //private static string cadenaConexion="Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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
        
        public static List<Localidad> buscarLocalidades()
        {
            setCadenaConexion();
            List<Localidad> localidades = new List<Localidad>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select id_localidad,nombre from Localidad";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                localidades.Add(new Localidad()
                {
                    id_localidad = (int)dr["id_localidad"],
                    nombre = dr["nombre"].ToString()
                });
            }
            cn.Close();
            return localidades;
        }

        public static Localidad buscarLocalidad(int id)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = "SELECT id_localidad,nombre FROM Localidad " +
                                  "WHERE id_localidad=@paramId_localidad";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@paramId_localidad", id);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.id_localidad = (int)dr["id_localidad"];
                    localidad.nombre = dr["nombre"].ToString();

                    cn.Close();
                    return localidad;
                }
                else
                {
                    cn.Close();
                    return null;
                }
            }
          
        

        public static int insertarLocalidad(string nombre)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into Localidad (nombre) values (@paramNombre)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);
            int idloc = Convert.ToInt32(cmd1.ExecuteScalar());

            cn.Close();
            return idloc;
        }

        public static void actualizarLocalidad(int id, string nombre)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "UPDATE Localidad SET nombre=@paramNombre, " +
                              "WHERE id_localidad=@paramId_localidad";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramId_localidad", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void eliminarLocalidad(int id)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consultaBarriosDeLocalidad = "DELETE FROM Barrio WHERE id_localidad_fk=@paramId_localidad_fk";

                SqlCommand cmdBarriosDeLocalidad = new SqlCommand();
                cmdBarriosDeLocalidad.Parameters.AddWithValue("@paramId_localidad_fk", id);

                cmdBarriosDeLocalidad.CommandText = consultaBarriosDeLocalidad;
                cmdBarriosDeLocalidad.CommandType = CommandType.Text;
                cmdBarriosDeLocalidad.Connection = cn;
                cmdBarriosDeLocalidad.Transaction = tran;

                cmdBarriosDeLocalidad.ExecuteNonQuery();

                string consultaLocalidad = "DELETE FROM Localidad WHERE id_localidad=@paramId_localidad";

                SqlCommand cmdLocalidad = new SqlCommand();
                cmdLocalidad.Parameters.AddWithValue("@paramId_localidad", id);

                cmdLocalidad.CommandText = consultaLocalidad;
                cmdLocalidad.CommandType = CommandType.Text;
                cmdLocalidad.Connection = cn;
                cmdLocalidad.Transaction = tran;

                cmdLocalidad.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (SqlException ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error al eliminar localidad\nDetalles: "+ex.Message);
            }
        }
        /*
         * Método para buscar los datos de una localidad por su id.
         * Accede a la base de datos para buscar la localidad.
         * Toma como parámetro el id_localidad.
         * Retorna un objeto Localidad.
         */
        public static Localidad mostrarLocalidad(int id_localidad)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Localidad localidad = null;
            try
            {
                cn.Open();
                string consulta = "select * from localidad where id_localidad=@idLocalidad";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("idLocalidad", id_localidad);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    localidad = new Localidad();
                    localidad.id_localidad = (int)dr["id_localidad"];
                    localidad.nombre = dr["nombre"].ToString();
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
            return localidad;
                
        }
    }
}
