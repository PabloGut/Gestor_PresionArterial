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
        /*
         * Método para obtener todos los pacientes de un profesional médico.
         * Se pasan como parametros el tipo y número de documento del médico.
         * Llama al metodo mostrarPacientesDelProfesional() de la clase PacienteDAO.
         * El valor de retorno es un DataTable.
         */
        public static DataTable mostrarPacientesDelMedicoLogueado(int id_tipodoc_medico, long nroDocMedico)
        {
            return PacienteDAO.mostrarPacientesDelProfesional(id_tipodoc_medico, nroDocMedico);
        }
        /*
         * Método para buscar los datos de un profesional médico a través de tipo y número de documento.
         * Recibe como parámetros el tipoDoc y nroDoc correspondientes al profesional médico.
         * Retorna un objeto ProfesionalMedico.
         */
        public static ProfesionaMedico buscarProfesionalMedicoPorTipoNroDocumento(int tipoDoc, long nroDoc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            cn.Open();
            ProfesionaMedico medico = null;
            string consulta = "select nombre,apellido, matricula, id_especialidad_fk, nroCelular, email from ProfesionalMedico where id_tipodoc_fk=@idtipodoc and nro_documento=@nrodoc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idtipodoc", tipoDoc);
            cmd.Parameters.AddWithValue("@nrodoc", nroDoc);


            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                medico.nombre = dr["nombre"].ToString();
                medico.apellido = dr["apellido"].ToString();
                medico.matricula =(long) dr["matricula"];
                medico.id_especialidad = (int)dr["id_especialidad_fk"];
                medico.nroCelular = (long)dr["nroCelular"];
                medico.mail = dr["email"].ToString();
            }
            cn.Close();
            medico.especialidad = EspecialidadDAO.mostrarEspecialidad(medico.id_especialidad);
            return medico;


        }
    }
}
