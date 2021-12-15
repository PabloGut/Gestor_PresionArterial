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
    public class SustanciaAmbienteDAO
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
        * Método para obtener todas las columnas de la tabla SustanciaAmbiente.
        * No recibe datos como parámetro.
        * Retorna una lista de objetos SustanciaAmbiente.
        */
        public static List<SustaciaAmbiente> mostrarSustanciasDelAmbiente()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<SustaciaAmbiente> sustanciasDelAmbiente = new List<SustaciaAmbiente>();
            try
            {
                cn.Open();

                string consulta = "select * from SustanciaAmbiente";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sustanciasDelAmbiente.Add(new SustaciaAmbiente()
                    {
                        id_sustanciaAmbiente = (int)dr["id_sustanciaAmbiente"],
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
            return sustanciasDelAmbiente;
        }
        public static void RegistrarSustanciaAmbienteAlergia(SustaciaAmbiente sustanciaAmbiente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"insert into SustanciaAmbiente(nombre)
                                  values(@nombre)";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", sustanciaAmbiente.nombre);

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static void ActualizarSustanciaAmbienteAlergia(SustaciaAmbiente sustaciaAmbiente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"update SustanciaAmbiente
                                    set nombre=@nombre
                                    where id_sustanciaAmbiente=@idSustanciaAmbiente";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", sustaciaAmbiente.nombre);
                cmd.Parameters.AddWithValue("@idSustanciaAmbiente", sustaciaAmbiente.id_sustanciaAmbiente);

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
    }
}
