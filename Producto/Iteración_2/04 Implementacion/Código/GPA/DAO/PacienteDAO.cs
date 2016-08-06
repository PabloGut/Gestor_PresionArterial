using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class PacienteDAO
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
        public static List<Paciente> buscarPaciente(int id_tipoDoc,long nroDocumento)
        {
            setCadenaConexion();
            List<Paciente> pacientes = new List<Paciente>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select nombre,apellido,id_hc_fk from Paciente where id_tipoDoc_fk=@id_tipoDoc and nro_documento=@nroDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id_tipoDoc", id_tipoDoc);
            cmd.Parameters.AddWithValue("@nroDocumento", nroDocumento);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["id_hc_fk"] != DBNull.Value)
                {
                    pacientes.Add(new Paciente()
                    {
                        nombre = dr["nombre"].ToString(),
                        apellido = dr["apellido"].ToString(),
                        id_hc = (int)dr["id_hc_fk"]
                    });
                }
                else
                {
                    pacientes.Add(new Paciente()
                    {
                        nombre = dr["nombre"].ToString(),
                        apellido = dr["apellido"].ToString(),
                    });
                }
                
            }
            cn.Close();
            return pacientes;
        }
        public static Boolean ExisteHC(int id_tipoDoc, long nroDocumento)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select id_hc_fk from Paciente where id_tipoDoc_fk=@id_tipoDoc and nro_documento=@nroDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id_tipoDoc",id_tipoDoc);
            cmd.Parameters.AddWithValue("@nroDocumento", (int)nroDocumento);
            

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

           
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["id_hc_fk"] == DBNull.Value)
                    {
                        return false;
                    }
                }
                
            }
            cn.Close();
            return true;
        }
        public static void AsignarHCPaciente(int id_tipoDoc, long nroDocumento,int idhc)
        {
            

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "update Paciente set id_hc_fk=@idhc where id_tipoDoc_fk=@id_tipoDoc and nro_documento=@nroDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id_tipoDoc", id_tipoDoc);
            cmd.Parameters.AddWithValue("@nroDocumento", nroDocumento);
            cmd.Parameters.AddWithValue("@idhc", idhc);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            
            cn.Close();
            
        }
    }
}
