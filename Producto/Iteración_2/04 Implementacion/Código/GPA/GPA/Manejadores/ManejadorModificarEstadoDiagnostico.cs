using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorModificarEstadoDiagnostico
    {
        public List<EstadoDiagnostico> presentarEstadoDiagnostico()
        {
            return EstadoDiagnosticoLN.obtenerEstadosDiagnostico();
        }
        public List<EstudioDiagnosticoPorImagen> presentarEstudiosDiagnosticoPorImagen(int idRazonamiento)
        {
            return EstudioDiagnosticoPorImagenLN.obtenerEstudiosDiagnosticoPorImagen(idRazonamiento);
        }
        public List<RazonamientoDiagnostico> presentarDiagnosticos(int idHc)
        {
            return RazonamientoDiagnosticoLN.obtenerDiagnosticos(idHc);
        }
        public List<PracticaComplementaria> presentarPracticaComplementaria(int idRazonamiento)
        {
            return PracticaComplementariaLN.obtenerPracticasComplementarias(idRazonamiento);
        }
        public List<Laboratorio> presentarAnalisisLaboratorio(int idRazonamiento)
        {
            return LaboratorioLN.obtenerAnalisisLaboratorio(idRazonamiento);
        }
        public Laboratorio crearLaboratorio(int idLaboratorio,string nombreAnalisis, DateTime fechaSolicitud, string indicaciones)
        {
            AnalisisLaboratorio analisis = crearAnalisisLaboratorio(nombreAnalisis);
            Laboratorio laboratorio = new Laboratorio();
            laboratorio.analisis = analisis;
            laboratorio.fechaSolicitud = fechaSolicitud;
            laboratorio.indicaciones = indicaciones;
            laboratorio.id_laboratorio = idLaboratorio;
            return laboratorio;
            
        }
        public AnalisisLaboratorio crearAnalisisLaboratorio(string nombreAnalisis)
        {
            AnalisisLaboratorio analisis = new AnalisisLaboratorio();
            analisis.nombre = nombreAnalisis;
            return analisis;
        }
        public EstudioDiagnosticoPorImagen crearEstudio(NombreEstudio nombre, DateTime fechaSolicitud, string indicaciones, int idEstudio)
        {
            EstudioDiagnosticoPorImagen nuevoEstudio = new EstudioDiagnosticoPorImagen();
            nuevoEstudio.nombreEstudio = nombre;
            nuevoEstudio.fechaSolicitud = fechaSolicitud;
            nuevoEstudio.indicaciones = indicaciones;
            nuevoEstudio.id_estudioDiagnosticoPorImagen = idEstudio;

            return nuevoEstudio;
        }
        public NombreEstudio crearNombreEstudio(string nombre)
        {
            NombreEstudio nuevoNombre = new NombreEstudio();
            nuevoNombre.nombre = nombre;

            return nuevoNombre;
        }
        public PracticaComplementaria crearPracticaComplementaria(TipoPracticaComplementaria tipo, DateTime fechaSolicitud, string indicaciones, int idPractica, string observaciones)
        {
            PracticaComplementaria practica = new PracticaComplementaria();
            practica.tipo = tipo;
            practica.fechaSolicitud = fechaSolicitud;
            practica.indicaciones = indicaciones;
            practica.id_PracticaComplementaria = idPractica;
            practica.observaciones = observaciones;
            return practica;
        }
        public TipoPracticaComplementaria crearTipoPracticaComplementaria(string nombre)
        {
            TipoPracticaComplementaria tipo = new TipoPracticaComplementaria();
            tipo.nombre = nombre;

            return tipo;
        }
        public void updateRazonamientoDiagnostico(RazonamientoDiagnostico diagnostico)
        {
            RazonamientoDiagnosticoLN.updateRazonamientoDiagnostico(diagnostico);
        }
    }
}
