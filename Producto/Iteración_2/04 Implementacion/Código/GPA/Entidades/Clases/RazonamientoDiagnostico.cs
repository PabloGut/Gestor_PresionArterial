﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class RazonamientoDiagnostico
    {
        public int id_razonamiento { set; get; }
        public string conceptoInicial { set; get; }
        public string diagnostico { set; get; }
        public int id_estadoDiagnostico { set; get; }
        public EstadoDiagnostico estado { set; get; }
        public string motivoDescartado { set; get; }
        public DateTime fechaDescartado { set; get; }
        public string motivoConfirmado { set; get; }
        public DateTime fechaConfirmado { set; get; }
        public DateTime fechaTentativo { set; get; }
        public string motivoTentativo { set; get; }
        public int id_examenGeneral { set; get; }
        public List<Laboratorio> analisis { set; get; }
        public List<EstudioDiagnosticoPorImagen> estudios { set; get; }
        public List<PracticaComplementaria> practicas { set; get; }
        public List<Tratamiento> tratamientos { set; get; }

        public List<Tratamiento> tratamientosACancelar { set; get; }




    }
}
