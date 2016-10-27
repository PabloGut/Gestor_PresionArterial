using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
namespace GPA.Manejadores
{
    public class ManejadorConsultarPaciente
    {
        private PacienteLN paciente;
        public ManejadorConsultarPaciente()
        {
           
        }
        /*
         * Método para buscar todos los pacientes de un médico.
         * Realiza una petición al método buscar paciente de la capa lógica de negocio.
         * Recibe como parámetros: tipo de documento, número de documento, nombre y apellido del paciente.
         * Retorna un DataTable.
         */
        public DataTable mostrarPacientesDeMedicoLogueado(int tipoDocMedico, long nroDocMedico)
        {
            
            return ProfesionalMedicoLN.mostrarPacientesDelMedico(tipoDocMedico,nroDocMedico);
        }
        /*
        * Método para buscar los pacientes que cumplen con los parámetros ingresados.
         * Llama al método mostrarPacienteBuscadoDelProfesional de la capa lógica de negocio.
        * Recibe como parámetros tipoDocMedico, nroDocMedico relacionados al ProfesionalMedico.
        * Recibe como parámetros tipoDocPaciente, nroDocPaciente y nombreYApellidoPaciente relacionados al Paciente que está siendo buscado.
        * Retorna un dataTable
        */
        public DataTable mostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente, string nombreYApellidoPaciente)
        {
            return PacienteLN.mostrarPacienteBuscadoDelProfesional(tipoDocMedico, nroDocMedico, tipoDocPaciente, nroDocPaciente, nombreYApellidoPaciente); 
        }
        /*
       * Método para buscar los pacientes que cumplen con los parámetros ingresados.
        * Llama al método mostrarPacienteBuscadoDelProfesional de la capa lógica de negocio.
       * Recibe como parámetros tipoDocMedico, nroDocMedico relacionados al ProfesionalMedico.
       * Recibe como parámetro nombreYApellidoPaciente relacionados al Paciente que está siendo buscado.
       * Retorna un dataTable
       */
        public DataTable mostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico, string nombreYApellidoPaciente)
        {
            return PacienteLN.mostrarPacienteBuscadoDelProfesional(tipoDocMedico, nroDocMedico, nombreYApellidoPaciente);
        }
        /*
         * Método para mostrar los tipos de documentos.
         * Llama al método mostrarTipoDocumento de la capa lógica de negocio.
         * No recibe parámetros.
         * Retorna una lista de objetos TipoDocumento.
         */
        public List<TipoDocumento> mostrarTiposDocumentos()
        {
            return TipoDocumentoLN.mostrarTipoDocumento();
        }
        /*
          * Método para mostrar un paciente.
           * Llama al método mostrarPacienteBuscado de la capa lógica de negocio.
          * Recibe como parámetros tipoDocMedico, nroDocMedico relacionados al ProfesionalMedico.
          * Recibe como parámetros tipoDocPaciente y nroDocPaciente relacionados al Paciente que se quiere mostrar.
          * Retorna un objeto Paciente.
        */
        public Paciente mostrarPacienteBuscado(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente)
        {
            return PacienteLN.mostrarPacienteBuscado(tipoDocMedico, nroDocMedico, tipoDocPaciente, nroDocPaciente);
        }
    }
}
