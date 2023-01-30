alter session set "_oracle_script" = true;
create user proyecto identified by 2802;
grant dba to proyecto;

/*==============================================================*/
/* Table: RESIDENCIA                                                 */
/*==============================================================*/
create table Residencia(
idResidencia number not null,
numResidentesMax int not null,
constraint pk_residencia primary key(idResidencia)
);
Alter table residencia  add tipoResidencia varchar2(30) not null; 
alter table residencia add constraint ckc_tiporesidencia check(tipoResidencia in('Reptiliario Grande','Reptiliario Pequenio','Terrario','Casa Perro','Casa Gato','Acuario','Jaula'));

/*==============================================================*/
/* Table: DUENIO                                                 */
/*==============================================================*/
create table Duenio(
cedulaDuenio number not null,
nombreDuenio varchar2(40) not null,
numTelefonoDuenio number not null,
constraint pk_duenio primary key(cedulaDuenio)
);

/*==============================================================*/
/* Table: EMPLEADO                                                 */
/*==============================================================*/
create table Empleado(
codEmpleado number not null,
nombreEmpleado varchar2(25) not null,
apellidoEmpleado varchar2(40) not null,
cargoEmpleado varchar2(25) not null,
fechaIngreso date not null,
salarioEmpleado integer not null,
constraint pk_empleado primary key(codEmpleado),
constraint ckc_cargoEmpleado check(cargoEmpleado in('Veterinario','Auxiliar','Gerente','Vendedor'))
);

/*==============================================================*/
/* Table: PRODUCTO                                                 */
/*==============================================================*/
create table Producto(
serialProducto number not null,
nombreProducto varchar2(30) not null,
precioProducto integer not null,
tipoProducto varchar2(25) not null,
constraint pk_producto primary key(serialProducto),
constraint ckc_tipoProducto check(tipoProducto in('Alimento','Medicamento','Juguete','Accesorio','Hogar'))
);

/*==============================================================*/
/* Table: MASCOTA                                                 */
/*==============================================================*/
create table Mascota(
idMascota number not null,
nombreMascota varchar2(30) not null,
tipoMascota varchar2(20) not null,
especieMascota varchar2(30) not null,
generoMascota varchar2(30) not null,
cedulaDuenio number not null,
constraint pk_mascota primary key(idMascota),
constraint fk_duemasco foreign key (cedulaDuenio) references Duenio(cedulaDuenio) on delete cascade
);
alter table mascota add constraint ckc_generoMascota check(generoMascota in('Macho','Hembra'));
alter table mascota add constraint ckc_tipomascota check(tipoMascota in('Reptil','Perro','Gato','Anfibio','Pez','Roedor'));

/*==============================================================*/
/* Table: ALOJA                                                 */
/*==============================================================*/
create table Aloja (
idAloja number generated always as identity not null,
idResidencia number not null,
idMascota number not null,
fechaInicioAlojamiento timestamp not null,
fechaFinAlojamiento timestamp not null,
constraint pk_aloja primary key(idAloja),
constraint fk_resialoj foreign key(idResidencia) references Residencia(idResidencia) on delete cascade,
constraint fk_mascoaloj foreign key(idMascota) references Mascota(idMascota) on delete cascade,
constraint uq_fechaini unique(fechaInicioAlojamiento) 
);

/*==============================================================*/
/* Table: ATIENDE                                                 */
/*==============================================================*/
create table atiende(
idAtencion number generated always as identity not null,
codEmpleado number not null,
idMascota number not null,
tipoAtencion varchar2(30) not null,
fechaAtencion date not null,
costoAtencion varchar2(25) not null,
descriptcion varchar2(50),
constraint pk_atiende primary key(idAtencion),
constraint fk_empatiende foreign key(codEmpleado) references Empleado(codEmpleado) on delete cascade,
constraint fk_mascoatiende foreign key(idMascota) references Mascota(idMascota) on delete cascade,
constraint ckc_tipoAtencion check(tipoAtencion in('Medica','Limpieza','Consulta')) 
);

/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
create table venta(
idVenta number generated always as identity not null,
idProducto number not null,
idEmpleado number not null,
numProducto number not null,
fechaVenta timestamp not null,
valorVenta integer not null,
constraint pk_venta primary key(idVenta),
constraint fk_prodvent foreign key(idProducto) references Producto(serialProducto) on delete cascade,
constraint fk_empvent foreign key(idEmpleado) references Empleado(codEmpleado) on delete cascade
);

/*==============================================================*/
/* Table: HACECOMPRA                                                 */
/*==============================================================*/
create table haceCompra(
idCliente number not null,
idVenta number not null,
constraint pk_haceCompra primary key(idCliente,idVenta),
constraint fk_clihaComp foreign key(idCliente) references Duenio(cedulaDuenio) on delete cascade,
constraint fk_venthaComp foreign key(idVenta) references Venta(idVenta) on delete cascade
);