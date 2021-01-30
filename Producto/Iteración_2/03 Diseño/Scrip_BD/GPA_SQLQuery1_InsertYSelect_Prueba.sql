

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

select * from Paciente

ALTER TABLE Usuario 
ALTER COLUMN contraseña varbinary(MAX) not null;

ALTER TABLE TipoSintoma 
ALTER COLUMN nombre varchar(100);

update Paciente
set id_domicilio_fk='11'
where id_tipoDoc_fk=1 and nro_documento='12036547'

insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('Usuario1',PWDENCRYPT(123456),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('Usuario1',PWDENCRYPT(654321),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('MedicoUsuario1',PWDENCRYPT(102030),'16/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('LJ',PWDENCRYPT(123),TRY_CONVERT(date,'25/05/2020',103));
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('EA',PWDENCRYPT(123456),'24/06/2016')
insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('EE',PWDENCRYPT(123456),'24/06/2016')


insert into Usuario(nombre_usuario,contraseña,fecha_creacion) values ('admin',PWDENCRYPT(123),TRY_CONVERT(date,'25/05/2020',103));

select *
from Usuario

delete from Usuario

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
values ('1','15036547','Luis','Juncos','4760021','152568741','LuisJuncos@hotmail.com','6','1','1','222545')

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

alter table ProfesionalMedico ADD id_sexo_fk int;

select * from Historia_Clinica where id_tipodoc_fk=1 and nro_documento=15036547
select * from Historia_Clinica where id_tipodoc_paciente_fk=1 and nro_doc_paciente_fk=20002657

update Historia_Clinica
set id_tipodoc_paciente_fk='1', nro_doc_paciente_fk='20002657'
where id_hc='8'

select *
from ProfesionalMedico

select *
from Paciente
order by id_usuario_fk

select *
from Operaciones

update ProfesionalMedico
set id_sexo_fk='1'
where  id_tipoDoc_fk='8' and nro_documento='15036547'

update Operaciones
set id_tipoAntecedenteMorbido_fk='2'
where  id_tipoAntecedenteMorbido_fk='1'

select id_estudio,nombre as 'Nombre del estudio',fecha_estudio,doctorACargo,informe_estudio,id_hc_fk,id_institucion_fk from Estudio where id_hc_fk=8





drop table Operaciones



select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentracción', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um,UnidadMedidaXMedicamento umm, FormaAdministracion fa, FormaAdministracionXMedicamento fam, PresentacionMedicamento pm, PresentacionMedicamentoXMedicamento prem 
where m.id_medicamento= em.id_medicamento_fk 
and m.id_medicamento=nc.id_medicamento_fk and em.id_medicamento_fk=umm.id_medicamento_fk and um.id_unidadMedida=umm.id_unidadMedida_fk
and m.id_medicamento=fam.id_medicamento_fk and fa.id_formaAdministracion=fam.id_formaAdministracion_fk
and m.id_medicamento=prem.id_medicamento_fk and pm.id_presentacionMedicamento=prem.id_presentacionMedicamento_fk
and em.concentracion='25' and em.id_unidadMedida_fk='2' and em.id_formaAdministracion_fk='1' and em.id_presentacionMedicamento_fk='1' and em.cantidadComprimidos='30'

--Obtiene resultado correcto------------------
select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk,nc.id_nombreComercial
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_unidadMedida_fk=um.id_unidadMedida
and em.id_formaAdministracion_fk=fa.id_formaAdministracion
and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento
select * from FormaAdministracion

select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk,nc.id_nombreComercial
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_unidadMedida_fk=um.id_unidadMedida
and em.id_formaAdministracion_fk=fa.id_formaAdministracion
and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento
and em.concentracion='30' and em.id_unidadMedida_fk='2' and em.id_formaAdministracion_fk='1' and em.id_presentacionMedicamento_fk='1' and em.cantidadComprimidos='30'

---------------------------------------------------


select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración',um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um,FormaAdministracion fa, PresentacionMedicamento pm
where m.id_medicamento= em.id_medicamento_fk and em.id_medicamento_fk=nc.id_medicamento_fk 
and em.id_unidadMedida_fk=um.id_unidadMedida
and em.id_formaAdministracion_fk=fa.id_formaAdministracion
and em.id_presentacionMedicamento_fk=pm.id_presentacionMedicamento

select * from Medicamento
select * from NombreComercial
select * from EspecificacionMedicamento
select * from UnidadMedidaXMedicamento

----delete from UnidadMedidaXMedicamento
--delete from FormaAdministracionXMedicamento
--delete from PresentacionMedicamentoXMedicamento

delete  from Medicamento
delete from Historia_Clinica
select m.nombreGenerico, um.nombre, m.id_medicamento
from Medicamento m, UnidadMedidaXMedicamento umm, UnidadMedida um
where m.id_medicamento=umm.id_medicamento_fk and um.id_unidadMedida=umm.id_unidadMedida_fk and m.nombreGenerico like 'Hidroclorotiazida'


select * from PresentacionMedicamentoXMedicamento
where id_medicamento_fk='10' and id_presentacionMedicamento_fk='1'

select * from Medicamento
--em.id_especificacion='2' and em.id_medicamento_fk='16' 


select m.id_medicamento, m.nombreGenerico, em.id_especificacion, nc.nombre
from Medicamento m, EspecificacionMedicamento em, NombreComercial nc
where m.id_medicamento=em.id_medicamento_fk
and m.id_medicamento=nc.id_medicamento_fk

select * from UnidadMedidaXMedicamento
select * from FormaAdministracionXMedicamento
select * from PresentacionMedicamentoXMedicamento

alter table UnidadMedidaXMedicamento
add id_nombreComercial_fk int

alter table UnidadMedidaXMedicamento
drop column id_nombreComercial_fk

alter table UnidadMedidaXMedicamento
add id_nombreComercial_fk int primary key 

select * from UnidadMedidaXMedicamento

insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
values(21,2,19)
insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
values(21,2,20)
insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
values(21,2,21)
insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
values(22,2,22)
insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
values(22,2,23)


insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
values(21,1,19)
insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
values(21,1,20)
insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
values(21,2,21)
insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
values(22,1,22)
insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
values(22,1,23)


insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
values(21,1,19)
insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
values(21,1,20)
insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
values(21,1,21)
insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
values(22,1,22)
insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
values(22,1,23)

 select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk,em.id_nombreComercial_fk
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_unidadMedida_fk=um.id_unidadMedida
and em.id_formaAdministracion_fk=fa.id_formaAdministracion
and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento
and m.nombreGenerico like 'N%'



select * from NombreComercial
select * from UnidadMedidaXMedicamento
select * from EspecificacionMedicamento
select * from NombreComercial
select * from Medicamento


select m.nombreGenerico, um.nombre, m.id_medicamento
from Medicamento m, UnidadMedidaXMedicamento umm,UnidadMedida um
where m.id_medicamento=umm.id_medicamento_fk and um.id_unidadMedida=umm.id_unidadMedida_fk


select * from Medicamento
select * from FormaAdministracionXMedicamento
select * from EspecificacionMedicamento
select distinct em.*  from EspecificacionMedicamento em
select * from EspecificacionMedicamento
select * from NombreComercial


select distinct um.id_unidadMedida,cast(um.nombre as varchar(max))
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, UnidadMedidaXMedicamento umm, UnidadMedida um
where m.id_medicamento=em.id_medicamento_fk 
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_unidadMedida_fk=umm.id_unidadMedida_fk 
and em.id_medicamento_fk=umm.id_medicamento_fk
and em.id_nombreComercial_fk=umm.id_nombreComercial_fk
and umm.id_unidadMedida_fk=um.id_unidadMedida
and umm.id_medicamento_fk=m.id_medicamento
and umm.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_medicamento_fk='21' and em.id_nombreComercial_fk='19'

select distinct fa.id_formaAdministracion,cast(fa.nombre as varchar(max)) as 'Forma de administración'
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, FormaAdministracionXMedicamento fam, FormaAdministracion fa
where m.id_medicamento=em.id_medicamento_fk 
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_formaAdministracion_fk=fam.id_formaAdministracion_fk 
and em.id_medicamento_fk=fam.id_medicamento_fk
and em.id_nombreComercial_fk=fam.id_nombreComercial_fk
and fam.id_formaAdministracion_fk=fa.id_formaAdministracion
and fam.id_medicamento_fk=m.id_medicamento
and fam.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_medicamento_fk='22' and em.id_nombreComercial_fk='22'

select distinct pm.id_presentacionMedicamento,cast(pm.nombre as varchar(max)) as 'Presentación medicamento'
from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, PresentacionMedicamentoXMedicamento pmm, PresentacionMedicamento pm
where m.id_medicamento=em.id_medicamento_fk 
and em.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_presentacionMedicamento_fk=pmm.id_presentacionMedicamento_fk 
and em.id_medicamento_fk=pmm.id_medicamento_fk
and em.id_nombreComercial_fk=pmm.id_nombreComercial_fk
and pmm.id_presentacionMedicamento_fk=pm.id_presentacionMedicamento
and pmm.id_medicamento_fk=m.id_medicamento
and pmm.id_nombreComercial_fk=nc.id_nombreComercial
and em.id_medicamento_fk='21' and em.id_nombreComercial_fk='25'



select m.nombreGenerico,nc.nombre
from Medicamento m, NombreComercial nc
where m.id_medicamento=nc.id_medicamento_fk
and m.id_medicamento='21'

select * from FormaAdministracionXMedicamento

alter table Sintoma 
add id_tipoSintoma_fk int,
descripcion text,
id_parteDelCuerpo_fk int,
haciaDondeIrradia text,
id_comoSeModifica_fk int,
id_elementoDeModificacion_fk int,
id_caracterDolor_fk int,
observaciones text

alter table Sintoma
add foreign key(id_parteDelCuerpo_fk) references ParteDelCuerpo(id_parteDelCuerpo),
foreign key(id_comoSeModifica_fk) references ModificacionSintoma(id_modificacionesSintoma),
foreign key (id_elementoDeModificacion_fk) references ElementoDeModificacion(id_elementoDeModificacion),
foreign key (id_caracterDolor_fk) references CaracterDelDolor(id_caracterDelDolor)


alter table Sintoma 
add fechaRegistro date

alter table AntecedentesMorbidos
add id_operacion_fk int, id_traumatismo_fk int, id_enfermedad_fk int

alter table AntecedentesMorbidos
add foreign key (id_operacion_fk) references Operaciones(id_operacion),
foreign key (id_traumatismo_fk) references Traumatismos(id_traumatismo),
foreign key (id_enfermedad_fk) references Enfermedades(id_enfermedad)

alter table ProfesionalMedico
add foreign key (id_domicilio_fk) references Domicilio(id_domicilio)

drop table ProgramacionMedicamento
select * from UnidadMedida

select concentracion,cantidadComprimidos, id_especificacion from EspecificacionMedicamento
where id_medicamento_fk='21'
and id_nombreComercial_fk='19'
and id_unidadMedida_fk='2'
and id_formaAdministracion_fk='1'
and id_presentacionMedicamento_fk='1'

alter table Historia_Clinica
add id_tipodoc_paciente_fk int,id_nrodoc_paciente_fk int

alter table Historia_Clinica
add foreign key(id_tipodoc_paciente_fk, id_nrodoc_paciente_fk) references Paciente(id_tipoDoc_fk,nro_documento)
delete from Historia_Clinica

select * from Historia_Clinica
select * from HabitosActividadFisica
select * from HabitosTabaquismo
select * from Paciente
delete from Historia_Clinica where id_hc=58
delete from HabitosTabaquismo where id_hc_fk=30

select * from ProgramacionMedicamento

delete from HabitosTabaquismo


delete from Sintoma 

drop table Consulta
drop table ProgramacionMedicamento

select * from Historia_Clinica
select * from HabitosMedicamento
select * from HabitosTabaquismo
select * from Sustancia

update Paciente
set id_hc_fk= null
where  id_hc_fk= '37'

alter table Historia_Clinica
alter column principalProblema text

alter table HabitosDrogasIlicitas
drop column dejoConsumir 

alter table Aborto
drop column fechaRegistro 

alter table HabitosDrogasIlicitas
add foreign key (id_hc_fk) references Historia_Clinica(id_hc)

select * from Paciente where id_hc_fk=57
select * from AntecedentesMorbidos

select * from Operaciones


select hc.nro_hc, hc.fecha_inicio_atencion_con_profesional,hc.principalProblema 'Motivo de la primera consulta'
from Paciente p, Historia_Clinica hc, AntecedentesMorbidos am
where p.id_hc_fk=hc.id_hc and id_tipoDoc_fk=8 and nro_documento=20258789

select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk
from Historia_Clinica hc, AntecedentesMorbidos am
where hc.id_hc= am.id_hc_fk and am.id_hc_fk='57'

select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk, tam.nombre, enf.nombre, am.tratamiento, am.evolucion
from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf
where hc.id_hc= am.id_hc_fk and hc.id_hc= '57' and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
and am.id_enfermedad_fk=enf.id_enfermedad 


select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk, tam.nombre, ope.nombre, am.evolucion, am.tratamiento
from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Operaciones ope
where hc.id_hc= am.id_hc_fk and hc.id_hc= '57' and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
and am.id_operacion_fk=ope.id_operacion 

select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk, tam.nombre, trau.nombre, am.evolucion, am.tratamiento
from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Traumatismos trau
where hc.id_hc= am.id_hc_fk and hc.id_hc= '57' and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
and am.id_traumatismo_fk=trau.id_traumatismo


select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk, tam.nombre, enf.nombre, am.tratamiento, am.evolucion
from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf
where hc.id_hc= am.id_hc_fk and hc.id_hc= '57' and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
and am.id_enfermedad_fk=enf.id_enfermedad 

select * from AntecedentesGinecoObstetricos

select am.fechaRegistro, am.id_tipoAntecedenteMorbido_fk, tam.nombre, enf.nombre, am.tratamiento, am.evolucion,CONCAT(am.cantidadTiempo,' ',et.nombre) as 'Cantidad de tiempo en que ocurrió'
from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf,ElementoDelTiempo et
where hc.id_hc= am.id_hc_fk and hc.id_hc= '57' and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
and am.id_enfermedad_fk=enf.id_enfermedad 
and am.id_elementoTiempo_fk=et.id_elementoDelTiempo


select ag.fechaRegistro, ag.cantidadEmbarazos,CONCAT(ag.cantidadEmbarazosPrematuros,' con parto de tipo ',tp1.nombre) as 'Cantidad de embarazos prematuros', CONCAT(ag.cantidadEmbarazosATermino,' con parto de tipo ',tp2.nombre) as 'Cantidad de embarazos a término',CONCAT(ag.cantidadEmbarazosPosTermino,' con parto de tipo ',tp3.nombre) as 'Cantidad de embarazos postérmino'
from Historia_Clinica hc, AntecedentesGinecoObstetricos ag, TipoParto tp1, TipoParto tp2, TipoParto tp3
where hc.id_hc=ag.id_hc_fk and hc.id_hc='18'
and ag.id_TipoParto1_fk=tp1.id_TipoParto
and ag.id_TipoParto2_fk=tp2.id_TipoParto
and ag.id_TipoParto3_fk=tp3.id_TipoParto


select ag.fechaRegistro, ag.cantidadEmbarazos,CONCAT(ag.cantidadEmbarazosPrematuros,' con parto de tipo ',tp1.nombre) as 'Cantidad de embarazos prematuros', CONCAT(ag.cantidadEmbarazosATermino,' con parto de tipo ',tp2.nombre) as 'Cantidad de embarazos a término'
from Historia_Clinica hc, AntecedentesGinecoObstetricos ag, TipoParto tp1, TipoParto tp2,TipoParto tp3
where hc.id_hc=ag.id_hc_fk and hc.id_hc='59'
and ag.id_TipoParto1_fk=tp1.id_TipoParto
and ag.id_TipoParto2_fk=tp2.id_TipoParto
and ag.id_TipoParto3_fk=tp3.id_TipoParto
and ISNULL(ag.id_TipoParto3_fk,0)=0

select * from Historia_Clinica

select * from AntecedentesGinecoObstetricos

select ag.fechaRegistro, ag.cantidadEmbarazos,CONCAT(ag.cantidadEmbarazosPrematuros,' con parto de tipo ',tp1.nombre) as 'Cantidad de embarazos prematuros', CONCAT(ag.cantidadEmbarazosATermino,' con parto de tipo ',tp2.nombre) as 'Cantidad de embarazos a término',CONCAT(ag.cantidadEmbarazosPosTermino,' con parto de tipo ',tp3.nombre) as 'Cantidad de embarazos postérmino', ab.cantidadTotal as 'Cantidad de abortos',CONCAT(ab.cantidadProvocados,' Aborto/s ',ta2.nombre) as 'Abortos provocados', CONCAT(ab.cantidadEspontaneo,' Aborto/s ',ta1.nombre) as 'Abortos espontaneos', ab.nroHijosVivos as 'Numero de hijos vivos',ab.problemasAsociadosAlEmbarazo as 'Problemas asociados al embarazo' 
from Historia_Clinica hc, AntecedentesGinecoObstetricos ag, TipoParto tp1, TipoParto tp2, TipoParto tp3, Aborto ab, TipoAborto ta1,TipoAborto ta2
where hc.id_hc=ag.id_hc_fk and hc.id_hc='59'
and ag.id_TipoParto1_fk=tp1.id_TipoParto
and ag.id_TipoParto2_fk=tp2.id_TipoParto
and ag.id_TipoParto3_fk=tp3.id_TipoParto
and ag.id_Aborto_fk=ab.id_aborto
and ab.id_TipoAborto1_fk=ta1.id_TipoAborto
and ab.id_TipoAborto2_fk=ta2.id_TipoAborto

select aa.fechaRegistro as 'Fecha de registro', a.nombre as 'Nombre del alimento', aa.efectos as 'Efectos de la alergia'
from AlergiaAlimento aa,Alimento a
where id_hc_fk='23'
and aa.id_alimento_fk=a.id_alimento

select asa.fechaRegistro as 'Fecha de registro', sa.nombre as 'Nombre de la sustancia', asa.efectos as 'Efectos de la alergia'
from AlergiaSustanciaAmbiente asa, SustanciaAmbiente sa
where asa.id_hc_fk='24'
and asa.id_sustanciaAmbiente_fk=sa.id_sustanciaAmbiente

select * from AlergiaInsecto

select ascp.fechaRegistro as 'Fecha de registro', scp.nombre as 'Nombre de la sustancia', ascp.efectos as 'Efectos de la alergia'
from AlergiaSustanciaContactoPiel ascp, SustanciaContactoPiel scp
where ascp.id_hc_fk='25'
and ascp.id_sustanciaContactoPiel_fk=scp.id_sustanciaContactoPiel

select am.fechaRegistro as 'Fecha de registro', ma.nombre as 'Nombre del medicamento', am.efectos as 'Efectos de la alergia'
from AlergiaMedicamento am, MedicamentoAlergia ma
where am.id_hc_fk='57'
and am.id_medicamentoAlergia_fk=ma.id_medicamentoAlergia

select ai.fechaRegistro as 'Fecha de registro', ins.nombre as 'Nombre del insecto', ai.efectos as 'Efectos de la alergia'
from AlergiaInsecto ai, Insecto ins
where ai.id_hc_fk='57'
and ai.id_insecto_fk=ins.id_insecto

select * from SistemaLinfatico

alter table Sintoma
add id_consulta_fk int

alter table Consulta
add id_hc_fk int not null

alter table Consulta
add foreign key (id_hc_fk) references Historia_Clinica(id_hc)

alter table Sintoma
add foreign key (id_consulta_fk) references Consulta(id_consulta)

alter table ExamenGeneral
add id_pulsoArterial_fk int

alter table ExamenGeneral
add foreign key(id_pulsoArterial_fk) references PulsoArterial(id_pulsoArterial)

drop table HipotesisInicial
drop table DiagnosticoDefinitivo
drop table ResultadoTemperatura

alter table ExamenGeneral
add id_razonamiento_fk int

alter table ExamenGeneral
add foreign key(id_razonamiento_fk) references RazonamientoDiagnostico(id_razonamiento)


select * from ExamenGeneral

sp_rename 'PulsoArterial.ausculacion', 'auscultacion' --Cambia nombre de columna

select * from PulsoArterial
select * from DetallePulsoArterial
select * from ExamenGeneral
select @@IDENTITY
select SCOPE_IDENTITY()
select IDENT_CURRENT('Consulta')
select IDENT_CURRENT('RazonamientoDiagnostico')
select IDENT_CURRENT('PulsoArterial')
select IDENT_CURRENT('ExamenGeneral')

select c.nroConsulta, c.fechaConsulta,c.horaConsulta,c.motivoConsulta, ex.posicionYDecubito,ex.marchaYDeambulacion,ex.facieExpresionFisonomia,ex.concienciaEstadoPsiquico,ex.constitucionEstadoNutritivo,ex.peso,ex.talla
from Consulta c, ExamenGeneral ex, Historia_Clinica hc
where c.id_examenGeneral_fk=ex.id_examenGeneral
and hc.id_hc=c.id_hc_fk and hc.id_hc='56'

select * from AntecedentesGinecoObstetricos

alter table ResultadoTemperatura
add valorMaximo float, valorMinimo 

alter table Temperatura
add temperaturaGradosCentigrados float

alter table Temperatura
drop column temperaturaGradosCentigrados

select * from ResultadoTemperatura
select nombre, valorMaximo, valorMinimo
from ResultadoTemperatura
where 36 between valorMinimo and valorMaximo

/*alter table EscalaPulso
alter column nombre text

select * from HipotesisInicial

alter table AlergiaMedicamento
add id_medicamentoAlergia_fk int

alter table AlergiaMedicamento
add foreign key(id_medicamentoAlergia_fk) references MedicamentoAlergia(id_medicamentoAlergia)

drop table DetallePulsoArterial
drop table PulsoArterial
drop table EscalaPulso
drop table Pulso

delete from AnalisisLaboratorio
delete from NombreEstudio
delete from EstadoHipotesis

DBCC CHECKIDENT('AnalisisLaboratorio',RESEED,0)
DBCC CHECKIDENT('NombreEstudio',RESEED,0)
DBCC CHECKIDENT('EstadoHipotesis',RESEED,0)

select * from Usuario

select @@IDENTITY
select SCOPE_IDENTITY()
select IDENT_CURRENT('RazonamientoDiagnostico')*/

/*CREATE TABLE DetalleMedicionPresionArterial(
id_nroMedicion int,
id_medicion_fk int,
hora time,
pulso int,
valorMaximo int,
valorMinimo int,
primary key (id_nroMedicion,id_medicion_fk),
foreign key (id_medicion_fk) references MedicionDePrecionArterial(id_medicion))

alter table ClasificacionPresionArterial
drop column nombre

alter table ClasificacionPresionArterial
add categoria text

alter table ClasificacionPresionArterial
add maximaDesde int

alter table ClasificacionPresionArterial
add maximaHasta int

alter table ClasificacionPresionArterial
add minimaDesde int

alter table ClasificacionPresionArterial
add minimaHasta int

alter table ExamenGeneral
add id_medicion_fk int

alter table ExamenGeneral
add foreign key (id_medicion_fk) references MedicionDePrecionArterial(id_medicion)

alter table MedicionDePrecionArterial
drop column horaInicio

alter table MedicionDePrecionArterial
add horaInicio time

alter table MedicionDePrecionArterial
drop constraint FK__MedicionD__id_ex__0A688BB1 

alter table MedicionDePrecionArterial
drop column id_extremidad_fk

alter table MedicionDePrecionArterial
add id_ubicacionExtremidad_fk int

alter table MedicionDePrecionArterial
add foreign key(id_ubicacionExtremidad_fk) references UbicacionExtremidad(id_ubicacionExtremidad)*/

select * from RazonamientoDiagnostico

alter table AnalisisLaboratorio
add valorResultado float,
id_unidadMedida_fk int not null,
id_metodoAnalisisLaboratorio_fk int

select * from Historia_Clinica

alter table AntecedentesPatologicosPersonales
alter column descripcion_otrasEnfermedades text

alter table TipoSintoma
drop column nombre
alter table TipoSintoma
add nombre nvarchar(50)


alter table RazonamientoDiagnostico
drop column fechaConfirmado
alter table RazonamientoDiagnostico
drop column motivoTentativo
alter table RazonamientoDiagnostico
drop column fechaTentativo
alter table RazonamientoDiagnostico
drop column id_ExamenGeneral_fk

/*alter table RazonamientoDiagnostico
add motivoDescartado text
alter table RazonamientoDiagnostico
add fechaDescartado date*/
alter table RazonamientoDiagnostico
add motivoConfirmado text
alter table RazonamientoDiagnostico
add fechaConfirmado date
alter table RazonamientoDiagnostico
add motivoTentativo text
alter table RazonamientoDiagnostico
add fechaTentativo date

alter table RazonamientoDiagnostico
add id_ExamenGeneral_fk int
alter table RazonamientoDiagnostico
add foreign key (id_ExamenGeneral_fk) references ExamenGeneral(id_examenGeneral)


alter table RazonamientoDiagnostico
alter column fechaDescartado date

alter table RazonamientoDiagnostico
alter column fechaConfirmado date

alter table RazonamientoDiagnostico
alter column fechaTentativo date

alter table RazonamientoDiagnostico
add foreign key (id_estadoDiagnostico_fk) references EstadoDiagnostico(id_estadoDiagnostico)

alter table RazonamientoDiagnostico
drop column fechaTentativo

select * from RazonamientoDiagnostico
drop table RazonamientoDiagnosticoPrueba


delete from NombreEstudio

select * from PracticaComplementaria

alter table PracticaComplementaria
alter column fechaSolicitud date

alter table PracticaComplementaria
alter column fechaRealizacion date
alter table PracticaComplementaria
alter column doctorACargo varchar(50)
alter table Paciente
alter column altura int

alter table MedicionDePrecionArterial
add id_hc_fk int
alter table MedicionDePrecionArterial
add foreign key (id_hc_fk) references Historia_Clinica(id_hc)

select * from Paciente
where nombre='Soledad'
select * from Historia_Clinica

select p.nombre,p.apellido, hc.nro_hc, hc.id_hc, c.nroConsulta, c.fechaConsulta, c.motivoConsulta
from Historia_Clinica hc, Paciente p, Consulta c
where p.id_hc_fk=hc.id_hc and hc.id_hc=c.id_hc_fk
order by c.nroConsulta

select * from UnidadMedida

select  c.fechaConsulta, c.nroConsulta, nro_hc, p.nombre, p.apellido
from Consulta c, Historia_Clinica h, Paciente p
where c.id_hc_fk=h.id_hc and h.id_tipodoc_paciente_fk=p.id_tipoDoc_fk and h.id_nrodoc_paciente_fk=p.nro_documento
group by c.nroConsulta, c.fechaConsulta,  nro_hc, p.nombre, p.apellido

select * from Laboratorio

alter table ItemEstudioLaboratorio
drop column valorresultado
alter table ItemEstudioLaboratorio
drop column id_unidadMedida_fk

alter table ItemEstudioLaboratorio
drop column nombre
alter table ItemEstudioLaboratorio
add id_itemLaboratorio int
alter table ItemEstudioLaboratorio
add foreign key (id_itemLaboratorio) references itemLaboratorio(id_itemLaboratorio)

drop table TipoSintoma
drop table DetalleItemLaboratorio
drop table DetalleLaboratorio


select * from itemLaboratorio
select * from ItemEstudioLaboratorio
select * from DetalleItemLaboratorio
select * from DetalleValorReferencia


select ie.id_itemEstudioLaboratorio,ie.id_itemLaboratorio_fk, il.nombre,il.id_itemLaboratorio
from ItemEstudioLaboratorio ie, itemLaboratorio il, DetalleItemLaboratorio dil, DetalleValorReferencia dvr
where ie.id_itemLaboratorio_fk=il.id_itemLaboratorio
and dil.id_item_fk=ie.id_itemEstudioLaboratorio
and dvr.id_detalleItemLaboratorio_fk=dil.id_detalleItemLaboratorio

select ie.id_itemEstudioLaboratorio,ie.id_itemLaboratorio_fk, il.nombre,il.id_itemLaboratorio, dil.nombre,dil.valorDesde, dil.valorHasta, dvr.descripcion,dvr.valorDesde, dvr.valorHasta
from ItemEstudioLaboratorio ie full outer join itemLaboratorio il on ie.id_itemLaboratorio_fk=il.id_itemLaboratorio
full outer join DetalleItemLaboratorio dil on dil.id_item_fk=ie.id_itemEstudioLaboratorio
full outer join DetalleValorReferencia dvr on dvr.id_detalleItemLaboratorio_fk=dil.id_detalleItemLaboratorio

select * from DetalleValorReferencia
select * from DetalleItemLaboratorio
select id_nombreEstudio 
from NombreEstudio 
where nombre like 'Ecografía Renal'

select *
from TipoSintoma

select * from TipoSintoma 
where nombre not like '--Seleccionar--'

select * from DetalleMedicionPresionArterial
select * from MedicionDePrecionArterial


select *
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d
where m.id_medicion=d.id_medicion_fk
and m.id_hc_fk=34


select * 
from Historia_Clinica hc, Paciente p
where hc.id_nrodoc_paciente_fk=p.nro_documento
and hc.id_tipodoc_paciente_fk=p.id_tipoDoc_fk
and hc.id_hc=23

select * from Consulta
where id_medicion_fk=34

select *
from Sexo

select *
from Paciente

delete from Paciente


select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.id_tipoDoc_fk, p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', e.nombre as 'Estado', s.nombre as'Sexo'
 from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, Estado e, Sexo s
where p.id_profesionalMedico_tipoDoc_fk='8' and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_estado_fk=e.id_estado and p.id_sexo_fk= s.id_sexo


update ProfesionalMedico 
set  id_tipodoc_fk=1



---------------------------------------------------------------------------------------------------

/*
usuario prueba
usaurio: shaba1
pass: 2chd05qk


usuario prueba
usaurio: mgonzalez1
pass: 1s3vibbq

usuario: amoreno1
pass: envk00lp
*/
--quitar y agregar una columna 
alter table CaracterDelDolor
drop column nombre
alter table CaracterDelDolor
add nombre text


alter table EvolucionDiagnostico
add id_estadoDiagnostico int

alter table EvolucionDiagnostico
add foreign key (id_estadoDiagnostico) references EstadoDiagnostico(id_estadoDiagnostico)


select *
from EstadoDiagnostico

select *
from EvolucionDiagnostico

select *
from SitioMedicion

select *
from ParteDelCuerpo

select *
from UbicacionExtremidad



select *
from MedicionDePrecionArterial m
where m.id_hc_fk=4


select m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'Ubicacion Extremidad',CAST(sm.nombre as nvarchar(100)) as 'Sitio Medicion',CAST(md.nombre as nvarchar(100)) as 'Momento del día',CAST(p.nombre as nvarchar(100)) as 'Posición'
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
where m.id_medicion=d.id_medicion_fk
and m.id_extremidad_fk=ex.id_extremidad
and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
and m.id_posicion_fk=p.id_posicion
and m.id_momentoDelDia_fk=md.id_momentoDelDia
and m.id_sitioMedicion_fk= sm.id_sitioMedicion
and m.id_hc_fk=4
--and m.id_medicion=54
group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100))


select distinct m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad'
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
where m.id_medicion=d.id_medicion_fk
and m.id_extremidad_fk=ex.id_extremidad
and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
and m.id_posicion_fk=p.id_posicion
and m.id_momentoDelDia_fk=md.id_momentoDelDia
and m.id_sitioMedicion_fk= sm.id_sitioMedicion
--and m.id_hc_fk=2
--and m.id_medicion=54
group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100))


