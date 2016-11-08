using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarAtencionMedicaEnConsultorio
    {
        private MenuPrincipal pantalla;
        List<ClasificacionPresionArterial> clasificaciones;
        MedicionDePresionArterial medicion;
        
        public void registrarAtencionMedicaEnConsultorio(MenuPrincipal mp){
            pantalla=mp;
            medicion = new MedicionDePresionArterial();
            mostrarTiposDeDatos();
        }

        public void mostrarTiposDeDatos()
        {
            pantalla.presentarAtencionEnConsultorio(ExtremidadLN.mostrarExtremidades(), PosicionLN.mostrarPosiciones(), SitioMedicionLN.mostrarSitiosDeMedicion(), MomentoDiaLN.mostrarMomentosDelDia());
        }
        
        public void registrarSintomas(List<Sintoma> sintomas, int idConsulta)
        {
            SintomaLN.registrarSintomasDeConsulta(sintomas, idConsulta);
        }

        public void mostrarUbicacionesDeExtremidad(int id_extremidad)
        {
            pantalla.presentarUbicacionesExtremidadDeExtremidad(UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(id_extremidad));
        }

        public void buscarClasificacionesDePresionArterial()
        {
            clasificaciones = ClasificacionPresionArterialLN.mostrarClasificacionesDePresionArterial();
        }

        public void registrarMedicion(DateTime fecha, DateTime horaInicio, Posicion posicion, UbicacionExtremidad ubicacion, SitioMedicion sitio, MomentoDia momento)
        {
            medicion.posicion = posicion; medicion.fecha = fecha; medicion.horaInicio = horaInicio; medicion.ubicacion = ubicacion; medicion.sitio = sitio; medicion.momento = momento;
        }

        public void registrarDetalleDeMedicion(DetalleMedicionPresionArterial detalle)
        {
            detalle.id_nroMedicion = medicion.mediciones.Count+1;
            medicion.mediciones.Add(detalle);
            calcularPromedioYClasificacionDePresionArterial();
        }

        public void calcularPromedioYClasificacionDePresionArterial()
        {
            medicion.promedio = MedicionDePresionArterialLN.calcularPromedio(medicion.mediciones);
            int promedioSistolica=MedicionDePresionArterialLN.calcularPromedioValorMinimo(medicion.mediciones);
            int promedioDiastolica=MedicionDePresionArterialLN.calcularPromedioValorMaximo(medicion.mediciones);
            bool clasificado = false;
            foreach(ClasificacionPresionArterial clasificacion in clasificaciones)
            {
                if(ClasificacionPresionArterialLN.esClasificacionPresionArterial(promedioSistolica,promedioDiastolica, clasificacion))
                {
                    medicion.clasificacion = clasificacion;
                    pantalla.presentarCalculosPresionArterial("Promedio: " + medicion.promedio + "mmHg", "Categoría: " + clasificacion.categoria, "Rango valor máximo: De " + clasificacion.maximaDesde + "mmHg a " + clasificacion.maximaHasta + "mmHg", "Rango valor mínimo: De " + clasificacion.minimaDesde + "mmHg a " + clasificacion.minimaHasta + "mmHg");
                    clasificado = true;
                }
            }
            if (clasificado == false) 
            { 
                medicion.clasificacion = null;
                pantalla.presentarCalculosPresionArterial("Promedio: " + medicion.promedio + "mmHg", "Categoría: Sin clasificación", "Rango valor máximo: -", "Rango valor mínimo: -");
            }
        }
    }
}
