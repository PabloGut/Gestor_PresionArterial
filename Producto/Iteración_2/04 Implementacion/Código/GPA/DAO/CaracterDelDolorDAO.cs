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
    }
}
