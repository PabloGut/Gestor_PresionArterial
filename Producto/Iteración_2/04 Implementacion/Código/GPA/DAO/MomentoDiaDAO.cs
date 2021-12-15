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
    public class MomentoDiaDAO
    {
        private static string cadenaConexion;

        public static void SetCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string GetCadenaConexion()
        {
            return cadenaConexion;
        }
        public static List<MomentoDia> MostrarMomentosDelDia()
        {
            SqlConnection cn = null;
            List<MomentoDia> momentosDia = new List<MomentoDia>();
            try
            {
                SetCadenaConexion();
                cn = new SqlConnection(GetCadenaConexion());
                cn.Open();

                string consulta = "select * from MomentoDelDia";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    momentosDia.Add(new MomentoDia()
                    {
                        idMomentoDia = (int)dr["id_momentoDelDia"],
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
            return momentosDia;
        }
    }
}
