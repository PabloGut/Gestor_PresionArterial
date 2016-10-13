using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarHabitosActividadFisica
    {
        public List<ActividadFisica> mostrarActividadFisica()
        {
            return ActividadFisicaLN.mostrarActividadFisica();
        }
        public List<GradoActividadFisica> mostrarGradosActividadFisica()
        {
            return GradoActividadFisicaLN.mostrarGradosActividadFisica();
        }
        public List<IntensidadActividadFisica> mostrarIntensidadActividadFisica()
        {
            return IntensidadActividadFisicaLN.mostrarIntensidadesActividadFisica();
        }
    }
}
