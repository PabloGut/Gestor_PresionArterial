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
    public class HipotesisInicialDAO
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
        public static void registrarHipotesisInicial(HipotesisInicial hipotesis, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into HipotesisInicial(id_razonamientoDiagnostico_fk,descripcion, id_estadoHipotesis_fk)
                                  values(@id_razonamientoDiagnostico,@descripcion,@id_estadoHipotesis_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico", hipotesis.id_razonamientoDiagnostico);
                cmd.Parameters.AddWithValue("@descripcion", hipotesis.descripcion);
                cmd.Parameters.AddWithValue("@id_estadoHipotesis_fk",hipotesis.id_estadoH);

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
