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
    public class ManejadorRegistrarEstudiosPracticas
    {
        public EstudioDiagnosticoPorImagen crearEstudio(NombreEstudio nombre, DateTime fechaRealizacion, string doctor, string informe, string obsevaciones)
        {
            EstudioDiagnosticoPorImagen estudio = new EstudioDiagnosticoPorImagen();
            estudio.nombreEstudio = nombre;
            estudio.fechaRealizacion = fechaRealizacion;
            estudio.DoctorACargo = doctor;
            estudio.informeEstudio= informe;
            estudio.observaciones = obsevaciones;

            return estudio;
        }
        public NombreEstudio crearNombreEstudio(string nombre)
        {
            NombreEstudio nombreEstudio = new NombreEstudio();
            nombreEstudio.nombre = nombre;
            return nombreEstudio;
        }
        public int obtenerNombreEstudio(string nombre)
        {
            return NombreEstudioLN.obtenerNombreEstudio(nombre);
        }
        public int obtenerTipoPracticaComplementaria(string nombre)
        {
            return TipoPracticaComplementariaLN.mostrarTipoPracticaComplementaria(nombre);
        }
    }
}
