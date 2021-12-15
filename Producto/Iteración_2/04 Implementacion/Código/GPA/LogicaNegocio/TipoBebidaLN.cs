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
    public class TipoBebidaLN
    {
        public static List<TipoBebida> mostrarTiposDeBebidas()
        {
            return TipoBebidaDAO.mostrarTiposDeBebidas();
        }
        public static void RegistrarTipoBebida(TipoBebida Tipo)
        {
            try
            {
                TipoBebidaDAO.RegistrarTipoBebida(Tipo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void ActualizarTipoBebida(TipoBebida Tipo)
        {
            try
            {
                TipoBebidaDAO.ActualizarTipoBebida(Tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
