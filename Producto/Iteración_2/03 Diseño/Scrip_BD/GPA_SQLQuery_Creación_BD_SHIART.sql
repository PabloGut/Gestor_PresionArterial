--CREATE DATABASE GPA_BD_4;
CREATE TABLE Localidad(
id_localidad integer PRIMARY KEY IDENTITY,
nombre varchar(50) not null)

CREATE TABLE Barrio(
id_barrio integer PRIMARY KEY IDENTITY,
nombre varchar(20)not null,
descripcion varchar(50),
id_localidad_fk integer not null
FOREIGN KEY (id_localidad_fk) REFERENCES Localidad(id_localidad))

CREATE TABLE Domicilio(
id_domicilio integer PRIMARY KEY IDENTITY,
calle varchar(200) not null,
numero integer not null,
codigo_postal integer not null,
piso integer,
departamento varchar(20),
id_barrio_fk integer not null,
FOREIGN KEY (id_barrio_fk) REFERENCES Barrio(id_barrio))


CREATE TABLE Usuario(
id_usuario int primary key identity,
nombre_usuario varchar(100) not null,
contraseña  varbinary(max) not null,
fecha_creacion date not null)

CREATE TABLE Estado (
id_estado int PRIMARY KEY IDENTITY,
nombre varchar(50) not null,
descripcion varchar(50))

create table Especialidad(
id_especialidad int primary key identity,
nombre varchar(100) not null,
descripcion varchar(100) not null)

create table Sexo(
id_sexo int primary key identity,
nombre varchar(100) not null)

CREATE TABLE UnidadMedida (
id_unidadMedida int primary key identity,
nombre text,
descripcion text)

create table itemLaboratorio(
id_itemLaboratorio int identity,
nombre text,
primary key (id_itemLaboratorio))

CREATE TABLE ElementoDelTiempo(
id_elementoDelTiempo int primary key identity,
nombre text)


CREATE TABLE FormaAdministracion (
id_formaAdministracion int primary key identity,
nombre text)

CREATE TABLE PresentacionMedicamento (
id_presentacionMedicamento int primary key identity,
nombre text)

CREATE TABLE Medicamento (
id_medicamento int primary key identity,
nombreGenerico text,
concentracion float,
id_unidadMedida_fk int,
id_formaAdministracion_fk int,
id_presentacionMedicamento_fk int)

CREATE TABLE NombreComercial (
id_nombreComercial int primary key identity,
nombre text,
id_medicamento_fk int,
foreign key (id_medicamento_fk) references Medicamento(id_medicamento))


CREATE TABLE MomentoDelDia(
id_momentoDelDia int primary key identity,
nombre text)

CREATE TABLE SitioMedicion(
id_sitioMedicion int primary key identity,
nombre text)


CREATE TABLE Terapia(
id_terapia int primary key identity,
nombre varchar(100),
descripcion varchar(100))





CREATE TABLE ProfesionalMedico (
id_tipodoc_fk int not null,
nro_documento int not null,
nombre varchar(100) not null,
apellido varchar(100),
fechaNacimiento date not null,
matricula varchar(100),
telefono varchar(100),
nroCelular varchar(100),
email varchar(100),
id_usuario_fk int not null,
id_estado_fk int not null,
id_especialidad_fk int not null,
id_sexo_fk int,
id_domicilio_fk int,
PRIMARY KEY (id_tipodoc_fk,nro_documento),
foreign key(id_usuario_fk) references Usuario(id_usuario),
foreign key (id_estado_fk) references Estado(id_estado),
foreign key (id_especialidad_fk) references Especialidad(id_especialidad),
foreign key (id_sexo_fk) references Sexo(id_sexo),
foreign key (id_domicilio_fk) references Domicilio(id_domicilio))


CREATE TABLE TipoPracticaComplementaria(
id_tipoPractica int PRIMARY KEY IDENTITY,
nombre varchar(50),
descripcion text)


CREATE TABLE MetodoAnalisisLaboratorio(
id_metodo int primary key identity,
nombre varchar(100) not null)

CREATE TABLE AnalisisLaboratorio(
id_analisisLaboratorio integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
descripcion text)

CREATE TABLE Institucion(
id_institucion integer PRIMARY KEY IDENTITY,
nombre varchar(30) not null,
descripcion varchar(200))

CREATE TABLE TemperaturaPiel(
id_temperatura int primary key identity,
nombre text)

CREATE TABLE Piel(
id_piel int primary key identity,
color text,
elasticidad text,
humedad text,
untuosidad text,
turgor text,
lesiones text,
id_temperatura_fk int,
foreign key (id_temperatura_fk) references TemperaturaPiel(id_temperatura))