select top(10) m.fecha, d.id_nroMedicion,d.hora,d.valorMaximo,d.valorMinimo,d.pulso,AVG(valorMaximo),AVG(valorMinimo)
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
where m.id_medicion=d.id_medicion_fk
and m.id_extremidad_fk=ex.id_extremidad
and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
and m.id_posicion_fk=p.id_posicion
and m.id_momentoDelDia_fk=md.id_momentoDelDia
and m.id_sitioMedicion_fk= sm.id_sitioMedicion
and m.id_hc_fk=4
--and m.id_medicion=54
group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100)), d.id_nroMedicion,d.hora,d.valorMaximo,d.valorMinimo,d.pulso



select AVG(valorMaximo) as 'PromedioValorMaximo',AVG(valorMinimo) as 'PromedioValorMinimo',AVG(pulso) as 'PromedioPulso'
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d
where m.id_medicion=d.id_medicion_fk
and m.id_hc_fk=2
and m.id_medicion=54
group by m.id_medicion;

select *
from Consulta c, ExamenGeneral e
where c.id_examenGeneral_fk=e.id_examenGeneral

select *
from EstadoDiagnostico

select *
from RazonamientoDiagnostico

select *
from Consulta

select *
from EvolucionDiagnostico e,RazonamientoDiagnostico r
where e.id_diagnostico=r.id_razonamiento
and e.id_hc=4

