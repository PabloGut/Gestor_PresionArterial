using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class ElementoDeModificacionLN
    {
        public static List<ElementoDeModificacion> mostrarElementosDeModificacion()
        {
            return ElementoDeModificacionDAO.mostrarElementosDeModificacionesDelSintoma();
        }
        public static void InsertElementoModificacion(ElementoDeModificacion Elemento)
        {
            ElementoDeModificacionDAO.InsertElementoModificacion(Elemento);
        }
        public static void DeleteElementoModificacion(ElementoDeModificacion Elemento)
        {
            ElementoDeModificacionDAO.DeleteElementoModificacion(Elemento);
        }
        public static void UpdateElementoModificacion(ElementoDeModificacion Elemento)
        {
            ElementoDeModificacionDAO.UpdateElementoModificacion(Elemento);
        }
    }
}