create table TipoDocumento(
id_tipoDoc int primary key identity,
nombre varchar(100),
descripcion varchar(100))

CREATE TABLE Frecuencia(
id_frecuencia int primary key identity,
nombre text)

CREATE TABLE EstadoProgramacion(
id_estadoProgramacion int primary key identity,
nombre text)

CREATE TABLE Pulso(
id_Pulso int primary key identity,
nombre text)

CREATE TABLE EscalaPulso(
id_escalaPulso int primary key identity,
nombre text)

CREATE TABLE PulsoArterial(
id_pulsoArterial int primary key identity,
auscultacion text,
observaciones text)

CREATE TABLE Extremidad(
id_extremidad int primary key identity,
nombre text)

CREATE TABLE UbicacionExtremidad(
id_ubicacionExtremidad int primary key identity,
nombre text,
id_extremidad_fk int,
foreign key (id_extremidad_fk) references Extremidad(id_extremidad))

CREATE TABLE Posicion(
id_posicion int primary key identity,
nombre text)

CREATE TABLE ClasificacionPresionArterial(
id_clasificacion int primary key identity,
categoria text,
maximaDesde int,
maximaHasta int,
minimaDesde int,
minimaHasta int)





create table EspecificacionMedicamento(
id_especificacion int identity,
id_medicamento_fk int,
concentracion int,
id_unidadMedida_fk int,
id_formaAdministracion_fk int,
id_presentacionMedicamento_fk int,
id_nombreComercial_fk int,
cantidadComprimidos int,
primary key (id_especificacion,id_medicamento_fk),
foreign key(id_medicamento_fk) references Medicamento(id_medicamento),
foreign key(id_unidadMedida_fk) references UnidadMedida(id_unidadMedida),
foreign key(id_formaAdministracion_fk) references FormaAdministracion(id_formaAdministracion),
foreign key(id_presentacionMedicamento_fk) references PresentacionMedicamento(id_presentacionMedicamento),
foreign key(id_nombreComercial_fk) references NombreComercial(id_nombreComercial))

----------------------------------------------------------------------------------------------
CREATE TABLE Paciente (
id_tipoDoc_fk int not null,
nro_documento int not null,
nombre varchar(100) not null,
apellido varchar(100),
telefono varchar(100),
nroCelular varchar(100),
email varchar(100),
id_usuario_fk int not null,
id_estado_fk int not null,
fecha_nacimiento date not null,
edad int not null,
altura int,
peso int,
id_hc_fk int not null,
id_domicilio_fk int not null,
id_profesionalMedico_tipoDoc_fk int not null,
id_profesionalMedico_nroDoc_fk int not null,
id_sexo_fk int,
PRIMARY KEY (id_tipoDoc_fk,nro_documento),
--FOREIGN KEY (id_hc_fk) REFERENCES Historia_Clinica(id_hc),
FOREIGN KEY (id_usuario_fk) REFERENCES Usuario(id_usuario),
FOREIGN KEY (id_estado_fk) REFERENCES Estado(id_estado),
FOREIGN KEY (id_domicilio_fk) REFERENCES Domicilio(id_domicilio),
FOREIGN KEY (id_profesionalMedico_tipoDoc_fk,id_profesionalMedico_nroDoc_fk) REFERENCES ProfesionalMedico(id_tipoDoc_fk,nro_documento),
FOREIGN KEY (id_sexo_fk) references Sexo(id_sexo))

CREATE TABLE Historia_Clinica(
id_hc integer PRIMARY KEY IDENTITY,
nro_hc integer NOT NULL,
fecha_creación date NOT NULL,
hora_creacion time not null,
principalProblema text,
fecha_inicio_atencion_con_profesional date not null,
id_tipodoc_profesionaMedico_fk int,
id_nrodoc_profesionalMedico_fk int,
id_tipodoc_paciente_fk int,
id_nrodoc_paciente_fk int,
foreign key(id_tipodoc_profesionaMedico_fk, id_nrodoc_profesionalMedico_fk) references ProfesionalMedico(id_tipodoc_fk,nro_documento),
foreign key(id_tipodoc_paciente_fk, id_nrodoc_paciente_fk) references Paciente(id_tipoDoc_fk,nro_documento))



CREATE TABLE EstadoDiagnostico(
id_estadoDiagnostico int identity,
nombre varchar(50),
constraint id_estadoDiagnostico_pk primary key (id_estadoDiagnostico))

