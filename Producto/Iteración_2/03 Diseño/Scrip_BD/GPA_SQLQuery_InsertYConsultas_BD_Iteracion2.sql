--Insert into TipoDocumento(nombre,descripcion)
--values ('DNI','Documento nacional de identidad')

--/*Insert de usuarios*/
--Insert into Usuario(nombre_usuario,contrase�a,fecha_creacion)
--values ('JuanRod',PWDENCRYPT(123),TRY_CONVERT(date,'25/05/2020',103))

--Insert into Usuario(nombre_usuario,contrase�a,fecha_creacion)
--values ('MartinM',PWDENCRYPT(111),TRY_CONVERT(date,'25/05/2020',103))

--insert into Usuario(nombre_usuario,contrase�a,fecha_creacion) 
--values ('LJ',PWDENCRYPT(102030),'16/06/2016')

--select PWDCOMPARE('LJ102030',u.contrase�a)
--from Usuario u
--where u.nombre_usuario like 'LJ';

--Delete 
--from Usuario where nombre_usuario like 'LJ'

--delete 
--from ProfesionalMedico where nombre like 'Luis'

/*-----------------*/


--Insert into Estado(nombre,descripcion)
--values ('Activo', 'El usuario concurre regularmente al consultorio')

--Insert into Localidad(nombre)
--values('C�rdoba')

--Insert into Barrio(nombre,descripcion,id_localidad_fk)
--values('Las Margaritas','barrio de la zona norte de la ciudad de cordoba',1)

--Insert into Barrio(nombre,descripcion,id_localidad_fk)
--values('Las Magnolias','barrio de la zona norte de la ciudad de cordoba',1)

--Insert into Barrio(nombre,descripcion,id_localidad_fk)
--values('Las France','barrio de la zona norte de la ciudad de cordoba',1)

--Insert into Domicilio(calle,numero,codigo_postal,piso ,departamento,id_barrio_fk)
--values ('Bv. Los Granaderos', '3000', '5008',null,null,2)

--Insert into Domicilio(calle,numero,codigo_postal,piso ,departamento,id_barrio_fk)
--values ('Quinquela Martin', '210', '5008',null,null,3)

--Insert into Domicilio(calle,numero,codigo_postal,piso ,departamento,id_barrio_fk)
--values ('Las Verientes', '210', '5008',null,null,4)
--select * from ProfesionalMedico

--Insert into Especialidad(nombre, descripcion)
--values ('Nefrolog�a','Parte de la medicina que se ocupa de la anatom�a, la fisiolog�a y las enfermedades del ri��n.')

--Insert into Sexo(nombre)
--values('Masculino')

--Insert into Sexo(nombre)
--values('Femenino')

/*-------Insert M�dicos-----*/
--insert into ProfesionalMedico(id_tipoDoc_fk,nro_documento,nombre,apellido,fechaNacimiento,matricula,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,id_especialidad_fk)
--values (1,'15036547','Luis','Juncos',TRY_CONVERT(date,'25/05/2020',103),'222545','4760021','152568741','LuisJuncos@hotmail.com','6','1','1')
--/*-------------------------*/

--/*-------Insert Pacientes-----*/
--Insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_nacimiento,edad,altura,peso,id_hc_fk,id_domicilio_fk,id_profesionalMedico_tipoDoc_fk,id_profesionalMedico_nroDoc_fk,id_sexo_fk)
--values(1,'20258789','Juan','Rodriguez','7489523','152789800','juanRod@hotmail.com','8','1',TRY_CONVERT(date,'10/03/1977',103),'39',1.98,'72',null,'3','1','15036547',1)

--Insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_nacimiento,edad,altura,peso,id_hc_fk,id_domicilio_fk,id_profesionalMedico_tipoDoc_fk,id_profesionalMedico_nroDoc_fk,id_sexo_fk)
--values(1,'20000325','Mart�n','Molina','74700000','152801200','martinM@hotmail.com','9','1',TRY_CONVERT(date,'20/03/1977',103),'35',1.65,'70',null,'4','1','15036547',1)
--/*--------------------------*/

/*-------InsertSintoma-----*/
--insert into TipoSintoma(nombre)
--values('--Seleccionar--')

--insert into TipoSintoma(nombre)
--values('Dolor')

--insert into TipoSintoma(nombre)
--values('Molestia')

--select * from TipoSintoma

/*--------------------------*/

/*-------Insert Parte del cuerpo-----*/
--insert into ParteDelCuerpo(nombre)
--values('--Seleccionar--')

