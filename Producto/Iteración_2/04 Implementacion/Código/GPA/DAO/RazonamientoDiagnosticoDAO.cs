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
    public class RazonamientoDiagnosticoDAO
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
        /*public static int registrarRazonamientoDiagnostico(RazonamientoDiagnostico razonamientoDiagnostico)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            string consulta = "insert into RazonamientoDiagnostico(conceptoInicial)values(@conceptoInicial)";

            try
            {

                cn.Open();
                tran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@conceptoInicial", razonamientoDiagnostico.conceptoInicial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity",cn,tran);

                razonamientoDiagnostico.id_razonamiento = Convert.ToInt32(cmd1.ExecuteScalar());

                if (razonamientoDiagnostico.hipotesis != null && razonamientoDiagnostico.hipotesis.Count > 0)
                {
                    foreach (HipotesisInicial hipotesis in razonamientoDiagnostico.hipotesis)
                    {
                        hipotesis.id_razonamientoDiagnostico = razonamientoDiagnostico.id_razonamiento;
                        HipotesisInicialDAO.registrarHipotesisInicial(hipotesis, tran, cn);
                    }
                }

                if (razonamientoDiagnostico.diagnosticos != null && razonamientoDiagnostico.diagnosticos.Count > 0)
                {
                    foreach (Diagnostico diagnostico in razonamientoDiagnostico.diagnosticos)
                    {
                        diagnostico.id_razonamientoDiagnostico = razonamientoDiagnostico.id_razonamiento;
                        DiagnosticoDAO.registrarDiagnostico(diagnostico, tran, cn);
                    }
                }

                if (razonamientoDiagnostico.estudios != null && razonamientoDiagnostico.estudios.Count > 0)
                {

                    foreach (EstudioDiagnosticoPorImagen estudio in razonamientoDiagnostico.estudios)
                    {
                        estudio.id_razonamientoDiagnostico = razonamientoDiagnostico.id_razonamiento;
                        EstudioDiagnosticoPorImagenDAO.registrarEstudioDiagnosticoPorImagen(estudio, tran, cn);

                    }
                }

                if (razonamientoDiagnostico.pruebas != null && razonamientoDiagnostico.pruebas.Count > 0)
                {
                    foreach (PruebasDeLaboratorio prueba in razonamientoDiagnostico.pruebas)
                    {
                        prueba.id_razonamientoDiagnostico = razonamientoDiagnostico.id_razonamiento;
                        PruebaDeLaboratorioDAO.registrarAnalisisLaboratorioARealizar(prueba, tran, cn);
                    }
                }

                tran.Commit();
                cn.Close();

 
            }
            catch(Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            return razonamientoDiagnostico.id_razonamiento;
        }*/
        public static void registrarRazonamientoDiagnostico(RazonamientoDiagnostico diagnostico,SqlTransaction tran,SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into RazonamientoDiagnostico(conceptoInicial,diagnostico,id_estadoDiagnostico_fk,motivoDescartado,fechaDescartado,id_examenGeneral_fk, motivoConfirmado,fechaConfirmado,motivoTentativo,fechaTentativo)
                                    values(@conceptoInicial,@diagnostico,@id_estadoDiagnostico_fk,@motivoDescartado,@fechaDescartado,@id_examenGeneral_fk,@motivoConfirmado,@fechaConfirmado,@motivoTentativo,@fechaTentativo)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@conceptoInicial", diagnostico.conceptoInicial);
                cmd.Parameters.AddWithValue("@diagnostico", diagnostico.diagnostico);
                cmd.Parameters.AddWithValue("@id_estadoDiagnostico_fk", diagnostico.estado.id_estado);
                
                if (!string.IsNullOrEmpty(diagnostico.motivoDescartado))
                {
                    cmd.Parameters.AddWithValue("@motivoDescartado", diagnostico.motivoDescartado);
                    cmd.Parameters.AddWithValue("@fechaDescartado", diagnostico.fechaDescartado);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoDescartado", DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaDescartado", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(diagnostico.motivoConfirmado))
                {
                    cmd.Parameters.AddWithValue("@motivoConfirmado", diagnostico.motivoConfirmado);
                    cmd.Parameters.AddWithValue("@fechaConfirmado", diagnostico.fechaConfirmado);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoConfirmado", DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaConfirmado", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(diagnostico.motivoTentativo))
                {
                    cmd.Parameters.AddWithValue("@motivoTentativo", diagnostico.motivoTentativo);
                    cmd.Parameters.AddWithValue("@fechaTentativo", diagnostico.fechaTentativo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoTentativo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaTentativo", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("id_examenGeneral_fk", diagnostico.id_examenGeneral);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('RazonamientoDiagnostico')", cn, tran);

                diagnostico.id_razonamiento = Convert.ToInt32(cmd1.ExecuteScalar());

                if (diagnostico.tratamientos != null && diagnostico.tratamientos.Count > 0)
                {
                    foreach (Tratamiento tratamiento in diagnostico.tratamientos)
                    {
                        tratamiento.id_razonamiento_fk = diagnostico.id_razonamiento;
                        TratamientoDAO.registrarTratamientos(tratamiento, cn, tran);
                    }
                }

                if (diagnostico.estudios != null && diagnostico.estudios.Count > 0)
                {
                    foreach (EstudioDiagnosticoPorImagen estudio in diagnostico.estudios)
                    {
                        estudio.id_razonamientoDiagnostico = diagnostico.id_razonamiento;
                        EstudioDiagnosticoPorImagenDAO.registrarEstudioDiagnosticoPorImagen(estudio, tran, cn);
                    }
                }

                if (diagnostico.analisis != null && diagnostico.analisis.Count > 0)
                {
                    foreach (Laboratorio laboratorio in diagnostico.analisis)
                    {
                        laboratorio.id_razonamientoDiagnostico = diagnostico.id_razonamiento;
                        PruebaDeLaboratorioDAO.registrarAnalisisLaboratorioARealizar(laboratorio, tran, cn);
                    }
                }
                if (diagnostico.practicas != null && diagnostico.practicas.Count > 0)
                {
                    foreach (PracticaComplementaria practica in diagnostico.practicas)
                    {
                        practica.id_razonamientoDiagnostico = diagnostico.id_razonamiento;
                        PracticaComplementariaDAO.registrarPracticaComplementariaARealizar(practica, tran, cn);
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
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    }
}
