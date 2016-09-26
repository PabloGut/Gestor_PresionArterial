using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarAlergias
    {
        public List<Alimento> mostrarAlimentos()
        {
            return AlimentoLN.mostrarAlimentos();
        }
        public List<SustaciaAmbiente> mostrarSustanciasDelAmbiente()
        {
            return SustanciaAmbienteLN.mostrarSustanciasDelAmbiente();
        }
        public List<SustanciaContactoPiel> mostrarSustanciasContactoPiel()
        {
            return SustanciaContactoPielLN.mostrarSustaciasContactoPiel();
        }
        public List<Insecto> mostrarInsectos()
        {
            return InsectoLN.mostrarInsectos();
        }

    }
}
