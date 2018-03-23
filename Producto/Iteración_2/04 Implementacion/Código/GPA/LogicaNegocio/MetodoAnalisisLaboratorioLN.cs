using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class MetodoAnalisisLaboratorioLN
    {
        public static List<MetodoAnalisisLaboratorio> obtenerMetodosAnalisisLaboratorio()
        {
            return MetodoAnalisisLaboratorioDAO.obtenerMetodosAnalisisLaboratorio();
        }
        public static MetodoAnalisisLaboratorio obtenerMetodoAnalisisLaboratorio(int id)
        {
            return MetodoAnalisisLaboratorioDAO.obtenerMetodoAnalisisLaboratorio(id);
        }
        public static void insertMentodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioDAO.insertMetodosAnalisisLaboratorio(metodo);
        }
        public static void updateMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioDAO.updateMetodosAnalisisLaboratorio(metodo);
        }
        public static void deleteMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioDAO.deleteMetodoAnalisisLaboratorio(metodo);
        }
    }
}