drop table EvolucionDiagnostico

select *
from EvolucionDiagnostico


select r.*
from Consulta c, ExamenGeneral e, RazonamientoDiagnostico r
where c.id_examenGeneral_fk=e.id_examenGeneral
and r.id_examenGeneral_fk=e.id_examenGeneral
and c.id_consulta=3


select r.diagnostico, r.id_razonamiento,r.id_estadoDiagnostico_fk,r.conceptoInicial,r.fechaTentativo,r.fechaTentativo,r.fechaConfirmado, r.motivoDescartado, ediag.nombre
                                from Historia_Clinica hc,Paciente p, Consulta c, ExamenGeneral ex, RazonamientoDiagnostico r, EstadoDiagnostico ediag
                                where p.id_hc_fk=hc.id_hc
                                and hc.id_hc=c.id_hc_fk 
                                and c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=r.id_ExamenGeneral_fk
                                and r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and hc.id_hc=3

select ed.fechaSolicitud,ne.nombre,ed.indicaciones,ed.id_estudioDiagnosticoPorImagen
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, EstudiosDiagnosticoPorImagen ed, NombreEstudio ne
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and ed.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and ed.id_nombreEstudio_fk=ne.id_nombreEstudio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=1


select ed.fechaSolicitud,ne.nombre,ed.indicaciones,ed.id_estudioDiagnosticoPorImagen
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, EstudiosDiagnosticoPorImagen ed, NombreEstudio ne
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and ed.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and ed.id_nombreEstudio_fk=ne.id_nombreEstudio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and ed.fechaRealizacion is null
								and r.id_razonamiento=3