--insert into ParteDelCuerpo(nombre)
--values('Cabeza')

--insert into ParteDelCuerpo(nombre)
--values('Cuello')

--insert into ParteDelCuerpo(nombre)
--values('Garganta')

--insert into ParteDelCuerpo(nombre)
--values('Espalda')

--insert into ParteDelCuerpo(nombre)
--values('Cintura')

/*--------------------------*/

/*-------Insert Car�cter del dolor-----*/
--insert into CaracterDelDolor(nombre)
--values('--Seleccionar--')

--insert into CaracterDelDolor(nombre)
--values('C�lico')

--insert into CaracterDelDolor(nombre)
--values('Urente')

--insert into CaracterDelDolor(nombre)
--values('Dolor de car�cter sordo')

--insert into CaracterDelDolor(nombre)
--values('Constrictivo')

--insert into CaracterDelDolor(nombre)
--values('Pulsatil')

--insert into CaracterDelDolor(nombre)
--values('Neuralgia')

--insert into CaracterDelDolor(nombre)
--values('Pungitivo o de tipo punzante')

--insert into CaracterDelDolor(nombre)
--values('Fulgurante')

--insert into CaracterDelDolor(nombre)
--values('Terebrante')

/*--------------------------*/

/*-------Insert Elementos del tiempo-----*/
--insert into ElementoDelTiempo(nombre)
--values('--Seleccionar--')

--insert into ElementoDelTiempo(nombre)
--values('D�as')

--insert into ElementoDelTiempo(nombre)
--values('Meses')

--insert into ElementoDelTiempo(nombre)
--values('A�os')


/*--------------------------*/

/*-------Insert Descripci�n del tiempo-----*/

--insert into DescripcionDelTiempo(nombre)
--values('--Seleccionar--')

--insert into DescripcionDelTiempo(nombre)
--values('Antenoche')

--insert into DescripcionDelTiempo(nombre)
--values('Hace tres d�as')

--insert into DescripcionDelTiempo(nombre)
--values('La semana pasada')

/*--------------------------*/

/*-------Insert Modificaci�nS�ntoma-----*/

select * from ModificacionSintoma
--insert into ModificacionSintoma(nombre)
--values('--Seleccionar--')

--insert into ModificacionSintoma(nombre)
--values('Aumentando')

--insert into ModificacionSintoma(nombre)
--values('Disminuyendo')

--insert into ModificacionSintoma(nombre)
--values('No se modifica')

/*--------------------------*/

/*-------Insert ElementoDeModificacion-----*/
select * from ElementoDeModificacion

insert into ElementoDeModificacion(nombre)
values('--Seleccionar--')

insert into ElementoDeModificacion(nombre)
values('Alimentos')

insert into ElementoDeModificacion(nombre)
values('Posiciones corporales')
/*--------------------------*/

/*-------Insert TiposAntecedentesM�rbidos-----*/
--delete from TiposAntecedentesMorbidos 

--insert into TiposAntecedentesMorbidos(nombre)
--values('Enfermedad')

--insert into TiposAntecedentesMorbidos(nombre)
--values('Operaci�n')

--insert into TiposAntecedentesMorbidos(nombre)
--values('Traumatismo')
/*--------------------------*/

/*-------Insert Enfermedades-----*/
--insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
--values('Hipertensi�n Arterial','1')

--insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
--values('Diabetes Mellitus','1')

--insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
--values('Epilepsia','1')

--insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
--values('Asma','1')
/*--------------------------*/


/*-------Insert Operaciones-----*/
--insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
--values('Apendicectom�a','2')

--insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
--values('Cirug�a de cataratas','2')

--insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
--values('Ces�rea','2')

--insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
--values('Bypass de arteria coronaria','2')
/*--------------------------*/

/*-------Insert Traumatismos-----*/
--insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
--values('Traumatismo de cr�neo','3')

--insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
--values('Traumatismo de cara','3')

--insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
--values('Traumatismo de columna vertebral','3')
/*--------------------------*/

/*-------Insert TipoParto-----*/

--insert into TipoParto(nombre)
--values('--Seleccionar--')

--insert into TipoParto(nombre)
--values('Cesarea')

--insert into TipoParto(nombre)
--values('Natural')
--/*--------------------------*/

--/*-------Insert TipoAborto-----*/


--insert into TipoAborto(nombre)
--values('--Seleccionar--')

