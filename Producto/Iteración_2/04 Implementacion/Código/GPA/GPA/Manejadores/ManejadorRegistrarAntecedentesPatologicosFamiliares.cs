using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using LogicaNegocio;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarAntecedentesPatologicosFamiliares
    {
        public List<Familiar> mostrarFamiliares()
        {
            return FamiliarLN.mostrarFamiliares();
        }
       
    }
}
