﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class TipoAbortoLN
    {
        public static List<TipoAborto> mostrarTiposDeAbortos()
        {
            return TipoAbortoDAO.mostrarTiposDeAbortos();
        }
    }
}
