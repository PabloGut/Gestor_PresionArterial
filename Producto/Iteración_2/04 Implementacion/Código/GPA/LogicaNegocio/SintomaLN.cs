using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace LogicaNegocio
{
    public class SintomaLN
    {
        public static void registrarSintomas(List<Sintoma> sintomas, int idHc)
        {
            SintomaDAO.registrarSintomas(sintomas, idHc);
        }
        public static void registrarSintomasDeConsulta(List<Sintoma> sintomas, int idConsulta)
        {
            SintomaDAO.registrarSintomasDeConsulta(sintomas, idConsulta);
        }
    }
}
