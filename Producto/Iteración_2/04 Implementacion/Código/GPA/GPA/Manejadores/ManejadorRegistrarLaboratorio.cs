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
            return ItemEstudioLaboratorioLN.buscarIdItemEstudioLaboratorio(nombreEstudio);
        }
        public DetalleLaboratorio crearDetalleLaboratorio()
        {
            DetalleLaboratorio detalle = new DetalleLaboratorio();
            return detalle;
        }
        public DetalleLaboratorio crearDetalleLaboratorio(double valorResultado, int idUnidadMedida, DetalleResultadoEstudio detalleResultadoEstudio)
        {
            DetalleLaboratorio detalle = new DetalleLaboratorio();
            detalle.valorResultado = valorResultado;
            detalle.idUnidadMedida = idUnidadMedida;
            detalle.detalleResultadoEstudio = detalleResultadoEstudio;

            return detalle;
        }
        public ItemEstudioLaboratorio crearItemEstudioLaboratorio(int idItemLaboratorio)
        {
            ItemEstudioLaboratorio item = new ItemEstudioLaboratorio();
            item.id_itemLaboratorio = idItemLaboratorio;

            return item;
        }
        public DetalleResultadoEstudio crearDetalleResultadoEstudio()
        {
            DetalleResultadoEstudio item = new DetalleResultadoEstudio();

            return item;
        }
        public int obtenerIdAnalisisLaboratorio(string nombre)
        {
            //return AnalisisLaboratorioLN.obtenerAnalisisLaboratorio(nombre);
            return ItemEstudioLaboratorioLN.buscarIdItemEstudioLaboratorio(nombre);

        }
        public void insertResultadoEstudioLaboratorio(Laboratorio laboratorio)
        {
            try { 
            LaboratorioLN.insertResultadosEstudioLaboratorio(laboratorio);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
