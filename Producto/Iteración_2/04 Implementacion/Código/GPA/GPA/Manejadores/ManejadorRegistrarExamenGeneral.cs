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
    public class ManejadorRegistrarExamenGeneral
    {
        public List<Ubicacion> mostrarUbicaciones()
        {
            return UbicacionLN.mostrarUbicaciones();
        }
        public List<Tamaño> mostrarTamañoGanglio()
        {
            return TamañoLN.mostrarTamañosGanglios();
        }
        public List<EscalaPulso> mostrarEscalaPulso()
        {
            return EscalaPulsoLN.mostrarEscalaPulso();
        }
        public List<Pulso> mostrarPulsos()
        {
            return PulsoLN.mostrarPulsos();
        }
        public List<Consistencia> mostrarConsistencia()
        {
            return ConsistenciaLN.mostrarConsistencia();
        }
    }
}
