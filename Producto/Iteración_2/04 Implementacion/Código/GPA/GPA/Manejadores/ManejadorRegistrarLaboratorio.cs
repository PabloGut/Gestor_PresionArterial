using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarLaboratorio
    {
        public List<MetodoAnalisisLaboratorio> obtenerMetodosAnalisisLaboratorio()
        {
            return MetodoAnalisisLaboratorioLN.obtenerMetodosAnalisisLaboratorio();
        }
        public List<ItemLaboratorio> obtenerItemLaboratorio()
        {
            return ItemLaboratorioLN.obtenerItemLaboratorio();
        }
        public List<ItemLaboratorio> buscarItemLaboratorio(string nombre)
        {
            return ItemLaboratorioLN.buscarItemLaboratorio(nombre);
        }
        public List<UnidadDeMedida> obtenerUnidadesDeMedida()
        {
            return UnidadMedidaLN.mostrarUnidadesDeMedida();
        }
    }
}
