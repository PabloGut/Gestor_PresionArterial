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
        public static int registrarRazonamientoDiagnostico(RazonamientoDiagnostico razonamientoDiagnostico)
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
                        PruebaDeLaboratorioDAO.registrarAnalisisLaboratorioD(prueba, tran, cn);
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
        }
        public static int registrarRazonamientoDiagnostico(RazonamientoDiagnostico razonamientoDiagnostico,SqlTransaction tran,SqlConnection cn)
        {
            try
            {
                string consulta = "insert into RazonamientoDiagnostico(conceptoInicial)values(@conceptoInicial)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@conceptoInicial", razonamientoDiagnostico.conceptoInicial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('RazonamientoDiagnostico')", cn, tran);

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
                        PruebaDeLaboratorioDAO.registrarAnalisisLaboratorioD(prueba, tran, cn);
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
            return razonamientoDiagnostico.id_razonamiento;
        }
    }
}
