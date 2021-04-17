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
    public class EvolucionDiagnosticoDAO
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
        public static void registrarEvolucionDiagnostico(EvolucionDiagnostico evolucionDiagnostico)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.Open();

                string consulta = @"insert into EvolucionDiagnostico(id_hc, id_diagnostico, fecha,id_estadoDiagnostico)
                                  values(@idHc,@idDiagnostico,@fecha,@idEstadoDiagnostico)";

                tran = cn.BeginTransaction();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idHc", evolucionDiagnostico.idHc);
                cmd.Parameters.AddWithValue("@idDiagnostico", evolucionDiagnostico.diagnostico.id_razonamiento);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@idEstadoDiagnostico", evolucionDiagnostico.diagnostico.id_estadoDiagnostico);

                cmd.ExecuteNonQuery();

                RazonamientoDiagnosticoDAO.updateRazonamientoDiagnostico(evolucionDiagnostico.diagnostico, cn, tran);
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }

        }
        public static List<EvolucionDiagnostico> consultarRazonamientos()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<EvolucionDiagnostico> lista = new List<EvolucionDiagnostico>();
            try
            {
                cn.Open();

                string consulta = @"select c.id_consulta,r.id_razonamiento,c.fechaConsulta,e.id_examenGeneral
                                    from Consulta c,ExamenGeneral e, RazonamientoDiagnostico r
                                     where c.id_examenGeneral_fk = e.id_examenGeneral
                                    and e.id_examenGeneral = r.id_examenGeneral_fk
                                    and c.id_hc_fk = @idHc
                                    and c.id_consulta = idConsulta
                                    and e.id_examenGeneral = idExameGeneral";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new EvolucionDiagnostico()
                    {
                        //idConsulta = (int)dr["id_medida"],
                        idDiagnostico = (int)dr["id_razonamiento"],
                        fecha = Convert.ToDateTime(dr["fechaConsulta"].ToString()),
                        idExamenGeneral= (int)dr["id_examenGeneral"]
                    });
                }

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return lista;
        }
        public static void registrarEvolucionDiagnosticoConExamenGeneral(EvolucionDiagnostico evolucionDiagnostico, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {

                string consulta = @"insert into EvolucionDiagnostico(id_hc, id_diagnostico, fecha,id_examenGeneral,id_estadoDiagnostico)
                                  values(@idHc,@idDiagnostico,@fecha,@idExamenGeneral,@idEstadoDiagnostico)";

                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idHc", evolucionDiagnostico.idHc);
                cmd.Parameters.AddWithValue("@idDiagnostico", evolucionDiagnostico.diagnostico.id_razonamiento);
                cmd.Parameters.AddWithValue("@fecha", evolucionDiagnostico.fecha);

                if (evolucionDiagnostico.idExamenGeneral !=0)
                    cmd.Parameters.AddWithValue("@idExamenGeneral", evolucionDiagnostico.idExamenGeneral);
                else
                    cmd.Parameters.AddWithValue("@idExamenGeneral", DBNull.Value);

                cmd.Parameters.AddWithValue("@idEstadoDiagnostico", evolucionDiagnostico.idEstadoDiagnostico);

                cmd.ExecuteNonQuery();


                //Agregar los estudios
                if (evolucionDiagnostico.diagnostico.tratamientos != null && evolucionDiagnostico.diagnostico.tratamientos.Count > 0)
                {
                    foreach (Tratamiento tratamiento in evolucionDiagnostico.diagnostico.tratamientos)
                    {
                        tratamiento.id_razonamiento_fk = evolucionDiagnostico.diagnostico.id_razonamiento;
                        TratamientoDAO.registrarTratamientos(tratamiento, cn, tran);
                    }
                }

                if (evolucionDiagnostico.diagnostico.estudios != null && evolucionDiagnostico.diagnostico.estudios.Count > 0)
                {
                    foreach (EstudioDiagnosticoPorImagen estudio in evolucionDiagnostico.diagnostico.estudios)
                    {
                        estudio.id_razonamientoDiagnostico = evolucionDiagnostico.diagnostico.id_razonamiento;
                        EstudioDiagnosticoPorImagenDAO.registrarEstudioDiagnosticoPorImagen(estudio, tran, cn);
                    }
                }

                if (evolucionDiagnostico.diagnostico.analisis != null && evolucionDiagnostico.diagnostico.analisis.Count > 0)
                {
                    foreach (Laboratorio laboratorio in evolucionDiagnostico.diagnostico.analisis)
                    {
                        laboratorio.id_razonamientoDiagnostico = evolucionDiagnostico.diagnostico.id_razonamiento;
                        PruebaDeLaboratorioDAO.registrarAnalisisLaboratorioARealizar(laboratorio, tran, cn);
                    }
                }
                if (evolucionDiagnostico.diagnostico.practicas != null && evolucionDiagnostico.diagnostico.practicas.Count > 0)
                {
                    foreach (PracticaComplementaria practica in evolucionDiagnostico.diagnostico.practicas)
                    {
                        practica.id_razonamientoDiagnostico = evolucionDiagnostico.diagnostico.id_razonamiento;
                        PracticaComplementariaDAO.registrarPracticaComplementariaARealizar(practica, tran, cn);
                    }
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                //throw new ApplicationException(e.Message);
                throw e;
            }

        }


    }
}
