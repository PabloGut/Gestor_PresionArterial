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
        public List<UnidadDeMedida> mostrarUnidadMedidaParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoLN.mostrarUnidadMedidaParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial);
        }
        public List<FormaAdministracion> mostrarFormasAdministracionParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoLN.mostrarFormasAdministracionParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial);
        }
        public List<PresentacionMedicamento> mostrarPresentacionMedicamentoParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoLN.mostrarPresentacionMedicamentoParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial);
        }
        public List<MomentoDia> mostrarMomentosDelDia()
        {
            return MomentoDiaLN.mostrarMomentosDelDia();
        }
        public List<PresentacionMedicamento> mostrarPresentacionesMedicamento()
        {
            return PresentacionMedicamentoLN.mostrarPresentacionesMedicamento();
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public List<Frecuencia> mostrarFrecuencias()
        {
            return FrecuenciaLN.mostrarFrecuencias();
        }
        public int buscarIdEstado(string nombreEstado)
        {
            return EstadoProgramacionLN.buscarIdEstado(nombreEstado);
        }
        public List<int> mostrarConcentracionMedicamento(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            return EspecificacionMedicamentoLN.mostrarConcentracionEspecificacion(idMedicamento, idNombreComercial, idUnidadMedida, idPresentacion, idFormaAdministracion);
        }
        public List<int> mostrarCantidadComrpimidos(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            return EspecificacionMedicamentoLN.mostrarCantidadComprimidos(idMedicamento, idNombreComercial, idUnidadMedida, idPresentacion, idFormaAdministracion);
        }
        public void buscarIdEspecificacion(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoLN.buscasIdEspecificacion(especificacion);
        }
        public void registrarHabitosDrogasLicitas(List<HabitoMedicamento> habitos, int idHc)
        {
            HabitoMedicamentoLN.registrarHabitosMedicamento(habitos, idHc);
        }
    }
}
