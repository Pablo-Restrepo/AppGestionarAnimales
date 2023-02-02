/*==============================================================*/
/* Table: RESIDENCIA                                                 */
/*==============================================================*/
insert into residencia values (1,1,'Reptiliario Grande');
insert into residencia values (2,1,'Reptiliario Pequenio');
insert into residencia values (3,2,'Terrario');
insert into residencia values (4,2,'Casa Perro');
insert into residencia values (5,2,'Casa Gato');
insert into residencia values (6,10,'Acuario');
insert into residencia values (7,1,'Jaula');
insert into residencia values (8,2,'Casa Perro');

/*==============================================================*/
/* Table: DUENIO                                                 */
/*==============================================================*/
insert into Duenio values(1001,'Samuel',3123456789);
insert into Duenio values(1002,'Ruben',1235677489);
insert into Duenio values(1003,'Juan',7778889991);
insert into Duenio values(1004,'Alejandro',1112223334);
insert into Duenio values(1005,'Guillermo',4445556667);
insert into Duenio values(1006,'Miguel',9991112223);
insert into Duenio values(1007,'Hernandez',3334445556);

/*==============================================================*/
/* Table: EMPLEADO                                                 */
/*==============================================================*/
insert into Empleado(CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) values(100,'Raul','Alvarez','Gerente',500000);
insert into Empleado(CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) values(200,'Sara','Moledo','Veterinario',400000);
insert into Empleado(CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) values(300,'Oswaldo','Palacios','Veterinario',400000);
insert into Empleado(CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) values(400,'Juan','Guarnizo','Auxiliar',350000);
insert into Empleado(CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) values(500,'Aroia','Garcia','Vendedor',300000);

/*==============================================================*/
/* Table: PRODUCTO                                                 */
/*==============================================================*/
insert into producto values(7000,'Cama Perro',1000,'Hogar');
insert into producto values(7001,'Pastilla contra Pulgas',500,'Medicamento');
insert into producto values(7002,'Nutre Can Bulto',700,'Alimento');
insert into producto values(7003,'Collar para Perro de cadena',1000,'Accesorio');
insert into producto values(7004,'Hueso Chillon',1000,'Juguete');

/*==============================================================*/
/* Table: MASCOTA                                                 */
/*==============================================================*/
insert into mascota values (1,'Tomy','Perro','Criollo','Macho',1001);
insert into mascota values (2,'Gertrudis','Reptil','Camaleon','Hembra',1002);
insert into mascota values (3,'Nucita','Roedor','Conejiillo','Hembra',1003);
insert into mascota values (4,'Agata','Gato','Mestizo','Hembra',1004);
insert into mascota values (5,'Nemo','Pez','Pez Payaso','Macho',1005);
insert into mascota values (6,'Sally','Anfibio','Anaconda','Macho',1006);
insert into mascota values (7,'Nieve','Perro','Criollo','Hembra',1007);

/*==============================================================*/
/* Table: ALOJA                                                 */
/*==============================================================*/
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (4,1,'08/05/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (4,1,'08/05/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (2,2,'28/05/2020 18:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (7,3,'02/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (5,4,'20/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (6,5,'30/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (1,6,'30/09/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAFINALOJAMIENTO) values (8,7,'12/10/2020 14:45:00');

/*==============================================================*/
/* Table: ATIENDE                                                 */
/*==============================================================*/
insert into atiende(CODEMPLEADO,IDMASCOTA,TIPOATENCION,COSTOATENCION,DESCRIPTCION) values (300,2,'Medica',30000,'Malestar estomacal');
insert into atiende(CODEMPLEADO,IDMASCOTA,TIPOATENCION,COSTOATENCION,DESCRIPTCION) values (200,1,'Limpieza',20000,'Baño y Peluquiada');
insert into atiende(CODEMPLEADO,IDMASCOTA,TIPOATENCION,COSTOATENCION,DESCRIPTCION) values (200,3,'Consulta',30000,'Secreciones extranias');
insert into atiende(CODEMPLEADO,IDMASCOTA,TIPOATENCION,COSTOATENCION,DESCRIPTCION) values (300,4,'Medica',50000,'Bacterias estomacales');


/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
insert into venta(IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO) values (7000,100,2);
insert into venta(IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO) values (7001,200,4);
insert into venta(IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO) values (7003,300,3);
insert into venta(IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO) values (7004,400,6);

/*==============================================================*/
/* Table: HACECOMPRA                                            */
/*==============================================================*/
insert into hacecompra values (1001,2);
insert into hacecompra values (1002,1);
insert into hacecompra values (1003,3);
insert into hacecompra values (1004,4);