--insert into TipoAborto(nombre)
--values('Espont�neo')

--insert into TipoAborto(nombre)
--values('Provocado')
--/*--------------------------*/

--/*-------Insert Familiar-----*/
--delete from Familiar

--insert into Familiar(nombre)
--values('--Seleccionar--')

--insert into Familiar(nombre)
--values('Madre')

--insert into Familiar(nombre)
--values('Padre')

--insert into Familiar(nombre)
--values('Hermano')

--insert into Familiar(nombre)
--values('Hermana')


/*--------------------------*/

/*-------Insert Alimento-----*/

--insert into Alimento(nombre)
--values('--Seleccionar--')

--insert into Alimento(nombre)
--values('Pescado')

--insert into Alimento(nombre)
--values('Leche')

--insert into Alimento(nombre)
--values('Man�')

--insert into Alimento(nombre)
--values('Soja')

--insert into Alimento(nombre)
--values('Nuez')

--insert into Alimento(nombre)
--values('Trigo')

--insert into Alimento(nombre)
--values('Huevo')

/*--------------------------*/

/*-------Insert SustanciasAmbiente-----*/


--insert into SustanciaAmbiente(nombre)
--values('--Seleccionar--')

--insert into SustanciaAmbiente(nombre)
--values('P�lenes')

--insert into SustanciaAmbiente(nombre)
--values('Mohos')

--insert into SustanciaAmbiente(nombre)
--values('�caros')

--insert into SustanciaAmbiente(nombre)
--values('Hongos')

/*--------------------------*/

/*-------Insert SustanciaContactoPiel-----*/
delete from SustanciaContactoPiel

--insert into SustanciaContactoPiel(nombre)
--values('--Seleccionar--')

--insert into SustanciaContactoPiel(nombre)
--values('Tinturas para cabello')

--insert into SustanciaContactoPiel(nombre)
--values('Plaguisidas')

--insert into SustanciaContactoPiel(nombre)
--values('Guantes de caucho')

--insert into SustanciaContactoPiel(nombre)
--values('Shampoos')
/*--------------------------*/

/*-------Insert Insectos-----*/


--insert into Insecto(nombre)
--values('--Seleccionar--')

--insert into Insecto(nombre)
--values('Abejas')

--insert into Insecto(nombre)
--values('Avispas')

--insert into Insecto(nombre)
--values('Hormigas')

--/*--------------------------*/

--/*-------Insert Medicamento-----*/

--insert into MedicamentoAlergia(nombre)
--values('--Seleccionar--')

--insert into MedicamentoAlergia(nombre)
--values('Penicilina')

--insert into MedicamentoAlergia(nombre)
--values('Anest�sicos locales')

--insert into MedicamentoAlergia(nombre)
--values('Sulfamidas')

--insert into MedicamentoAlergia(nombre)
--values('Relajantes musculares')

--insert into MedicamentoAlergia(nombre)
--values('Insulina no humana')

--insert into MedicamentoAlergia(nombre)
--values('Contrastes yodados')
/*--------------------------*/

/*-------Insert ElementoQueFuma-----*/
delete from ElementoQueFuma

--insert into ElementoQueFuma(nombre)
--values('--Seleccionar--')

--insert into ElementoQueFuma(nombre)
--values('Cigarrillos')

--insert into ElementoQueFuma(nombre)
--values('Etiquetas')

select * from ComponenteDelTiempo

/*--------------------------*/


/*-------Insert ComponenteTiempo-----*/


--insert into ComponenteDelTiempo(nombre)
--values('--Seleccionar--')

--insert into ComponenteDelTiempo(nombre)
--values('D�a')

--insert into ComponenteDelTiempo(nombre)
--values('Mes')

--insert into ComponenteDelTiempo(nombre)
--values('A�o')
/*--------------------------*/


/*-------Insert TipoBebida-----*/

--insert into TipoBebida(nombre)
--values('--Seleccionar--')

--insert into TipoBebida(nombre)
--values('Vino')

--insert into TipoBebida(nombre)
--values('Cerveza')

--insert into TipoBebida(nombre)
--values('Whisky')

--insert into TipoBebida(nombre)
--values('Tequila')

--insert into TipoBebida(nombre)
--values('Ron')

--insert into TipoBebida(nombre)
--values('Vodka')


/*--------------------------*/

/*-------Insert Medida-----*/

select *
from Medida
--insert into Medida(nombre)
--values('--Seleccionar--')

