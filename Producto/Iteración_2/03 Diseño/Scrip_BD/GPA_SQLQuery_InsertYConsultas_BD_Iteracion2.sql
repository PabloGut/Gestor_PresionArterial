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

/*-------Insert-----*/

/*--------------------------*/



