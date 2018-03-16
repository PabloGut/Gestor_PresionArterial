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
    public class EstudioDiagnosticoPorImagenDAO
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
        public static void registrarEstudioDiagnosticoPorImagen(EstudioDiagnosticoPorImagen estudio, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into EstudiosDiagnosticoPorImagen(fechaSolicitud,indicaciones,id_nombreEstudio_fk, id_razonamientoDiagnostico_fk)
                                  values(@fechaSolicitud,@indicaciones,@id_nombreEstudio_fk,@id_razonamientoDiagnostico_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@fechaSolicitud", estudio.fechaSolicitud);
                if (!string.IsNullOrEmpty(estudio.indicaciones))
                {
                    cmd.Parameters.AddWithValue("@indicaciones", estudio.indicaciones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@indicaciones", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@id_nombreEstudio_fk", estudio.nombreEstudio.id_nombreEstudio);
                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", estudio.id_razonamientoDiagnostico);

                cmd.ExecuteNonQuery();
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
        public static List<EstudioDiagnosticoPorImagen> obtenerEstudioDiagnosticoPorImagen(int idRazonamiento)
        {
            setCadenaConexion();

            List<EstudioDiagnosticoPorImagen> estudios = new List<EstudioDiagnosticoPorImagen>();
            NombreEstudio nomEstudio=null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select ed.fechaSolicitud,ne.nombre,ed.indicaciones,ed.id_estudioDiagnosticoPorImagen
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, EstudiosDiagnosticoPorImagen ed, NombreEstudio ne
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and ed.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and ed.id_nombreEstudio_fk=ne.id_nombreEstudio
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
                    nomEstudio = new NombreEstudio();
                    nomEstudio.nombre = dr["nombre"].ToString();

                    EstudioDiagnosticoPorImagen estudio = new EstudioDiagnosticoPorImagen();
                    estudio.fechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]);
                    estudio.nombreEstudio = nomEstudio;
                    estudio.indicaciones = dr["indicaciones"].ToString();
                    estudio.id_estudioDiagnosticoPorImagen = (int)dr["id_estudioDiagnosticoPorImagen"];

                    estudios.Add(estudio);
                }

                return estudios;
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

    }
}
