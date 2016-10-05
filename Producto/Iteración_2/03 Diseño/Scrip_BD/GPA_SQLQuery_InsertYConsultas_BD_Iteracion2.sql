Insert into TipoDocumento(nombre,descripcion)
values ('DNI','Documento nacional de identidad')

/*Insert de usuarios*/
Insert into Usuario(nombre_usuario,contraseña,fecha_creacion)
values ('JuanRod',PWDENCRYPT(123),'03/09/2016')

Insert into Usuario(nombre_usuario,contraseña,fecha_creacion)
values ('MartinM',PWDENCRYPT(111),'03/09/2016')

insert into Usuario(nombre_usuario,contraseña,fecha_creacion) 
values ('LJ',PWDENCRYPT(102030),'16/06/2016')


/*-----------------*/

Insert into Estado(nombre,descripcion)
values ('Activo', 'El usuario concurre regularmente al consultorio')

Insert into Localidad(nombre)
values('Córdoba')

Insert into Barrio(nombre,descripcion,id_localidad_fk)
values('Las Margaritas','barrio de la zona norte de la ciudad de cordoba',8)

Insert into Domicilio(calle,numero,codigo_postal,piso ,departamento,id_barrio_fk)
values ('Bv. Los Granaderos', '3000', '5008',null,null,9)

Insert into Domicilio(calle,numero,codigo_postal,piso ,departamento,id_barrio_fk)
values ('Tuyutí', '210', '5008',null,null,9)
select * from ProfesionalMedico

Insert into Especialidad(nombre, descripcion)
values ('Nefrología','Parte de la medicina que se ocupa de la anatomía, la fisiología y las enfermedades del riñón.')

Insert into Sexo(nombre)
values('Masculino')

Insert into Sexo(nombre)
values('Femenino')

/*-------Insert Médicos-----*/
insert into ProfesionalMedico(id_tipoDoc_fk,nro_documento,nombre,apellido,fechaNacimiento,matricula,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,id_especialidad_fk)
values ('8','15036547','Luis','Juncos','20/06/1950','222545','4760021','152568741','LuisJuncos@hotmail.com','24','1','6')
/*-------------------------*/

/*-------Insert Pacientes-----*/
Insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_nacimiento,edad,altura,peso,id_hc_fk,id_domicilio_fk,id_profesionalMedico_tipoDoc_fk,id_profesionalMedico_nroDoc_fk)
values(8,'20258789','Juan','Rodriguez','7489523','152789800','juanRod@hotmail.com','22','1','10/03/1977','39',1.98,'72',null,'17','8','15036547')

Insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_nacimiento,edad,altura,peso,id_hc_fk,id_domicilio_fk,id_profesionalMedico_tipoDoc_fk,id_profesionalMedico_nroDoc_fk)
values(8,'20000325','Martín','Molina','74700000','152801200','martinM@hotmail.com','23','1','20/03/1977','35',1.65,'70',null,'18','8','15036547')
/*--------------------------*/


/*-------Insert Pacientes-----*/
insert into TipoSintoma(nombre)
values('Dolor')

insert into TipoSintoma(nombre)
values('Molestia')

select * from ParteDelCuerpo
/*--------------------------*/

/*-------Insert Parte del cuerpo-----*/
insert into ParteDelCuerpo(nombre)
values('Cabeza')

insert into ParteDelCuerpo(nombre)
values('Cuello')

insert into ParteDelCuerpo(nombre)
values('Garganta')

insert into ParteDelCuerpo(nombre)
values('Espalda')

insert into ParteDelCuerpo(nombre)
values('Cintura')

/*--------------------------*/

/*-------Insert Carácter del dolor-----*/
insert into CaracterDelDolor(nombre)
values('Cólico')

insert into CaracterDelDolor(nombre)
values('Urente')

insert into CaracterDelDolor(nombre)
values('Dolor de carácter sordo')

insert into CaracterDelDolor(nombre)
values('Constrictivo')

insert into CaracterDelDolor(nombre)
values('Pulsatil')

insert into CaracterDelDolor(nombre)
values('Neuralgia')

