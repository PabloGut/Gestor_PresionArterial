﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class TipoAntecedenteMorbidoLN
    {
        public static List<TipoAntecedenteMorbido> mostrarTiposAntecedentesMorbidos()
        {
            return TipoAntecedenteMorbidoDAO.mostrarTiposAntecedentesMorbidos();
        }
        public static TipoAntecedenteMorbido MostrarNombrePorTipo(int TipoAntecedente)
        {
            return TipoAntecedenteMorbidoDAO.MostrarNombrePorTipo(TipoAntecedente);
        }
    }
   
}
