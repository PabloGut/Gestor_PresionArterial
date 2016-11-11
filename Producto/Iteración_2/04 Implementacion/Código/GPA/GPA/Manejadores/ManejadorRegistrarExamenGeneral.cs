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
        public int registrarExamenGeneral(ExamenGeneral examen)
        {
            return ExamenGeneralLN.registrarExamenGeneral(examen);
        }
        public void registrarSistemaLinfatico(List<SistemaLinfatico> territoriosExaminados, int idExamenGeneral)
        {
            SistemaLinfaticoLN.registrarSistemaLinfatico(territoriosExaminados, idExamenGeneral);
        }
        public int registrarPulsoArterial(PulsoArterial pulsoArterial)
        {
            return PulsoArterialLN.registrarPulsoArterial(pulsoArterial);
        }
        public List<NombreEstudio> mostrarNombreEstudios()
        {
            return NombreEstudioLN.mostrarNombreEstudios();
        }
        public List<AnalisisLaboratorio> mostrarAnalisisLaboratorio()
        {
            return AnalisisLaboratorioLN.mostrarAnalisisLaboratorio();
        }
        public int mostrarIdEstadoHipotesis(string nombreEstado)
        {
            return EstadoHipotesisLN.mostrarIdEstadoHipotesis(nombreEstado);
        }
        public int registrarRazonamientoDiagnostico(RazonamientoDiagnostico razonamiento)
        {
            return RazonamientoDiagnosticoLN.registrarRazonamientoDiagnostico(razonamiento);
        }
    }
}
