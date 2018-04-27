using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class TipoSintomaLN
    {
        public static List<TipoSintoma> mostrarTiposSintomas()
        {
            return TipoSintomaDAO.mostrarTiposSintomas();
        }
        public static List<TipoSintoma> presentarTipoSintoma()
        {
            return TipoSintomaDAO.presentarTiposSintomas();
        }
        public static void insertTipoSintoma(TipoSintoma tipoSintoma)
        {
            TipoSintomaDAO.insertTipoSintoma(tipoSintoma);
        }
        public static void updateTipoSintoma(TipoSintoma tipoSintoma)
        {
            TipoSintomaDAO.updateTipoSintoma(tipoSintoma);
        }
        public static void deleteTipoSintoma(TipoSintoma tipoSintoma)
        {
            TipoSintomaDAO.deleteTipoSintoma(tipoSintoma);
        }
    }
}
