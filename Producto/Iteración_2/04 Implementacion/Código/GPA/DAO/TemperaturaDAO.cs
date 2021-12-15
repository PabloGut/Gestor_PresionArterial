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
    public class TemperaturaDAO
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
         * Obtiene la clasificación de temperatura corporal de acuerdo al valor de temperatura pasado como parámetro.
         * Recibe como parametro: float valorTemperatura.
         * Retorna un string correspondiente al nombre de la clasificación.
         */
        public static string mostrarClasificacionDeTemperatura(float valorTemperatura)
        {   
            setCadenaConexion();
            string nombre="";
            SqlConnection cn= new SqlConnection(getCadenaConexion());

            string consulta = @"select nombre, valorMaximo, valorMinimo
                              from ResultadoTemperatura
                              where @valorTemperatura BETWEEN valorMinimo and valorMaximo";
            try{
                cn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@valorTemperatura", valorTemperatura);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["nombre"]!=null)
                        nombre = dr["nombre"].ToString();
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
            return nombre;
        }
        public static void RegistrarTemperatura(Temperatura temperatura, SqlTransaction tran, SqlConnection cn)
        {
            try
            {

                string consulta = @"insert into Temperatura(id_sitioMedicio_fk, temperaturaGradosCentigrados, id_resultadoTemperatura_fk,id_examenGeneral_fk)
                                  values(@id_sitioMedicio_fk,@temperaturaGradosCentigrados,@id_resultadoTemperatura_fk,@id_examenGeneral_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;


                if (temperatura.sitioMedicion.id_sitioMedicion > 0)
                {
                    cmd.Parameters.AddWithValue("@id_sitioMedicio_fk", temperatura.sitioMedicion.id_sitioMedicion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_sitioMedicio_fk", DBNull.Value);
                }
                if (temperatura.valorTemperatura> 0)
                {
                    cmd.Parameters.AddWithValue("@temperaturaGradosCentigrados", temperatura.valorTemperatura);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@temperaturaGradosCentigrados", DBNull.Value);
                }
                if (temperatura.id_resultadoTemperatura > 0)
                {
                    cmd.Parameters.AddWithValue("@id_resultadoTemperatura_fk", temperatura.id_resultadoTemperatura);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_resultadoTemperatura_fk", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@id_examenGeneral_fk", temperatura.id_examenGeneral);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw e;
            }
        }
        public static int ObtenerIdResultadoTemperatura(String  resultado)
        {
            setCadenaConexion();
            int idResultado=0;
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"select id_resultadoTemperatura
                              from ResultadoTemperatura
                              where nombre like @resultado";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@resultado", resultado);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["id_resultadoTemperatura"] != null)
                        idResultado = (int)dr["id_resultadoTemperatura"];
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
            return idResultado;
        }
    }
}