--insert into Medida(nombre, descripcion)
--values('Vaso largo','Su capacidad aproximada ronda los 235 y los 355 ml')

--insert into Medida(nombre, descripcion)
--values('Vaso corto','Su capacidad aproximada ronda los 30 y los 120 ml')

alter table Medida
add descripcion text
/*--------------------------*/

/*-------Insert SustanciasDrogasIlicitas-----*/

--insert into Sustancia(nombre)
--values('--Seleccionar--')

--insert into Sustancia(nombre)
--values('Coca�na')

--insert into Sustancia(nombre)
--values('Hero�na')


/*--------------------------*/

/*-------Insert NombreComercial de medicamentos-----*/
--insert into NombreComercial(nombre)
--values('DIUREX')

--/*--------------------------*/

--/*-------Insert UnidadMedida-----*/
--insert into UnidadMedida(nombre,descripcion)
--values('g.','Gramos')
--insert into UnidadMedida(nombre,descripcion)
--values('mg.','Miligramos')
--insert into UnidadMedida(nombre)
--values('ng/dl')
--insert into UnidadMedida(nombre)
--values('ug/24hs')
--insert into UnidadMedida(nombre)
--values('ml/24hs')
/*--------------------------*/

/*-------Insert FormaAdministracion-----*/
--insert into FormaAdministracion(nombre)
--values('V�a oral')

--insert into FormaAdministracion(nombre)
--values('V�a sublingual')

--insert into FormaAdministracion(nombre)
--values('V�a gastroent�rica')

--insert into FormaAdministracion(nombre)
--values('V�a intravenosa')

--insert into FormaAdministracion(nombre)
--values('V�a intramuscular')

--insert into FormaAdministracion(nombre)
--values('V�a subcut�nea')
/*--------------------------*/


/*-------Insert Medicamentos-----*/
--insert into Medicamento(nombreGenerico)
--values('HIDROCLOROTIAZIDA')

/*--------------------------*/
/*-------Insert Presentaci�nMedicamento-----*/
--insert into PresentacionMedicamento(nombre)
--values('Comprimidos')

/*--------------------------*/

/*-------Insert Frecuencia-----*/


--insert into Frecuencia(nombre)
--values('--Seleccionar--')

--insert into Frecuencia(nombre)
--values('Diaria')
/*--------------------------*/

/*-------Insert MomentoDelDia-----*/


--insert into MomentoDelDia(nombre)
--values('--Seleccionar--')
--insert into MomentoDelDia(nombre)
--values('Ma�ana')
--insert into MomentoDelDia(nombre)
--values('Tarde')
--insert into MomentoDelDia(nombre)
--values('Noche')


/*--------------------------*/

/*-------Insert ActividadFisica-----*/


--insert into ActividadFisica(nombre)
--values('--Seleccionar--')
--insert into ActividadFisica(nombre)
--values('Futbol')
--insert into ActividadFisica(nombre)
--values('Basquet')
--insert into ActividadFisica(nombre)
--values('Voley')
/*--------------------------*/

/*-------Insert GradoActividad-----*/


--insert into GradoActividad(nombre)
--values('--Seleccionar--')
--insert into GradoActividad(nombre,descripcion)
--values('Bajo','Menos de 30 minutos de actividad f�sica por semana.')
--insert into GradoActividad(nombre,descripcion)
--values('Medio','Correspondiente a 30 minutos de 3-5 veces por semana.')
--insert into GradoActividad(nombre,descripcion)
--values('Alto','Correspondiente a 30 minutos o mas de actividad f�sica y m�s de 5 veces a la semana.')
/*--------------------------*/

/*-------Insert IntensidadActividadFisica-----*/
delete from IntensidadActividadFisica

--insert into IntensidadActividadFisica(nombre)
--values('--Seleccionar--')
--insert into IntensidadActividadFisica(nombre)
--values('Muy suave')
--insert into IntensidadActividadFisica(nombre)
--values('Suave')
--insert into IntensidadActividadFisica(nombre)
--values('Moderado')
--insert into IntensidadActividadFisica(nombre)
--values('Intenso')
--insert into IntensidadActividadFisica(nombre)
--values('M�ximo')

/*--------------------------*/

/*-------Insert EstadoProgramacion-----*/
--insert into EstadoProgramacion(nombre)
--values('Activa')
--insert into EstadoProgramacion(nombre)
--values('Cancelada')

/*--------------------------*/

