using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Clases;
using System.Data;

namespace DAO
{
    public class ProfesionalMedicoDAO
    {
        private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";

        public static void buscarProfesionalMédico(Usuario usuarioMedico)
        {
            
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select pm.id_tipoDoc_fk,pm.nro_documento,pm.nombre,pm.apellido from ProfesionalMedico pm, Usuario u where pm.id_usuario_fk=@id_usuario and pm.id_usuario_fk=u.id_usuario";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProfesionaMedico pm = new ProfesionaMedico(dr["nombre"].ToString(),dr["apellido"].ToString(),(int)dr["id_tipodoc_fk"],(long)dr["nro_documento"]);

            }

        }
    }
}
