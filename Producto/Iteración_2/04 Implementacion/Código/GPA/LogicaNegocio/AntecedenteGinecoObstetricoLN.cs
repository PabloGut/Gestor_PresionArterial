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
        public static DataTable mostrarAntecedenteGinecoObtetrico(int idHc)
        {
            AntecedenteGinecoObstetrico antecedente = AntecedentesGinecoObstetricosDAO.obtenerAntecedenteGinecoObstetrico(idHc);
            DataTable dt = null;
            if (antecedente != null)
            {
                if (antecedente.cantidadEmbarazosPrematuros > 0 && antecedente.cantidadEmbarazosATermino > 0 && antecedente.cantidadEmbarazosPosTermino > 0)
                {
                    if (antecedente.id_aborto > 0)
                    {
                        dt=AntecedentesGinecoObstetricosDAO.mostrarAntecedenteGinecoObstetrico(idHc);
                    }
                    //Agregar código para los casos en que alguna cantidad sea cero y no tenga antecedentes de abortos.
                }
            }
            return dt;
        }
    }
}
