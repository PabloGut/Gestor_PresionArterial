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
            SqlConnection cn = new SqlConnection(getCadenaConexion());
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
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idAlimento", alergia.id_alimento);

                    if (string.IsNullOrEmpty(alergia.efectos) == true)
                    {
                        cmd.Parameters.AddWithValue("@efectos", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@efectos", alergia.efectos);
                    }
                    
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
        public static DataTable mostrarAlegiasAlimentos(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @"select aa.fechaRegistro as 'Fecha de registro', a.nombre as 'Nombre del alérgeno', aa.efectos as 'Efectos de la alergia'
                                  from AlergiaAlimento aa,Alimento a
                                  where id_hc_fk=@idHc
                                  and aa.id_alimento_fk=a.id_alimento";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();

                da.Fill(dt);
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
            return dt;
        }
    }
}
