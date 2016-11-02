using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
using System.Data.SqlClient;

namespace GPA.Manejadores
{
    public class ManejadorConsultarHC
    {
        public HistoriaClinica mostrarHistoriaClinica(Paciente paciente)
        {
            return HistoriaClinicaLN.mostrarHistoriaClinica(paciente);
        }
        public DataTable mostrarAntecedentesMorbidosEnfermedades(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosEnfermedades(idHc);
        }
        public DataTable mostrarAntecedentesMorbidosOperaciones(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosOperaciones(idHc);
        }
        public DataTable mostrarAntecedentesMorbidosTraumatismos(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosTraumatismos(idHc);
        }

    }
}
