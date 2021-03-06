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
    public class CaracterDelDolorDAO
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
       * Método para obtener los nombres de los tipos de dolores.
       * No recibe parámetros.
       * Retorna una lista de objetos CaracterDelDolor.
       */
        public static List<CaracterDelDolor> mostrarCaracterDelDolor()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<CaracterDelDolor> caracterDolor = new List<CaracterDelDolor>();
            try
            {
                cn.Open();

                string consulta = "select * from CaracterDelDolor";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    caracterDolor.Add(new CaracterDelDolor()
                    {
                        id_caracterDelDolor = (int)dr["id_caracterDelDolor"],
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
            return caracterDolor;
        }
        public static void updateCaracterDolor(CaracterDelDolor caracter)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"update CaracterDelDolor
                                set nombre=@nombre
                                where id_caracterDelDolor=@idCaracterDelDolor";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", caracter.nombre);
                cmd.Parameters.AddWithValue("@idCaracterDelDolor", caracter.id_caracterDelDolor);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en update:" + e.Message);
            }
        }
        public static void deleteCaracterDolor(CaracterDelDolor caracter)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"delete from CaracterDelDolor
                                where id_caracterDelDolor=@idCaracterDelDolor";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@idCaracterDelDolor", caracter.id_caracterDelDolor);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en delete:" + e.Message);
            }
        }
        public static void insertCaracterDolor(CaracterDelDolor caracter)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into CaracterDelDolor(nombre)
                                values(@nombre)";

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@nombre", caracter.nombre);

                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error en insert:" + e.Message);
            }
        }
    }
}
