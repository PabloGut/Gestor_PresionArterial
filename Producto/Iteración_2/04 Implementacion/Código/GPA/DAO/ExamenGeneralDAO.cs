using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ExamenGeneralDAO
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
        /*public static int registrarExamenGeneral(ExamenGeneral examen)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            int idExamen;
            try
            {
                cn.Open();

                string consulta = @"insert into ExamaneGeneral(posicionYdecubito,marchaYDeambulacion,facieExpresionFisonomia, concienciaEstadoPsiquico, constitucionEstadoNutritivo, peso,talla,id_razonamiento_fk)
                                  values(@posicionYdecubito,@marchaYDeambulacion,@facieExpresionFisonomia,@concienciaEstadoPsiquico,@constitucionEstadoNutritivo,@peso,@talla,@id_razonamiento_fk)";

                
                SqlCommand cmd = new SqlCommand();

                if (examen.posicionYDecubito.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@posicionYdecubito", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@posicionYdecubito", examen.posicionYDecubito);
                }

                if (examen.marchaYDeambulacion.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@marchaYDeambulacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@marchaYDeambulacion", examen.marchaYDeambulacion);
                }

                if (examen.facieExpresionFisonomia.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@facieExpresionFisonomia", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@facieExpresionFisonomia", examen.facieExpresionFisonomia);
                }

                if (examen.concienciaEstadoPsiquico.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@concienciaEstadoPsiquico", examen.concienciaEstadoPsiquico);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@concienciaEstadoPsiquico", DBNull.Value);
                }

                if (examen.constitucionEstadoNutritivo.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@constitucionEstadoNutritivo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@constitucionEstadoNutritivo", examen.constitucionEstadoNutritivo);
                }
                
                cmd.Parameters.AddWithValue("@peso", examen.peso);
                cmd.Parameters.AddWithValue("@talla", examen.talla);

                if (examen.id_razonamiento == 0)
                {
                    cmd.Parameters.AddWithValue("@id_razonamiento_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_razonamiento_fk", examen.id_razonamiento);
                }

               

                cmd.Connection = cn;
                
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);

                idExamen = Convert.ToInt32(cmd1.ExecuteScalar());

                cn.Close();

            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                   
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return idExamen;
        }*/
        public static int registrarExamenGeneral(ExamenGeneral examen,SqlTransaction tran, SqlConnection cn, int id_hc)
        {
            try
            {
                if (examen.pulso != null)
                {
                    examen.id_pulso = PulsoArterialDAO.registrarPulsoArterial(examen.pulso, tran, cn);
                }

                int id_medicion_fk=0;
                if (examen.medicion != null)
                {
                    id_medicion_fk = MedicionDePresionArterialDAO.RegistrarMedicionDePresionArterial(examen.medicion, tran, cn, id_hc);
                }
                int id_piel_fk = 0;
                if (examen.examenPiel != null)
                {
                    id_piel_fk = PielDAO.registrarExamenPiel(examen.examenPiel, cn, tran);
                }

                string consulta = @"insert into ExamenGeneral(posicionYdecubito,marchaYDeambulacion,facieExpresionFisonomia, concienciaEstadoPsiquico, constitucionEstadoNutritivo, peso,talla,id_piel_fk,descripcionComoRespira,observacionesRespiracion,id_pulsoArterial_fk,id_medicion_fk)
                                  values(@posicionYdecubito,@marchaYDeambulacion,@facieExpresionFisonomia,@concienciaEstadoPsiquico,@constitucionEstadoNutritivo,@peso,@talla,@id_piel_fk,@descComoRespira,@obsRespiracion,@id_pulsoArterial_fk,@id_medicion_fk)";

                SqlCommand cmd = new SqlCommand();

                if (examen.posicionYDecubito.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@posicionYdecubito", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@posicionYdecubito", examen.posicionYDecubito);
                }

                if (examen.marchaYDeambulacion.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@marchaYDeambulacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@marchaYDeambulacion", examen.marchaYDeambulacion);
                }

                if (examen.facieExpresionFisonomia.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@facieExpresionFisonomia", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@facieExpresionFisonomia", examen.facieExpresionFisonomia);
                }

                if (examen.concienciaEstadoPsiquico.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@concienciaEstadoPsiquico", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@concienciaEstadoPsiquico", examen.concienciaEstadoPsiquico);
                }

                if (examen.constitucionEstadoNutritivo.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@constitucionEstadoNutritivo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@constitucionEstadoNutritivo", examen.constitucionEstadoNutritivo);
                }

                cmd.Parameters.AddWithValue("@peso", examen.peso);
                cmd.Parameters.AddWithValue("@talla", examen.talla);

                if (examen.descripcionComoRespira.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@descComoRespira", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@descComoRespira", examen.descripcionComoRespira);
                }

                if (examen.observacionesRespiracion.Equals("No precisa") == true)
                {
                    cmd.Parameters.AddWithValue("@obsRespiracion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@obsRespiracion", examen.observacionesRespiracion);
                }

                if (examen.id_pulso == 0)
                {
                    cmd.Parameters.AddWithValue("@id_pulsoArterial_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_pulsoArterial_fk", examen.id_pulso);
                }

                if (id_medicion_fk == 0)
                {
                    cmd.Parameters.AddWithValue("@id_medicion_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_medicion_fk", id_medicion_fk);
                }

                if (id_piel_fk == 0)
                {
                    cmd.Parameters.AddWithValue("@id_piel_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_piel_fk", id_piel_fk);
                }

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('ExamenGeneral')", cn, tran);

                examen.id_examenGeneral = Convert.ToInt32(cmd1.ExecuteScalar());

                if (examen.territoriosExaminados != null)
                {
                    foreach (SistemaLinfatico territorio in examen.territoriosExaminados)
                    {
                        territorio.id_examenGeneral = examen.id_examenGeneral;
                        SistemaLinfaticoDAO.registrarSistemaLinfatico(territorio, tran, cn);
                    }
                }
                if (examen.listaDiagnosticos != null)
                {
                    foreach (RazonamientoDiagnostico diagnostico in examen.listaDiagnosticos)
                    {
                        diagnostico.id_examenGeneral = examen.id_examenGeneral;
                        RazonamientoDiagnosticoDAO.registrarRazonamientoDiagnostico(diagnostico, tran, cn);
                    }
                }

                if(examen.listaTemperaturas !=null)
                {
                    foreach (Temperatura temp in examen.listaTemperaturas)
                    {
                        temp.id_examenGeneral = examen.id_examenGeneral;
                        TemperaturaDAO.RegistrarTemperatura(temp, tran, cn);

                    }
                }

            }
            catch (Exception e)
            {

                //if (cn.State == ConnectionState.Open)
                //{
                //    cn.Close();
                //    tran.Rollback();
                //}
                throw e;
            }
            return examen.id_examenGeneral;
        }
        public static DataTable MostrarResumenExamenGeneral(int id_hc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select c.nroConsulta,c.fechaConsulta,c.HoraConsulta,c.motivoConsulta,rd.conceptoInicial,rd.diagnostico,ed.nombre as 'Estado Diagnóstico', 
                                CASE ed.nombre WHEN 'Tentativo' THEN rd.motivoTentativo
                                WHEN 'Definitivo' THEN rd.motivoConfirmado
                                WHEN 'Descartado' THEN rd.motivoDescartado
                                END as 'Motivo Cambio Estado',
                                CASE ed.nombre WHEN 'Tentativo' THEN rd.fechaTentativo
                                WHEN 'Definitivo' THEN rd.fechaConfirmado
                                WHEN 'Descartado' THEN rd.fechaDescartado
                                END as 'Fecha cambio estado'
                                from Consulta c, ExamenGeneral ex, Historia_Clinica hc, RazonamientoDiagnostico rd, EstadoDiagnostico ed
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and hc.id_hc=c.id_hc_fk 
                                and ex.id_examenGeneral=rd.id_examenGeneral_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and hc.id_hc=@id_hc";
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
