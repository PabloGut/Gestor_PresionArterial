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
    public class AlergiaInsectoDAO
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
        /*
        * Método para registrar las alergias a los insectos.
        * Recibe como parámetros una lista de objetos AlergiaInsecto y el id de la historia clínica.
        * El valor de retorno es void.
        */
        public static void registrarAlergiaInsecto(List<AlergiaInsecto> alergiaInsecto, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AlergiaInsecto(fechaRegistro,id_insecto_fk, efectos, id_hc_fk)
                                  values(@fechaRegistro,@idInsecto,@efectos,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AlergiaInsecto alergia in alergiaInsecto)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idInsecto", alergia.id_insecto);
                    if (string.IsNullOrEmpty(alergia.efectos) == true)
                    {
                        cmd.Parameters.AddWithValue("@efectos",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@efectos", alergia.efectos);
                    }
                    
                    cmd.Parameters.AddWithValue("@idHc", idHc);

                    cmd.ExecuteNonQuery();
                }
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
        }
        public static DataTable mostrarAlegiasInsectos(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @"select ai.fechaRegistro as 'Fecha de registro', ins.nombre as 'Nombre del alérgeno', ai.efectos as 'Efectos de la alergia'
                                    from AlergiaInsecto ai, Insecto ins
                                    where ai.id_hc_fk=@idHc
                                    and ai.id_insecto_fk=ins.id_insecto";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
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
