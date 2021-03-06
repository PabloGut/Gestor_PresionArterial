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
    public class SustanciaContactoPielDAO
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
         * Método para obtener todas las columnas de la tabla SustanciaContactoPiel.
         * No recibe datos como parámetro.
         * Retorna una lista de objetos SustanciaContactoPiel.
         */
        public static List<SustanciaContactoPiel> mostrarSustanciasContactoPiel()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<SustanciaContactoPiel> sustanciasContactoPiel = new List<SustanciaContactoPiel>();
            try
            {
                cn.Open();

                string consulta = "select * from SustanciaContactoPiel";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    sustanciasContactoPiel.Add(new SustanciaContactoPiel()
                    {
                        id_sustanciaContactoPiel = (int)dr["id_sustanciaContactoPiel"],
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
            return sustanciasContactoPiel;
        }
    }
}
