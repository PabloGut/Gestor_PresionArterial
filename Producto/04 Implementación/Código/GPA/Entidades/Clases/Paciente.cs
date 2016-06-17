using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Paciente :Persona
    {
        public Paciente(string nombre, string apellido,int id_tipoDoc,int nroDoc,int id_domicilio,long telefono,long nroCelular,string mail,int id_usuario,int id_estado)
        : base(nombre,apellido,id_tipoDoc,nroDoc,id_domicilio,telefono,nroCelular,mail,id_usuario,id_estado)
        {

        }
        public DateTime fechaInicioTratamiento { get; set; }
        public int edad { get; set; }
        public float altura { get; set; }
        public int peso { get; set; }

    }
}
