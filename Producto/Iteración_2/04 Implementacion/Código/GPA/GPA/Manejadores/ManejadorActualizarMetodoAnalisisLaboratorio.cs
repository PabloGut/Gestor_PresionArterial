using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
namespace GPA.Manejadores
{
    public class ManejadorActualizarMetodoAnalisisLaboratorio
    {
        public List<MetodoAnalisisLaboratorio> obtenerMetodosAnalisisLaboratorio()
        {
            return MetodoAnalisisLaboratorioLN.obtenerMetodosAnalisisLaboratorio();
        }
        public MetodoAnalisisLaboratorio obtenerMetodoAnalisisLaboratorio(int id)
        {
            return MetodoAnalisisLaboratorioLN.obtenerMetodoAnalisisLaboratorio(id);
        }
        public void insertMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioLN.insertMentodoAnalisisLaboratorio(metodo);
        }
        public void updateMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioLN.updateMetodoAnalisisLaboratorio(metodo);
        }
        public void deleteMetodoAnalisisLaboratorio(MetodoAnalisisLaboratorio metodo)
        {
            MetodoAnalisisLaboratorioLN.deleteMetodoAnalisisLaboratorio(metodo);
        }
    }
}
