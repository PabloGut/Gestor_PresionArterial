﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class EvolucionDiagnosticoLN
    {
        public static void insertEvolucionDiagnostico(EvolucionDiagnostico evolucionDiagnostico)
        {
            EvolucionDiagnosticoDAO.registrarEvolucionDiagnostico(evolucionDiagnostico);
        }
    }
}
