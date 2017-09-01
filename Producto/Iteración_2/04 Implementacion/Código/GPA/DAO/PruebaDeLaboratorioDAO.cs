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
    public class PruebaDeLaboratorioDAO
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
        public static void registrarAnalisisLaboratorioD(Laboratorio prueba, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into PruebasDeLaboratorio(id_razonamientoDiagnostico_fk,id_analisis_fk, indicaciones)
                                  values(@id_razonamientoDiagnostico_fk,@id_analisis_fk,@indicaciones)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", prueba.id_razonamientoDiagnostico);
                cmd.Parameters.AddWithValue("@id_analisis_fk", prueba.id_analisis);
                cmd.Parameters.AddWithValue("@indicaciones", prueba.indicaciones);

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
