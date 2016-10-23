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
    public class HabitoTabaquismoDAO
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
        public static void registrarHabitosTabaquismo(List<HabitoTabaquismo> habitosTabaquismo, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into HabitosTabaquismo(cantidad,id_elementoQueFuma_fk, id_componenteDelTiempo_fk, añosFumando, fechaRegistro, id_hc_fk)
                                  values(@cantidad,@idElementoQueFuma,@idComponenteDelTiempo,@añosFumando,@fechaRegistro,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoTabaquismo habito in habitosTabaquismo)
                {
                    cmd.Parameters.AddWithValue("@cantidad", habito.cantidad);
                    cmd.Parameters.AddWithValue("@idElementoQueFuma", habito.id_elementoQueFuma);
                    cmd.Parameters.AddWithValue("@idComponenteDelTiempo", habito.id_componenteTiempo);
                    cmd.Parameters.AddWithValue("@añosFumando", habito.añosFumando);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idHc", habito.id_hc);

                    cmd.ExecuteNonQuery();

                    if (habito.dejoDeFumar != null)
                    {
                        SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);
                        habito.dejoDeFumar.id_habitoTabaquismo = Convert.ToInt32(cmd1.ExecuteScalar());

                        DejoDeFumarDAO.registrarDejoDeFumar(habito.dejoDeFumar,tran,cn);
                    }
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
