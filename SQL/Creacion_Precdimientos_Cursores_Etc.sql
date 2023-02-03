/*==============================================================*/
/* PAQUETE CON FUNCION Y PROCEDIMIENTO QUE USA CURSOR                                      */
/*==============================================================*/
CREATE OR REPLACE PACKAGE paq_gerente as
    FUNCTION total_ingresos_empleado(p_codEmpleado IN NUMBER, p_fechaInicio IN DATE, p_fechaFin IN DATE)
        RETURN INTEGER;
    
    PROCEDURE pr_verificacion_residencias(p_cursor OUT SYS_REFCURSOR) ;
    
    PROCEDURE listar_empleados(p_fechaInicio IN DATE, p_fechaFin IN DATE, p_cursor OUT SYS_REFCURSOR);
END paq_gerente;    

Create or replace package body paq_gerente as
    FUNCTION total_ingresos_empleado(p_codEmpleado IN NUMBER, p_fechaInicio IN DATE, p_fechaFin IN DATE)
    RETURN INTEGER
    AS
        v_total INTEGER;
    BEGIN
        SELECT SUM(valorVenta)
        INTO v_total
        FROM venta
        WHERE idEmpleado = p_codEmpleado
        AND fechaVenta BETWEEN p_fechaInicio AND p_fechaFin;
    
        RETURN v_total;
    END;

    PROCEDURE pr_verificacion_residencias(p_cursor OUT SYS_REFCURSOR) as
        v_id_residencia NUMBER;
        v_tipo_residencia VARCHAR2(30);
    BEGIN
        FOR a IN (SELECT IDRESIDENCIA, TIPORESIDENCIA FROM RESIDENCIA) LOOP
            v_id_residencia := a.IDRESIDENCIA;
            v_tipo_residencia := a.TIPORESIDENCIA;
            OPEN p_cursor for               
            SELECT aloja.IDRESIDENCIA, NOMBREMASCOTA, TIPOMASCOTA, ESPECIEMASCOTA, GENEROMASCOTA
            FROM MASCOTA inner join aloja
            on mascota.idmascota = aloja.idmascota
            WHERE mascota.IDMASCOTA IN (SELECT aloja.IDMASCOTA
                                FROM ALOJA
                                WHERE aloja.IDRESIDENCIA = v_id_residencia);
        END loop;
    END pr_verificacion_residencias;
    
    PROCEDURE listar_empleados(p_fechaInicio IN DATE, p_fechaFin IN DATE, p_cursor OUT SYS_REFCURSOR)
    AS
    BEGIN
        OPEN p_cursor FOR
        SELECT codEmpleado, nombreEmpleado, apellidoEmpleado, cargoEmpleado, fechaIngreso, salarioEmpleado
        FROM empleado
        WHERE fechaIngreso BETWEEN p_fechaInicio AND p_fechaFin;
    END listar_empleados;
end paq_gerente;


---Probando el procedimiento
set serveroutput on;
DECLARE
  p_cursor SYS_REFCURSOR;
  v_id_residencia NUMBER;
  v_nombre_mascota VARCHAR2(30);
  v_tipo_mascota VARCHAR2(30);
  v_especie_mascota VARCHAR2(30);
  v_genero_mascota VARCHAR2(30);
BEGIN
  paq_gerente.pr_verificacion_residencias(p_cursor);
  LOOP
    FETCH p_cursor INTO v_id_residencia, v_nombre_mascota, v_tipo_mascota, v_especie_mascota, v_genero_mascota;
    EXIT WHEN p_cursor%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE('ID Residencia: ' || v_id_residencia || ' Nombre Mascota: ' || v_nombre_mascota || ' Tipo Mascota: ' || v_tipo_mascota || ' Especie Mascota: ' || v_especie_mascota || ' Género Mascota: ' || v_genero_mascota);
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