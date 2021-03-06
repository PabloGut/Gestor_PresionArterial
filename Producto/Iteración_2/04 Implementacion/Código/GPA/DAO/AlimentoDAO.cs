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
    public class AlimentoDAO
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
         * Método para obtener todas las columnas de la tabla Alimento.
         * No recibe datos como parámetro.
         * Retorna una lista de objetos Alimento.
         */
        public static List<Alimento> mostrarAlimentos()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<Alimento> alimentos = new List<Alimento>();
            try
            {
                cn.Open();

                string consulta = "select * from Alimento";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    alimentos.Add(new Alimento()
                    {
                        id_alimento = (int)dr["id_alimento"],
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
            return alimentos;
        }
    }
}
