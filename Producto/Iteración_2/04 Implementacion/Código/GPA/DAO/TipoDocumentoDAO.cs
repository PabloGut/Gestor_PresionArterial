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
            setCadenaConexion();
            List<TipoDocumento> tiposDoc = new List<TipoDocumento>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta="select id_TipoDoc,nombre,descripcion from TipoDocumento";

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
                    nombre = dr["nombre"].ToString(),
                    descripcion = dr["descripcion"].ToString()
                });
            }
            cn.Close();
            return tiposDoc;
        }

        public static int insertarTipoDoc(string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into TipoDocumento (nombre, descripcion) values (@paramNombre, @paramDescripcion)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);
            int idhc = Convert.ToInt32(cmd1.ExecuteScalar());


            cn.Close();
            return idhc;
        }

        public static void actualizarTipoDoc(int id, string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "UPDATE TipoDocumento SET nombre=@paramNombre, descripcion=@paramDescripcion " +
                              "WHERE id_tipoDoc=@paramId_tipoDoc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramNombre", nombre);
            cmd.Parameters.AddWithValue("@paramDescripcion", descripcion);
            cmd.Parameters.AddWithValue("@paramId_tipoDoc", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void eliminarTipoDoc(int id)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "DELETE FROM TipoDocumento WHERE id_tipoDoc=@paramId_tipoDoc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramId_tipoDoc", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}
