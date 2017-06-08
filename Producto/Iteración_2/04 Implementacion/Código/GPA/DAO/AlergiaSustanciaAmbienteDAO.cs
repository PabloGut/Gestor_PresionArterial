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
    public class AlergiaSustanciaAmbienteDAO
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
         * Método para registrar las alergias a sustancias del ambiente.
         * Recibe como parámetros una lista de objetos AlergiaSustanciaAmbiente y el id de la historia clínica.
         * El valor de retorno es void.
         */
        public static void registrarAlergiaSustanciasDelAmbiente(List<AlergiaSustanciaAmbiente> alergiaSustanciaAmbiente, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AlergiaSustanciaAmbiente(fechaRegistro,id_sustanciaAmbiente_fk, efectos, id_hc_fk)
                                  values(@fechaRegistro,@idSustanciaAmbiente,@efectos,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AlergiaSustanciaAmbiente alergia in alergiaSustanciaAmbiente)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idSustanciaAmbiente", alergia.id_sustanciaAmbiente);

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
        public static DataTable mostrarAlegiasSustanciasDelAmbiente(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @"select asa.fechaRegistro as 'Fecha de registro', sa.nombre as 'Nombre del alérgeno', asa.efectos as 'Efectos de la alergia'
                                    from AlergiaSustanciaAmbiente asa, SustanciaAmbiente sa
                                    where asa.id_hc_fk=@idHc
                                    and asa.id_sustanciaAmbiente_fk=sa.id_sustanciaAmbiente";

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
