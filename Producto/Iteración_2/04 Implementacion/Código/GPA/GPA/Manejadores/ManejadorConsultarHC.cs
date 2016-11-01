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
    public class ManejadorConsultarHC
    {
        public DataSet mostrarHistoriaClinica(Paciente paciente)
        {
            return HistoriaClinicaLN.mostrarHistoriaClinica(paciente);
        }
    }
}
