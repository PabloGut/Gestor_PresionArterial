﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarEnfermedadActual
    {
        public List<ParteDelCuerpo> mostrarPartesDelCuerpoHumano()
        {
            return ParteDelCuerpoDAO.mostrarPartesDelCuerpoHumano();
        }
        public List<TipoSintoma> mostrarTiposSintomas()
        {
            return TipoSintomaLN.mostrarTiposSintomas();
        }
        public List<CaracterDelDolor> mostrarCaracterDelDolor()
        {
            return CaracterDelDolorLN.mostrarCaracterDelDolor();
        }
    }
}
