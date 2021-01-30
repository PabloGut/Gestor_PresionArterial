using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarExamenGeneral
    {
        private MenuPrincipal pantalla;
        private List<ClasificacionPresionArterial> clasificaciones;
        public MedicionDePresionArterial medicion {get; set;}

        public void registrarExamenGeneral(MenuPrincipal mp)
        {
            pantalla = mp;
            medicion = new MedicionDePresionArterial();
            mostrarPresionArterial();
        }

        public List<Ubicacion> mostrarUbicaciones()
        {
            return UbicacionLN.mostrarUbicaciones();
        }
        public List<Tamaño> mostrarTamañoGanglio()
        {
            return TamañoLN.mostrarTamañosGanglios();
        }
        public List<EscalaPulso> mostrarEscalaPulso()
        {
            return EscalaPulsoLN.mostrarEscalaPulso();
        }
        public List<Pulso> mostrarPulsos()
        {
            return PulsoLN.mostrarPulsos();
        }
        public List<Consistencia> mostrarConsistencia()
        {
            return ConsistenciaLN.mostrarConsistencia();
        }
        public List<SitioMedicionTemperatura> mostrarSitioMedicionTemperatura()
        {
            return SitioMedicionTemperaturaLN.mostrarSitioMedicionTemperatura();
        }
        public string mostrarClasificacionTemperatura(float valor)
        {
            return TemperaturaLN.determinarResultado(valor);
        }
        /*public int registrarExamenGeneral(ExamenGeneral examen)
        {
            return ExamenGeneralLN.registrarExamenGeneral(examen);
        }*/
        public void registrarSistemaLinfatico(List<SistemaLinfatico> territoriosExaminados, int idExamenGeneral)
        {
            SistemaLinfaticoLN.registrarSistemaLinfatico(territoriosExaminados, idExamenGeneral);
        }
        public int registrarPulsoArterial(PulsoArterial pulsoArterial)
        {
            return PulsoArterialLN.registrarPulsoArterial(pulsoArterial);
        }
        public ExamenGeneral crearExamenGeneralPaso1(string posicionYDecubito,string marchaDeambulacion,string facieExpresionFisonomia,string concienciaEstadoPsiquico,string constitucionEstadoNutritivo,int peso, int talla)
        {
            ExamenGeneral nuevoExamen = new ExamenGeneral();
            nuevoExamen.posicionYDecubito = posicionYDecubito;
            nuevoExamen.marchaYDeambulacion = marchaDeambulacion;
            nuevoExamen.facieExpresionFisonomia=facieExpresionFisonomia;
            nuevoExamen.concienciaEstadoPsiquico = concienciaEstadoPsiquico;
            nuevoExamen.constitucionEstadoNutritivo = constitucionEstadoNutritivo;
            nuevoExamen.peso = peso;
            nuevoExamen.talla = talla;

            return nuevoExamen;
        }
        public Piel crearExamenDePielPaso1(string colorPiel, string elasticidad, string humedad, string untuosidad, string turgor, string lesiones, TemperaturaPiel temperaturaPiel)
        {
            Piel nuevoExamenPiel = new Piel();
            nuevoExamenPiel.color = colorPiel;
            nuevoExamenPiel.elasticidad = elasticidad;
            nuevoExamenPiel.untuosidad = untuosidad;
            nuevoExamenPiel.turgor = turgor;
            nuevoExamenPiel.lesiones = lesiones;
            nuevoExamenPiel.temperatura = temperaturaPiel;

            return nuevoExamenPiel;
        }
        public SistemaLinfatico crearSistemaLinfaticoPaso2(int ubicacion, int tamaño, int aproximacionNumerica, int consistencia, string descripcion, string sensiblePalpacion, string palpaConLimitesPrecisos, string tiendeConfluir, string seMovilizaConDedos, string adheridaPlanosProfundos, string procesoInflamatorioComprometePiel, string lesion, string observaciones)
        {
            SistemaLinfatico nuevoAnalisisSistemaLinfatico = new SistemaLinfatico();
            nuevoAnalisisSistemaLinfatico.id_ubicacion = ubicacion;
            nuevoAnalisisSistemaLinfatico.id_tamaño = tamaño;
            nuevoAnalisisSistemaLinfatico.aproximacionNumerica = aproximacionNumerica;
            nuevoAnalisisSistemaLinfatico.id_consistencia = consistencia;
            nuevoAnalisisSistemaLinfatico.descripcion = descripcion;
            nuevoAnalisisSistemaLinfatico.sensiblePalpacion = sensiblePalpacion;
            nuevoAnalisisSistemaLinfatico.sePalpaConLimitesPrecisos = palpaConLimitesPrecisos;
            nuevoAnalisisSistemaLinfatico.tiendeAConfluir = tiendeConfluir;
            nuevoAnalisisSistemaLinfatico.sePuedeMovilizarConDedos = seMovilizaConDedos;
            nuevoAnalisisSistemaLinfatico.adheridaPlanosProfundos = adheridaPlanosProfundos;
            nuevoAnalisisSistemaLinfatico.procesoInflamatorioComprometeLaPiel = procesoInflamatorioComprometePiel;
            nuevoAnalisisSistemaLinfatico.lesion = lesion;
            nuevoAnalisisSistemaLinfatico.observaciones = observaciones;

            return nuevoAnalisisSistemaLinfatico;
        }
        public PulsoArterial crearPulsoArterialPaso3(string auscultacion, string observaciones, List<DetallePulsoArterial> detalles)
        {
            PulsoArterial pulso = new PulsoArterial();
            pulso.auscultacion = auscultacion;
            pulso.observaciones = observaciones;
            pulso.detalles = detalles;

            return pulso;
        }
        public Respiracion crearRespiracionPaso3(string descripcion, string observaciones)
        {
            Respiracion respiracion = new Respiracion();
            respiracion.descripcion = descripcion;
            respiracion.observaciones = observaciones;

            return respiracion;
        }
        public Temperatura crearTemperaturaPaso4(int sitioMedicion, string resultado, float valorTemperatura)
        {
            Temperatura temperatura = new Temperatura();

            SitioMedicionTemperatura sitio = new SitioMedicionTemperatura();

            sitio.id_sitioMedicion = sitioMedicion;

            temperatura.sitioMedicion=sitio;

            ResultadoTemperatura nuevoResultado = new ResultadoTemperatura();
            nuevoResultado.nombre = resultado;

            temperatura.resultado = nuevoResultado;
            temperatura.valorTemperatura = valorTemperatura;

            return temperatura;
        }
        public List<Temperatura> crearListaTemperatura()
        {
            List<Temperatura> lista = new List<Temperatura>();
            return lista;
        }
        public void mostrarPresionArterial()
        {
            pantalla.presentarExamenGeneralPresionArterial(ExtremidadLN.mostrarExtremidades(), PosicionLN.mostrarPosiciones(), SitioMedicionLN.mostrarSitiosDeMedicion(), MomentoDiaLN.mostrarMomentosDelDia());
        }

        public void buscarClasificacionesDePresionArterial()
        {
            clasificaciones = ClasificacionPresionArterialLN.mostrarClasificacionesDePresionArterial();
        }

        public void mostrarUbicacionesDeExtremidad(int id_extremidad)
        {
            pantalla.presentarUbicacionesExtremidadDeExtremidad(UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(id_extremidad));
        }

        public void registrarMedicion(DateTime fecha, DateTime horaInicio, Posicion posicion, UbicacionExtremidad ubicacion, SitioMedicion sitio, MomentoDia momento, Extremidad extremidad)
        {
            medicion.posicion = posicion; medicion.fecha = fecha; medicion.horaInicio = horaInicio; medicion.ubicacion = ubicacion; medicion.sitio = sitio; medicion.momento = momento; medicion.extremidad = extremidad;
        }

        public void registrarDetalleDeMedicion(DateTime hora, int pulso, int valorMinimo, int valorMaximo)
        {
            DetalleMedicionPresionArterial detalle = new DetalleMedicionPresionArterial();
            detalle.id_nroMedicion = medicion.mediciones.Count + 1; detalle.hora = hora; detalle.pulso = pulso; detalle.valorMinimo = valorMinimo; detalle.valorMaximo = valorMaximo;
            medicion.mediciones.Add(detalle);
            //calcularPromedioYClasificacionDePresionArterial();
        }

        public void calcularPromedioYClasificacionDePresionArterial()
        {
            medicion.promedio = MedicionDePresionArterialLN.calcularPromedio(medicion.mediciones);
            int promedioSistolica = MedicionDePresionArterialLN.calcularPromedioValorMinimo(medicion.mediciones);
            int promedioDiastolica = MedicionDePresionArterialLN.calcularPromedioValorMaximo(medicion.mediciones);
            bool clasificado = false;
            foreach (ClasificacionPresionArterial clasificacion in clasificaciones)
            {
                if (ClasificacionPresionArterialLN.esClasificacionPresionArterial(promedioSistolica, promedioDiastolica, clasificacion))
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

        public List<NombreEstudio> mostrarNombreEstudios()
        {
            return NombreEstudioLN.mostrarNombreEstudios();
        }
        public List<AnalisisLaboratorio> mostrarAnalisisLaboratorio()
        {
            return AnalisisLaboratorioLN.mostrarAnalisisLaboratorio();
        }
        public List<TipoPracticaComplementaria> mostrarTipoPracticaComplementaria()
        {
            return TipoPracticaComplementariaLN.mostrarPracticasComplementarias();
        }
        public int mostrarIdEstadoDiagnostico(string nombreEstado)
        {
            return EstadoDiagnosticoLN.mostrarIdEstadoDiagnostico(nombreEstado);
        }
        /*public int registrarRazonamientoDiagnostico(RazonamientoDiagnostico razonamiento)
        {
            return RazonamientoDiagnosticoLN.registrarRazonamientoDiagnostico(razonamiento);
        }*/
        /*
         * Crear un diagnostico con tratamientos
         */
        public RazonamientoDiagnostico crearRazonamientoDiagnostico(string conceptoInicial, string Desdiagnostico, EstadoDiagnostico estadoDiagnostico, string motivo, DateTime fecha, List<Laboratorio> analisis, List<EstudioDiagnosticoPorImagen> estudios,List<PracticaComplementaria> practicas, List<Tratamiento> tratamientos)
        {
            RazonamientoDiagnostico diagnostico = new RazonamientoDiagnostico();
            diagnostico.conceptoInicial = conceptoInicial;
            diagnostico.diagnostico = Desdiagnostico;
            diagnostico.estado = estadoDiagnostico;

            switch (estadoDiagnostico.nombre)
            {
                case "Tentativo":
                    diagnostico.fechaTentativo =Convert.ToDateTime(fecha.ToShortDateString());
                    diagnostico.motivoTentativo = motivo;
                    break;

                case "Definitivo":
                    diagnostico.fechaConfirmado = fecha;
                    diagnostico.motivoConfirmado = motivo;
                    break;

                case "Descartado":
                    diagnostico.fechaDescartado = fecha;
                    diagnostico.motivoDescartado = motivo;
                    break;
            }

            diagnostico.analisis = analisis;
            diagnostico.estudios = estudios;
            diagnostico.practicas = practicas;
            diagnostico.tratamientos = tratamientos;

            return diagnostico;
        }
        public List<RazonamientoDiagnostico> CrearListaDiagnosticos()
        {
            List<RazonamientoDiagnostico> lista = new List<RazonamientoDiagnostico>();
            return lista;
        }
        public EstadoDiagnostico crearEstadoDiagnostico(int id_estado, string nombre)
        {
            EstadoDiagnostico estado = new EstadoDiagnostico();
            estado.id_estado = id_estado;
            estado.nombre = nombre;
            return estado;
        }
        public List<Laboratorio> crearListaLaboratorio()
        {
            List<Laboratorio> listaLaboratorio = new List<Laboratorio>();
            return listaLaboratorio;
        }
        public AnalisisLaboratorio crearAnalisisLaboratorio(int id, string nombre)
        {
            AnalisisLaboratorio analisisLaboratorio = new AnalisisLaboratorio();
            analisisLaboratorio.id_analisis = id;
            analisisLaboratorio.nombre = nombre;

            return analisisLaboratorio;
        }
        public Laboratorio crearLaboratorio(string indicaciones)
        {
            Laboratorio laboratorio = new Laboratorio();
            laboratorio.indicaciones = indicaciones;
            return laboratorio;
        }
        public NombreEstudio crearNombreEstudio(int id_estudio, string nombre)
        {
            NombreEstudio estudio = new NombreEstudio();
            estudio.id_nombreEstudio = id_estudio;
            estudio.nombre = nombre;
            return estudio;
        }
        public EstudioDiagnosticoPorImagen crearEstudioDiagnosticoPorImagen(string indicaciones)
        {
            EstudioDiagnosticoPorImagen estudio = new EstudioDiagnosticoPorImagen();
            estudio.indicaciones = indicaciones;
            return estudio;
        }
        public List<EstudioDiagnosticoPorImagen> crearListaEstudioDiagnosticoPorImagen()
        {
            List<EstudioDiagnosticoPorImagen> listaEstudioDiagnosticoImagen = new List<EstudioDiagnosticoPorImagen>();
            return listaEstudioDiagnosticoImagen;
        }
        public TipoPracticaComplementaria crearTipoPracticaComplementaria(int id_practica, string nombre)
        {
            TipoPracticaComplementaria practica = new TipoPracticaComplementaria();
            practica.id_tipoPracticaComplementaria = id_practica;
            practica.nombre = nombre;
            return practica;
        }
        public PracticaComplementaria crearPracticaComplementaria(string indicaciones)
        {
            PracticaComplementaria practica = new PracticaComplementaria();
            practica.indicaciones = indicaciones;
            return practica;
        }
        public List<PracticaComplementaria> crearListaPracticaComplementaria()
        {
            List<PracticaComplementaria> listaPracticas = new List<PracticaComplementaria>();
            return listaPracticas;
        }
        public Tratamiento crearTratamiento(Terapia terapia, string indicaciones, DateTime fechaInicio, string motivo)
        {
            Tratamiento tratamiento = new Tratamiento();
            tratamiento.terapia = terapia;
            tratamiento.indicaciones = indicaciones;
            tratamiento.fechaInicio = fechaInicio;
            tratamiento.motivoInicio = motivo;

            return tratamiento;
        }
        public Tratamiento crearTratamiento(Terapia terapia, string indicaciones, DateTime fechaInicio, string motivo,List<ProgramacionMedicamento> medicamentos)
        {
            Tratamiento tratamiento = new Tratamiento();
            tratamiento.terapia = terapia;
            tratamiento.indicaciones = indicaciones;
            tratamiento.fechaInicio = fechaInicio;
            tratamiento.motivoInicio = motivo;
            tratamiento.medicamentos = medicamentos;
            return tratamiento;
        }
        public List<Tratamiento> crearListaTratamiento()
        {
            List<Tratamiento> listatTratamiento = new List<Tratamiento>();
            return listatTratamiento;
        }
        public Terapia crearTerapia(int id_terapia, string nombre)
        {
            Terapia terapia = new Terapia();
            terapia.id_terapia = id_terapia;
            terapia.nombre = nombre;
            return terapia;
        }
        public ProgramacionMedicamento crearProgramacionMedicamento()
        {
            ProgramacionMedicamento programacion = new ProgramacionMedicamento();
            return programacion;
        }
        public EspecificacionMedicamento crearEspecificacionMedicamento()
        {
            EspecificacionMedicamento especificacion = new EspecificacionMedicamento();
            return especificacion;
        }
        public void buscarEspecificacionMedicamento(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoLN.buscasIdEspecificacion(especificacion);
        }
        public List<ProgramacionMedicamento> crearListaProgramacionMedicamento()
        {
            List<ProgramacionMedicamento> lista = new List<ProgramacionMedicamento>();
            return lista;
        }
        public List<EstadoDiagnostico> obtenerEstadoDiagnostico()
        {
            return EstadoDiagnosticoLN.obtenerEstadosDiagnostico();
        }
        public List<TemperaturaPiel> obtenerTemperaturasPiel()
        {
            return TemperaturaPielLN.obtenerTemperaturasPiel();
        }
        public List<Terapia> mostrarTerapias()
        {
            return TerapiaLN.mostrarTerapias();
        }
        public List<Medicamento> presentarNombreGenericoMedicamento()
        {
            return MedicamentoLN.mostrarNombreMedicamentos();
        }
        public List<NombreComercial> presentarNombreComercialMedicamento(int id)
        {
            return NombreComercialLN.mostrarNombresComercialesDeMedicamento(id);
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
        public List<int> mostrarConcentracionMedicamento(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            return EspecificacionMedicamentoLN.mostrarConcentracionEspecificacion(idMedicamento, idNombreComercial, idUnidadMedida, idPresentacion, idFormaAdministracion);
        }
        public List<int> mostrarCantidadComrpimidos(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            return EspecificacionMedicamentoLN.mostrarCantidadComprimidos(idMedicamento, idNombreComercial, idUnidadMedida, idPresentacion, idFormaAdministracion);
        }
        public List<Frecuencia> mostrarFrecuencias()
        {
            return FrecuenciaLN.mostrarFrecuencias();
        }
        public List<MomentoDia> mostrarMomentosDelDia()
        {
            return MomentoDiaLN.mostrarMomentosDelDia();
        }
        public List<PresentacionMedicamento> mostrarPresentacionesMedicamento()
        {
            return PresentacionMedicamentoLN.mostrarPresentacionesMedicamento();
        }
        public int buscarIdEstado(string estado)
        {
            return EstadoProgramacionLN.buscarIdEstado(estado);
        }
    }
}
