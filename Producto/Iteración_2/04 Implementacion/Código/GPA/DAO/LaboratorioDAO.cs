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

        public static void setCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string getCadenaConexion()
        {
            return cadenaConexion;
        }
        public static List<Laboratorio> obtenerAnalisisLaboratorio(int idRazonamiento)
        {
            setCadenaConexion();

            List<Laboratorio> analisis = new List<Laboratorio>();
            AnalisisLaboratorio analisisLaboratorio = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select l.id_laboratorio, l.fechaSolicitud,al.nombre,l.indicaciones
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, Laboratorio l, AnalisisLaboratorio al
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and l.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and l.id_analisisLaboratorio_fk=al.id_analisisLaboratorio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=@idRazonamiento";

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
        public static void updateLaboratorio(Laboratorio laboratorio, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            string consulta = @"update Laboratorio
                                set fechaRealizacion=@fechaRealizacion, doctorACargo=@doctorACargo,
                                id_institucion_fk=@idInstitucion, observacionDeLosResultados=@observaciones,
                                id_metodoAnalisisLaboratorio_fk=@idMetodo, 
                                id_analisisLaboratorio_fk=@idAnalisisLaboratorio
                                where id_laboratorio=@idLaboratorio";    

            cmd.Parameters.AddWithValue("@fechaRealizacion", laboratorio.fechaRealizacion);
            cmd.Parameters.AddWithValue("@doctorACargo", laboratorio.DoctorACargo);
            cmd.Parameters.AddWithValue("@idInstitucion", laboratorio.id_institucion);

            if(string.IsNullOrEmpty(laboratorio.observaciones))
                cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@observaciones", laboratorio.observaciones);

            cmd.Parameters.AddWithValue("@idMetodo", laboratorio.id_metodoLaboratorio);
            cmd.Parameters.AddWithValue("@idAnalisisLaboratorio", laboratorio.id_analisisLaboratorio_fk);
            cmd.Parameters.AddWithValue("@idLaboratorio", laboratorio.id_laboratorio);


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
    }
}
