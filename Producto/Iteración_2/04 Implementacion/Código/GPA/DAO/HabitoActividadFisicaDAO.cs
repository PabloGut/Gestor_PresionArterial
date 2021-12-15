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
    public class HabitoActividadFisicaDAO
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
        public static void registrarHabitosActividadFisica(List<HabitoActividadFisica> habitosActividadFisica, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();



                string consulta = @"insert into HabitosActividadFisica(id_actividadFisica_fk,id_gradoActividadFisica_fk,id_intensidad_fk,fechaRegistro,id_hc_fk)
                                  values(@idActividadFisica,@idGradoActividad,@idIntensidad,@fechaRegistro,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoActividadFisica habito in habitosActividadFisica)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@idActividadFisica", habito.id_actividadFisica);
                    cmd.Parameters.AddWithValue("@idGradoActividad", habito.id_gradoActividadFisica);
                    cmd.Parameters.AddWithValue("@idIntensidad", habito.id_intensidad);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);
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
        public static DataTable MostrarHabitosActividadFisica(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select haf.fechaRegistro as 'Fecha registro',af.nombre 'Deporte/Actividad',af.descripcion as 'Descripción deporte o actividad',ga.nombre as 'Grado actividad',ga.descripcion as 'Descripcion grado actividad',iaf.nombre as 'Intensidad Actividad Física'
                                    from HabitosActividadFisica haf, ActividadFisica af, GradoActividad ga, IntensidadActividadFisica iaf
                                    where haf.id_actividadFisica_fk=af.id_actividadFisica
                                    and haf.id_gradoActividadFisica_fk=ga.id_gradoActividad
                                    and haf.id_intensidad_fk=iaf.id_intensidad
                                    and haf.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HabitosActividadFisica");
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
