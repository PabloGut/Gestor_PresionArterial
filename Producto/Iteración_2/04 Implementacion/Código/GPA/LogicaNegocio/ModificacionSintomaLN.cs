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
    public class ModificacionSintomaLN
    {
        public static List<ModificacionSintoma> mostrarModificacionesDelSintoma()
        {
            return ModificacionSintomaDAO.mostrarModificacionesDelSintoma();
        }
        public static void InsertModificacionSintoma(ModificacionSintoma Modificacion)
        {
            ModificacionSintomaDAO.InsertModificacionSintoma(Modificacion);
        }
        public static void DeleteMoficicacionSintoma(ModificacionSintoma Modificacion)
        {
            ModificacionSintomaDAO.DeleteModificacionSintoma(Modificacion);
        }
        public static void UpdateModificacionSintoma(ModificacionSintoma Modificacion)
        {
            ModificacionSintomaDAO.UpdateModificacionSintoma(Modificacion);
        }

    }
}
