﻿using System;
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
                //throw new ApplicationException("Error:" + e.Message);
                throw e;
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
                                and r.id_razonamiento=@idRazonamiento
                                and ed.fechaRealizacion is null";

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
        public static void updateEstudioDiagnosticoPorImagen(EstudioDiagnosticoPorImagen estudio, SqlConnection cn ,SqlTransaction tran)
        {
            SqlCommand cmd= new SqlCommand();

            string consulta= @"update EstudiosDiagnosticoPorImagen
                              set fechaRealizacion=@fechaRealizacion, doctorACargo=@doctor, id_institucion_fk=@institucion,
                              observacionDeLosResultados=@observaciones,
                              informe=@informe,
                              id_nombreEstudio_fk=@idNombreEstudio
                              where id_estudioDiagnosticoPorImagen=@idEstudioDiagnosticoImagen";
            try
            {
                cmd.Parameters.AddWithValue("@fechaRealizacion", estudio.fechaRealizacion);
                cmd.Parameters.AddWithValue("@doctor", estudio.DoctorACargo);
                cmd.Parameters.AddWithValue("@institucion", estudio.idInstitucion);
                cmd.Parameters.AddWithValue("@observaciones", estudio.observaciones);
                cmd.Parameters.AddWithValue("@informe", estudio.informeEstudio);
                cmd.Parameters.AddWithValue("@idNombreEstudio", estudio.id_nombreEstudio);
                cmd.Parameters.AddWithValue("@idEstudioDiagnosticoImagen", estudio.id_estudioDiagnosticoPorImagen);
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new ApplicationException("Error al actualizar estudio diagnostico por imagen: " + e.Message);
            }
        }
        public static List<EstudioDiagnosticoPorImagen> obtenerEstudioDiagnosticoPorImagenIdConsulta(int idConsulta)
        {
            setCadenaConexion();

            List<EstudioDiagnosticoPorImagen> estudios = new List<EstudioDiagnosticoPorImagen>();
            NombreEstudio nomEstudio = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select ne.nombre as 'Estudio', edi.fechaSolicitud as 'Fecha de solicitud', edi.indicaciones
                                from Consulta c, ExamenGeneral ex, RazonamientoDiagnostico rd, EstadoDiagnostico ed, EstudiosDiagnosticoPorImagen edi,NombreEstudio ne
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=rd.id_examenGeneral_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and ed.nombre not like 'Descartado'
                                and edi.id_razonamientoDiagnostico_fk=rd.id_razonamiento
                                and edi.id_nombreEstudio_fk=ne.id_nombreEstudio
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
                    nomEstudio = new NombreEstudio();
                    nomEstudio.nombre = dr["Estudio"].ToString();

                    EstudioDiagnosticoPorImagen estudio = new EstudioDiagnosticoPorImagen();
                    estudio.fechaSolicitud = Convert.ToDateTime(dr["Fecha de solicitud"]);
                    estudio.nombreEstudio = nomEstudio;
                    estudio.indicaciones = dr["indicaciones"].ToString();

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
        public static DataTable MostrarEstudioDiagnosticoPorImagen(int id_hc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select ne.nombre as 'Estudio', edi.fechaSolicitud as 'Fecha de solicitud', edi.indicaciones, edi.fechaRealizacion as 'Fecha de Realizacion',edi.informe as 'Informe',edi.observacionDeLosResultados as 'Observaciones'
                                from Consulta c, ExamenGeneral ex, RazonamientoDiagnostico rd, EstadoDiagnostico ed, EstudiosDiagnosticoPorImagen edi,NombreEstudio ne
                                where c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=rd.id_examenGeneral_fk
                                and rd.id_estadoDiagnostico_fk=ed.id_estadoDiagnostico
                                and ed.nombre not like 'Descartado'
                                and edi.id_razonamientoDiagnostico_fk=rd.id_razonamiento
                                and edi.id_nombreEstudio_fk=ne.id_nombreEstudio
                                and c.id_consulta=@id_hc";
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
