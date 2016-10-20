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
    public class AntecedenteGinecoObstetricoLN
    {
        public static void registrarAntecedenteGinecoObstetrico(AntecedenteGinecoObstetrico antecedente)
        {
            AntecedentesGinecoObstetricosDAO.registrarAntecedentesGinecoObstetricos(antecedente);
        }
    }
}
