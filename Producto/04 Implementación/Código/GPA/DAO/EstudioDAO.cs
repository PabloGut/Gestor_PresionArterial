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
    public class EstudioDAO
    {
        private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
        public static void insertarEstudio(Estudio estudio)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into Estudio(nombre,fecha_estudio,doctorACargo,informe_estudio,id_hc_fk,id_institucion_fk) values (@nombre,@fechaEstudio,@doctorACargo,@informe,@id_hc,@id_inst)";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombre",estudio.nombre);
            cmd.Parameters.AddWithValue("@fechaEstudio",estudio.fecha);
            cmd.Parameters.AddWithValue("@doctorACargo",estudio.doctorACargo);
            cmd.Parameters.AddWithValue("@informe",estudio.informeEstudio);
            cmd.Parameters.AddWithValue("@id_hc",estudio.id_hc);
            cmd.Parameters.AddWithValue("@id_inst", estudio.id_institucion);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
