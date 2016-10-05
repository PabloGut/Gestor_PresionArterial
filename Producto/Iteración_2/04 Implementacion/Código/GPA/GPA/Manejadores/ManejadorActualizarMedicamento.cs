using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorActualizarMedicamento
    {
        public List<UnidadDeMedida> mostrarUnidadesDeMedida()
        {
            return UnidadMedidaLN.mostrarUnidadesDeMedida();
        }
        public List<PresentacionMedicamento> mostrarPresentacionesMedicamento()
        {
            return PresentacionMedicamentoLN.mostrarPresentacionesMedicamento();
        }
        public List<FormaAdministracion> mostrarFormasDeAdministracion()
        {
            return FormaAdministracionLN.mostrarFormasDeAdministracion();
        }
        public DataTable mostrarMedicamentos()
        {
            return EspecificacionMedicamentoLN.mostrarMedicamentos();
        }
        public void registrarMedicamento(Medicamento medicamento,NombreComercial nombreComercial)
        {
            MedicamentoLN.registrarMedicamento(medicamento, nombreComercial);
        }
        public void registrarEspecificacionMedicamento(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoLN.registrarEspecificacionMedicamento(especificacion);
        }
        public void registrarNombreComercialMedicamento(NombreComercial nombreComercial)
        {
            NombreComercialLN.registrarNombreComercial(nombreComercial);
        }
        public Boolean existeNombreComercial(string nombreComercial)
        {
            return NombreComercialLN.existeNombreComercial(nombreComercial);
        }
        public Boolean existeEspecificacion(EspecificacionMedicamento especificacion)
        {
            return EspecificacionMedicamentoLN.existeEspecificacion(especificacion);
        }

    }
}
