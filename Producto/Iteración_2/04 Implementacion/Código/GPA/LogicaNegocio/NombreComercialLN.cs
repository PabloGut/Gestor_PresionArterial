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
    public class NombreComercialLN
    {
        public static void registrarNombreComercial(NombreComercial nombreComercial)
        {
            NombreComercialDAO.registrarNombreComercialDeMedicamento(nombreComercial);
        }
        public static Boolean existeNombreComercial(string nombreComercial)
        {
            return NombreComercialDAO.existeNombreComercial(nombreComercial);
        }
        public static int idNombreComercial(string nombre)
        {
            return NombreComercialDAO.idNombreComercial(nombre);
        }
        public static List<NombreComercial> mostrarNombresComercialesDeMedicamento(int idMedicamento)
        {
            return NombreComercialDAO.mostrarNombresComercialesDeMedicamento(idMedicamento);
        }

    }
}
