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
    public class PracticaComplementariaDAO
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
        public static void registrarPracticaComplementariaARealizar(PracticaComplementaria practica, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into Laboratorio(fechaSolicitud,indicaciones,id_analisisLaboratorio_fk, id_razonamientoDiagnostico_fk)
                                  values(@fechaSolicitud,@indicaciones,@id_analisisLaboratorio_fk,@id_razonamientoDiagnostico_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@fechaSolicitud", practica.fechaSolicitud);
                if (!string.IsNullOrEmpty(practica.indicaciones))
                {
                    cmd.Parameters.AddWithValue("@indicaciones", practica.indicaciones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@indicaciones",DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@id_analisisLaboratorio_fk", practica.id_tipoPractica);
                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", practica.id_razonamientoDiagnostico);

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
