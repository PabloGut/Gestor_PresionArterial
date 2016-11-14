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
    public class ConsultaDAO
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
        public static void registrarConsulta(Consulta consultaPaciente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into Consulta(nroConsulta,fechaConsulta,horaConsulta,motivoConsulta,id_examenGeneral_fk,id_hc_fk)
                                    values(@nroConsulta,@fechaConsulta,@horaConsulta,@motivoConsulta,@id_examenGeneral_fk,@id_hc_fk)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nroConsulta", consultaPaciente.nroConsulta);
                cmd.Parameters.AddWithValue("@fechaConsulta", consultaPaciente.fecha);
                cmd.Parameters.AddWithValue("@horaConsulta", consultaPaciente.hora);
                cmd.Parameters.AddWithValue("@motivoConsulta", consultaPaciente.motivoConsulta);

                if (consultaPaciente.id_examenGeneral == 0)
                {
                    cmd.Parameters.AddWithValue("@id_examenGeneral_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_examenGeneral_fk", consultaPaciente.id_examenGeneral);
                }
                
                cmd.Parameters.AddWithValue("@id_hc_fk", consultaPaciente.id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

               

                if (consultaPaciente.sintoma != null && consultaPaciente.sintoma.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);
                    consultaPaciente.id_consulta = Convert.ToInt32(cmd1.ExecuteScalar());

                    foreach (Sintoma sintoma in consultaPaciente.sintoma)
                    {
                        sintoma.id_consulta = consultaPaciente.id_consulta;
                        SintomaDAO.registrarSintomasDeConsulta(sintoma, cn, tran);
                    }
                }

                tran.Commit();
                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
        public static int buscarNroConsulta(int idHc)
        {
            setCadenaConexion();
            int nro = 0;
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                String consulta = "SELECT TOP 1 nroConsulta FROM Consulta where id_hc_fk=@idHc ORDER BY nroConsulta DESC";

                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nro = (int)dr["nroConsulta"];

                    }
                    cn.Close();
                    return nro;
                }
                else
                {
                    return nro;
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
        }
        /*
         * Método para registrar la atención médica en el consultorio.
         * Recibe como parámetro un objeto consulta.
         * Registra en base de datos los datos de la consulta, sintomas y examen general.
         * Valor de retorno void.
         */
        public static void registrarConsultaYExameGeneral(Consulta consultaPaciente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                if (consultaPaciente.examen != null)
                {
                    consultaPaciente.id_examenGeneral = ExamenGeneralDAO.registrarExamenGeneral(consultaPaciente.examen, tran, cn);
                }

                string consulta = @"insert into Consulta(nroConsulta,fechaConsulta,horaConsulta,motivoConsulta,id_examenGeneral_fk,id_hc_fk)
                                    values(@nroConsulta,@fechaConsulta,@horaConsulta,@motivoConsulta,@id_examenGeneral_fk,@id_hc_fk)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nroConsulta", consultaPaciente.nroConsulta);
                cmd.Parameters.AddWithValue("@fechaConsulta", consultaPaciente.fecha);
                cmd.Parameters.AddWithValue("@horaConsulta", consultaPaciente.hora);
                cmd.Parameters.AddWithValue("@motivoConsulta", consultaPaciente.motivoConsulta);

                if (consultaPaciente.id_examenGeneral == 0)
                {
                    cmd.Parameters.AddWithValue("@id_examenGeneral_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_examenGeneral_fk", consultaPaciente.id_examenGeneral);
                }

                cmd.Parameters.AddWithValue("@id_hc_fk", consultaPaciente.id_hc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                if (consultaPaciente.sintoma != null && consultaPaciente.sintoma.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('Consulta')", cn, tran);
                    consultaPaciente.id_consulta = Convert.ToInt32(cmd1.ExecuteScalar());

                    foreach (Sintoma sintoma in consultaPaciente.sintoma)
                    {
                        sintoma.id_consulta = consultaPaciente.id_consulta;
                        SintomaDAO.registrarSintomasDeConsulta(sintoma, cn, tran);
                    }
                }

                tran.Commit();
                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
        public static DataTable mostrarConsultasAnteriores(int id_hc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select c.nroConsulta, c.fechaConsulta,c.horaConsulta,c.motivoConsulta, ex.posicionYDecubito,ex.marchaYDeambulacion,ex.facieExpresionFisonomia,ex.concienciaEstadoPsiquico,ex.constitucionEstadoNutritivo,ex.peso,ex.talla
                                from Consulta c, ExamenGeneral ex, Historia_Clinica hc
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and hc.id_hc=c.id_hc_fk and hc.id_hc=@id_hc";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", id_hc);

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
                throw new ApplicationException("Error:" + e.Message);
            }
            return dt;
        }
    }
}
