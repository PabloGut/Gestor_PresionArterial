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
    public class DetalleMedicionPresionArterialDAO
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

        public static void registrarDetallesMedicionPresionArterial(int id_medicion, DetalleMedicionPresionArterial detalle, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"INSERT INTO DetalleMedicionPresionArterial(id_medicion_fk, hora, pulso, valorMaximo, valorMinimo)
                                    VALUES (@paramId_medicion_fk, @paramHora, @paramPulso, @paramValorMaximo, @paramValorMinimo)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@paramId_medicion_fk", id_medicion);
                cmd.Parameters.AddWithValue("@paramHora", detalle.hora.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramPulso", detalle.pulso);
                cmd.Parameters.AddWithValue("@paramValorMaximo", detalle.valorMaximo);
                cmd.Parameters.AddWithValue("@paramValorMinimo", detalle.valorMinimo);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new Exception("Error al insertar detalles de medición de presión arterial:" + e.Message);
            }

        }
    }
}