insert into CaracterDelDolor(nombre)
values('Pungitivo o de tipo punzante')

insert into CaracterDelDolor(nombre)
values('Fulgurante')

insert into CaracterDelDolor(nombre)
values('Terebrante')

/*--------------------------*/

/*-------Insert Elementos del tiempo-----*/
insert into ElementoDelTiempo(nombre)
values('Días')

insert into ElementoDelTiempo(nombre)
values('Meses')

insert into ElementoDelTiempo(nombre)
values('Años')


/*--------------------------*/

/*-------Insert Descripción del tiempo-----*/

insert into DescripcionDelTiempo(nombre)
values('Antenoche')

insert into DescripcionDelTiempo(nombre)
values('Hace tres días')

insert into DescripcionDelTiempo(nombre)
values('La semana pasada')

/*--------------------------*/

/*-------Insert ModificaciónSíntoma-----*/
insert into ModificacionSintoma(nombre)
values('Aumentando')

insert into ModificacionSintoma(nombre)
values('Disminuyendo')

insert into ModificacionSintoma(nombre)
values('No se modifica')

select * from ElementoDeModificacion
delete from ModificacionSintoma 
/*--------------------------*/

/*-------Insert ElementoDeModificacion-----*/
insert into ElementoDeModificacion(nombre)
values('Alimentos')

insert into ElementoDeModificacion(nombre)
values('Posiciones corporales')
/*--------------------------*/

/*-------Insert TiposAntecedentesMórbidos-----*/

insert into TiposAntecedentesMorbidos(nombre)
values('Enfermedad')

insert into TiposAntecedentesMorbidos(nombre)
values('Operación')

insert into TiposAntecedentesMorbidos(nombre)
values('Traumatismo')
/*--------------------------*/

/*-------Insert Enfermedades-----*/
insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
values('Hipertensión Arterial','1')

insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
values('Diabetes Mellitus','1')

insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
values('Epilepsia','1')

insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
values('Asma','1')
/*--------------------------*/


/*-------Insert Operaciones-----*/
insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
values('Apendicectomía','2')

insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
values('Cirugía de cataratas','2')

insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
values('Cesárea','2')

insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
values('Bypass de arteria coronaria','2')
/*--------------------------*/

/*-------Insert Traumatismos-----*/
insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
values('Traumatismo de cráneo','3')

insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
values('Traumatismo de cara','3')

insert into Traumatismos(nombre,id_tipoAntecedenteMorbido_fk)
values('Traumatismo de columna vertebral','3')
/*--------------------------*/

/*-------Insert TipoParto-----*/
insert into TipoParto(nombre)
values('Cesarea')

insert into TipoParto(nombre)
values('Natural')
/*--------------------------*/

/*-------Insert TipoAborto-----*/
insert into TipoAborto(nombre)
values('Espontáneo')

insert into TipoAborto(nombre)
values('Provocado')
/*--------------------------*/

/*-------Insert Familiar-----*/
insert into Familiar(nombre)
values('Madre')

insert into Familiar(nombre)
values('Padre')

insert into Familiar(nombre)
values('Hermano')

insert into Familiar(nombre)
values('Hermana')


/*--------------------------*/

/*-------Insert Alimento-----*/
insert into Alimento(nombre)
values('Pescado')

insert into Alimento(nombre)
values('Leche')

insert into Alimento(nombre)
values('Maní')

insert into Alimento(nombre)
values('Soja')

insert into Alimento(nombre)
values('Nuez')

insert into Alimento(nombre)
values('Trigo')

insert into Alimento(nombre)
values('Huevo')

/*--------------------------*/

/*-------Insert SustanciasAmbiente-----*/
insert into SustanciaAmbiente(nombre)
values('Pólenes')

insert into SustanciaAmbiente(nombre)
values('Mohos')

insert into SustanciaAmbiente(nombre)
values('Ácaros')

insert into SustanciaAmbiente(nombre)
values('Hongos')

/*--------------------------*/

/*-------Insert SustanciaContactoPiel-----*/
insert into SustanciaContactoPiel(nombre)
values('Tinturas para cabello')

