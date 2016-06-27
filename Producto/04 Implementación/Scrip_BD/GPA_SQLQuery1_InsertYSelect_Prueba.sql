Insert into Historia_Clinica(nro_hc,fecha_creación,diagnostico,antecedentes,fecha_inicio_atencion_con_profesional)
values ('1','15/06/2016','HTA','Sin antecedentes','15/06/2016')


Insert into Institucion(nombre,descripcion)
values ('OULTON','Diagnóstico por imagenes')

Insert into Barrio(nombre,descripcion,id_localidad_fk)
values('Centro',null,1)

Insert into Localidad(nombre)
values ('Cordoba')

Insert into Domicilio(calle,numero,codigo_postal,piso,departamento,id_institucion,id_barrio)
values ('Velez Sarfield', '2000','5000',null,null,1,2)

Insert into Domicilio(calle,numero,codigo_postal,piso,departamento,id_institucion,id_barrio)
values ('Tuyuti', '620','5008',null,null,null,4)

Insert into Estudio("fecha_estudio","doctorACargo",informe_estudio,id_hc_fk,id_institucion_fk)
values ('15/06/2016','Diaz','Normal','1','1')

select *
from Historia_Clinica



select *
from Estudio

select *
from Usuario

delete from Historia_Clinica
where nro_hc=3


select hc.nro_hc, hc.diagnostico,hc.antecedentes, e.fecha_estudio as 'Fecha en que se realizó el estudio', e.doctorACargo as 'Doctor a cargo de realizar el estudio',e.informe_estudio as 'Informe del estudio realizado',ins.nombre as 'Institución donde se realiza el estudio'
from Estudio e, Historia_Clinica hc, Institucion ins
where e.id_hc_fk=hc.id_hc
and e.id_institucion_fk=ins.id_institucion

select ins.nombre, dom.calle, dom.numero,ba.nombre as 'Barrio',lo.nombre as 'Localidad'
from Institucion ins, Domicilio dom, Barrio ba, Localidad lo
where ins.id_institucion=dom.id_institucion
and dom.id_barrio=ba.id_barrio
and ba.id_localidad_fk=lo.id_localidad

select dom.calle, dom.numero
from Institucion ins, Domicilio dom
where ins.id_institucion='1' and ins.id_institucion=dom.id_institucion


Insert into Localidad(nombre)

values ('Rio Ceballos')

insert into TipoDocumento(nombre)values('DNI')

select * from ProfesionalMedico

ALTER TABLE Usuario 
ALTER COLUMN contraseña varbinary(MAX) not null;

ALTER TABLE Paciente 
ALTER COLUMN id_hc_fk int;

update Paciente
set id_domicilio_fk='11'
where id_tipoDoc_fk=1 and nro_documento='12036547'

insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('Usuario1',PWDENCRYPT(123456),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('Usuario1',PWDENCRYPT(654321),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('MedicoUsuario1',PWDENCRYPT(102030),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('LJ',102030,'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('EA',PWDENCRYPT(123456),'24/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('EE',PWDENCRYPT(123456),'24/06/2016')



insert into Estado(nombre,descripcion) values ('Activo',NUll)
insert into Estado(nombre,descripcion) values ('Inactivo',NUll)

insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','12036547','Juan','Gomez','4785289','156874598','juanGomez@hotmail.com','6','1','16/06/2016','55','1.65','55','1')

insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','11456987','Elias','Rodriguez','4767845','156124578','EliasRodriguez@hotmail.com','7','1','16/06/2016','56','1.70','60','2')

insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','11222333','Esteban','Altamirano','4760012','156540022','EA@hotmail.com','12','1','16/06/2016','56','1.70','60',null)

Insert into Historia_Clinica(nro_hc,fecha_creación,diagnostico,antecedentes,fecha_inicio_atencion_con_profesional)
values ('2','16/06/2016','HTA','Sin antecedentes','16/06/2016')

insert into Especialidad(nombre,descripcion)
values('Nefrología','Parte de la medicina que se ocupa de la anatomía, la fisiología y las enfermedades del riñón.')

insert into ProfesionalMedico(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,id_especialidad_fk,matricula_profesional)
values ('1','15036547','Luis','Juncos','4760021','152568741','LuisJuncos@hotmail.com','10','1','1','222545')

Insert into Barrio(nombre,descripcion,id_localidad_fk)
values('Las Margaritas',null,1)

Insert into Domicilio(calle,numero,codigo_postal,piso,departamento,id_institucion,id_barrio)
values ('Bv. Los Granaderos', '250','5008',null,null,null,3)

alter table Paciente ADD id_domicilio_fk int
alter table Historia_Clinica ADD id_ int

select id_usuario from Usuario us where us.nombre_usuario='Usuario1' and PWDCOMPARE(us.contraseña,123456)=1


insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('GG',ENCRYPTBYPASSPHRASE('clave','789'),'16/06/2016')

select id_usuario
from Usuario
where nombre_usuario='LJ' and CONVERT(varchar(255), DECRYPTBYPASSPHRASE('clave',contraseña))='102030'


 desencriptar=CONVERT(varchar(200), DECRYPTBYPASSPHRASE('clave',contraseña

 select id_tipodoc_fk,nro_documento from ProfesionalMedico where id_usuario_fk=1



 delete Usuario
 where nombre_usuario='LJ'

 insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','20002657','Gabriela','Gonzalez','4760845','156880078','gabrielagonzalez@hotmail.com','11','1','16/06/2016','56','1.70','60',null)

insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','20002657','Gabriela','Gonzalez','4760845','156880078','gabrielagonzalez@hotmail.com','11','1','16/06/2016','56','1.70','60',null)

insert into Paciente(id_tipoDoc_fk,nro_documento,nombre,apellido,telefono,nroCelular,email,id_usuario_fk,id_estado_fk,fecha_inicio_tratamiento,
edad,altura,peso,id_hc_fk) values ('1','12345678','Elias','Morales','4760845','156880078','EM@hotmail.com','13','1','16/06/2016','56','1.70','60',null)

select id_hc_fk from Paciente where id_tipoDoc_fk='1' and nro_documento='20002657'

SELECT TOP 1  id_hc FROM Historia_Clinica 
ORDER BY id_hc DESC 

SELECT * FROM Historia_Clinica WHERE id_hc = (SELECT MAX(id_hc) FROM Historia_Clinica)

alter table Historia_Clinica ADD id_tipodoc_fk int ,
nro_documento int;

alter table Historia_Clinica ADD id_tipodoc_fk int ,
nro_documento int;

alter table Historia_Clinica
alter column nro_documento bigint;

alter table Historia_Clinica
alter column diagnostico text 

alter table Historia_Clinica
alter column antecedentes text 

alter table Historia_Clinica
add id_tipodoc_paciente_fk int,
nro_doc_paciente_fk bigint



select * from Historia_Clinica where id_tipodoc_fk=1 and nro_documento=15036547
select * from Historia_Clinica where id_tipodoc_paciente_fk=1 and nro_doc_paciente_fk=20002657

update Historia_Clinica
set id_tipodoc_paciente_fk='1', nro_doc_paciente_fk='20002657'
where id_hc='8'

select *
from Historia_Clinica

select *
from Paciente
order by id_usuario_fk
select *
from Usuario

select id_estudio,nombre as 'Nombre del estudio',fecha_estudio,doctorACargo,informe_estudio,id_hc_fk,id_institucion_fk from Estudio where id_hc_fk=8