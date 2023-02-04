/*==============================================================*/
/* PAQUETE CON FUNCION Y PROCEDIMIENTO QUE USA CURSOR                                      */
/*==============================================================*/
CREATE OR REPLACE PACKAGE paq_gerente as
    FUNCTION total_ingresos_empleado(p_codEmpleado IN NUMBER, p_fechaInicio IN DATE, p_fechaFin IN DATE)
        RETURN number;
    
    PROCEDURE pr_verificacion_residencias(p_tipo_residencia varchar2,p_cursor OUT SYS_REFCURSOR) ;
    
    PROCEDURE listar_empleados(p_fechaInicio IN DATE, p_fechaFin IN DATE, p_cursor OUT SYS_REFCURSOR);
END paq_gerente;    

Create or replace package body paq_gerente as
    FUNCTION total_ingresos_empleado(p_codEmpleado IN NUMBER, p_fechaInicio IN DATE, p_fechaFin IN DATE)
    RETURN number
    AS
        v_total number;
    BEGIN
        SELECT SUM(valorVenta) as IngresoXEmpleado
        INTO v_total
        FROM venta
        WHERE idEmpleado = p_codEmpleado
        AND fechaVenta BETWEEN p_fechaInicio AND p_fechaFin;
    
        RETURN v_total;
    END;

    PROCEDURE pr_verificacion_residencias(p_tipo_residencia varchar2, p_cursor OUT SYS_REFCURSOR) as
        v_id_residencia NUMBER;
    BEGIN
        open p_cursor for
            SELECT tiporesidencia as Tipo_De_Residencia, NOMBREMASCOTA as Nombre_de_Mascota, TIPOMASCOTA as Tipo_De_Mascota, ESPECIEMASCOTA as Especie_De_Mascota, GENEROMASCOTA as Genero_De_Mascota
            from aloja 
            inner join (select *
                        from residencia
                        where tiporesidencia like p_tipo_residencia) RESIDENCIA_FILTRADA
            on aloja.idresidencia = RESIDENCIA_FILTRADA.idresidencia
            inner join mascota
            on aloja.idmascota = mascota.idmascota;
    END pr_verificacion_residencias;
    
    PROCEDURE listar_empleados(p_fechaInicio IN DATE, p_fechaFin IN DATE, p_cursor OUT SYS_REFCURSOR)
    AS
    BEGIN
        OPEN p_cursor FOR
        SELECT codEmpleado as Codigo_Empleado, nombreEmpleado as Nombre_De_Empleado, apellidoEmpleado as Apellido_De_Empleado, cargoEmpleado as Cargo_De_Empleado, fechaIngreso as Fecha_De_Ingreso, salarioEmpleado as Salario_De_Empleado
        FROM empleado
        WHERE fechaIngreso BETWEEN p_fechaInicio AND p_fechaFin;
    END listar_empleados;
end paq_gerente;
--Probando la funcionalidad total_ingresos_empleado
set serveroutput on;
DECLARE
    v_total number;
BEGIN
    v_total := paq_gerente.total_ingresos_empleado(123, to_date('01/01/2020'), SYSDATE);
    DBMS_OUTPUT.PUT_LINE('Resultado: ' || v_total);
END;
---Probando el procedimiento pr_verificacion_residencias
set serveroutput on;
DECLARE
    p_cursor SYS_REFCURSOR;
    v_tipo_residencia VARCHAR2(30);
    v_nombre_mascota VARCHAR2(30);
    v_tipo_mascota VARCHAR2(30);
    v_especie_mascota VARCHAR2(30);
    v_genero_mascota VARCHAR2(30);
    p_tipo_residencia VARCHAR2(30);

BEGIN
    p_tipo_residencia := 'Acuario';
    paq_gerente.pr_verificacion_residencias(p_tipo_residencia,p_cursor);
    LOOP
        FETCH p_cursor INTO v_tipo_residencia, v_nombre_mascota, v_tipo_mascota, v_especie_mascota, v_genero_mascota;
        EXIT WHEN p_cursor%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('Tipo de residencia: ' || v_tipo_residencia || ', Nombre de Mascota: ' || v_nombre_mascota || ', Tipo de Mascota: ' || v_tipo_mascota || ', Especie de Mascota: ' || v_especie_mascota || ', G�nero de Mascota: ' || v_genero_mascota);
    END LOOP;
    CLOSE p_cursor;
END;



/*==============================================================*/
/* TRIGGERS                                                */
/*==============================================================*/
CREATE OR REPLACE TRIGGER tr_actualizar_fecha_ingreso
BEFORE INSERT ON Empleado
FOR EACH ROW
BEGIN
    :new.fechaIngreso := SYSDATE;
END;

CREATE OR REPLACE TRIGGER tr_veficar_vet_atencion
BEFORE INSERT ON Atiende
FOR EACH ROW
declare
    v_cargo_empleado varchar2(20);
BEGIN
    Select cargoEmpleado into v_cargo_empleado 
    from empleado
    where codEmpleado like :new.codEmpleado;
    IF v_cargo_empleado <> 'Veterinario' THEN
        RAISE_APPLICATION_ERROR(-20001, 'El veterinario no puede atenderse a si mismo');
    END IF;
END;

CREATE OR REPLACE TRIGGER tr_actualizar_fecha_alojamiento
BEFORE INSERT ON Aloja
FOR EACH ROW
BEGIN
    :new.fechaInicioAlojamiento := SYSTIMESTAMP;
END;

CREATE OR REPLACE TRIGGER tr_actualizar_fecha_venta
BEFORE INSERT ON Venta
FOR EACH ROW
BEGIN
    :new.fechaVenta := SYSTIMESTAMP;
END;

CREATE OR REPLACE TRIGGER tr_actualizar_fecha_atencion
BEFORE INSERT ON Atiende
FOR EACH ROW
BEGIN
    :new.fechaAtencion := SYSDATE;
END;

CREATE OR REPLACE TRIGGER tr_ingreso_valor_venta
BEFORE INSERT ON venta
FOR EACH ROW
declare
    v_valor_producto integer;
BEGIN
    Select precioProducto into v_valor_producto
    from producto
    where serialProducto like :new.idProducto;
    :new.valorVenta := :new.numProducto*v_valor_producto;
END;