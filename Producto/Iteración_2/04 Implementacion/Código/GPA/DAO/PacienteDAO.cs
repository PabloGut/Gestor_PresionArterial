﻿using System;
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
                cmdInsertarUsuario.Parameters.AddWithValue("@paramFecha_creacion", Convert.ToString(fecha_creacion));

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
                cmdInsertarPaciente.Parameters.AddWithValue("@paramFecha_inicio_tratamiento", Convert.ToString(DateTime.Today));
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
        /*
          * Método para obtener todos los pacientes de un profesional médico.
          * Se pasan como parametros el tipo y número de documento del médico.
          * Accede a la base de datos y accede a los datos requeridos.
          * El valor de retorno es Datatable.
          */
        public static DataTable mostrarPacientesDelProfesional(int tipoDocMedico, long nroDocMedico)
        {
            
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt;
            SqlDataAdapter da;
            try
            {
                cn.Open();

                string consulta = @"select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', e.nombre as 'Estado', s.nombre as'Sexo'
                                   from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, Estado e, Sexo s
                                   where p.id_profesionalMedico_tipoDoc_fk=@tipoDocMedico and p.id_profesionalMedico_nroDoc_fk=@nroDocMedico
                                   and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
                                   and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
                                   and p.id_estado_fk=e.id_estado and p.id_sexo_fk= s.id_sexo";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@tipoDocMedico", tipoDocMedico);
                cmd.Parameters.AddWithValue("@nroDocMedico", nroDocMedico);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
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
            return dt;
        }
        /*
         * Método para buscar los pacientes que cumplen con los parámetros ingresados.
         * Recibe como parámetros tipoDocMedico, nroDocMedico relacionados al ProfesionalMedico.
         * Recibe como parámetros tipoDocPaciente, nroDocPaciente y nombreYApellidoPaciente relacionados al Paciente que está siendo buscado.
         * Retorna un dataTable
         */
        public static DataTable mostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico,int tipoDocPaciente, long nroDocPaciente, string nombreYApellidoPaciente)
        {

            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt;
            SqlDataAdapter da;
            try
            {
                cn.Open();

                string consulta = @"select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', e.nombre as Estado, s.nombre as 'Sexo'
                                    from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es, Estado e, Sexo s
                                    where p.id_profesionalMedico_tipoDoc_fk=@tipoDocMedico and p.id_profesionalMedico_nroDoc_fk=@nroDocMedico
                                    and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
                                    and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
                                    and p.id_sexo_fk=s.id_sexo and p.id_estado_fk=e.id_estado
                                    and p.id_tipoDoc_fk=@tipoDocPaciente and p.nro_documento=@nroDocPaciente and p.nombre+' '+p.apellido like '%'+@nombreYApellidoPaciente+'%'";


                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@tipoDocMedico", tipoDocMedico);
                cmd.Parameters.AddWithValue("@nroDocMedico", nroDocMedico);
                cmd.Parameters.AddWithValue("@tipoDocPaciente", tipoDocPaciente);
                cmd.Parameters.AddWithValue("@nroDocPaciente", nroDocPaciente);
                cmd.Parameters.AddWithValue("@nombreYApellidoPaciente", nombreYApellidoPaciente);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
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
            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
           
        }
        /*
         * Método para obtener los datos de un Paciente.
         * Recibe como parámetro el tipo de documento, número de documento, nombre y apellido del paciente.
         * Retorna un objeto Paciente.
         */
        public static Paciente mostrarPacienteBuscado(int tipoDocPaciente, int nroDocPaciente, string nombreYApellido,int tipoDocMedico, int nroDocMedico)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Paciente paciente = null; 
            try
            {
                cn.Open();
                String consulta = @"select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', pm.nombre , pm.apellido, pm.matricula, pm.email, pm.nroCelular, es.nombre, e.nombre as Estado, s.nombre as 'Sexo'
                                    from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es, Estado e, Sexo s
                                    where p.id_profesionalMedico_tipoDoc_fk=@tipoDocMedico and p.id_profesionalMedico_nroDoc_fk=@nroDocMedico
                                    and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
                                    and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
                                    and p.id_profesionalMedico_tipoDoc_fk=pm.id_tipodoc_fk and p.id_profesionalMedico_nroDoc_fk=pm.nro_documento
                                    and pm.id_especialidad_fk= es.id_especialidad
                                    and p.id_sexo_fk=s.id_sexo and p.id_estado_fk=s.id_estado
                                    and p.id_tipoDoc_fk=@tipoDocPaciente and p.nro_documento=@nroDocPaciente and p.nombre+' '+p.apeillido like '@nombreYApellido%'";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    


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
            return paciente;
        }
    }
}
