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
    public class ManejadorRegistrarAntecedentesGinecoObstetricos
    {
        public List<TipoParto> mostrarTiposDeParto()
        {
            return TipoPartoLN.mostrarTiposDeParto();
        }
        public List<TipoAborto> mostrarTiposDeAbortos()
        {
            return TipoAbortoLN.mostrarTiposDeAbortos();
        }
        public void registrarAntecedentesGinecoObstetricos(AntecedenteGinecoObstetrico antecedente)
        {
            AntecedenteGinecoObstetricoLN.registrarAntecedenteGinecoObstetrico(antecedente);
        }

    }
}
