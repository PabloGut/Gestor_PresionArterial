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
    public class HabitoDrogasIlicitasDAO
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
        public static void registrarHabitosDrogasIlicitas(List<HabitoDrogasIlicitas> habitosDrogasIlicitas, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into HabitosDrogasIlicitas(id_sustancia_fk,fechaRegistro,tiempoConsumiendo,id_ElementoDelTiempo_fk,id_hc_fk)
                                  values(@idSustancia,@fechaRegistro,@tiempoConsumiendo,@idElementoTiempo,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoDrogasIlicitas habito in habitosDrogasIlicitas)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@idSustancia", habito.id_sustancia);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);
                    cmd.Parameters.AddWithValue("@tiempoConsumiendo", habito.tiempoConsumiendo);
                    cmd.Parameters.AddWithValue("@idElementoTiempo", habito.id_elementoTiempo);
                    cmd.Parameters.AddWithValue("@idHc",idHc);
                    

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
        public static DataTable MostrarHabitosDrogasIlicitas(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select hd.fechaRegistro as 'Fecha de registro',s.nombre as 'Sustancia',hd.tiempoConsumiendo as 'Tiempo Consumiendo',et.nombre as 'Unidad de tiempo'
                                    from HabitosDrogasIlicitas hd, Sustancia s, ElementoDelTiempo et
                                    where hd.id_sustancia_fk=s.id_sustancia
                                    and hd.id_ElementoDelTiempo_fk=et.id_elementoDelTiempo
                                    and hd.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HabitosDrogasIlicitas");
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
