using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarAntecedentesPatologicosPersonales
    {
        public void registrarAntecedentesPatologicosPersonales(DateTime fechaRegistro, List<String> enfermedades, string descOtrasEnfermedades, int idhc)
        {
            AntecedentePatologicoPersonal antecendente = new AntecedentePatologicoPersonal();

            antecendente.fechaRegistro = fechaRegistro;
            antecendente.enfermedades = crearCadena(enfermedades);
            antecendente.otrasEnfermedades = descOtrasEnfermedades;
            antecendente.idhc = idhc;

            AntecedentePatologicoPersonalLN.registrarAntecedentePatologicoPersonal(antecendente);

        }
        public string crearCadena(List<String> enfermedades)
        {
            string listaEnfermedades = "";

            if (enfermedades.Count > 1)
            {
                foreach (string nombreenfermedad in enfermedades)
                {
                    listaEnfermedades += nombreenfermedad;

                    listaEnfermedades += ", ";
                }
            }
            else
            {
                foreach (string nombreenfermedad in enfermedades)
                {
                    listaEnfermedades += nombreenfermedad;
                }
            }
            return listaEnfermedades;
        }
    }
}
