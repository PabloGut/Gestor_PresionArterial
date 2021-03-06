﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
namespace LogicaNegocio
{
    public class TipoPracticaComplementariaLN
    {
        public static List<TipoPracticaComplementaria> mostrarPracticasComplementarias()
        {
            return TipoPracticaComplementariaDAO.mostrarPracticasComplementarias();
        }
        public static int mostrarTipoPracticaComplementaria(string nombre)
        {
            return TipoPracticaComplementariaDAO.mostrarPracticaComplementaria(nombre);
        }
    }
}