select c.id_consulta,r.id_razonamiento,c.fechaConsulta,e.id_examenGeneral
from Consulta c,ExamenGeneral e,RazonamientoDiagnostico r
where c.id_examenGeneral_fk=e.id_examenGeneral 
and e.id_examenGeneral=r.id_examenGeneral_fk
and c.id_hc_fk=3
and c.id_consulta=3
and e.id_examenGeneral=3

select *
from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d
where m.id_medicion=d.id_medicion_fk
and m.id_hc_fk=4

select *
from Laboratorio

select r.*
from RazonamientoDiagnostico r,EstudiosDiagnosticoPorImagen es, Laboratorio l, PracticaComplementaria p
where r.id_razonamiento=es.id_razonamientoDiagnostico_fk
and r.id_razonamiento= l.id_razonamientoDiagnostico_fk
and r.id_razonamiento=p.id_razonamientoDiagnostico_fk
and r.id_razonamiento=13;

select *
from RazonamientoDiagnostico r, EstudiosDiagnosticoPorImagen es
where r.id_razonamiento=es.id_razonamientoDiagnostico_fk
and es.id_razonamientoDiagnostico_fk=13

select *
from Laboratorio es
where es.id_razonamientoDiagnostico_fk=13

select *
from PracticaComplementaria p
where p.id_razonamientoDiagnostico_fk=13

