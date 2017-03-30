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
    public class HabitoAlcoholismoDAO
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
        public static void registrarHabitosAlcoholismo(List<HabitoAlcoholismo> habitosAlcoholismo, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into HabitosAlcoholismo(id_tipoBebida_fk,fechaRegistro,cantidad,id_medida_fk,id_componenteTiempo_fk,id_hc_fk)
                                  values(@idTipoBebido,@fechaRegistro,@cantidad,@idMedida,@idComponenteTiempo,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoAlcoholismo habito in habitosAlcoholismo)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@idTipoBebido", habito.id_tipoBebida);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);
                    cmd.Parameters.AddWithValue("@cantidad", habito.cantidad);
                    cmd.Parameters.AddWithValue("@idMedida", habito.id_medida);
                    cmd.Parameters.AddWithValue("@idComponenteTiempo", habito.id_componenteTiempo);
                    cmd.Parameters.AddWithValue("@idHc", idHc);

                    cmd.ExecuteNonQuery();
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
