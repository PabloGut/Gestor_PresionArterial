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
        //private static string cadenaConexion="Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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
        public static DataTable buscarInstituciones()
        {
            //List<Institucion> instituciones = new List<Institucion>();
            setCadenaConexion();
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

           
        }
        /*public static List<Domicilio> buscarDomicilioInstitucion(int id_institucion)
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
                                        //numero = dr["numero"].ToString()

                                    });
            }
            cn.Close();
            return domicilio;
        }*/
        /*public static void InsertarInstitucion(string nombre, string descripcion, Domicilio domicilio)
        {

            SqlTransaction tran = null;

            string consulta = "insert into Institucion(nombre,descripcion) values (@nombre,@desc)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@desc", descripcion);

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {

                cn.Open();
                tran = cn.BeginTransaction();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);
                //domicilio.id_institucion = Convert.ToInt32(cmd1.ExecuteScalar());

                DomicilioDAO.insertarDomicilio(domicilio, cn, tran);
                tran.Commit();
                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("error al guardar la institución. " + e.Message);
            }

        }*/
        
        public static void InsertarInstitucion(Institucion institucion)
        {
            
            SqlTransaction tran = null;

            string consulta = "insert into Institucion(nombre,descripcion) values (@nombre,@desc)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombre", institucion.nombre);

            if (!string.IsNullOrEmpty(institucion.descripcion))
                cmd.Parameters.AddWithValue("@desc", institucion.descripcion);
            else
                cmd.Parameters.AddWithValue("@desc", DBNull.Value);

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {

                cn.Open();
                tran = cn.BeginTransaction();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("error al guardar la institución. " + e.Message);
            }


        }
        public static Institucion buscarIdInstitucion(int id)
        {
            setCadenaConexion();

            String consulta = "Select id_institucion, nombre, descripcion from Institucion where id_institucion=@id";
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = null;

            Institucion ins = null;

            try {


                cn.Open();

                cmd.Parameters.AddWithValue("@id", id);
                

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                dr=cmd.ExecuteReader();

                while(dr.Read())
                {
                    ins = new Institucion();
                    ins.id = (int)dr["id_institucion"];
                    ins.nombre = dr["nombre"].ToString();
                    ins.descripcion = dr["descripcion"].ToString();
                }

                cn.Close();
                return ins;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error!!! " + e.Message);
            }


        }
        public static List<Institucion> obtenerInstituciones()
        {
            List<Institucion> instituciones = new List<Institucion>();
            setCadenaConexion();

            SqlDataReader dr=null;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                cn.Open();

                //String consulta="Select ins.nombre,dom.calle,dom.numero from Institucion ins, Domicilio dom where ins.id_institucion=dom.id_institucion"; 
                String consulta = "Select id_institucion,nombre, descripcion from Institucion";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                dr=cmd.ExecuteReader();

                while (dr.Read())
                {
                    instituciones.Add(new Institucion() { 
                        
                        id=(int)dr["id_institucion"],
                        nombre=dr["nombre"].ToString(),
                        descripcion=dr["descripcion"].ToString()
                    });
                }

                cn.Close();
                return instituciones ;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error!!! " + e.Message);
            }

        }
        public static void updateInstitucion(Institucion institucion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            string consulta = @"update Institucion
                                set nombre=@nombre, descripcion=@descripcion
                                where id_institucion=@idInstitucion";

            try
            {
                cn.Open();

                cmd.Parameters.AddWithValue("@nombre", institucion.nombre);
                if (!string.IsNullOrEmpty(institucion.descripcion))
                    cmd.Parameters.AddWithValue("@descripcion", institucion.descripcion);
                else
                    cmd.Parameters.AddWithValue("@descripcion", DBNull.Value);

                cmd.Parameters.AddWithValue("@idInstitucion", institucion.id);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();


                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error!!! " + e.Message);
            }
        }

    }
}
