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
    public class MedicionDePresionArterialDAO
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

        public static int registrarMedicionDePresionArterial(MedicionDePresionArterial medicion)
        {

            SqlTransaction tran = null;

            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,promedio,id_sitioMedicion_fk,horaInicio,id_ubicacionExtremidad_fk)
                                VALUES (@paramFecha,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramPromedio,@paramId_sitioMedicion_fk,@paramHoraInicio,@paramId_ubicacionExtremidad_fk)";

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@fecha", medicion.fecha.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@id_posicion_fk", medicion.posicion.id_posicion);
                if (medicion.clasificacion==null)
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", medicion.clasificacion.id_clasificacion);
                }
                cmd.Parameters.AddWithValue("@paramId_momentoDelDia_fk", medicion.momento.idMomentoDia);
                cmd.Parameters.AddWithValue("@paramPromedio", medicion.promedio);
                cmd.Parameters.AddWithValue("@paramId_sitioMedicion_fk", medicion.sitio.id_sitioMedicion);
                cmd.Parameters.AddWithValue("@paramHoraInicio", medicion.horaInicio.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_ubicacionExtremidad_fk", medicion.ubicacion.id_ubicacionExtremidad);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);
                medicion.id_medicion = (int)cmd1.ExecuteScalar();

                foreach (DetalleMedicionPresionArterial detalle in medicion.mediciones)
                {
                    DetalleMedicionPresionArterialDAO.registrarDetallesMedicionPresionArterial(medicion.id_medicion, detalle, tran, cn);
                }

                tran.Commit();
                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error al insertar medición de presión arterial: " + e.Message);
            }
            return medicion.id_medicion;

        }
    }
}
