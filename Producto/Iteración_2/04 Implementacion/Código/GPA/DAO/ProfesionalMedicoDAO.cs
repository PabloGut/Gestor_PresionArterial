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
        public static ProfesionaMedico buscarProfesionalMédico(Usuario usuarioMedico)
        {
            ProfesionaMedico pm=null;
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
                pm = new ProfesionaMedico(dr["nombre"].ToString(),dr["apellido"].ToString(),(int)dr["id_tipodoc_fk"],(long)dr["nro_documento"]);

            }
            cn.Close();
            return pm;
        }

        public static List<ProfesionaMedico> buscarProfesionalMédico(int id_tipoDoc, long nroDocumento)
        {
            setCadenaConexion();
            List<ProfesionaMedico> profesionales = new List<ProfesionaMedico>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select nombre,apellido from ProfesionalMedico where id_tipoDoc_fk=@id_tipoDoc and nro_documento=@nroDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id_tipoDoc", id_tipoDoc);
            cmd.Parameters.AddWithValue("@nroDocumento", nroDocumento);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                profesionales.Add(new ProfesionaMedico()
                {
                        nombre = dr["nombre"].ToString(),
                        apellido = dr["apellido"].ToString(),
                });
            }
            cn.Close();
            return profesionales;
        }

        public static ProfesionaMedico buscarMedicoDeUsuario(int id_usuario)
        {
            
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            ProfesionaMedico medico=null;
            string consulta = "select id_tipodoc_fk,nro_documento from ProfesionalMedico where id_usuario_fk=@id_usuario";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medico = new ProfesionaMedico((int)dr["id_tipodoc_fk"], Convert.ToInt32(dr["nro_documento"].ToString()));
            }
            cn.Close();
            return medico;

        }
        public static void buscarMedicoLogueado(ProfesionaMedico profesionalLogueado)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            //ProfesionaMedico medico = null;
            string consulta = "select nombre,apellido from ProfesionalMedico where id_tipodoc_fk=@idtipodoc and nro_documento=@nrodoc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idtipodoc", profesionalLogueado.id_tipoDoc);
            cmd.Parameters.AddWithValue("@nrodoc", profesionalLogueado.nroDoc);


            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //medico = new ProfesionaMedico(dr["nombre"].ToString(),dr["apellido"].ToString());
                profesionalLogueado.nombre = dr["nombre"].ToString();
                profesionalLogueado.apellido = dr["apellido"].ToString();
            }
            cn.Close();
        }

        public static void insertarProfesionalMédico(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int id_especialidad, int matricula, string nombre_usuario, string contraseña, DateTime fecha_creacion, int id_estado)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consultaInsertarDomicilio = "INSERT INTO Domicilio (calle,numero,codigo_postal,piso,departamento,id_barrio) VALUES (@paramCalle,@paramNumero,@paramCodigo_postal,@paramPiso,@paramDepartamento,@paramId_barrio)";

                SqlCommand cmdInsertarDomicilio = new SqlCommand();
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramCalle", calle);
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramNumero", numero);
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramCodigo_postal", codigo_postal);
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramPiso", piso);
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramDepartamento", departamento);
                cmdInsertarDomicilio.Parameters.AddWithValue("@paramId_barrio", id_barrio);

                cmdInsertarDomicilio.CommandText = consultaInsertarDomicilio;
                cmdInsertarDomicilio.CommandType = CommandType.Text;
                cmdInsertarDomicilio.Connection = cn;
                cmdInsertarDomicilio.Transaction = tran;

                cmdInsertarDomicilio.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT @@Identity", cn);
                cmd1.Transaction = tran;
                int id_domicilio = Convert.ToInt32(cmd1.ExecuteScalar());

                string consultaInsertarUsuario = "INSERT INTO Usuario (nombre_usuario,contraseña,fecha_creacion) VALUES (@paramNombre_usuario,ENCRYPTBYPASSPHRASE('clave',@paramContraseña),@paramFecha_creacion)";

                SqlCommand cmdInsertarUsuario = new SqlCommand();
                cmdInsertarUsuario.Parameters.AddWithValue("@paramNombre_usuario", nombre_usuario);
                cmdInsertarUsuario.Parameters.AddWithValue("@paramContraseña", contraseña);
                cmdInsertarUsuario.Parameters.AddWithValue("@paramFecha_creacion", fecha_creacion.ToString("s", System.Globalization.CultureInfo.InvariantCulture));

                cmdInsertarUsuario.CommandText = consultaInsertarUsuario;
                cmdInsertarUsuario.CommandType = CommandType.Text;
                cmdInsertarUsuario.Connection = cn;
                cmdInsertarUsuario.Transaction = tran;

                cmdInsertarUsuario.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("SELECT @@Identity", cn);
                cmd2.Transaction = tran;
                int id_usuario = Convert.ToInt32(cmd2.ExecuteScalar());

                string consultaInsertarProfesionalMedico = "INSERT INTO ProfesionalMedico (id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,id_especialidad_fk,matricula_profesional,id_domicilio_fk) VALUES (@paramId_tipoDoc_fk,@paramNro_documento,@paramNombre,@paramApellido,@paramTelefono,@paramNroCelular,@paramEmail,@paramId_usuario_fk,@paramId_estado_fk,@paramId_especialidad_fk,@paramMatricula_profesional,@paramId_domicilio_fk)";

                SqlCommand cmdInsertarProfesionalMedico = new SqlCommand();
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramId_tipoDoc_fk", id_tipoDoc);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramNro_documento", nro_documento);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramNombre", nombre);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramApellido", apellido);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramTelefono", telefono);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramNroCelular", nroCelular);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramEmail", email);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramId_usuario_fk", id_usuario);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramId_estado_fk", id_estado);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramId_especialidad_fk", id_especialidad);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramMatricula_profesional", matricula);
                cmdInsertarProfesionalMedico.Parameters.AddWithValue("@paramId_domicilio_fk", id_domicilio);

                cmdInsertarProfesionalMedico.CommandText = consultaInsertarProfesionalMedico;
                cmdInsertarProfesionalMedico.CommandType = CommandType.Text;
                cmdInsertarProfesionalMedico.Connection = cn;
                cmdInsertarProfesionalMedico.Transaction = tran;

                cmdInsertarProfesionalMedico.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (SqlException ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error al insertar profesional médico\nDetalles: " + ex.Message);
            }
        }
    }
}
