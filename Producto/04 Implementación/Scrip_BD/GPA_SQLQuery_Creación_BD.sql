
--CREATE DATABASE GPA_BD_2;

CREATE TABLE Historia_Clinica(
id_hc integer PRIMARY KEY IDENTITY,
nro_hc integer NOT NULL,
fecha_creación date NOT NULL,
diagnostico varchar(20),
antecedentes varchar(20),
fecha_inicio_atencion_con_profesional date not null
)

CREATE TABLE Estudio(
id_estudio integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
fecha_estudio date not null,
doctorACargo varchar(30) not null,
informe_estudio text not null,
id_hc_fk integer not null,
id_institucion_fk integer not null,
FOREIGN KEY (id_hc_fk) REFERENCES Historia_Clinica(id_hc))

CREATE TABLE Institucion(
id_institucion integer PRIMARY KEY IDENTITY,
nombre varchar(30) not null,
descripcion varchar(200))

ALTER TABLE Estudio
add FOREIGN KEY (id_institucion_fk) REFERENCES Institucion(id_institucion);


CREATE TABLE Domicilio(
id_domicilio integer PRIMARY KEY IDENTITY,
calle varchar(200) not null,
numero integer not null,
codigo_postal integer not null,
piso integer,
departamento varchar(20),
id_institucion integer,
id_barrio integer not null,
FOREIGN KEY (id_institucion) REFERENCES Institucion(id_institucion))


CREATE TABLE Barrio(
id_barrio integer PRIMARY KEY IDENTITY,
nombre varchar(20)not null,
descripcion varchar(50),
id_localidad_fk integer not null)

ALTER TABLE Domicilio
add FOREIGN KEY (id_barrio) REFERENCES Barrio(id_barrio);

CREATE TABLE Localidad(
id_localidad integer PRIMARY KEY IDENTITY,
nombre varchar(20) not null)

ALTER TABLE Barrio
add FOREIGN KEY (id_localidad_fk) REFERENCES localidad(id_localidad);

CREATE TABLE Laboratorio(
id_laboratorio integer PRIMARY KEY IDENTITY,
fecha date not null,
ficha varchar(20),
doctorACargo varchar(20) not null)

CREATE TABLE EstudioLaboratorio(
id_estudioLab integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
metodo varchar(200) not null,
id_laboratorio_fk integer not null,
FOREIGN KEY (id_laboratorio_fk) REFERENCES laboratorio(id_laboratorio))

CREATE TABLE DetalleEstudioLaboratorio(
id_detalleEstudioLab integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
resultado float not null,
unidad varchar(200) not null,
id_estudioLab_fk integer not null,
FOREIGN KEY (id_estudioLab_fk) REFERENCES estudioLaboratorio(id_estudioLab))

CREATE TABLE ValorReferencia(
id_valorReferencia integer PRIMARY KEY IDENTITY,
nombre varchar(200) not null,
valorDesde float,
valorHasta float,
id_detalleEstudioLab_fk integer not null,
FOREIGN KEY (id_detalleEstudioLab_fk) REFERENCES detalleEstudioLaboratorio(id_detalleEstudioLab))

CREATE TABLE DetalleValorReferencia(
id_detalleValorReferencia integer PRIMARY KEY IDENTITY,
descripcion varchar(200),
valorDesde float not null,
valorHasta float not null,
id_valorReferencia_fk integer not null,
FOREIGN KEY (id_valorReferencia_fk) REFERENCES valorReferencia(id_valorReferencia))


create table TipoDocumento(
id_tipoDoc int primary key identity,
nombre varchar(100))

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
fecha_inicio_tratamiento date not null,
edad int not null,
altura float,
peso int,
id_hc_fk int not null,
PRIMARY KEY (id_tipoDoc_fk,nro_documento),
FOREIGN KEY (id_hc_fk) REFERENCES Historia_Clinica(id_hc))

CREATE TABLE Estado (
id_estado int PRIMARY KEY IDENTITY,
nombre varchar(50) not null,
descripcion varchar(50))

CREATE TABLE Usuario(
id_usuario int primary key identity,
nombre_usuario varchar(100) not null,
contraseña  varbinary(50) not null,
fecha_creacion date not null)

alter table Paciente
add foreign key (id_usuario_fk) references Usuario(id_usuario),
foreign key (id_estado_fk) references Estado(id_estado),
foreign key (id_tipodoc_fk) references TipoDocumento(id_tipoDoc)

CREATE TABLE ProfesionalMedico (
id_tipodoc_fk int not null,
nro_documento int not null,
nombre varchar(100) not null,
apellido varchar(100),
telefono varchar(100),
nroCelular varchar(100),
email varchar(100),
id_usuario_fk int not null,
id_estado_fk int not null,
id_especialidad_fk int not null,
PRIMARY KEY (id_tipodoc_fk,nro_documento))

create table Especialidad(
id_especialidad int primary key identity,
nombre varchar(100) not null,
descripcion varchar(100) not null)

alter table ProfesionalMedico
add foreign key(id_usuario_fk) references Usuario(id_usuario),
foreign key (id_estado_fk) references Estado(id_estado),
foreign key (id_especialidad_fk) references Especialidad(id_especialidad)

alter table ProfesionalMedico
add matricula_profesional varchar(100)


CREATE TABLE UsuarioNuevo(
id_usuario int primary key identity,
nombre_usuario varchar(100) not null,
contraseña  varbinary(max) not null,
fecha_creacion date not null)


