CREATE OR REPLACE PACKAGE paq_gerente as
    FUNCTION total_ingresos_empleado(p_codEmpleado IN NUMBER, p_fechaInicio IN DATE, p_fechaFin IN DATE);
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
end paq_gerente;

CREATE OR REPLACE TRIGGER tr_actualizar_fecha_ingreso
BEFORE INSERT ON Empleado
FOR EACH ROW
BEGIN
  :new.fechaIngreso := SYSDATE;
END;

CREATE OR REPLACE TRIGGER tr_actualizar_fecha_alojamiento
BEFORE INSERT ON Aloja
FOR EACH ROW
BEGIN
  :new.fechaInicioAlojamiento := SYSTIMESTAMP;
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