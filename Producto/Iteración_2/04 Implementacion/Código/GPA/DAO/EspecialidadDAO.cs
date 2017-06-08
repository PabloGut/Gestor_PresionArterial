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
    public class EspecialidadDAO
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

        public static List<Especialidad> buscarEspecialidades()
        {
            setCadenaConexion();
            List<Especialidad> especialidades = new List<Especialidad>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select id_especialidad,nombre,descripcion from Especialidad";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                especialidades.Add(new Especialidad()
                {
                    id_especialidad = (int)dr["id_especialidad"],
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString()
                });
            }
            cn.Close();
            return especialidades;
        }

        public static int insertarEspecialidad(string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into Especialidad (nombre, descripcion) values (@paramNombre, @paramDescripcion)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);
            int idhc = Convert.ToInt32(cmd1.ExecuteScalar());


            cn.Close();
            return idhc;
        }

        public static void actualizarEspecialidad(int id, string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "UPDATE Especialidad SET nombre=@paramNombre, descripcion=@paramDescripcion " +
                              "WHERE id_especialidad=@paramId_especialidad";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);
            cmd.Parameters.AddWithValue("@paramId_especialidad", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void eliminarEspecialidad(int id)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "DELETE FROM Especialidad WHERE id_especialidad=@paramId_especialidad";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramId_especialidad", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        /*
         * Método para buscar el nombre de la especialidad correspondiente al id_especialidad.
         * Recibe como parámetro el id_especialidad.
         * Retorna un objeto Especialidad.
         */
        public static Especialidad mostrarEspecialidad(int id_especidadlidad)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Especialidad especialidad = null;
            try
            {
                cn.Open();
                string consulta = "select nombre from Especialidad where id_especialidad=@idEspecialidad";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idEspecialidad", id_especidadlidad);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    especialidad = new Especialidad();
                    especialidad.nombre = dr["nombre"].ToString();
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
            return especialidad;
        }
    }
}
