using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarAtencionMedicaEnConsultorio
    {
        private MenuPrincipal pantalla;

        public void registrarAtencionMedicaEnConsultorio(MenuPrincipal mp)
        {
            pantalla = mp;
        }

        public void registrarSintomas(List<Sintoma> sintomas, int idConsulta)
        {
            SintomaLN.registrarSintomasDeConsulta(sintomas, idConsulta);
        }
        public string mostrarFechaActual()
        {
            return ConsultaLN.mostrarFechaActual();
        }
        public string mostrarHoraActual()
        {
            return ConsultaLN.mostrarHoraActual();
        }
        public int calcularNroConsulta(int idHc)
        {
            return ConsultaLN.calcularSiguinteNroConsulta(idHc);
        }
        public void registrarConsultaYExamenGeneral(Consulta consulta)
        {
            ConsultaLN.registrarConsultaYExamenGeneral(consulta);
        }
    }
}
