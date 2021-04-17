using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace GPA.Manejadores
{
    public class ManejadorConsultarHC
    {
        public HistoriaClinica mostrarHistoriaClinica(Paciente paciente)
        {
            return HistoriaClinicaLN.mostrarHistoriaClinica(paciente);
        }
        public DataTable mostrarAntecedentesMorbidosEnfermedades(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosEnfermedades(idHc);
        }
        public DataTable mostrarAntecedentesMorbidosOperaciones(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosOperaciones(idHc);
        }
        public DataTable mostrarAntecedentesMorbidosTraumatismos(int idHc)
        {
            return AntecedenteMorbidoLN.mostrarAntecedentesMorbidosTraumatismos(idHc);
        }
        public DataTable mostrarAntecedentesGinecoObstetricos(int idHc)
        {
            return AntecedenteGinecoObstetricoLN.mostrarAntecedenteGinecoObtetrico(idHc);
        }
        public DataTable mostrarAlergiasAlimentos(int idHc)
        {
            return AlergiaAlimentoLN.mostrarAlergiasAlimentos(idHc);
        }
        public DataTable mostrarAlergiasSustanciasAmbiente(int idHc)
        {
            return AlergiaSustanciaAmbienteLN.mostrarAlergiasSustanciaAmbiente(idHc);
        }
        public DataTable mostrarAlergiasSustanciaContactoPiel(int idHc)
        {
            return AlergiaSustanciaContactoPielLN.mostrarAlergiasSustanciaContactoPiel(idHc);
        }
        public DataTable mostrarAlergiasInsectos(int idHc)
        {
            return AlergiaInsectoLN.mostrarAlergiasInsectos(idHc);
        }
        public DataTable mostrarAlergiasMedicamentos(int idHc)
        {
            return AlergiaMedicamentoLN.mostrarAlergiasMedicamentos(idHc);
        }
        public DataTable mostrarConsultasAnteriores(int idHc)
        {
            return ConsultaLN.mostrarConsultasAnteriores(idHc);
        }
        public DataTable mostrarAntecedentesPatologicosPersonales(int idHc)
        {
            return AntecedentePatologicoPersonalLN.mostrarAntecedentesPatologicosPersonales(idHc);
        }
        public DataTable MostrarAntecesPatologicosFamiliares(int idHc)
        {
            return AntecedenteFamiliarLN.MostrarAntecedentesFamiliares(idHc);
        }
        public DataTable MostrarHabitosTabaquismo(int idHc)
        {
            return HabitoTabaquismoLN.MostrarHabitosTabaquismo(idHc);
        }
        public DataTable MostrarHabitosAlcoholismo(int idHc)
        {
            return HabitoAlcoholismoLN.MostrarHabitosAlcoholismo(idHc);
        }
        public DataTable MostrarHabitosMedicamentos(int idHc)
        {
            return HabitoMedicamentoLN.MostrarHabitosMedicamento(idHc);
        }
        public DataTable mostrarHabitosMedicamentos(int idHc)
        {
            return HabitoMedicamentoLN.MostrarHabitosMedicamento(idHc);
        }
        public DataTable mostrarHabitosActividadFisica(int idHc)
        {
            return HabitoActividadFisicaLN.MostrarHabitoActividadFisica(idHc);
        }
        public DataTable MostrarHabitosDrogasIlicitas(int idHc)
        {
            return HabitoDrogasIlicitasLN.MostrarHabitosDrogasIlicitas(idHc);
        }
    }
}
