using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class TratamientoDAO
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
        public static void registrarTratamientos(Tratamiento tratamiento, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into Tratamiento(indicaciones,fechaInicio,motivoInicioTratamiento,id_terapia_fk, id_razonamientoDiagnostico_fk)
                                values(@indicaciones,@fechaInicio,@motivoInicio,@id_terapia_fk,@id_razonamientoDiagnostico_fk)";

            try
            {
                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrEmpty(tratamiento.indicaciones))
                {
                    cmd.Parameters.AddWithValue("@indicaciones", tratamiento.indicaciones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@indicaciones", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@fechaInicio", tratamiento.fechaInicio);

                if (!string.IsNullOrEmpty(tratamiento.motivoInicio))
                {
                    cmd.Parameters.AddWithValue("@motivoInicio", tratamiento.motivoInicio);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoInicio", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@id_terapia_fk", tratamiento.terapia.id_terapia);
                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", tratamiento.id_razonamiento_fk);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                if (tratamiento.medicamentos != null && tratamiento.medicamentos.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('Tratamiento')", cn, tran);
                    tratamiento.id_tratamiento = Convert.ToInt32(cmd1.ExecuteScalar());

                    foreach (ProgramacionMedicamento pro in tratamiento.medicamentos)
                    {
                        pro.id_tratamiento = tratamiento.id_tratamiento;
                        ProgramacionMedicamentoDAO.registrarTratamientoProgramacionMedicamento(pro, tran, cn);
                    }
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                //throw new ApplicationException("Error:" + e.Message);
                throw e;
            }

        }
        public static List<Tratamiento> mostrarTratamientos(int idRazonamientoDiagnostico)
        {
            setCadenaConexion();
            List<Tratamiento> tratamientos = new List<Tratamiento>();
            Terapia terapia = null;
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"select  t.id_tratamiento,t.indicaciones,t.fechaInicio,t.motivoInicioTratamiento, te.id_terapia, te.nombre
                                    from Tratamiento t , Terapia te
                                    where t.id_terapia_fk=te.id_terapia
                                    and t.id_razonamientoDiagnostico_fk=@idRazonamientoDiagnostico
                                    and t.fechaFin is null";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idRazonamientoDiagnostico", idRazonamientoDiagnostico);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tratamientos.Add(new Tratamiento()
                    {
                        id_tratamiento = (int)dr["id_tratamiento"],
                        indicaciones = dr["indicaciones"].ToString(),
                        fechaInicio = Convert.ToDateTime(dr["fechaInicio"].ToString()),
                        motivoInicio= dr["motivoInicioTratamiento"].ToString(),
                        terapia= new Terapia()
                        {
                            id_terapia= (int)dr["id_terapia"],
                            nombre = dr["nombre"].ToString()
                        }

                    });;
                }

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

            return tratamientos;

        }
        public static void cancelarTratamiento(Tratamiento tratamiento, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            string consulta = @"update Tratamiento
                                set fechaFin=@fechaFin, motivoFinTratamiento=@motivoFin
                                where id_tratamiento=@idTratamiento
                                and id_razonamientoDiagnostico_fk=@idRazonamientoDiagnostico";
            try
            {
                cmd.Parameters.AddWithValue("@fechaFin", tratamiento.fechaFin);
                cmd.Parameters.AddWithValue("@motivoFin", tratamiento.motivoFin);
                cmd.Parameters.AddWithValue("@idTratamiento", tratamiento.id_tratamiento);
                cmd.Parameters.AddWithValue("@idRazonamientoDiagnostico", tratamiento.id_razonamiento_fk);

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataTable MostrarTratamientos(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select  t.id_tratamiento,t.indicaciones,t.fechaInicio,t.motivoInicioTratamiento, te.id_terapia, te.nombre, t.fechaFin,t.motivoFinTratamiento,rd.diagnostico
                                from Tratamiento t , Terapia te, RazonamientoDiagnostico rd, ExamenGeneral eg, Consulta c
                                where c.id_examenGeneral_fk=eg.id_examenGeneral
								and t.id_terapia_fk=te.id_terapia
								and rd.id_examenGeneral_fk=eg.id_examenGeneral
                                and t.id_razonamientoDiagnostico_fk=rd.id_razonamiento
								and c.id_hc_fk=@id_hc
								and te.nombre not like 'Medicamentos'";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", idHc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

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
                throw e;
            }
            return dt;
        }
    }
}
