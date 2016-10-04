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
    public class EstadoDAO
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

        public static List<Estado> buscarEstados()
        {
            setCadenaConexion();
            List<Estado> estados = new List<Estado>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT E.id_estado, E.nombre, E.descripcion FROM Estado E";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                estados.Add(new Estado()
                {
                    id_estado = (int)dr["id_estado"],
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString(),
                });
            }
            cn.Close();
            return estados;
        }

        public static Estado buscarEstadoPorNombre(string nombre)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT id_estado,nombre,descripcion FROM Estado " +
                              "WHERE nombre LIKE @paramNombre";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Estado estado = new Estado();
                estado.id_estado = (int)dr["id_estado"];
                estado.nombre = dr["nombre"].ToString();
                estado.descripcion = dr["descripcion"].ToString();
                cn.Close();
                return estado;
            }
            else
            {
                cn.Close();
                return null;
            }
        }
    }
}
