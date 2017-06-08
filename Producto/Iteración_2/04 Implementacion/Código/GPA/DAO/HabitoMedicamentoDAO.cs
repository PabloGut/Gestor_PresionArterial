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
    public class HabitoMedicamentoDAO
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
        public static void registrarHabitosMedicamento(List<HabitoMedicamento> habitosMedicamento, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into HabitosMedicamento(id_hc_fk,id_programacionMedicamento_fk,fechaRegistro)
                                  values(@idHc,@idProgramacionMedicamento,@fechaRegistro)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoMedicamento habito in habitosMedicamento)
                {
                    
                    ProgramacionMedicamentoDAO.registrarProgramacionMedicamento(habito.programacion, tran, cn);

                    cmd.Parameters.AddWithValue("@idHc", idHc);
                    cmd.Parameters.AddWithValue("@idProgramacionMedicamento", habito.programacion.id_programacionMedicamento);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }
                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    
    }
}
