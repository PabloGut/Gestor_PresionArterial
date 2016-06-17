using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class LocalidadDAO
    {
        private static string cadenaConexion="Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";

        public static DataTable buscarLocalidades()
        {
            DataTable dt = new DataTable();
            string consulta = "select * from Localidad";

            SqlConnection cn= new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            dt.Load(cmd.ExecuteReader());

            return dt;

        }
    }
}
