﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarMedicionPresionArterial
    {
        public void registrarMedicioPresionArterialEnHistoriaClinica(MedicionDePresionArterial medicion)
        {
            try
            {
                MedicionDePresionArterialLN.RegistrarMedicionPresionArterialEnHistoriaClinicia(medicion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
