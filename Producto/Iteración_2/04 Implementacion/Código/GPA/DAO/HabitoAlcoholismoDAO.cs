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
        public static DataTable MostrarHabitosAlcoholismo(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select ha.fechaRegistro as 'Fecha de registro',tb.nombre as 'Nombre Bebida',m.nombre as 'Medida',m.descripcion as 'Descripcion', ct.nombre as 'Componente del tiempo', ha.cantidad
                                    from HabitosAlcoholismo ha, TipoBebida tb, Medida m, ComponenteDelTiempo ct
                                    where ha.id_tipoBebida_fk=tb.id_tipoBebida
                                    and m.id_medida=ha.id_medida_fk
                                    and ha.id_componenteTiempo_fk=ct.id_componenteTiempo
                                    and ha.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HabitosAlcoholismo");
                da.Fill(dt);
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dt;
        }
    }
}
