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
    public class DiagnosticoDAO
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
        public static void registrarDiagnostico(Diagnostico diagnostico, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into DiagnosticoDefinitico(id_razonamientoDiagnostico_fk,descripcion)
                                  values(@id_razonamientoDiagnostico,@descripcion)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico", diagnostico.id_razonamientoDiagnostico);
                cmd.Parameters.AddWithValue("@descripcion", diagnostico.descripcion);
                
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
