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
    public class InstitucionDAO
    {
        private static string cadenaConexion="Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
       
        public static DataTable buscarInstituciones()
        {
            //List<Institucion> instituciones = new List<Institucion>();
            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            //String consulta="Select ins.nombre,dom.calle,dom.numero from Institucion ins, Domicilio dom where ins.id_institucion=dom.id_institucion"; 
            String consulta="Select id_institucion,nombre from Institucion"; 

            SqlCommand cmd= new SqlCommand();
            cmd.CommandText=consulta ;
            cmd.CommandType= CommandType.Text;
            cmd.Connection= cn;
            dt.Load(cmd.ExecuteReader());

            cn.Close();
            return dt;

            /*while(dr.Read())
            {
                instituciones.Add(new Institucion()
                                    {
                                        nombre=dr["nombre"].ToString()
                                        
                                    });
            }
            cn.Close();
            return instituciones;
            */
 
        }
        public static List<Domicilio> buscarDomicilioInstitucion(int id_institucion)
        {
            List<Domicilio> domicilio = new List<Domicilio>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            String consulta = "Select dom.calle,dom.numero from Institucion ins, Domicilio dom where ins.id_institucion=@id and ins.id_institucion=dom.id_institucion";

            cmd.Parameters.AddWithValue("@id",id_institucion);
            
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                domicilio.Add(new Domicilio()
                                    {
                                        calle = dr["calle"].ToString(),
                                        numero = dr["numero"].ToString()

                                    });
            }
            cn.Close();
            return domicilio;
        }
    }
}
