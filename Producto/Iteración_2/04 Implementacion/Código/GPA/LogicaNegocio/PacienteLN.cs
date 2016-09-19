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
        public static DataTable mostrarPacienteBuscadoDelProfesional(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente, string nombreYApellidoPaciente)
        {
            return PacienteDAO.mostrarPacienteBuscadoDelProfesional(tipoDocMedico, nroDocMedico, tipoDocPaciente, nroDocPaciente, nombreYApellidoPaciente);
        }
        public static Paciente mostrarPacienteBuscado(int tipoDocMedico, long nroDocMedico, int tipoDocPaciente, long nroDocPaciente)
        {
            return PacienteDAO.mostrarPacienteBuscado(tipoDocMedico,nroDocMedico,tipoDocPaciente,nroDocPaciente);
        }
        public static Boolean existeHC(int tipoDoc, long nroDoc)
        {
            return PacienteDAO.ExisteHC(tipoDoc, nroDoc);
        }
    }
}
