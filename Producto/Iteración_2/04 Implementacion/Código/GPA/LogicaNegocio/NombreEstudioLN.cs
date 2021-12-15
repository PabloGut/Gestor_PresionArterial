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
    public class NombreEstudioLN
    {
        public static List<NombreEstudio> MostrarNombreEstudios()
        {
            try
            {
                return NombreEstudioDAO.MostrarNombreEstudio();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static int obtenerNombreEstudio(string nombre)
        {
            return NombreEstudioDAO.obtenerIdNombreEstudio(nombre);
        }
    }
}
