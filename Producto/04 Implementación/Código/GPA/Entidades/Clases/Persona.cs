using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Persona
    {
        public Persona(string nombre, string apellido,int id_tipoDoc,long nroDoc,int id_domicilio,long telefono,long nroCelular,string mail,int id_usuario,int id_estado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id_tipoDoc = id_tipoDoc;
            this.nroDoc = nroDoc;
            this.id_domicilio = id_domicilio;
            this.telefono = telefono;
            this.nroCelular = nroCelular;
            this.mail = mail;
            this.id_usuario = id_usuario;
            this.id_estado = id_estado;
        }
        public Persona(string nombre, string apellido, int id_tipoDoc, long nroDoc)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.id_tipoDoc = id_tipoDoc;
            this.nroDoc = nroDoc;         
        }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int id_tipoDoc { get; set; }
        public long nroDoc { get; set; }
        public int id_domicilio { get; set; }
        public long telefono { get; set; }
        public long nroCelular { get; set; }
        public string mail { get; set; }
        public int id_usuario { get; set; }
        public int id_estado { get; set; }



    }
}