CREATE TABLE MedicionDePrecionArterial(
id_medicion int primary key identity,
fecha date,
horaInicio time,
id_extremidad_fk int,
id_ubicacionExtremidad_fk int,
id_posicion_fk int,
id_clasificacion_fk int,
id_momentoDelDia_fk int,
promedio float,  
id_sitioMedicion_fk int,
id_hc_fk int,
foreign key (id_extremidad_fk) references Extremidad(id_extremidad),
foreign key (id_ubicacionExtremidad_fk) references UbicacionExtremidad(id_ubicacionExtremidad),
foreign key (id_posicion_fk) references Posicion(id_posicion),
foreign key (id_clasificacion_fk) references ClasificacionPresionArterial(id_clasificacion),
foreign key (id_momentoDelDia_fk) references MomentoDelDia(id_momentoDelDia),
foreign key (id_sitioMedicion_fk) references SitioMedicion(id_sitioMedicion),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))


CREATE TABLE ExamenGeneral(
id_examenGeneral int primary key identity,
posicionYDecubito text,
marchaYDeambulacion text,
facieExpresionFisonomia text,
concienciaEstadoPsiquico text,
constitucionEstadoNutritivo text,
peso int,
talla int,
id_piel_fk int,
descripcionComoRespira text,
observacionesRespiracion text,
id_pulsoArterial_fk int,
id_medicion_fk int,
foreign key (id_piel_fk) references Piel(id_piel),
foreign key (id_pulsoArterial_fk) references PulsoArterial(id_pulsoArterial),
foreign key (id_medicion_fk) references MedicionDePrecionArterial(id_medicion))



CREATE TABLE RazonamientoDiagnostico(
id_razonamiento int primary key identity,
conceptoInicial text,
diagnostico text,
id_estadoDiagnostico_fk int not null,
motivoDescartado text,
fechaDescartado date,
motivoConfirmado text,
fechaConfirmado date,
motivoTentativo text,
fechaTentativo date,
id_examenGeneral_fk int not null,
foreign key (id_estadoDiagnostico_fk) references EstadoDiagnostico(id_estadoDiagnostico),
foreign key (id_examenGeneral_fk) references ExamenGeneral(id_examenGeneral))

CREATE TABLE Tratamiento(
id_tratamiento int identity,
indicaciones text,
fechaInicio date,
motivoInicioTratamiento text,
fechaFin date,
motivoFinTratamiento text,
id_terapia_fk int not null,
id_razonamientoDiagnostico_fk int not null,
primary key (id_tratamiento),
foreign key (id_terapia_fk) references Terapia(id_terapia),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento))


CREATE TABLE Estudio(
id_estudio integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
fecha_estudio date not null,
doctorACargo varchar(30) not null,
informe_estudio text not null,
id_hc_fk integer not null,
id_institucion_fk integer not null,
FOREIGN KEY (id_hc_fk) REFERENCES Historia_Clinica(id_hc),
FOREIGN KEY (id_institucion_fk) REFERENCES Institucion(id_institucion))

CREATE TABLE SustanciaContactoPiel (
id_sustanciaContactoPiel int primary key identity,
nombre varchar(100) not null)

