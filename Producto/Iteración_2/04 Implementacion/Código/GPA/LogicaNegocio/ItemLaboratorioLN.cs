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
    public class ItemLaboratorioLN
    {
        public static List<ItemLaboratorio> obtenerItemLaboratorio()
        {
            return ItemLaboratorioDAO.obtenerItemLaboratorio();
        }
        public static List<ItemLaboratorio> buscarItemLaboratorio(string nombre)
        {
            return ItemLaboratorioDAO.buscarItemLaboratorio(nombre);
        }
        public static List<DetalleItemLaboratorio> obtenerDetalleItemLaboratorio(int idItemLaboratorio)
        {
            return DetalleItemLaboratorioDAO.obtenerIdDetalleItemLaboratorio(idItemLaboratorio);
        }
        public static int obtenerItemLaboratorio(string nombreItemLaboratorio)
        {
            return ItemEstudioLaboratorioDAO.buscarIdItemLaboratorio(nombreItemLaboratorio);
        }
    }
}
