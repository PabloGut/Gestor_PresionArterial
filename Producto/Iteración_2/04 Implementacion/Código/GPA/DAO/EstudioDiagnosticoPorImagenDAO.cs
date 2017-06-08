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
    public class EstudioDiagnosticoPorImagenDAO
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
        public static void registrarEstudioDiagnosticoPorImagen(EstudioDiagnosticoPorImagen estudio, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into EstudiosDiagnosticoPorImagen(id_razonamientoDiagnostico_fk,id_nombreEstudio_fk, indicaciones)
                                  values(@id_razonamientoDiagnostico_fk,@id_nombreEstudio_fk,@indicaciones)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", estudio.id_razonamientoDiagnostico);
                cmd.Parameters.AddWithValue("@id_nombreEstudio_fk", estudio.id_nombreEstudio);
                cmd.Parameters.AddWithValue("@indicaciones", estudio.indicaciones);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new ApplicationException("Error:" + e.Message);
            }

        }
    }
}
