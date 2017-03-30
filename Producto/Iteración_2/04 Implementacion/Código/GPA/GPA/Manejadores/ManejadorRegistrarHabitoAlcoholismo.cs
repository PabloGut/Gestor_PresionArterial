using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarHabitoAlcoholismo
    {
        public List<TipoBebida> mostrarTiposDeBebidas()
        {
            return TipoBebidaLN.mostrarTiposDeBebidas();
        }
        public List<ComponenteDelTiempo> mostrarComponentesDelTiempo()
        {
            return ComponenteDelTiempoLN.mostrarComponentesDelTiempo();
        }
        public List<Medida> mostrarMedidasBebidasAlcoholicas()
        {
            return MedidaLN.mostrarMedidasDeBebidasAlcoholicas();
        }
        public void registrarHabitosAlcoholismo(List<HabitoAlcoholismo> habitos, int idHc)
        {
            HabitoAlcoholismoLN.registrasHabitosAlcoholismo(habitos, idHc);
        }
    }
}