select id_hc_fk from Paciente where id_tipoDoc_fk=@id_tipoDoc and nro_documento=@nroDocumento

select l.fechaSolicitud,l.fechaRealizacion,l.doctorACargo,l.observacionDeLosResultados,a.nombre,ma.nombre,dl.valorResultado,itl.nombre,dvr.descripcion,dvr.valorDesde,dvr.valorHasta,dil.nombre
from Laboratorio l, AnalisisLaboratorio a, MetodoAnalisisLaboratorio ma,DetalleLaboratorio dl,ItemEstudioLaboratorio il,itemLaboratorio itl,DetalleItemLaboratorio dil,DetalleValorReferencia dvr
where l.id_metodoAnalisisLaboratorio_fk=a.id_analisisLaboratorio
and ma.id_metodo=l.id_metodoAnalisisLaboratorio_fk
and l.id_laboratorio=dl.id_laboratorio_fk
and dl.id_itemEstudioLaboratorio_fk=il.id_itemEstudioLaboratorio
and il.id_itemLaboratorio_fk=itl.id_itemLaboratorio
and il.id_itemEstudioLaboratorio=dil.id_detalleItemLaboratorio
and dvr.id_detalleItemLaboratorio_fk=dil.id_detalleItemLaboratorio

select *
from Laboratorio

