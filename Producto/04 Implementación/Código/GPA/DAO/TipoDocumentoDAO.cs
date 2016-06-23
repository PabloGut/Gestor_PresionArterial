using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Clases;

namespace DAO
{
    public class TipoDocumentoDAO
    {
        //private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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
        public static List<TipoDocumento> buscarTiposDoc()
        {
            List<TipoDocumento> tiposDoc = new List<TipoDocumento>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta="select id_TipoDoc,nombre from TipoDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tiposDoc.Add(new TipoDocumento()
                {
                    id_tipoDoc = (int)dr["id_TipoDoc"],
                    nombre = dr["nombre"].ToString()
                });
            }
            cn.Close();
            return tiposDoc;



        }
    }
}
