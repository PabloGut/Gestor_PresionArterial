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
        private MenuPrincipal pantalla;
        private List<ClasificacionPresionArterial> clasificaciones;
        public MedicionDePresionArterial medicion {get; set;}

        public void registrarExamenGeneral(MenuPrincipal mp)
        {
            pantalla = mp;
            medicion = new MedicionDePresionArterial();
            mostrarPresionArterial();
        }

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

        public void mostrarPresionArterial()
        {
            pantalla.presentarExamenGeneralPresionArterial(ExtremidadLN.mostrarExtremidades(), PosicionLN.mostrarPosiciones(), SitioMedicionLN.mostrarSitiosDeMedicion(), MomentoDiaLN.mostrarMomentosDelDia());
        }

        public void buscarClasificacionesDePresionArterial()
        {
            clasificaciones = ClasificacionPresionArterialLN.mostrarClasificacionesDePresionArterial();
        }

        public void mostrarUbicacionesDeExtremidad(int id_extremidad)
        {
            pantalla.presentarUbicacionesExtremidadDeExtremidad(UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(id_extremidad));
        }

        public void registrarMedicion(DateTime fecha, DateTime horaInicio, Posicion posicion, UbicacionExtremidad ubicacion, SitioMedicion sitio, MomentoDia momento)
        {
            medicion.posicion = posicion; medicion.fecha = fecha; medicion.horaInicio = horaInicio; medicion.ubicacion = ubicacion; medicion.sitio = sitio; medicion.momento = momento;
        }

        public void registrarDetalleDeMedicion(DateTime hora, int pulso, int valorMinimo, int valorMaximo)
        {
            DetalleMedicionPresionArterial detalle = new DetalleMedicionPresionArterial();
            detalle.id_nroMedicion = medicion.mediciones.Count + 1; detalle.hora = hora; detalle.pulso = pulso; detalle.valorMinimo = valorMinimo; detalle.valorMaximo = valorMaximo;
            medicion.mediciones.Add(detalle);
            calcularPromedioYClasificacionDePresionArterial();
        }

        public void calcularPromedioYClasificacionDePresionArterial()
        {
            medicion.promedio = MedicionDePresionArterialLN.calcularPromedio(medicion.mediciones);
            int promedioSistolica = MedicionDePresionArterialLN.calcularPromedioValorMinimo(medicion.mediciones);
            int promedioDiastolica = MedicionDePresionArterialLN.calcularPromedioValorMaximo(medicion.mediciones);
            bool clasificado = false;
            foreach (ClasificacionPresionArterial clasificacion in clasificaciones)
            {
                if (ClasificacionPresionArterialLN.esClasificacionPresionArterial(promedioSistolica, promedioDiastolica, clasificacion))
                {
                    medicion.clasificacion = clasificacion;
                    pantalla.presentarCalculosPresionArterial("Promedio: " + medicion.promedio + "mmHg", "Categoría: " + clasificacion.categoria, "Rango valor máximo: De " + clasificacion.maximaDesde + "mmHg a " + clasificacion.maximaHasta + "mmHg", "Rango valor mínimo: De " + clasificacion.minimaDesde + "mmHg a " + clasificacion.minimaHasta + "mmHg");
                    clasificado = true;
                }
            }
            if (clasificado == false)
            {
                medicion.clasificacion = null;
                pantalla.presentarCalculosPresionArterial("Promedio: " + medicion.promedio + "mmHg", "Categoría: Sin clasificación", "Rango valor máximo: -", "Rango valor mínimo: -");
            }
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
