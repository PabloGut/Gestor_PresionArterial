using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class SustanciaAmbienteLN
    {
        public static List<SustaciaAmbiente> mostrarSustanciasDelAmbiente()
        {
            return SustanciaAmbienteDAO.mostrarSustanciasDelAmbiente();
        }
    }
}
