using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ProfesionaMedico :Persona
    {
         public ProfesionaMedico(string nombre, string apellido,int id_tipoDoc,int nroDoc,int id_domicilio,long telefono,long nroCelular,string mail,int id_usuario,int id_estado, DateTime fechaNacimiento)
        : base(nombre,apellido,id_tipoDoc,nroDoc,id_domicilio,telefono,nroCelular,mail,id_usuario,id_estado,fechaNacimiento)
        {

        }
         public long matricula { get; set; }
         public int id_especialidad { get; set; }
         public Especialidad especialidad { get; set; }

         public ProfesionaMedico(string nombre, string apellido, int id_tipoDoc, long nroDoc)
             : base(nombre,apellido,id_tipoDoc,nroDoc)
         {

         }
         public ProfesionaMedico(int id_tipoDoc, long nroDoc)
             : base(id_tipoDoc, nroDoc)
         {

         }
         public ProfesionaMedico(string nombre, string apellido)
             : base(nombre, apellido)
         {

         }
    }
   
}
