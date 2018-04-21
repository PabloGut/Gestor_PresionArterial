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
    public class AnalisisLaboratorioLN
    {
        public static List<AnalisisLaboratorio> mostrarAnalisisLaboratorio()
        {
            return AnalisisLaboratorioDAO.mostrarAnalisisLaboratorio();
        }
        public static void registrarItemEstudioLaboratorio(ItemEstudioLaboratorio item)
        {
            ItemEstudioLaboratorioDAO.registrarItemEstudioLaboratorio(item);
        }
        public static int obtenerAnalisisLaboratorio(string nombreAnalisis)
        {
            return AnalisisLaboratorioDAO.obtenerLaboratorio(nombreAnalisis);
        }
    }
}