select *
from itemLaboratorio

select *
from DetalleResultadoEstudio


select il.*,dil.*,dvr.*
from ItemLaboratorio il, DetalleItemLaboratorio dil,DetalleValorReferencia dvr
where il.id_itemLaboratorio=dil.id_item_fk
and dil.id_detalleItemLaboratorio=dvr.id_detalleItemLaboratorio_fk


select il.*,dil.*
from ItemLaboratorio il, DetalleItemLaboratorio dil
where il.id_itemLaboratorio=dil.id_item_fk
--delete 
--from ItemEstudioLaboratorio
--where id_itemEstudioLaboratorio in (7,8)
--and id_itemLaboratorio_fk in (7,8)

--delete 
--from itemLaboratorio
--where id_itemLaboratorio in (7,8)

select *
from DetalleLaboratorio

drop detalleLaboratorio
update Laboratorio
 set observacionDeLosResultados='prueba'
where id_laboratorio=15


update Laboratorio
set doctorACargo='Juncos'
where id_laboratorio=15 and id_razonamientoDiagnostico_fk=13


alter table AnalisisLaboratorio
drop column descripcion



select m.*,d.*
from Consulta c, ExamenGeneral e , Historia_Clinica h , MedicionDePrecionArterial m , DetalleMedicionPresionArterial d
where c.id_examenGeneral_fk=e.id_examenGeneral
and c.id_hc_fk=h.id_hc
and e.id_medicion_fk= m.id_medicion
and e.id_medicion_fk=d.id_medicion_fk
and h.id_hc=2


