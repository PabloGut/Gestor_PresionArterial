using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
namespace LogicaNegocio
{
    public class PacienteLN
    {
        public static List<Paciente> buscarPaciente(int id_tipoDoc, long nroDocumento)
        {
            return PacienteDAO.buscarPaciente(id_tipoDoc, nroDocumento);
        }
        public static void AsignarHCPaciente(int id_tipoDoc, long nroDocumento, int idhc)
        {
            PacienteDAO.AsignarHCPaciente(id_tipoDoc, nroDocumento, idhc);
        }
        public static void insertarPaciente(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, int id_sexo, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, DateTime fecha_nacimiento, int edad, double altura, int peso, ProfesionaMedico medico, string nombre_usuario, string contraseña, DateTime fecha_creacion, int id_estado)
        {
            PacienteDAO.insertarPaciente(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, id_sexo, calle, numero, piso, departamento, codigo_postal, id_barrio, fecha_nacimiento, edad, altura, peso, medico, nombre_usuario, contraseña, fecha_creacion, id_estado);
        }
        public static DataTable mostrarPacientesDelProfesional(int tipoDocMedico, long nroDocMedico)
        {
            return PacienteDAO.mostrarPacientesDelProfesional(tipoDocMedico, nroDocMedico);
        }
        public static DataTable MostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente, string nombreYApellidoPaciente)
        {
            try
            {
                return PacienteDAO.MostrarPacienteBuscadoDelProfesional(tipoDocMedico, nroDocMedico, tipoDocPaciente, nroDocPaciente, nombreYApellidoPaciente);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable MostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico, string nombreYApellidoPaciente)
        {
            try
            {
                return PacienteDAO.mostrarPacienteBuscadoDelProfesional(tipoDocMedico, nroDocMedico, nombreYApellidoPaciente);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Paciente mostrarPacienteBuscado(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente)
        {
            return PacienteDAO.mostrarPacienteBuscado(tipoDocMedico,nroDocMedico,tipoDocPaciente,nroDocPaciente);
        }
        public static Paciente mostrarPacienteBuscado(int idHc)
        {
            try
            {
                return PacienteDAO.mostrarPacienteBuscado(idHc);
            }
            catch(Exception e)
            {
                throw e;
            }

           
        }
        public static Boolean existeHC(int tipoDoc, long nroDoc)
        {
            return PacienteDAO.ExisteHC(tipoDoc, nroDoc);
        }
        public static Paciente buscarUnPaciente(int idUsuarioPaciente)
        {
            return PacienteDAO.buscarUnPaciente(idUsuarioPaciente);
        }
        public static DataSet MostrarPacienteReporteHistoriaClinica(int idHc, DataSet ds)
        {
            return PacienteDAO.MostrarPacienteReporteHistoriaClinica(idHc,ds);
        }
    }
}
