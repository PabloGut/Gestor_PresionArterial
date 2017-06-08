using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarAlergias
    {
        public List<Alimento> mostrarAlimentos()
        {
            return AlimentoLN.mostrarAlimentos();
        }
        public List<SustaciaAmbiente> mostrarSustanciasDelAmbiente()
        {
            return SustanciaAmbienteLN.mostrarSustanciasDelAmbiente();
        }
        public List<SustanciaContactoPiel> mostrarSustanciasContactoPiel()
        {
            return SustanciaContactoPielLN.mostrarSustaciasContactoPiel();
        }
        public List<Insecto> mostrarInsectos()
        {
            return InsectoLN.mostrarInsectos();
        }
        public List<MedicamentoAlergia> mostrarMedicamentosQueProducenAlergias()
        {
            return MedicamentoAlergiaLN.mostrarMedicamentosQueProducenAlergia();
        }
        public void registrarAlergiasAlimento(List<AlergiaAlimento> alergiaAlimentos, int idHc)
        {
            AlergiaAlimentoLN.registrarAlergiaAlimentos(alergiaAlimentos, idHc);
        }
        public void registrarAlergiaSustanciaDelAmbiente(List<AlergiaSustanciaAmbiente> alergiaSustanciaAmbiente, int idHc)
        {
            AlergiaSustanciaAmbienteLN.registrarAlergiaSustanciasDelAmbiente(alergiaSustanciaAmbiente, idHc);
        }
        public void registrarAlergiaSustanciaContactoPiel(List<AlergiaSustanciaContactoPiel> alergiaSustanciaContactoPiel, int idHc)
        {
            AlergiaSustanciaContactoPielLN.registrarAlergiaSustanciasContactoPiel(alergiaSustanciaContactoPiel, idHc);
        }
        public void registrarAlergiaInsectos(List<AlergiaInsecto> alergiaInsecto, int idHc)
        {
            AlergiaInsectoLN.registrarAlergiasInsectos(alergiaInsecto, idHc);
        }
        public void registrarAlergiaMedicamento(List<AlergiaMedicamento> alergiaMedicamento, int idHc)
        {
            AlergiaMedicamentoLN.registrarAlergiaMedicamentos(alergiaMedicamento, idHc);
        }
    }
}
