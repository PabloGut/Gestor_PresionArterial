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
    public class AlergiaMedicamentoDAO
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
        * Método para registrar las alergias a los medicamento.
        * Recibe como parámetros una lista de objetos AlergiaMedicamento y el id de la historia clínica.
        * El valor de retorno es void.
        */
        public static void registrarAlergiaMedicamento(List<AlergiaMedicamento> alergiaMedicamento, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AlergiaMedicamento(fechaRegistro,efectos,id_medicamentoAlergia_fk,id_hc_fk)
                                  values(@fechaRegistro,@efectos,@idMedicamentoAlergia,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AlergiaMedicamento alergia in alergiaMedicamento)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    if (string.IsNullOrEmpty(alergia.efectos) == true)
                    {
                        cmd.Parameters.AddWithValue("@efectos",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@efectos", alergia.efectos);
                    }
                   
                    cmd.Parameters.AddWithValue("@idMedicamentoAlergia", alergia.id_MedicamentoAlergia);
                    cmd.Parameters.AddWithValue("@idHc", idHc);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    }
    
}
