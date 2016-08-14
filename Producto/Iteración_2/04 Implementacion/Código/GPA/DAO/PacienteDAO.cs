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

        public static void insertarPaciente(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int edad, double altura, int peso, string nombre_usuario, string contraseña, DateTime fecha_creacion, int id_estado)
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

                string consultaInsertarPaciente = "INSERT INTO Paciente (id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,edad,altura,peso,id_domicilio_fk) VALUES (@paramId_tipoDoc_fk,@paramNro_documento,@paramNombre,@paramApellido,@paramTelefono,@paramNroCelular,@paramEmail,@paramId_usuario_fk,@paramId_estado_fk,@paramFecha_inicio_tratamiento,@paramEdad,@paramAltura,@paramPeso,@paramId_domicilio_fk)";

                SqlCommand cmdInsertarPaciente = new SqlCommand();
                cmdInsertarPaciente.Parameters.AddWithValue("@paramId_tipoDoc_fk", id_tipoDoc);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramNro_documento", nro_documento);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramNombre", nombre);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramApellido", apellido);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramTelefono", telefono);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramNroCelular", nroCelular);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramEmail", email);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramId_usuario_fk", id_usuario);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramId_estado_fk", id_estado);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramFecha_inicio_tratamiento", DateTime.Today.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmdInsertarPaciente.Parameters.AddWithValue("@paramEdad", edad);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramAltura", altura);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramPeso", peso);
                cmdInsertarPaciente.Parameters.AddWithValue("@paramId_domicilio_fk", id_domicilio);

                cmdInsertarPaciente.CommandText = consultaInsertarPaciente;
                cmdInsertarPaciente.CommandType = CommandType.Text;
                cmdInsertarPaciente.Connection = cn;
                cmdInsertarPaciente.Transaction = tran;

                cmdInsertarPaciente.ExecuteNonQuery();

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
                throw new Exception("Error al insertar paciente\nDetalles: " + ex.Message);
            }
        }
    }
}
