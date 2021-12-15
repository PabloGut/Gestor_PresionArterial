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
    public class LaboratorioDAO
    {
        private static string cadenaConexion;

        public static void SetCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string GetCadenaConexion()
        {
            return cadenaConexion;
        }
        public static List<Laboratorio> ObtenerAnalisisLaboratorio(int idRazonamiento)
        {
            SetCadenaConexion();

            List<Laboratorio> analisis = new List<Laboratorio>();
            AnalisisLaboratorio analisisLaboratorio = null;

            SqlConnection cn = new SqlConnection(GetCadenaConexion());



            string consulta = @"select l.id_laboratorio, l.fechaSolicitud,il.nombre,l.indicaciones
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, LaboratorioNueva l, ItemLaboratorio il
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and l.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and l.id_itemLaboratorio_fk=il.id_itemLaboratorio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=@idRazonamiento
                                and l.fechaRealizacion is null";

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
                    analisisLaboratorio = new AnalisisLaboratorio();
                    analisisLaboratorio.nombre = dr["nombre"].ToString();

                    Laboratorio laboratorio = new Laboratorio();
                    laboratorio.id_laboratorio = (int)dr["id_laboratorio"];
                    laboratorio.fechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]);
                    laboratorio.analisis = analisisLaboratorio;
                    laboratorio.indicaciones = dr["indicaciones"].ToString();

                    analisis.Add(laboratorio);
                }

                return analisis;
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
        public static void UpdateLaboratorio(Laboratorio laboratorio, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            //string consulta = @"update LaboratorioNueva
            //                    set fechaRealizacion=@fechaRealizacion, doctorACargo=@doctorACargo,
            //                    id_institucion_fk=@idInstitucion, observacionDeLosResultados=@observaciones,
            //                    id_metodoAnalisisLaboratorio_fk=@idMetodo
            //                    where id_laboratorio=@idLaboratorio and id_razonamientoDiagnostico_fk=@idRazonamiento";

            string consulta = @"update LaboratorioNueva
                                set fechaRealizacion=@fechaRealizacion
                                where id_laboratorio=@idLaboratorio and id_razonamientoDiagnostico_fk=@idRazonamiento";

            cmd.Parameters.AddWithValue("@fechaRealizacion", laboratorio.fechaRealizacion);
            cmd.Parameters.AddWithValue("@doctorACargo", laboratorio.DoctorACargo);
            cmd.Parameters.AddWithValue("@idInstitucion", laboratorio.id_institucion);

            if(string.IsNullOrEmpty(laboratorio.observaciones))
                cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@observaciones", laboratorio.observaciones);

            cmd.Parameters.AddWithValue("@idMetodo", laboratorio.id_metodoLaboratorio);
            //cmd.Parameters.AddWithValue("@idAnalisisLaboratorio", laboratorio.id_analisisLaboratorio_fk);
            cmd.Parameters.AddWithValue("@idLaboratorio", laboratorio.id_laboratorio);
            cmd.Parameters.AddWithValue("@idRazonamiento", laboratorio.id_razonamientoDiagnostico);

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                foreach(DetalleLaboratorio detalle in laboratorio.listaDetalle)
                {
                    detalle.idLaboratorio = laboratorio.id_laboratorio;
                    DetalleLaboratorioDAO.insertDetalleLaboratorio(detalle, cn, tran);
                }
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
        public static void insertResultadosEstudioLaboratorio(Laboratorio laboratorio)
        {
            SetCadenaConexion();

            SqlConnection cn = new SqlConnection(GetCadenaConexion());
            SqlTransaction tran = null;
            SqlCommand cmd = new SqlCommand();

            string consulta = @"update LaboratorioNueva
                               set fechaRealizacion=@fechaRealizacion,doctorACargo=@doctorACargo,id_institucion_fk=@idInstitucion,observacionDeLosResultados=@observacionDeLosResultados,id_itemLaboratorio_fk=@idItemLaboratorio,id_metodoAnalisisLAboratorio_fk=@idMetodoAnalisisLaboratorio
                               where id_laboratorio=@idLaboratorio";

            cmd.Parameters.AddWithValue("@fechaRealizacion", laboratorio.fechaRealizacion);
            cmd.Parameters.AddWithValue("@doctorACargo", laboratorio.DoctorACargo);
            cmd.Parameters.AddWithValue("@idInstitucion", laboratorio.id_institucion);
            cmd.Parameters.AddWithValue("@observacionDeLosResultados", laboratorio.observaciones);
            cmd.Parameters.AddWithValue("@idMetodoAnalisisLaboratorio", laboratorio.id_metodoLaboratorio);
            cmd.Parameters.AddWithValue("@idLaboratorio", laboratorio.id_laboratorio);
            cmd.Parameters.AddWithValue("@idItemLaboratorio", laboratorio.id_analisisLaboratorio_fk);

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                //SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('Laboratorio')", cn, tran);

                //laboratorio.id_laboratorio = Convert.ToInt32(cmd1.ExecuteScalar());

                //llamar al metodo UpdateDetalleLaboratorio
                foreach (DetalleLaboratorio detalle in laboratorio.listaDetalle)
                {
                    detalle.idLaboratorio = laboratorio.id_laboratorio;
                    DetalleLaboratorioDAO.insertarDetalleLaboratorio(detalle, cn, tran);
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
                throw e;
            }
        }
        public static List<Laboratorio> obtenerLaboratorioIdConsulta(int idConsulta)
        {
            SetCadenaConexion();

            List<Laboratorio> analisis = new List<Laboratorio>();
            AnalisisLaboratorio analisisLaboratorio = null;

            SqlConnection cn = new SqlConnection(GetCadenaConexion());

            string consulta = @"select ilab.nombre as 'Estudio',ln.fechaSolicitud as 'Fecha de Solicitud',ln.indicaciones
                                from RazonamientoDiagnostico rd, LaboratorioNueva ln, EstadoDiagnostico ed,itemLaboratorio ilab,ExamenGeneral ex,Consulta c
                                where rd.id_razonamiento=ln.id_razonamientoDiagnostico_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and ln.id_itemLaboratorio_fk=ilab.id_itemLaboratorio
                                and rd.id_examenGeneral_fk=ex.id_examenGeneral
                                and c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ed.nombre not like 'Descartado'
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
                    analisisLaboratorio = new AnalisisLaboratorio();
                    analisisLaboratorio.nombre = dr["Estudio"].ToString();

                    Laboratorio laboratorio = new Laboratorio();
                    laboratorio.fechaSolicitud = Convert.ToDateTime(dr["Fecha de Solicitud"]);
                    laboratorio.analisis = analisisLaboratorio;
                    laboratorio.indicaciones = dr["indicaciones"].ToString();

                    analisis.Add(laboratorio);
                }
                return analisis;
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
        public static DataTable MostrarEstudiosLaboratorio(int idHc)
        {
            SetCadenaConexion();
            SqlConnection cn = new SqlConnection(GetCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select ilab.nombre as 'Estudio',ln.fechaSolicitud as 'Fecha de Solicitud',ln.indicaciones,c.id_hc_fk,ln.observacionDeLosResultados as 'Observaciones',ln.fechaRealizacion as 'Fecha Realizacion'
                                from RazonamientoDiagnostico rd, LaboratorioNueva ln,itemLaboratorio ilab,ExamenGeneral ex,Consulta c
                                where rd.id_razonamiento=ln.id_razonamientoDiagnostico_fk
                                and ln.id_itemLaboratorio_fk=ilab.id_itemLaboratorio
                                and rd.id_examenGeneral_fk=ex.id_examenGeneral
                                and c.id_examenGeneral_fk=ex.id_examenGeneral
                                and c.id_hc_fk=@id_hc";
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
