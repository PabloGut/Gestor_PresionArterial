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
    public class ManejadorRegistrarHabitosTabaquismo
    {
        public List<ElementoQueFuma> mostrarNombreElementoQueFuma()
        {
            return ElementoQueFumaLN.mostrarNombreElementoQueFuma();
        }
        public List<ComponenteDelTiempo> mostrarComponentesDelTiempo()
        {
            return ComponenteDelTiempoLN.mostrarComponentesDelTiempo();
        }
        public List<DescripcionDelTiempo> mostrarDescripcionesDelTiempo()
        {
            return DescripcionDelTiempoLN.mostrarDescripcionesDelTiempo();
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public void registrarHabitosTabaquismo(List<HabitoTabaquismo> habitos, int idHc)
        {
            HabitoTabaquismoLN.registrasHabitosTabaquismo(habitos, idHc);
        }
    }
}
