using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
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
            return ProfesionalMedicoDAO.mostrarPacientesDelMedicoLogueado(tipodocMedico, nroDocMedico);
        }
    }
}
