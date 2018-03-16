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
                throw new ApplicationException("Error:" + e.Message);
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

    }
}
