using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace GPA.Manejadores
{
    public class ManejadorConsultarHC
    {
        public HistoriaClinica mostrarHistoriaClinica(Paciente paciente)
        {
            return HistoriaClinicaDAO.mostrarHistoriaClinica(paciente);
        }
        public List<Estudio> mostrarEstudiosDeHcLista(int id_hc)
        {
            return EstudioDAO.mostrarEstudiosDeHCLista(id_hc);

        }
        public DataSet mostrarEstudiosDeHcDS(int id_hc)
        {
            return EstudioDAO.mostrarEstudiosDeHCDS(id_hc);
        }
    }
}
