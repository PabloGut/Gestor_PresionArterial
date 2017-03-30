using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarHabitosDrogasIlicitas
    {
        public List<SustanciaDrogaIlicita> mostrarSustanciasDrogasIlicitas()
        {
            return SustanciaDrogaIlicitaLN.mostrarSustanciasDrogasIlicitas();
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public void registrarHabitoDrogasIlicitas(List<HabitoDrogasIlicitas> habitos, int idHc)
        {
            HabitoDrogasIlicitasLN.registrarHabitoDrogasIlicitas(habitos, idHc);
        }
    }
}
