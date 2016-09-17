select * from TipoDocumento
select * from ProfesionalMedico

select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', e.nombre as 'Estado', s.nombre as'Sexo'
from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, Estado e, Sexo s
where p.id_profesionalMedico_tipoDoc_fk='8'and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_estado_fk=e.id_estado and p.id_sexo_fk= s.id_sexo

select * from Barrio
select * from Paciente

select id_usuario 
from Usuario 
where nombre_usuario='LJ' and CONVERT(varchar(255), DECRYPTBYPASSPHRASE('clave',contraseña))='102030'

select id_usuario
from Usuario
where nombre_usuario='LJ' and pwdcompare('102030',contraseña)='1'



select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', pm.nombre , pm.apellido, pm.matricula, pm.email, pm.nroCelular, es.nombre
from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es
where p.id_profesionalMedico_tipoDoc_fk='8'and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_profesionalMedico_tipoDoc_fk=pm.id_tipodoc_fk and p.id_profesionalMedico_nroDoc_fk=pm.nro_documento
and pm.id_especialidad_fk= es.id_especialidad
and p.id_tipoDoc_fk='8' and p.nro_documento='20258789' and p.nombre like 'Juan' and p.apellido like 'Rodriguez'

select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', pm.nombre , pm.apellido, pm.matricula, pm.email, pm.nroCelular, es.nombre
from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es
where p.id_profesionalMedico_tipoDoc_fk='8'and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_profesionalMedico_tipoDoc_fk=pm.id_tipodoc_fk and p.id_profesionalMedico_nroDoc_fk=pm.nro_documento
and pm.id_especialidad_fk= es.id_especialidad
and p.id_tipoDoc_fk='8' and p.nro_documento='20258789' and p.nombre + ' ' + p.apellido like 'Juan' +' '+ 'Rodriguez'

select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero, b.nombre as 'Barrio', l.nombre as 'Localidad', pm.nombre , pm.apellido, pm.matricula, pm.email, pm.nroCelular, es.nombre
from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es
where p.id_profesionalMedico_tipoDoc_fk='8'and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_profesionalMedico_tipoDoc_fk=pm.id_tipodoc_fk and p.id_profesionalMedico_nroDoc_fk=pm.nro_documento
and pm.id_especialidad_fk= es.id_especialidad
and p.nombre +' '+ p.apellido like 'M%'


select p.nombre as 'Nombre', p.apellido as 'Apellido', td.nombre as 'TipoDocumento', p.nro_documento as 'Número de documento', d.calle, d.numero as 'Número', b.nombre as 'Barrio', l.nombre as 'Localidad', e.nombre as Estado, s.nombre as 'Sexo'
from Paciente p, TipoDocumento td, Domicilio d, Barrio b, Localidad l, ProfesionalMedico pm, Especialidad es, Estado e, Sexo s
where p.id_profesionalMedico_tipoDoc_fk='8' and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk=td.id_tipoDoc and p.id_domicilio_fk=d.id_domicilio 
and d.id_barrio_fk=b.id_barrio and b.id_localidad_fk=l.id_localidad
and p.id_sexo_fk=s.id_sexo and p.id_estado_fk=e.id_estado
and p.id_tipoDoc_fk='8' and p.nro_documento='20000325' and p.nombre+' '+p.apellido like '%Martín%'

select p.nombre as 'Nombre', p.apellido as 'Apellido', p.telefono, p.nroCelular, p.email, p.fecha_nacimiento, p.altura, p.peso, p.id_domicilio_fk, p.id_profesionalMedico_tipoDoc_fk, p.id_profesionalMedico_nroDoc_fk
from Paciente p
where p.id_profesionalMedico_tipoDoc_fk='8' and p.id_profesionalMedico_nroDoc_fk='15036547'
and p.id_tipoDoc_fk='8' and p.nro_documento='20258789';

select pm.id_tipodoc_fk,pm.nro_documento, pm.nombre, pm.apellido , td.nombre as 'Tipo de Documento'
from ProfesionalMedico pm,TipoDocumento td
where pm.id_tipodoc_fk=td.id_tipoDoc and pm.id_usuario_fk='24'

select nombre,apellido, matricula, id_especialidad_fk, nroCelular, email 
from ProfesionalMedico pm,TipoDocumento
where id_tipodoc_fk='8' and nro_documento='15036547';
                                 