select top(10) m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'Ubicacion Extremidad',CAST(sm.nombre as nvarchar(100)) as 'Sitio Medicion',CAST(md.nombre as nvarchar(100)) as 'Momento del día',CAST(p.nombre as nvarchar(100)) as 'Posición'
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=4
                                group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100))
                                order by m.fecha desc


select r.diagnostico, r.id_razonamiento,r.id_estadoDiagnostico_fk,r.conceptoInicial,ediag.nombre
                                from Historia_Clinica hc,Paciente p, Consulta c, ExamenGeneral ex, RazonamientoDiagnostico r, EstadoDiagnostico ediag
                                where p.id_hc_fk=hc.id_hc
                                and hc.id_hc=c.id_hc_fk 
                                and c.id_examenGeneral_fk=ex.id_examenGeneral
                                and ex.id_examenGeneral=r.id_ExamenGeneral_fk
                                and r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and hc.id_hc=4;

								select ed.fechaSolicitud,ne.nombre,ed.indicaciones,ed.id_estudioDiagnosticoPorImagen, r.id_razonamiento
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, EstudiosDiagnosticoPorImagen ed, NombreEstudio ne
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and ed.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and ed.id_nombreEstudio_fk=ne.id_nombreEstudio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=13;


								select *
								from DetalleLaboratorio


								
alter table LaboratorioNueva
add primary key integer IDENTITY  (id_laboratorio) 



ALTER TABLE LaboratorioNueva
ADD CONSTRAINT id_laboratorio_pk PRIMARY KEY identity (id_labortorio);

alter table LaboratorioNueva
alter column id_laboratorio integer unsigned auto_increment

