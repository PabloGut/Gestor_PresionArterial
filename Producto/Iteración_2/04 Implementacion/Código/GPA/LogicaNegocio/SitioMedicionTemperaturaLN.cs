using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class SitioMedicionTemperaturaLN
    {
        public static List<SitioMedicionTemperatura> mostrarSitioMedicionTemperatura()
        {
            return SitioMedicionTemperaturaDAO.mostrarSitioMedicionTemperatura();
        }
    }
}
