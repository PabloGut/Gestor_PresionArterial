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
    public class BarrioDAO
    {
        private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";

        public static DataTable buscarBarrios()
        {
            DataTable dt= new DataTable();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select id_barrio, nombre from Barrio";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cmd.Connection = cn;
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return dt;
        }

        

        

    }
}
