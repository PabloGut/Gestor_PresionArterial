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
    public class ItemLaboratorioDAO
    {
        public static int registrarItemLaboratorio(string nombre, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into itemLaboratorio(nombre)
                                values(@nombre)";
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@nombre", nombre);

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('itemLaboratorio')", cn, tran);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());
                return id;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new Exception("Error al insertar: " + e.Message);
            }

        }
    }
}
