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
    }
}
