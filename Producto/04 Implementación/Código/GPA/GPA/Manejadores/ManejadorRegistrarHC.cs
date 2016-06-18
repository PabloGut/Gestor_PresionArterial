using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarHC
    {
        public void buscarProfesionaMedico(ProfesionaMedico pm)
        {
             ProfesionalMedicoDAO.buscarMedicoLogueado(pm);
        }
        public int buscarNroHc()
        {
            return HistoriaClinicaDAO.buscarNroHC();
        }
        public int registrarNvaHC(HistoriaClinica hc)
        {
            return HistoriaClinicaDAO.insertarHC(hc);
        }
        public void asignarHCAPaciente(int tipoDoc, long nroDoc,int idhc)
        {
            PacienteDAO.AsignarHCPaciente(tipoDoc, nroDoc,idhc);
        }
    }
}
