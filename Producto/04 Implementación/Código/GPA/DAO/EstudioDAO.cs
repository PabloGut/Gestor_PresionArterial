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
        public static List<Estudio> mostrarEstudiosDeHCLista(int id_hc)
        {
            setCadenaConexion();
            List<Estudio> estudios = new List<Estudio>();
             SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                cn.Open();

                string consulta = "select id_estudio,nombre,fecha_estudio,doctorACargo,informe_estudio,id_institucion_fk from Estudio where id_hc_fk=@nroHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@nroHc", id_hc);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        estudios.Add(new Estudio()
                        {
                            id_estudio=(int)dr["id_estudio"],
                            nombre = dr["nombre"].ToString(),
                            fecha = Convert.ToDateTime(dr["fecha_estudio"].ToString()),
                            doctorACargo = dr["doctorACargo"].ToString(),
                            informeEstudio = dr["informe_estudio"].ToString(),
                            id_institucion = (int)dr["id_institucion_fk"]
                        });
                    }
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return estudios;
        }
        public static DataSet mostrarEstudiosDeHCDS(int id_hc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(cadenaConexion);
            

            //string consulta = "select id_estudio,nombre,fecha_estudio,doctorACargo,informe_estudio,id_hc_fk,id_institucion_fk from Estudio where id_hc_fk=@nro";
            string consulta = "select * from Estudio where id_hc_fk=" + id_hc;

            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@nro",id_hc);

            DataSet ds = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                ds = new DataSet();
                da = new SqlDataAdapter(consulta, cn);
                System.Diagnostics.Debugger.Break() ;
                da.Fill(ds,"Estudio");

            }
            catch(Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            
            cn.Close();
            return ds;
        }
    }
}