CREATE TABLE AlergiaSustanciaContactoPiel (
id_alergiaSustanciaContactoPiel int primary key identity,
fechaRegistro date not null,
efectos text,
id_sustanciaContactoPiel_fk int not null,
id_hc_fk int not null,
foreign key (id_sustanciaContactoPiel_fk) references SustanciaContactoPiel(id_SustanciaContactoPiel),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE Insecto (
id_insecto int primary key identity,
nombre varchar(100) not null)

CREATE TABLE AlergiaInsecto (
id_alergiaInsecto int primary key identity,
fechaRegistro date not null,
efectos text,
id_insecto_fk int not null,
id_hc_fk int not null,
foreign key (id_insecto_fk) references Insecto(id_Insecto),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE SustanciaAmbiente (
id_sustanciaAmbiente int primary key identity,
nombre varchar(100) not null)

CREATE TABLE AlergiaSustanciaAmbiente (
id_alergiaSustanciaAmbiente int primary key identity,
fechaRegistro date not null,
efectos text,
id_sustanciaAmbiente_fk int not null,
id_hc_fk int not null,
foreign key (id_sustanciaAmbiente_fk) references SustanciaAmbiente(id_sustanciaAmbiente),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE Alimento (
id_alimento int primary key identity,
nombre varchar(100) not null)

CREATE TABLE AlergiaAlimento (
id_alergiaAlimento int primary key identity,
fechaRegistro date not null,
id_alimento_fk int not null,
efectos text,
id_hc_fk int not null,
foreign key (id_alimento_fk) references Alimento(id_alimento),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))





create table MedicamentoAlergia(
id_medicamentoAlergia int primary key identity,
nombre text)

CREATE TABLE AlergiaMedicamento (
id_alergiaMedicamento int primary key identity,
fechaRegistro date not null,
efectos text,
id_medicamentoAlergia_fk int not null,
id_hc_fk int not null,
foreign key (id_medicamentoAlergia_fk) references MedicamentoAlergia(id_medicamentoAlergia),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE NombrePorTipoAntecedenteMorbido (
id_nombrePortipoAntecedenteMorbido int primary key identity,
nombre varchar(200) not null)

CREATE TABLE TiposAntecedentesMorbidos (
id_tipoAntecedenteMorbido int primary key identity,
nombre varchar(200) not null)

CREATE TABLE Operaciones (
id_operacion int primary key identity,
nombre varchar(200) not null,
id_tipoAntecedenteMorbido_fk int not null,
foreign key (id_tipoAntecedenteMorbido_fk) references TiposAntecedentesMorbidos(id_tipoAntecedenteMorbido))

CREATE TABLE Traumatismos (
id_traumatismo int primary key identity,
nombre varchar(200) not null,
descripcion text,
id_tipoAntecedenteMorbido_fk int not null,
foreign key (id_tipoAntecedenteMorbido_fk) references TiposAntecedentesMorbidos(id_tipoAntecedenteMorbido))

CREATE TABLE Enfermedades (
id_enfermedad int primary key identity,
nombre varchar(200) not null,
id_tipoAntecedenteMorbido_fk int not null,
foreign key (id_tipoAntecedenteMorbido_fk) references TiposAntecedentesMorbidos(id_tipoAntecedenteMorbido))


CREATE TABLE AntecedentesMorbidos(
id_antecedenteMorbido int primary key identity,
fechaRegistro date not null,
id_tipoAntecedenteMorbido_fk int not null,
id_enfermedad_fk int,
id_operacion_fk int,
id_traumatismo_fk int,
cantidadTiempo int,
id_elementoTiempo_fk int,
evolucion text,
tratamiento text,
id_hc_fk int not null,
foreign key (id_tipoAntecedenteMorbido_fk) references TiposAntecedentesMorbidos(id_tipoAntecedenteMorbido),
foreign key (id_operacion_fk) references Operaciones(id_operacion),
foreign key (id_traumatismo_fk) references Traumatismos(id_traumatismo),
foreign key (id_enfermedad_fk) references Enfermedades(id_enfermedad),
foreign key (id_elementoTiempo_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))


CREATE TABLE TipoAborto(
id_TipoAborto int primary key identity,
nombre text,
descripcion text)

CREATE TABLE TipoParto(
id_TipoParto int primary key identity,
nombre text,
descripcion text)


CREATE TABLE Aborto(
id_aborto int primary key identity,
cantidadTotal int,
cantidadAbortoTipo1 int,
id_TipoAborto1_fk int,
cantidadAbortoTipo2 int,
id_TipoAborto2_fk int,
nroHijosVivos int,
problemasAsociadosAlEmbarazo text,
foreign key (id_TipoAborto1_fk) references TipoParto(id_tipoParto),
foreign key (id_TipoAborto2_fk) references TipoParto(id_tipoParto))

CREATE TABLE AntecedentesGinecoObstetricos(
id_antecedenteGinecoObstetrico int primary key identity,
fechaRegistro date not null,
cantidadEmbarazos int,
cantidadEmbarazosPrematuros int,
id_TipoParto1_fk int,
cantidadEmbarazosATermino int,
id_TipoParto2_fk int,
cantidadEmbarazosPosTermino int,
id_TipoParto3_fk int,
id_Aborto_fk int,
id_hc_fk int not null,
foreign key (id_TipoParto1_fk) references TipoParto(id_tipoParto),
foreign key (id_TipoParto2_fk) references TipoParto(id_tipoParto),
foreign key (id_TipoParto3_fk) references TipoParto(id_tipoParto),
foreign key (id_Aborto_fk) references Aborto(id_aborto),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE Medida(
id_medida int primary key identity,
nombre text)

CREATE TABLE TipoBebida(
id_tipoBebida int primary key identity,
nombre text)

CREATE TABLE ComponenteDelTiempo(
id_componenteTiempo int primary key identity,
nombre text)

CREATE TABLE HabitosAlcoholismo(
id_habitoBebidaAlcoholica int primary key identity,
id_tipoBebida_fk int,
fechaRegistro date not null,
cantidad int,
id_medida_fk int,
id_componenteTiempo_fk int,
id_hc_fk int not null,
foreign key (id_tipoBebida_fk) references TipoBebida(id_TipoBebida),
foreign key (id_medida_fk) references Medida(id_medida),
foreign key (id_componenteTiempo_fk) references ComponenteDelTiempo(id_componenteTiempo),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE Sustancia(
id_sustancia int primary key identity,
nombre text)


CREATE TABLE HabitosDrogasIlicitas(
id_habitoDrogasIlicitas int primary key identity,
id_sustancia_fk int,
fechaRegistro date not null,
tiempoConsumiendo int,
id_ElementoDelTiempo_fk int,
id_hc_fk int not null,
foreign key (id_sustancia_fk) references Sustancia(id_sustancia),
foreign key (id_ElementoDelTiempo_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE ActividadFisica(
id_actividadFisica int primary key identity,
nombre text,
descripcion text)

CREATE TABLE GradoActividad(
id_gradoActividad int primary key identity,
nombre text,
descripcion text)

CREATE TABLE IntensidadActividadFisica(
id_intensidad int primary key identity,
nombre text)


CREATE TABLE HabitosActividadFisica(
id_habitoActividadFisica int primary key identity,
id_actividadFisica_fk int,
id_gradoActividadFisica_fk int,
id_intensidad_fk int,
fechaRegistro date not null,
id_hc_fk int not null,
foreign key (id_actividadFisica_fk) references ActividadFisica(id_actividadFisica),
foreign key (id_gradoActividadFisica_fk) references GradoActividad(id_gradoActividad),
foreign key (id_intensidad_fk) references IntensidadActividadFisica(id_intensidad),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))


CREATE TABLE ElementoQueFuma(
id_elemento int primary key identity,
nombre text)

CREATE TABLE HabitosTabaquismo(
id_habitoFumar int primary key identity,
cantidad int,
id_elementoQueFuma_fk int,
id_ComponenteDelTiempo_fk int,
añosFumando int,
fechaRegistro date not null,
id_hc_fk int not null,
foreign key (id_elementoQueFuma_fk) references ElementoQueFuma(id_elemento),
foreign key (id_ComponenteDelTiempo_fk) references ComponenteDelTiempo(id_componenteTiempo),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE DescripcionDelTiempo(
id_descripcionDelTiempo int primary key identity,
nombre text)

CREATE TABLE DejoDeFumar(
id_DejoDeFumar int primary key identity,
cantidadTiempo int,
id_elementoDelTiempo_fk int,
id_descripcionTiempo_fk int,
cantidadFumaba int,
id_elementoQueFuma_fk int,
id_componenteTiempo_fk int,
id_habitoTabaquismo_fk int not null,
foreign key (id_descripcionTiempo_fk) references DescripcionDelTiempo(id_descripcionDelTiempo),
foreign key (id_elementoDelTiempo_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_elementoQueFuma_fk) references ElementoQueFuma(id_elemento),
foreign key (id_componenteTiempo_fk) references ComponenteDelTiempo(id_componenteTiempo),
foreign key (id_habitoTabaquismo_fk) references HabitosTabaquismo(id_habitoFumar))

CREATE TABLE ProgramacionMedicamento(
id_programacionMedicamento int primary key identity,
id_especificacionMedicamento_fk int,
id_medicamento_fk int,
id_frecuencia_fk int,
fechaDesde date,
fechaHasta date,
id_momentoDia1_fk int,
cantidadNumerador1 int,
cantidadDenominador1 int,
id_presentacionMedicamento1_fk int,
hora1 time,
id_momentoDia2_fk int,
cantidadNumerador2 int,
cantidadDenominador2 int,
id_presentacionMedicamento2_fk int,
hora2 time,
id_momentoDia3_fk int,
cantidadNumerador3 int,
cantidadDenominador3 int,
id_presentacionMedicamento3_fk int,
hora3 time,
motivoConsumo text,
cantidadTiempoConsumo int,
id_elementoDelTiempo1_fk int,
motivoCancelacionConsumo text,
tiempoDeCancelacion int,
id_elementoDelTiempo2_fk int, 
automedicado varchar(20),
id_estado_fk int,
id_examenGeneral_fk int,
id_tratamiento_fk int,
foreign key (id_especificacionMedicamento_fk,id_medicamento_fk) references EspecificacionMedicamento(id_especificacion, id_medicamento_fk),
foreign key (id_frecuencia_fk) references Frecuencia(id_frecuencia),
foreign key (id_momentoDia1_fk) references MomentoDelDia(id_momentoDelDia),
foreign key (id_presentacionMedicamento1_fk) references PresentacionMedicamento(id_presentacionMedicamento),
foreign key (id_momentoDia2_fk) references MomentoDelDia(id_momentoDelDia),
foreign key (id_presentacionMedicamento2_fk) references PresentacionMedicamento(id_presentacionMedicamento),
foreign key (id_momentoDia3_fk) references MomentoDelDia(id_momentoDelDia),
foreign key (id_presentacionMedicamento3_fk) references PresentacionMedicamento(id_presentacionMedicamento),
foreign key (id_elementoDelTiempo1_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_elementoDelTiempo2_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_estado_fk) references EstadoProgramacion(id_EstadoProgramacion),
foreign key (id_examenGeneral_fk) references ExamenGeneral(id_ExamenGeneral),
foreign key (id_tratamiento_fk) references Tratamiento(id_tratamiento))


CREATE TABLE HabitosMedicamento(
id_habitoMedicamento int primary key identity,
id_hc_fk int not null,
id_programacionMedicamento_fk int,
fechaRegistro date not null,
foreign key (id_programacionMedicamento_fk) references ProgramacionMedicamento(id_programacionMedicamento),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))





CREATE TABLE SitioMedicionTemperatura(
id_sitioMedicionTemperatura int primary key identity,
nombre text)

CREATE TABLE ResultadoTemperatura(
id_resultadoTemperatura int primary key identity,
nombre text,
valorMaximo float,
valorMinimo float)

CREATE TABLE Temperatura(
id_temperatura int primary key identity,
id_sitioMedicio_fk int,
temperaturaGradosCentigrados float,
id_resultadoTemperatura_fk int,
id_examenGeneral_fk int not null,
foreign key (id_sitioMedicio_fk) references SitioMedicionTemperatura(id_sitioMedicionTemperatura),
foreign key (id_resultadoTemperatura_fk) references ResultadoTemperatura(id_resultadoTemperatura),
foreign key (id_examenGeneral_fk) references ExamenGeneral(id_examenGeneral))

CREATE TABLE Ubicacion(
id_ubicacion int primary key identity,
nombre text)

CREATE TABLE Tamaño(
id_tamaño int primary key identity,
nombre text)

CREATE TABLE Consistencia(
id_consistencia int primary key identity,
nombre text)

CREATE TABLE SistemaLinfatico(
id_sistemaLinfatico int primary key identity,
id_ubicacion_fk int,
id_tamaño_fk int,
aproximacionNumerica int,
id_consistencia_fk int,
id_examenGeneral_fk int,
descripcion text,
sePalpaConLimitesPrecisos varchar(20),
tiendeAConfluir varchar(20),
sePuedeMovilizarConDedos varchar(20),
adheridaPlanosProfundos varchar(20),
procesoInflamatorioComprometePiel text,
lesion text,
observaciones text,
foreign key (id_ubicacion_fk) references Ubicacion(id_ubicacion),
foreign key (id_tamaño_fk) references Tamaño(id_tamaño),
foreign key (id_consistencia_fk) references Consistencia(id_consistencia),
foreign key (id_examenGeneral_fk) references ExamenGeneral(id_examenGeneral))



CREATE TABLE DetallePulsoArterial(
id_pulsoArterial int,
id_detallePulsoArterial int identity,
id_derecha_fk int,
id_izquierda_fk int,
id_pulso_fk int,
primary key(id_pulsoArterial,id_detallePulsoArterial),
foreign key (id_pulsoArterial) references PulsoArterial(id_pulsoArterial),
foreign key (id_derecha_fk) references EscalaPulso(id_escalaPulso),
foreign key (id_izquierda_fk) references EscalaPulso(id_escalaPulso),
foreign key (id_pulso_fk) references Pulso(id_pulso))


CREATE TABLE Nota(
id_nota int primary key identity,
fechaNota date,
descripcion text,
id_tratamiento_fk int not null)



CREATE TABLE PracticaComplementaria(
id_practicaComplementaria integer PRIMARY KEY IDENTITY,
fechaSolicitud date,
fechaRealizacion date,
doctorACargo varchar(50),
id_institucion_fk integer,
observacionDeLosResultados text,
indicaciones text,
informe text,
id_tipoPractica_fk int not null,
id_razonamientoDiagnostico_fk int not null,
FOREIGN KEY (id_institucion_fk) REFERENCES Institucion(id_institucion),
FOREIGN KEY (id_tipoPractica_fk) REFERENCES TipoPracticaComplementaria(id_tipoPractica),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento))

CREATE TABLE Laboratorio(
id_laboratorio integer PRIMARY KEY IDENTITY,
fechaSolicitud date not null,
fechaRealizacion date,
doctorACargo varchar(50),
id_institucion_fk integer,
observacionDeLosResultados text,
indicaciones text,
id_analisisLaboratorio_fk int not null,
id_metodoAnalisisLaboratorio_fk int ,
id_razonamientoDiagnostico_fk int not null,
FOREIGN KEY (id_institucion_fk) REFERENCES Institucion(id_institucion),
FOREIGN KEY (id_analisisLaboratorio_fk) REFERENCES AnalisisLaboratorio(id_analisisLaboratorio),
FOREIGN KEY (id_metodoAnalisisLaboratorio_fk) REFERENCES MetodoAnalisisLaboratorio(id_metodo),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento))


CREATE TABLE ItemEstudioLaboratorio(
id_itemEstudioLaboratorio integer IDENTITY,
id_itemLaboratorio_fk int,
PRIMARY KEY(id_itemEstudioLaboratorio),
FOREIGN KEY(id_itemLaboratorio_fk) references itemLaboratorio (id_itemLaboratorio))

create table DetalleLaboratorio(
id_detalleLaboratorio int identity,
valorResultado float,
id_unidadMedida_fk int,
id_itemEstudioLaboratorio_fk int,
id_laboratorio_fk int,
constraint id_detallelaboratorio_pk primary key (id_detalleLaboratorio),
constraint id_unidadMedida_fk foreign key (id_unidadMedida_fk) references UnidadMedida(id_unidadMedida),
constraint id_itemEstudioLaboratorio_fk foreign key (id_itemEstudioLaboratorio_fk) references ItemEstudioLaboratorio(id_itemEstudioLaboratorio),
constraint id_laboratorio_fk foreign key (id_laboratorio_fk) references Laboratorio(id_laboratorio))

CREATE TABLE DetalleItemLaboratorio(
id_detalleItemLaboratorio integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
valorDesde float,
valorHasta float,
id_unidadMedida_fk int ,
id_item_fk integer not null,
FOREIGN KEY (id_item_fk) references ItemEstudioLaboratorio(id_itemEstudioLaboratorio),
FOREIGN KEY (id_unidadMedida_fk) REFERENCES UnidadMedida(id_unidadMedida))


CREATE TABLE DetalleValorReferencia(
id_detalleValorReferencia integer PRIMARY KEY IDENTITY,
descripcion varchar(200),
valorDesde float not null,
valorHasta float not null,
id_unidadMedida_fk int,
id_detalleItemLaboratorio_fk integer not null,
foreign key (id_unidadMedida_fk) references UnidadMedida(id_unidadMedida),
FOREIGN KEY (id_detalleItemLaboratorio_fk) REFERENCES DetalleItemLaboratorio(id_detalleItemLaboratorio))






/*CREATE TABLE EstadoHipotesis(
id_estadoHipotesis int primary key identity,
nombre text)*/

/*CREATE TABLE HipotesisInicial(
id_razonamientoDiagnostico_fk int,
id_hipotesis int identity,
descripcion text,
id_estadoHipotesis_fk int,
motivoDescartar text,
primary key (id_hipotesis,id_razonamientoDiagnostico_fk),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento),
foreign key (id_estadoHipotesis_fk) references EstadoHipotesis(id_estadoHipotesis))*/

/*CREATE TABLE DiagnosticoDefinitivo(
id_razonamientoDiagnostico_fk int,
id_diagnostico int identity,
descripcion text,
evolucion text
primary key (id_diagnostico,id_razonamientoDiagnostico_fk),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento))
*/
create table NombreEstudio(
id_nombreEstudio int primary key identity,
nombre text,
descricpcion text)

create table EstudiosDiagnosticoPorImagen(
id_estudioDiagnosticoPorImagen int identity,
fechaSolicitud date not null,
fechaRealizacion date,
doctorACargo varchar(50),
id_institucion_fk integer,
observacionDeLosResultados text,
indicaciones text,
informe text,
id_nombreEstudio_fk int not null,
id_razonamientoDiagnostico_fk int not null,
primary key(id_estudioDiagnosticoPorImagen),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento),
foreign key (id_nombreEstudio_fk) references NombreEstudio(id_nombreEstudio))

CREATE TABLE Consulta(
id_consulta int primary key identity,
nroConsulta int not null,
fechaConsulta date,
horaConsulta time,
motivoConsulta text,
id_examenGeneral_fk int,
id_hc_fk int,
foreign key (id_examenGeneral_fk) references ExamenGeneral(id_examenGeneral),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

CREATE TABLE TipoSintoma(
id_TipoSintoma int primary key identity,
nombre nvarchar(50) not null)

CREATE TABLE ParteDelCuerpo(
id_parteDelCuerpo int primary key identity,
nombre nvarchar(50) not null)

CREATE TABLE ModificacionSintoma(
id_modificacionesSintoma int primary key identity,
nombre nvarchar(50) not null)

CREATE TABLE ElementoDeModificacion(
id_elementoDeModificacion int primary key identity,
nombre nvarchar(50) not null)

CREATE TABLE CaracterDelDolor(
id_caracterDelDolor int primary key identity,
nombre nvarchar(50) not null)

CREATE TABLE Sintoma(
id_Sintoma int primary key identity,
fechaInicioSintoma date,
cantidadDeTiempo int,
id_elementoDelTiempo_fk int,
id_descripcionDelTiempo_fk int,
id_tipoSintoma_fk int,
descripcion text,
id_parteDelCuerpo_fk int,
haciaDondeIrradia text,
id_comoSeModifica_fk int,
id_elementoDeModificacion_fk int,
id_caracterDolor_fk int,
observaciones text,
id_hc_fk int,
fechaRegistro date,
id_consulta_fk int,
foreign key (id_elementoDelTiempo_fk) references ElementoDelTiempo(id_elementoDelTiempo),
foreign key (id_descripcionDelTiempo_fk) references DescripcionDelTiempo(id_descripcionDelTiempo),
foreign key (id_tipoSintoma_fk) references TipoSintoma(id_tipoSintoma),
foreign key (id_parteDelCuerpo_fk) references ParteDelCuerpo(id_parteDelCuerpo),
foreign key (id_comoSeModifica_fk) references ModificacionSintoma(id_modificacionesSintoma),
foreign key (id_elementoDeModificacion_fk) references ElementoDeModificacion(id_elementoDeModificacion),
foreign key (id_caracterDolor_fk) references CaracterDelDolor(id_caracterDelDolor),
foreign key (id_hc_fk) references Historia_Clinica(id_hc),
foreign key (id_consulta_fk) references Consulta(id_consulta))







CREATE TABLE DetalleMedicionPresionArterial(
id_nroMedicion int,
id_medicion_fk int,
hora time,
pulso int,
valorMaximo int,
valorMinimo int,
primary key (id_nroMedicion,id_medicion_fk),
foreign key (id_medicion_fk) references MedicionDePrecionArterial(id_medicion))





Create table ProgramacionXMedicamento(
id_programacionMedicamento_fk int not null,
id_medicamento_fk int not null,
foreign key(id_programacionMedicamento_fk) references ProgramacionMedicamento(id_programacionMedicamento),
foreign key(id_medicamento_fk) references Medicamento(id_medicamento))


create table Familiar(
id_familiar int primary key identity,
nombre text)


create table UnidadMedidaXMedicamento(
id_medicamento_fk int,
id_unidadMedida_fk int,
id_nombreComercial_fk int,
primary key(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk),
foreign key(id_medicamento_fk) references Medicamento(id_medicamento),
foreign key(id_unidadMedida_fk) references UnidadMedida(id_unidadMedida),
foreign key(id_nombreComercial_fk) references NombreComercial(id_nombreComercial))

create table FormaAdministracionXMedicamento(
id_medicamento_fk int,
id_formaAdministracion_fk int,
id_nombreComercial_fk int,
primary key(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk),
foreign key(id_medicamento_fk) references Medicamento(id_medicamento),
foreign key(id_formaAdministracion_fk) references FormaAdministracion(id_formaAdministracion),
foreign key(id_nombreComercial_fk) references NombreComercial(id_nombreComercial))

create table PresentacionMedicamentoXMedicamento(
id_medicamento_fk int,
id_presentacionMedicamento_fk int,
id_nombreComercial_fk int,
primary key(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk),
foreign key(id_medicamento_fk) references Medicamento(id_medicamento),
foreign key(id_presentacionMedicamento_fk) references PresentacionMedicamento(id_presentacionMedicamento),
foreign key(id_nombreComercial_fk) references NombreComercial(id_nombreComercial))





create table AntecedentesFamiliares(
id_antecedenteFamiliar int primary key identity,
fechaRegistro date,
id_familiar_fk int,
familiarVive varchar(20),
enfermedades text,
descripcionOtrasEnfermedades text,
causaMuerte text,
observaciones text,
id_hc_fk int,
foreign key (id_familiar_fk) references Familiar(id_familiar),
foreign key (id_hc_fk) references Historia_Clinica(id_hc))

create table AntecedentesPatologicosPersonales(
id_antecedentePatologicoPersonal int identity,
fechaRegistro date,
enfermedades text,
descripcion_otrasEnfermedades text,
id_hc_fk int,
constraint antecedentePatologicoPersonal_pk primary key(id_antecedentePatologicoPersonal),
constraint antecedentePatologicoPersonal_fk foreign key (id_hc_fk) references Historia_Clinica (id_hc))



