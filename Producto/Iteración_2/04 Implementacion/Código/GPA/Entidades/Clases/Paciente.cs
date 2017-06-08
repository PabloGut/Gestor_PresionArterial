using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Paciente :Persona
    {
        public Paciente(string nombre, string apellido,int id_tipoDoc,long nroDoc,int id_domicilio,long telefono,long nroCelular,string mail,int id_usuario,int id_estado, DateTime fechaNacimiento, int edad, int altura, int peso,int id_hc, int id_tipodoc_medico,long nrodoc_medico)
        : base(nombre,apellido,id_tipoDoc,nroDoc,id_domicilio,telefono,nroCelular,mail,id_usuario,id_estado, fechaNacimiento)
        {
            this.edad = edad;
            this.altura = altura;
            this.peso = peso;
            this.id_hc = id_hc;
            this.id_tipodoc_medico = id_tipodoc_medico;
            this.nrodoc_medico = nrodoc_medico;
            
        }
        public Paciente()
        : base()
        {

        }
        public DateTime fechaInicioTratamiento { get; set; }
        public int edad { get; set; }
        public int altura { get; set; }
        public int peso { get; set; }
        public int nrohc { get; set; }
        public int id_hc { get; set; }
        public int id_tipodoc_medico { get; set; }
        public long nrodoc_medico { get; set; }
        public ProfesionaMedico medico { get; set; }
        

    }
}
