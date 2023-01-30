}/*==============================================================*/
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
insert into Empleado values(100,'Raul','Alvarez','Gerente','28/02/2019',500000);
insert into Empleado values(200,'Sara','Moledo','Veterinario','05/03/2019',400000);
insert into Empleado values(300,'Oswaldo','Palacios','Veterinario','25/04/2019',400000);
insert into Empleado values(400,'Juan','Guarnizo','Auxiliar','12/05/2019',350000);
insert into Empleado values(500,'Aroia','Garcia','Vendedor','28/02/2019',300000);

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
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (4,1,'02/05/2020 14:45:00','08/05/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (4,1,'02/05/2020 14:45:00','08/05/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (2,2,'14/05/2020 18:45:00','28/05/2020 18:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (7,3,'25/07/2020 14:45:00','02/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (5,4,'16/08/2020 14:45:00','20/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (6,5,'17/08/2020 14:45:00','30/08/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (1,6,'23/09/2020 14:45:00','30/09/2020 14:45:00');
insert into aloja(IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) values (8,7,'10/10/2020 14:45:00','12/10/2020 14:45:00');