CREATE TABLE LaboratorioNueva(
id_laboratorio integer PRIMARY KEY identity,
fechaSolicitud date not null,
fechaRealizacion date,
doctorACargo varchar(50),
id_institucion_fk integer,
observacionDeLosResultados text,
indicaciones text,
id_itemLaboratorio_fk int not null,
id_metodoAnalisisLaboratorio_fk int ,
id_razonamientoDiagnostico_fk int not null,
FOREIGN KEY (id_institucion_fk) REFERENCES Institucion(id_institucion),
FOREIGN KEY (id_itemLaboratorio_fk) REFERENCES ItemLaboratorio(id_itemLaboratorio),
FOREIGN KEY (id_metodoAnalisisLaboratorio_fk) REFERENCES MetodoAnalisisLaboratorio(id_metodo),
foreign key (id_razonamientoDiagnostico_fk) references RazonamientoDiagnostico(id_razonamiento))



create table DetalleLaboratorioNuevo(
id_detalleLaboratorio int identity,
valorResultado float,
id_unidadMedida_fk int,
id_itemLaboratorio_fk int,
id_laboratorio_fk int,
constraint id_detallelabnuevo_pk primary key (id_detalleLaboratorio),
constraint id_unidadMedidanuevo_fk foreign key (id_unidadMedida_fk) references UnidadMedida(id_unidadMedida),
constraint id_itemLaboratorionuevo_fk foreign key (id_itemLaboratorio_fk) references ItemLaboratorio(id_itemLaboratorio),
constraint id_laboratorionuevo_fk foreign key (id_laboratorio_fk) references Laboratorio(id_laboratorio))

insert into DetalleLaboratorioNuevo(id_detalleLaboratorio,valorResultado,id_unidadMedida_fk,id_itemLaboratorio_fk,id_laboratorio_fk)
select id_detalleLaboratorio,valorResultado,id_unidadMedida_fk,id_itemEstudioLaboratorio_fk,id_laboratorio_fk
from DetalleLaboratorio

drop table DetalleItemLaboratorio
---------------------------------------------------------------------------------------------
select ln.fechaSolicitud, ln.doctorACargo,ln.observacionDeLosResultados,il.nombre,rd.conceptoInicial,rd.diagnostico,dre.valorResultado
from LaboratorioNueva ln,itemLaboratorio il,DetalleLaboratorio dl,RazonamientoDiagnostico rd,DetalleResultadoEstudio dre
where ln.id_itemLaboratorio_fk=il.id_itemLaboratorio
and ln.id_laboratorio=dl.id_laboratorio_fk
and rd.id_razonamiento=ln.id_razonamientoDiagnostico_fk
and dl.id_detalleLaboratorio=dre.id_detalleLaboratorio
-------------------------------------------------------------------------------------
select *
from DetalleLaboratorio

ALTER TABLE Laboratorio DROP constraint id_analisisLaboratorio_fk
ALTER TABLE DetalleLaboratorio ADD FOREIGN KEY (id_laboratorio_fk) REFERENCES LaboratorioNueva(id_laboratorio)

ALTER TABLE DetalleLaboratorio DROP CONSTRAINT id_itemEstudioLaboratorio_fk
ALTER TABLE DetalleLaboratorio ADD FOREIGN KEY (id_itemEstudioLaboratorio_fk) REFERENCES ItemLaboratorio(id_itemLaboratorio)

alter table DetalleLaboratorio
nocheck constraint id_unidadMedida_fk

insert into LaboratorioNueva(id_laboratorio,fechaSolicitud,fechaRealizacion,doctorACargo,id_institucion_fk,observacionDeLosResultados,indicaciones,id_itemLaboratorio_fk,id_metodoAnalisisLaboratorio_fk,id_razonamientoDiagnostico_fk)
select *
from Laboratorio
where id_laboratorio=15;

SET IDENTITY_INSERT LaboratorioNueva ON

SET IDENTITY_INSERT DetalleLaboratorio ON

ALTER TABLE LaboratorioNueva NOCHECK CONSTRAINT FK__Laborator__id_it__1293BD5E;
ALTER TABLE LaboratorioNueva NOCHECK CONSTRAINT FK__Laborator__id_ra__147C05D0;

delete from LaboratorioNueva
drop table Laboratorio


select *
from LaboratorioNueva ln,DetalleLaboratorio dl,itemLaboratorio il
where ln.id_laboratorio=dl.id_laboratorio_fk and dl.id_itemEstudioLaboratorio_fk=il.id_itemLaboratorio

select *
from DetalleLaboratorio

select *
from DetalleResultadoEstudio

select *
from DetalleLaboratorio
insert into DetalleLaboratorio(id_unidadMedida_fk,id_itemEstudioLaboratorio_fk,id_laboratorio_fk)
                                values(1,2,15)


select l.id_laboratorio, l.fechaSolicitud,il.nombre,l.indicaciones
                                from RazonamientoDiagnostico r, EstadoDiagnostico ediag, LaboratorioNueva l, ItemLaboratorio il
                                where r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and l.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and l.id_itemLaboratorio_fk=il.id_itemLaboratorio
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and r.id_razonamiento=13
                                and l.fechaRealizacion is null


select *
from EvolucionDiagnostico ed, RazonamientoDiagnostico rd,Tratamiento t
where ed.id_diagnostico=rd.id_razonamiento
and t.id_razonamientoDiagnostico_fk=rd.id_razonamiento

select *
from Tratamiento

select *
from ProgramacionMedicamento


select  id_tratamiento,indicaciones,fechaInicio,motivoInicioTratamiento, id_terapia_fk
                                    from Tratamiento t , Terapia te
                                    where t.id_terapia_fk=te.id_terapia
                                    and t.id_razonamientoDiagnostico_fk=13
                                    and t.fechaFin is null


update Tratamiento
set fechaFin=null, motivoFinTratamiento=null
where id_tratamiento=9 
and id_razonamientoDiagnostico_fk=13;



select  t.id_tratamiento,t.indicaciones,t.fechaInicio,t.motivoInicioTratamiento, te.id_terapia, te.nombre
                                    from Tratamiento t , Terapia te
                                    where t.id_terapia_fk=te.id_terapia
                                    and t.id_razonamientoDiagnostico_fk=@idRazonamientoDiagnostico
                                    and t.fechaFin is null