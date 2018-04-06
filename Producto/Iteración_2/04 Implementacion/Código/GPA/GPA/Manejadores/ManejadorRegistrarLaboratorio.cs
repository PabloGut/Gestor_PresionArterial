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
        public int obteneridItemEstudioLaboratorio(string nombreEstudio)
        {
            return ItemEstudioLaboratorioLN.obtenerIdItemEstudioLaboratorio(nombreEstudio);
        }
        public void updateLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioLN.updateLaboratorio(laboratorio);
        }
        public DetalleLaboratorio crearDetalleLaboratorio(double valorResultado,int idUnidadMedida,ItemEstudioLaboratorio itemEstudioLaboratorio)
        {
            DetalleLaboratorio detalle = new DetalleLaboratorio();
            detalle.valorResultado = valorResultado;
            detalle.idUnidadMedida = idUnidadMedida;
            detalle.itemEstudioLaboratorio = itemEstudioLaboratorio;

            return detalle;
        }
        public ItemEstudioLaboratorio crearItemEstudioLaboratorio(int idItemLaboratorio)
        {
            ItemEstudioLaboratorio item = new ItemEstudioLaboratorio();
            item.id_itemLaboratorio = idItemLaboratorio;

            return item;
        }
    }
}
