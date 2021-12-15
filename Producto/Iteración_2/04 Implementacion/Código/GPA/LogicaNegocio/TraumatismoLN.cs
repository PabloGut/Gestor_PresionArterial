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
    public class TraumatismoLN
    {
        public static List<Traumatismo> mostrarTraumatismos(int id_tipoAntecedenteMorbido)
        {
            return TraumatismoDAO.mostrarTraumatismos(id_tipoAntecedenteMorbido);
        }
        public static void RegistrarTraumatismo(Traumatismo traumatismo)
        {
            TraumatismoDAO.RegistrarTraumatismo(traumatismo);
        }
        public static void ActualizarTraumatismo(Traumatismo traumatismo)
        {
            TraumatismoDAO.ActualizarTraumatismo(traumatismo);
        }

    }
}
