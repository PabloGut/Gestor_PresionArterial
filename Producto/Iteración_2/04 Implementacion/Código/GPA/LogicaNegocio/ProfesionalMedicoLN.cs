using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades.Clases;
namespace LogicaNegocio
{
    public class ProfesionalMedicoLN
    {
        /*
         * 
         * Método para buscar todos los pacientes de un médico.
         * Realiza una petición al método buscar paciente de la capa de datos.
         * Recibe como parámetros: tipo de documento, número de documento, nombre y apellido del paciente.
         * Retorna un DataTable.
         */
        public static DataTable mostrarPacientesDelMedico(int tipodocMedico, long nroDocMedico)
        {
            try
            {
                return ProfesionalMedicoDAO.mostrarPacientesDelMedicoLogueado(tipodocMedico, nroDocMedico);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void insertarProfesionalMédico(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, int id_sexo, DateTime fecha_nacimiento, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int id_especialidad, int matricula, string nombre_usuario, string contraseña, DateTime fecha_creacion, int id_estado)
        {
            ProfesionalMedicoDAO.insertarProfesionalMédico(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, id_sexo, fecha_nacimiento, calle, numero, piso, departamento, codigo_postal, id_barrio, id_especialidad, matricula, nombre_usuario, contraseña, fecha_creacion, id_estado);
        }
        public static ProfesionaMedico buscarProfesionalMedicoPorTipoNroDocumento(int tipoDoc, long nroDoc)
        {
            return ProfesionalMedicoDAO.buscarProfesionalMedicoPorTipoNroDocumento(tipoDoc, nroDoc);
        }
    }
}
