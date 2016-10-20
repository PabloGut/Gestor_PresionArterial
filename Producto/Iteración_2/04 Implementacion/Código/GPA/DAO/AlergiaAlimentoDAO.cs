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
    public class AlergiaAlimentoDAO
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
         * Método para registrar las alergias a los alimentos.
         * Recibe como parámetros una lista de objetos AlergiaAlimento y el id de la historia clínica.
         * El valor de retorno es void.
         */
        public static void registrarAlergiaAlimentos(List<AlergiaAlimento> alergiaAlimentos, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.Open();

                string consulta = @"insert into AlergiaAlimento(fechaRegistro,id_alimento_fk, efectos, id_hc_fk)
                                  values(@fechaRegistro,@idAlimento,@efectos,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AlergiaAlimento alergia in alergiaAlimentos)
                {
                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idAlimento", alergia.id_alimento);
                    cmd.Parameters.AddWithValue("@efectos", alergia.efectos);
                    cmd.Parameters.AddWithValue("@idHc", alergia.id_hc);

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
