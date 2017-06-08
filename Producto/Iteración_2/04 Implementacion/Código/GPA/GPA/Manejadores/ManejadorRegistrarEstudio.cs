using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace GPA
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
        public List<Entidades.Clases.Domicilio> obtenerDomicilioInstitucion(int id_institucion)
        {
            List<Entidades.Clases.Domicilio> domicilio = DAO.InstitucionDAO.buscarDomicilioInstitucion(id_institucion);
            return domicilio;
        }
        public List<Barrio> buscarBarrios()
        {
            List<Barrio> barrios = BarrioDAO.buscarBarrios();
            return barrios;
        }
        public List<Localidad> buscarLocalidades()
        {
            List<Localidad> localidades = LocalidadDAO.buscarLocalidades();
            return localidades;
        }
        public void registrarEstudio(Estudio estudio)
        {
            EstudioDAO.insertarEstudio(estudio);
        }
       
    }


}
