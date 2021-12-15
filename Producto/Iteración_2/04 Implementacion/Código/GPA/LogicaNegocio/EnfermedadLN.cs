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
    public class EnfermedadLN
    {
        public static  List<Enfermedad> mostrarEnfermedades(int id_tipoAntecedenteMorbido)
        {
            return EnfermedadesDAO.mostrarEnfermedades(id_tipoAntecedenteMorbido);
        }
        public static void RegistrarEnfermedad(Enfermedad enfermedad)
        {
            EnfermedadesDAO.RegistrarEnfermedad(enfermedad);
        }
        public static void ActualizarEnfermedad(Enfermedad enfermedad)
        {
            EnfermedadesDAO.ActualizarEnfermedad(enfermedad);
        }
    }
}
