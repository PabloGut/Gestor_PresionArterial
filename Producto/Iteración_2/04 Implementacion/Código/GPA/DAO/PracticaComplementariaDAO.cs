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
    public class PracticaComplementariaDAO
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
        public static void registrarPracticaComplementariaARealizar(PracticaComplementaria practica, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into PracticaComplementaria(fechaSolicitud,indicaciones,id_tipoPractica_fk,id_razonamientoDiagnostico_fk)
                                  values(@fechaSolicitud,@indicaciones,@id_tipoPractica_fk,@id_razonamientoDiagnostico_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@fechaSolicitud", practica.fechaSolicitud);
                if (!string.IsNullOrEmpty(practica.indicaciones))
                {
                    cmd.Parameters.AddWithValue("@indicaciones", practica.indicaciones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@indicaciones",DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@id_tipoPractica_fk", practica.tipo.id_tipoPracticaComplementaria);
                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", practica.id_razonamientoDiagnostico);

                cmd.ExecuteNonQuery();
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
        public static List<PracticaComplementaria> obtenerPracticasComplementarias(int idRazonamiento)
        {
            setCadenaConexion();

            List<PracticaComplementaria> practicas = new List<PracticaComplementaria>();
            TipoPracticaComplementaria tipo = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select pc.fechaSolicitud,tp.nombre,pc.indicaciones,pc.id_practicaComplementaria
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, PracticaComplementaria pc, TipoPracticaComplementaria tp
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and pc.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and pc.id_tipoPractica_fk=tp.id_tipoPractica
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=@idRazonamiento
                                and pc.fechaRealizacion is null";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idRazonamiento", idRazonamiento);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tipo = new TipoPracticaComplementaria();
                    tipo.nombre = dr["nombre"].ToString();

                    PracticaComplementaria practica = new PracticaComplementaria();
                    practica.fechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]);
                    practica.tipo = tipo;
                    practica.indicaciones = dr["indicaciones"].ToString();
                    practica.id_PracticaComplementaria = (int)dr["id_practicaComplementaria"];
                    practicas.Add(practica);
                }

                return practicas;
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
        public static DataTable MostrarEstudiosPracticasComplementarias(int id_hc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select tpc.nombre as 'Estudio',  pc.fechaSolicitud as 'Fecha de solicitud', pc.indicaciones, pc.informe as 'Informe', pc.fechaRealizacion as 'Fecha Realización'
                                from Consulta c, ExamenGeneral ex, RazonamientoDiagnostico rd, EstadoDiagnostico ed, PracticaComplementaria pc,TipoPracticaComplementaria tpc
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=rd.id_examenGeneral_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and ed.nombre not like 'Descartado'
                                and pc.id_razonamientoDiagnostico_fk=rd.id_razonamiento
                                and pc.id_tipoPractica_fk=tpc.id_tipoPractica
								and c.id_hc_fk=@id_hc";
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
                throw e;
            }
            return dt;
        }
        public static void updatePracticaComplementaria(PracticaComplementaria practica, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            string consulta = @"update PracticaComplementaria
                              set fechaRealizacion=@fechaRealizacion, doctorACargo=@doctor, id_institucion_fk=@institucion,
                              observacionDeLosResultados=@observaciones,
                              informe=@informe,
                              id_tipoPractica_fk=@idTipoPractica
                              where id_practicaComplementaria=@idPractica";
            try
            {
                cmd.Parameters.AddWithValue("@fechaRealizacion", practica.fechaRealizacion);
                cmd.Parameters.AddWithValue("@doctor", practica.DoctorACargo);
                cmd.Parameters.AddWithValue("@institucion", practica.idInstitucion);
                cmd.Parameters.AddWithValue("@observaciones", practica.observaciones);
                cmd.Parameters.AddWithValue("@informe", practica.informeEstudio);
                cmd.Parameters.AddWithValue("@idTipoPractica", practica.id_tipoPractica);
                cmd.Parameters.AddWithValue("@idPractica", practica.id_PracticaComplementaria);

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

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
        public static List<PracticaComplementaria> obtenerEstudioPracticaComplementariaIdConsulta(int idConsulta)
        {
            setCadenaConexion();

            List<PracticaComplementaria> practicas = new List<PracticaComplementaria>();
            TipoPracticaComplementaria  tipoPractica = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select tpc.nombre as 'Estudio',  pc.fechaSolicitud as 'Fecha de solicitud', pc.indicaciones
                                from Consulta c, ExamenGeneral ex, RazonamientoDiagnostico rd, EstadoDiagnostico ed, PracticaComplementaria pc,TipoPracticaComplementaria tpc
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=rd.id_examenGeneral_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and ed.nombre not like 'Descartado'
                                and pc.id_razonamientoDiagnostico_fk=rd.id_razonamiento
                                and pc.id_tipoPractica_fk=tpc.id_tipoPractica
                                and c.id_consulta=@idConsulta";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idConsulta", idConsulta);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tipoPractica = new TipoPracticaComplementaria();
                    tipoPractica.nombre = dr["Estudio"].ToString();

                    PracticaComplementaria practica = new PracticaComplementaria();
                    practica.fechaSolicitud = Convert.ToDateTime(dr["Fecha de solicitud"]);
                    practica.tipo = tipoPractica;
                    practica.indicaciones = dr["indicaciones"].ToString();

                    practicas.Add(practica);
                }

                return practicas;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
    }
}