/*-------Insert Ubicaci�n-----*/
--insert into Ubicacion(nombre)
--values('--Seleccionar--')
--insert into Ubicacion(nombre)
--values('Regi�n Occipital')
--insert into Ubicacion(nombre)
--values('Regi�n Masto�deas')
--insert into Ubicacion(nombre)
--values('Regi�n Preauriculares')
--insert into Ubicacion(nombre)
--values('Regi�n Submandibulares')
--insert into Ubicacion(nombre)
--values('Regi�n Cervical Anterior')
--insert into Ubicacion(nombre)
--values('Regi�n Cervical Lateral')
--insert into Ubicacion(nombre)
--values('Regi�n Cervical Posterior')
--insert into Ubicacion(nombre)
--values('Huecos Supraclaviculares')
--insert into Ubicacion(nombre)
--values('Regi�n Epitroclear derecha')
--insert into Ubicacion(nombre)
--values('Regi�n Epitroclear izquierda')
--insert into Ubicacion(nombre)
--values('Ax�la derecha')
--insert into Ubicacion(nombre)
--values('Ax�la izquierda')
--insert into Ubicacion(nombre)
--values('Regi�nes Inguinal derecha')
--insert into Ubicacion(nombre)
--values('Regi�nes Inguinal izquierda')
/*--------------------------*/

/*-------Insert Ubicaci�n-----*/
--insert into Tama�o(nombre)
--values('--Seleccionar--')
--insert into Tama�o(nombre)
--values('Normal')
--insert into Tama�o(nombre)
--values('Grande')
--/*--------------------------*/

--/*-------Insert Consistencia-----*/
--insert into Consistencia(nombre)
--values('--Seleccionar--')
--insert into Consistencia(nombre)
--values('El�stica (Normal)')
--insert into Consistencia(nombre)
--values('Muy duro')
--insert into Consistencia(nombre)
--values('Muy blando')
/*--------------------------*/

/*-------Insert Escala Pulso-----*/
--insert into EscalaPulso(nombre)
--values('--Seleccionar--')
--insert into EscalaPulso(nombre)
--values('No se palpan')
--insert into EscalaPulso(nombre)
--values('Se palpan disminuidos')
--insert into EscalaPulso(nombre)
--values('Se palpan normales')
--insert into EscalaPulso(nombre)
--values('Se palpan aumentados')
--insert into EscalaPulso(nombre)
--values('Se palpan muy aumentados')
--/*--------------------------*/

--/*-------Insert Escala Pulso-----*/
--insert into Pulso(nombre)
--values('--Seleccionar--')
--insert into Pulso(nombre)
--values('P. Carot�deo')
--insert into Pulso(nombre)
--values('P. Axilar')
--insert into Pulso(nombre)
--values('P. Branquial')
--insert into Pulso(nombre)
--values('P. Radial')
--insert into Pulso(nombre)
--values('P. Femoral')
--insert into Pulso(nombre)
--values('P. Popl�teo')
--insert into Pulso(nombre)
--values('P. Tibial Posterior')
--insert into Pulso(nombre)
--values('P. Pedio')
/*--------------------------*/
/*-------Insert Extremidad-----*/
--insert into Extremidad(nombre)
--values('Miembro Superior')
--insert into Extremidad(nombre)
--values('Miembro Inferior')
/*--------------------------*/

/*-------Insert UbicacionExtremidad-----*/
--insert into UbicacionExtremidad(nombre,id_extremidad_fk)
--values('Antebrazo',1)
--insert into UbicacionExtremidad(nombre,id_extremidad_fk)
--values('Brazo',1)
--insert into UbicacionExtremidad(nombre,id_extremidad_fk)
--values('Pantorrilla',2)
--insert into UbicacionExtremidad(nombre,id_extremidad_fk)
--values('Muslo',2)
select * from UbicacionExtremidad
/*--------------------------*/


/*-------Insert AnalisisLaboratorio-----*/
--insert into AnalisisLaboratorio(nombre)
--values('--Seleccionar--')
--insert into AnalisisLaboratorio(nombre)
--values('Hemoglobina')
--insert into AnalisisLaboratorio(nombre)
--values('Glucemia en ayunas')
--insert into AnalisisLaboratorio(nombre)
--values('Triglic�ridos')
/*--------------------------*/

/*-------Insert EstudiosDiagnosticoPorImagenes-----*/
--insert into NombreEstudio(nombre)
--values('--Seleccionar--')
--insert into NombreEstudio(nombre)
--values('Ecograf�a Renal')
--insert into NombreEstudio(nombre)
--values('Tomograf�a')
--insert into NombreEstudio(nombre)
--values('Radiograf�a de T�rax')
/*--------------------------*/

