using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
namespace GPA.Manejadores
{
    public class ManejadorEstudiosLaboratorio
    {
        public ItemEstudioLaboratorio crearItemEstudioLaboratorio(string nombre)
        {
            ItemEstudioLaboratorio item = new ItemEstudioLaboratorio();
            item.nombre = nombre;

            return item;
        }
        public DetalleItemLaboratorio crearDetalleItemLaboratorio(string nombre, float valorDesde, float valorHasta, int unidadMedida)
        {
            DetalleItemLaboratorio detalle = new DetalleItemLaboratorio();
            detalle.nombre = nombre;
            detalle.valorDesde = valorDesde;
            detalle.valorHasta = valorHasta;
            detalle.id_unidadMedida = unidadMedida;

            return detalle;
        }
        public DetalleValorReferenciaLaboratorio crearDetalleValorReferencia(string descripcion, float valorDesde, float valorHasta, int unidadMedida)
        {
            DetalleValorReferenciaLaboratorio detalle = new DetalleValorReferenciaLaboratorio();
            detalle.descripcion = descripcion;
            detalle.valorDesde = valorDesde;
            detalle.valorHasta = valorHasta;
            detalle.idUnidadMedida = unidadMedida;

            return detalle;
        }
    }
}
