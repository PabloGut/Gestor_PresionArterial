﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AnalisisLaboratorio
    {
        
        public int id_analisis { set; get; }
        public string nombre { set; get; }
        public string descripcion { set; get; }
        public int id_metodo { set; get; }
        public float valorResultado { set; get; }
        public int id_unidadMedida { set; get; }
        public int id_itemsEstudioLaboratorioa { set; get; }

    }
}
