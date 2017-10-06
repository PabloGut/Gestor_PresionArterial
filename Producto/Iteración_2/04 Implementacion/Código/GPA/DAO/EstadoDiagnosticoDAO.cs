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
    public class EstadoDiagnosticoDAO
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
        public static int mostrarIdEstadoDiagnostico(string estado)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            int idEstado = 0;
            try
            {
                cn.Open();

                string consulta = "select id_estadoDiagnostico from EstadoDiagnostico where nombre like @nombreEstado";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreEstado", estado);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idEstado = (int)dr["id_estadoDiagnostico"];
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
            return idEstado;
        }
        public static List<EstadoDiagnostico> obtenerEstadosDiagnosticos()
        {
            string consulta = @"select * from EstadoDiagnostico";

            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();
            List<EstadoDiagnostico> estados = new List<EstadoDiagnostico>();
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estados.Add(new EstadoDiagnostico()
                    {
                        id_estado=(int)dr["id_estadoDiagnostico"],
                        nombre=dr["nombre"].ToString(),
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
            return estados;
        }
    }
}
