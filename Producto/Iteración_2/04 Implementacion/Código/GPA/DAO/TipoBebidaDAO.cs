﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Clases;
using System.Data;

namespace DAO
{
    public class TipoBebidaDAO
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
         * Método para obtener todas las columnas de la tabla TipoBebida.
         * No recibe datos como parámetro.
         * Retorna una lista de objetos TipoBebida.
         */
        public static List<TipoBebida> mostrarTiposDeBebidas()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<TipoBebida> tiposDeBebidas = new List<TipoBebida>();
            try
            {
                cn.Open();

                string consulta = "select * from TipoBebida";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposDeBebidas.Add(new TipoBebida()
                    {
                        id_tipoBebida = (int)dr["id_tipoBebida"],
                        nombre = dr["nombre"].ToString()
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
            return tiposDeBebidas;
        }
        public static void RegistrarTipoBebida(TipoBebida Tipo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"insert into TipoBebida(nombre)
                                  values(@nombre)";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", Tipo.nombre);

                cmd.ExecuteNonQuery();

                tran.Commit();
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
        }
        public static void ActualizarTipoBebida(TipoBebida Tipo)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"update TipoBebida
                                    set nombre=@nombre
                                    where id_tipoBebida=@idTipoBebida";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", Tipo.nombre);
                cmd.Parameters.AddWithValue("@idTipoBebida", Tipo.id_tipoBebida);

                cmd.ExecuteNonQuery();

                tran.Commit();
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
        }
    }
}
