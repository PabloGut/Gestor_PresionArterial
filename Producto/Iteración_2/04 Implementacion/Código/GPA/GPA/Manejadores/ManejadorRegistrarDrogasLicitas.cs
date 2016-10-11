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
    public class ManejadorRegistrarDrogasLicitas
    {
        public List<Medicamento> mostrarNombresMedicamento()
        {
            return MedicamentoLN.mostrarNombreMedicamentos();
        }
        public List<NombreComercial> mostrarNombresComercialDeMedicamento(int idMedicamento)
        {
            return NombreComercialLN.mostrarNombresComercialesDeMedicamento(idMedicamento);
        }
    }
}