insert into SustanciaContactoPiel(nombre)
values('Plaguisidas')

insert into SustanciaContactoPiel(nombre)
values('Guantes de caucho')

insert into SustanciaContactoPiel(nombre)
values('Shampoos')
/*--------------------------*/

/*-------Insert Insectos-----*/
insert into Insecto(nombre)
values('Abejas')

insert into Insecto(nombre)
values('Avispas')

insert into Insecto(nombre)
values('Hormigas')

/*--------------------------*/

/*-------Insert Medicamento-----*/
insert into Medicamento(nombreGenerico)
values('Penicilina')

insert into Medicamento(nombreGenerico)
values('Anestésicos locales')

insert into Medicamento(nombreGenerico)
values('Sulfamidas')

insert into Medicamento(nombreGenerico)
values('Relajantes musculares')

insert into Medicamento(nombreGenerico)
values('Insulina no humana')

insert into Medicamento(nombreGenerico)
values('Contrastes yodados')
/*--------------------------*/

/*-------Insert ElementoQueFuma-----*/
insert into ElementoQueFuma(nombre)
values('Cigarrillos')

insert into ElementoQueFuma(nombre)
values('Etiquetas')

select * from ElementoDelTiempo

/*--------------------------*/


/*-------Insert ComponenteTiempo-----*/
insert into ComponenteDelTiempo(nombre)
values('Día')

insert into ComponenteDelTiempo(nombre)
values('Mes')

insert into ComponenteDelTiempo(nombre)
values('Año')
/*--------------------------*/


/*-------Insert TipoBebida-----*/
insert into TipoBebida(nombre)
values('Vino')

insert into TipoBebida(nombre)
values('Cerveza')

insert into TipoBebida(nombre)
values('Whisky')

insert into TipoBebida(nombre)
values('Tequila')

insert into TipoBebida(nombre)
values('Ron')

insert into TipoBebida(nombre)
values('Vodka')


/*--------------------------*/

/*-------Insert Medida-----*/
insert into Medida(nombre, descripcion)
values('Vaso largo','Su capacidad aproximada ronda los 235 y los 355 ml')

insert into Medida(nombre, descripcion)
values('Vaso corto','Su capacidad aproximada ronda los 30 y los 120 ml')

alter table Medida
add descripcion text
/*--------------------------*/

/*-------Insert SustanciasDrogasIlicitas-----*/
insert into Sustancia(nombre)
values('Cocaína')

insert into Sustancia(nombre)
values('Heroína')


/*--------------------------*/

/*-------Insert NombreComercial de medicamentos-----*/
insert into NombreComercial(nombre)
values('DIUREX')

/*--------------------------*/

/*-------Insert UnidadMedida-----*/
insert into UnidadMedida(nombre,descripcion)
values('g.','Gramos')
insert into UnidadMedida(nombre,descripcion)
values('mg.','Miligramos')
select * from UnidadMedida
/*--------------------------*/

/*-------Insert FormaAdministracion-----*/
insert into FormaAdministracion(nombre)
values('Vía oral')

insert into FormaAdministracion(nombre)
values('Vía sublingual')

insert into FormaAdministracion(nombre)
values('Vía gastroentérica')

insert into FormaAdministracion(nombre)
values('Vía intravenosa')

insert into FormaAdministracion(nombre)
values('Vía intramuscular')

insert into FormaAdministracion(nombre)
values('Vía subcutánea')
/*--------------------------*/


/*-------Insert Medicamentos-----*/
insert into Medicamento(nombreGenerico)
values('HIDROCLOROTIAZIDA')

/*--------------------------*/
/*-------Insert PresentaciónMedicamento-----*/
insert into PresentacionMedicamento(nombre)
values('Comprimidos')

/*--------------------------*/

/*-------Insert Frecuencia-----*/
insert into Frecuencia(nombre)
values('Diaria')
/*--------------------------*/


/*-------Insert-----*/

/*--------------------------*/

alter table Medicamento
add cantidadComprimidos int

select * from UnidadMedidaXMedicamento