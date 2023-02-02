/*==============================================================*/
/* Table: RESIDENCIA                                                 */
/*==============================================================*/
INSERT INTO RESIDENCIA VALUES (
    1, 1, 'Reptiliario Grande'
);

INSERT INTO RESIDENCIA VALUES (
    2, 1, 'Reptiliario Pequenio'
);

INSERT INTO RESIDENCIA VALUES (
    3, 2, 'Terrario'
);

INSERT INTO RESIDENCIA VALUES (
    4, 2, 'Casa Perro'
);

INSERT INTO RESIDENCIA VALUES (
    5, 2, 'Casa Gato'
);

INSERT INTO RESIDENCIA VALUES (
    6, 10, 'Acuario'
);

INSERT INTO RESIDENCIA VALUES (
    7, 1, 'Jaula'
);

INSERT INTO RESIDENCIA VALUES (
    8, 2, 'Casa Perro'
);

/*==============================================================*/
/* Table: DUENIO                                                 */
/*==============================================================*/
INSERT INTO DUENIO VALUES(
    1001, 'Samuel', 3123456789
);

INSERT INTO DUENIO VALUES(
    1002, 'Ruben', 1235677489
);

INSERT INTO DUENIO VALUES(
    1003, 'Juan', 7778889991
);

INSERT INTO DUENIO VALUES(
    1004, 'Alejandro', 1112223334
);

INSERT INTO DUENIO VALUES(
    1005, 'Guillermo', 4445556667
);

INSERT INTO DUENIO VALUES(
    1006, 'Miguel', 9991112223
);

INSERT INTO DUENIO VALUES(
    1007, 'Hernandez', 3334445556
);

/*==============================================================*/
/* Table: EMPLEADO                                                 */
/*==============================================================*/
INSERT INTO EMPLEADO VALUES(
    100, 'Raul', 'Alvarez', 'Gerente', '28/02/2019', 500000
);

INSERT INTO EMPLEADO VALUES(
    200, 'Sara', 'Moledo', 'Veterinario', '05/03/2019', 400000
);

INSERT INTO EMPLEADO VALUES(
    300, 'Oswaldo', 'Palacios', 'Veterinario', '25/04/2019', 400000
);

INSERT INTO EMPLEADO VALUES(
    400, 'Juan', 'Guarnizo', 'Auxiliar', '12/05/2019', 350000
);

INSERT INTO EMPLEADO VALUES(
    500, 'Aroia', 'Garcia', 'Vendedor', '28/02/2019', 300000
);

/*==============================================================*/
/* Table: PRODUCTO                                                 */
/*==============================================================*/
INSERT INTO PRODUCTO VALUES(
    7000, 'Cama Perro', 1000, 'Hogar'
);

INSERT INTO PRODUCTO VALUES(
    7001, 'Pastilla contra Pulgas', 500, 'Medicamento'
);

INSERT INTO PRODUCTO VALUES(
    7002, 'Nutre Can Bulto', 700, 'Alimento'
);

INSERT INTO PRODUCTO VALUES(
    7003, 'Collar para Perro de cadena', 1000, 'Accesorio'
);

INSERT INTO PRODUCTO VALUES(
    7004, 'Hueso Chillon', 1000, 'Juguete'
);

/*==============================================================*/
/* Table: MASCOTA                                                 */
/*==============================================================*/
INSERT INTO MASCOTA VALUES (
    1, 'Tomy', 'Perro', 'Criollo', 'Macho', 1001
);

INSERT INTO MASCOTA VALUES (
    2, 'Gertrudis', 'Reptil', 'Camaleon', 'Hembra', 1002
);

INSERT INTO MASCOTA VALUES (
    3, 'Nucita', 'Roedor', 'Conejiillo', 'Hembra', 1003
);

INSERT INTO MASCOTA VALUES (
    4, 'Agata', 'Gato', 'Mestizo', 'Hembra', 1004
);

INSERT INTO MASCOTA VALUES (
    5, 'Nemo', 'Pez', 'Pez Payaso', 'Macho', 1005
);

INSERT INTO MASCOTA VALUES (
    6, 'Sally', 'Anfibio', 'Anaconda', 'Macho', 1006
);

INSERT INTO MASCOTA VALUES (
    7, 'Nieve', 'Perro', 'Criollo', 'Hembra', 1007
);

/*==============================================================*/
/* Table: ALOJA                                                 */
/*==============================================================*/
INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    4, 1, '02/05/2020 14:45:00', '08/05/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    4, 1, '02/05/2020 14:45:00', '08/05/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    2, 2, '14/05/2020 18:45:00', '28/05/2020 18:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    7, 3, '25/07/2020 14:45:00', '02/08/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    5, 4, '16/08/2020 14:45:00', '20/08/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    6, 5, '17/08/2020 14:45:00', '30/08/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    1, 6, '23/09/2020 14:45:00', '30/09/2020 14:45:00'
);

INSERT INTO ALOJA(
    IDRESIDENCIA, IDMASCOTA, FECHAINICIOALOJAMIENTO, FECHAFINALOJAMIENTO
) VALUES (
    8, 7, '10/10/2020 14:45:00', '12/10/2020 14:45:00'
);