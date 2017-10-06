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
    public class PielDAO
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
        public static int registrarExamenPiel(Piel piel,SqlConnection cn,SqlTransaction tran)
        {
            try
            {
                string consulta = @"insert into Piel(color,elasticidad,humedad,untuosidad,turgor,lesiones,id_temperatura_fk)
                                    values(@color,@elasticidad,@humedad,@untuosidad,@turgor,@lesiones,@id_Temperatura_fk)";

                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrEmpty(piel.color))
                {
                    cmd.Parameters.AddWithValue("@color", piel.color);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@color", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(piel.elasticidad))
                {
                    cmd.Parameters.AddWithValue("@elasticidad", piel.elasticidad);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@elasticidad", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(piel.humedad))
                {
                    cmd.Parameters.AddWithValue("@humedad", piel.humedad);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@humedad", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(piel.untuosidad))
                {
                    cmd.Parameters.AddWithValue("@untuosidad", piel.untuosidad);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@untuosidad", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(piel.turgor))
                {
                    cmd.Parameters.AddWithValue("@turgor", piel.turgor);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@turgor", DBNull.Value);
                }

                if (!string.IsNullOrEmpty(piel.lesiones))
                {
                    cmd.Parameters.AddWithValue("@lesiones", piel.lesiones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lesiones", DBNull.Value);
                }

                if (piel.temperatura.id_temperatura >0)
                {
                    cmd.Parameters.AddWithValue("@id_Temperatura_fk", piel.temperatura.id_temperatura);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_Temperatura_fk", DBNull.Value);
                }

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                 SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('Piel')", cn, tran);
                 piel.id_piel= Convert.ToInt32(cmd1.ExecuteScalar());
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return piel.id_piel;
        }
    }
}