/*-------Insert PracticaComplementaria-----*/
--insert into TipoPracticaComplementaria(nombre,descripcion)
--values('--Seleccionar--','')
--insert into TipoPracticaComplementaria(nombre,descripcion)
--values('Pruebas endosc�picas','Son pruebas que visualizan el interior de cavidades u �rganos huecos del cuerpo como la colonoscopia')
--insert into TipoPracticaComplementaria(nombre,descripcion)
--values('Anatom�a Patol�gica','Son pruebas que analizan una muestra de tejido o biopsia o una pieza quir�rgica tras una cirug�a. Tambi�n incluye las citolog�as.')
--insert into TipoPracticaComplementaria(nombre,descripcion)
--values('Electrocardiograma','electrocardiograma ECG, electroencefalograma EEG, electromigrama EMG')

/*--------------------------*/

/*-------Insert-----*/

/*--------------------------*/

/*-------Insert Posicion-----*/
--insert into Posicion(nombre)
--values('--Seleccionar--')
--insert into Posicion(nombre)
--values('Acostado')
--insert into Posicion(nombre)
--values('De pie')
--insert into Posicion(nombre)
--values('Sentado')
/*--------------------------*/

/*-------Insert SitioMedicion-----*/
--insert into SitioMedicion(nombre)
--values('--Seleccionar--')
--insert into SitioMedicion(nombre)
--values('Consultorio')
--insert into SitioMedicion(nombre)
--values('Hogar')
/*--------------------------*/

/*-------Insert ClasificacionPresionArterial-----*/
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('Hipotensi�n',0,90,0,60)
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('Normal',120,129,80,84)
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('Lim�trofe',130,139,85,89)
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('HTA grado o nivel 1',140,159,90,99)
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('HTA grado o nivel 2',160,999,100,999)
--insert into ClasificacionPresionArterial(categoria,maximaDesde,maximaHasta,minimaDesde,minimaHasta)
--values('HTA sist�lica o aislada',140,999,0,90)
/*--------------------------*/

/*----------------Insert SitioMedicionTemperatura----------------------------*/
--insert into SitioMedicionTemperatura(nombre)
--values('--Seleccionar--')
--insert into SitioMedicionTemperatura(nombre)
--values('Boca(Bajo la lengua)')
--insert into SitioMedicionTemperatura(nombre)
--values('Axilas')
--insert into SitioMedicionTemperatura(nombre)
--values('Pliegue inguinal')
--/*-----------------------------------------------------*/
--/*---------------Insert ResultadoTemperatura------------------------------*/
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Hipotermia',36.4,0)
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Normal',37.2,36.5)
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Fiebre ligera',38.4,37.3)
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Fiebre Moderada',39.4, 38.5)
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Fiebre alta',40.4, 39.5)
--insert into ResultadoTemperatura(nombre,valorMaximo,valorMinimo)
--values('Fiebre muy alta',45, 40.5)
/*------------------------------------------------------*/


/*---------------Terapias Terapia------------------------------*/
--insert into Terapia(nombre)
--values('--Seleccionar--')
--insert into Terapia(nombre,descripcion)
--values('Dieta','Es la cantidad de alimentos y bebidas que se le proporciona a un organismo en un periodo de 24 horas')
--insert into Terapia(nombre,descripcion)
--values('Medicamentos','Aplicaci�n de medicamentos para la prevenci�n y tratamiento de las enfermedades')
--insert into Terapia(nombre)
--values('Actividad F�sica')
--------------------*/

--/*---------------EstadoDiagnostico EstadoDiagnostico------------------------------*/
--insert into EstadoDiagnostico(nombre)
--values('--Seleccionar--')
--insert into EstadoDiagnostico(nombre)
--values('Tentativo')
--insert into EstadoDiagnostico(nombre)
--values('Definitivo')
--insert into EstadoDiagnostico(nombre)
--values('Descartado')
------------------*/

/*---------------EstadoDiagnostico TemperaturaPiel------------------------------*/
--insert into TemperaturaPiel(nombre)
--values('--Seleccionar--')
--insert into TemperaturaPiel(nombre)
--values('Normal')
--insert into TemperaturaPiel(nombre)
--values('Aumentada')
--insert into TemperaturaPiel(nombre)
--values('Disminuida')
------------------*/

