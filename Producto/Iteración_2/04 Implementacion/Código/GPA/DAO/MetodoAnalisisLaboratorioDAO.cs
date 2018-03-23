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
    public class MetodoAnalisisLaboratorioDAO
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

        public static List<MetodoAnalisisLaboratorio> obtenerMetodosAnalisisLaboratorio()
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select id_metodo, nombre from MetodoAnalisisLaboratorio";

            List<MetodoAnalisisLaboratorio> metodos = new List<MetodoAnalisisLaboratorio>();
            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    metodos.Add(new MetodoAnalisisLaboratorio()
                    {
                        idMetodo = (int)dr["id_metodo"],
                        nombre = dr["nombre"].ToString()

                    });
                }

                cn.Close();
                return metodos;
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
        public static MetodoAnalisisLaboratorio obtenerMetodoAnalisisLaboratorio(int id)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select  id_metodo, nombre from MetodoAnalisisLaboratorio
                                where id_metodo=@id";

            MetodoAnalisisLaboratorio metodo = new MetodoAnalisisLaboratorio();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    metodo.idMetodo = (int)dr["id_metodo"];
                    metodo.nombre = dr["nombre"].ToString();
                }
  
                cn.Close();
                return metodo;
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
        public static void insertMetodosAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"insert into MetodoAnalisisLaboratorio(nombre) values (@nombre)";

            cmd.Parameters.AddWithValue("@nombre", metodo.nombre);

           
            try
            {
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
                throw new ApplicationException("Error:" + e.Message);
            }
        }
        public static void updateMetodosAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"update MetodoAnalisisLaboratorio 
                                set nombre=@nombre
                                where id_metodo=@idMetodo";

            cmd.Parameters.AddWithValue("@idMetodo", metodo.idMetodo);
            cmd.Parameters.AddWithValue("@nombre", metodo.nombre);
           
            try
            {
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
                throw new ApplicationException("Error:" + e.Message);
            }
        }
        public static void deleteMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            string consulta = @"delete from MetodoAnalisisLaboratorio
                                where id_metodo=@idMetodo";

            cmd.Parameters.AddWithValue("@idMetodo", metodo.idMetodo);
            try
            {
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
                throw new ApplicationException("Error al eliminar el método " + e.Message);
            }
        
        }
    }
}
