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
    public class ComponenteDelTiempoLN
    {
        public static List<ComponenteDelTiempo> mostrarComponentesDelTiempo()
        {
            return ComponeneteDelTiempoDAO.mostrarComponentesDelTiempo();
        }
    }
}
