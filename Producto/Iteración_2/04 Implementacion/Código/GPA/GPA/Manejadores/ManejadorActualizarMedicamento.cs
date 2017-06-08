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
        public int idNombreMedicamento(string nombre)
        {
            return NombreComercialLN.idNombreComercial(nombre);

        }
        public void actualizarEspecificacion(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoLN.actualizarEspecificacion(especificacion);

            if (EspecificacionMedicamentoLN.existeUnidadMedidaXMedicamento(especificacion.id_medicamento_fk, especificacion.id_unidadMedida_fk,especificacion.id_nombreComercial) == false)
            {
                EspecificacionMedicamentoLN.actualizarUnidadMedidaXMedicamento(especificacion);
            }
            if (EspecificacionMedicamentoLN.existeFormaAdministracionXMedicamento(especificacion.id_medicamento_fk, especificacion.id_formaAdministracion, especificacion.id_nombreComercial) == false)
            {
                EspecificacionMedicamentoLN.actualizarFormaAdministracionXMedicamento(especificacion);
            }
            if (EspecificacionMedicamentoLN.existePresentacionMedicamentoXMedicamento(especificacion.id_medicamento_fk, especificacion.id_presentacionMedicamento, especificacion.id_nombreComercial) == false)
            {
                EspecificacionMedicamentoLN.actualizarPresentacionMedicamentoXMedicamento(especificacion);
            }

        }
        public void eliminarEspecificacion(int idEspecificacion)
        {
            EspecificacionMedicamentoLN.eliminarEspecificacion(idEspecificacion);
        }
        public DataTable mostrarEspecificacionMedicamento(string nombreGenerico)
        {
            return EspecificacionMedicamentoLN.mostrarEspecificacionMedicamento(nombreGenerico);
        }
    }
}
