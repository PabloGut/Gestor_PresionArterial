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
    public class BarrioDAO
    {
        //nicoprivate static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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

        public static List<Barrio> buscarBarrios()
        {
            List<Barrio> barrios = new List<Barrio>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT B.id_barrio, B.nombre, B.descripcion, L.id_localidad, L.nombre AS nombre_localidad FROM Barrio B " +
                              "INNER JOIN Localidad L ON B.id_localidad_fk=L.id_localidad";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                barrios.Add(new Barrio()
                {
                    id_barrio = (int)dr["id_barrio"],
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString(),
                    localidad = new Localidad((int)dr["id_localidad"], dr["nombre_localidad"].ToString())
                });
            }
            cn.Close();
            return barrios;
        }

        public static List<Barrio> buscarBarriosDeLocalidad(int id)
        {
            setCadenaConexion();
            List<Barrio> barrios = new List<Barrio>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT B.id_barrio, B.nombre, B.descripcion, L.id_localidad, L.nombre AS nombre_localidad FROM Barrio B " +
                              "INNER JOIN Localidad L ON B.id_localidad_fk=L.id_localidad WHERE B.id_localidad_fk=@paramId_localidad";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramId_localidad", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                barrios.Add(new Barrio()
                {
                    id_barrio = (int)dr["id_barrio"],
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString(),
                    localidad = new Localidad((int)dr["id_localidad"], dr["nombre_localidad"].ToString())
                });
            }
            cn.Close();
            return barrios;
        }

        public static int insertarBarrio(int id_localidad, string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "INSERT INTO Barrio (nombre, descripcion, id_localidad_fk) " +
                              "VALUES (@paramNombre, @paramDescripcion, @paramId_localidad_fk)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);
            cmd.Parameters.AddWithValue("@paramId_localidad_fk", id_localidad);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("SELECT @@Identity", cn);
            int idhc = Convert.ToInt32(cmd1.ExecuteScalar());

            cn.Close();
            return idhc;
        }

        public static void actualizarBarrio(int id, string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "UPDATE Barrio SET nombre=@paramNombre, descripcion=@paramDescripcion " +
                              "WHERE id_barrio=@paramId_barrio";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);
            cmd.Parameters.AddWithValue("@paramId_barrio", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void eliminarBarrio(int id)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "DELETE FROM Barrio WHERE id_barrio=@paramId_barrio";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramId_barrio", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        /*
         * Método para buscar todos los datos de un barrio.
         * Recibe como parámetro el id_barrio.
         * Retorna un objeto barrio.
         */
        public static Barrio mostrarBarrio(int id_barrio)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            Barrio barrio = null;
            try
            {
                cn.Open();
                string consulta = "select * froma Barrio where id_barrio=@idBarrio";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    barrio = new Barrio();
                    barrio.id_barrio = (int)dr["id_barrio"];
                    barrio.nombre = dr["nombre"].ToString();
                    barrio.id_localidad=(int) dr["id_localidad"];
                    if (string.IsNullOrEmpty(dr["descripcion"].ToString()))
                    {
                        barrio.descripcion = dr["descripcion"].ToString();
                    }
                }
                barrio.localidad=LocalidadDAO.mostrarLocalidad(barrio.id_localidad);
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
            if (barrio != null)
            {
                barrio.localidad = LocalidadDAO.mostrarLocalidad(barrio.id_localidad);
            }
            return barrio;
        }
    }
}
