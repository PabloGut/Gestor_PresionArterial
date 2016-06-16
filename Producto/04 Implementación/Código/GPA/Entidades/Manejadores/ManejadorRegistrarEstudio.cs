using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Manejadores
{
   

    public class ManejadorRegistrarEstudio
    {
        private string nombreEstudio;
        private DateTime fechaEstudio;
        private string doctorACargo;
        private string informe;
        private string institucion;

        public ManejadorRegistrarEstudio()
        { }

        public void nombreEstudioIngresado(String nombre)
        {
            nombreEstudio = nombre;
        }
        public void fechaEstudioIngresado(DateTime fechaEstudio)
        {
            this.fechaEstudio = fechaEstudio;
        }
        public void doctorACargoIngresado(string doctorACargo)
        {
            this.doctorACargo = doctorACargo;
        }
        public void InformeIngresado(string informe)
        {
            this.informe = informe;
        }
        public void InstitucionSeleccionada(string institucion)
        {
            this.institucion = institucion;
        }
        public void buscarInstitucion(int id_institucion)
        {
 
        }
    }


}
