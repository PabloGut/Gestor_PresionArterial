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
    public class ComponeneteDelTiempoDAO
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
      * Método para obtener los nombres de todos los componentes del tiempo.
      * No recibe parámetros.
      * Retorna una lista de objetos CompoenenteDelTiempo.
      */
        public static List<ComponenteDelTiempo> mostrarComponentesDelTiempo()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<ComponenteDelTiempo> componentes = new List<ComponenteDelTiempo>();
            try
            {
                cn.Open();

                string consulta = "select * from ComponenteDelTiempo";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    componentes.Add(new ComponenteDelTiempo()
                    {
                        id_componenteTiempo = (int)dr["id_componenteTiempo"],
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
            return componentes;
        }
    }
}
