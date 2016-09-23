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
    }
}
