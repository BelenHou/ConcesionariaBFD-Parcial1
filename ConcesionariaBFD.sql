
CREATE DATABASE ConcesionariaBFD;
GO


USE ConcesionariaBFD;
GO

-- Tabla para Empleados
CREATE TABLE Empleados (
    ID_empleado INT PRIMARY KEY identity (1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
	NombreUsuario NVARCHAR(50) NOT NULL UNIQUE, -- Nombre de usuario único
    Contraseña NVARCHAR(255) NOT NULL, 
    Turno NVARCHAR(50) CHECK (Turno IN ('mañana', 'tarde')), -- Restricción para turno
    Puesto NVARCHAR(50) CHECK (Puesto IN ('Gerente', 'Empleado')) -- Restricción para puesto
);

--	SOLO EL QUE ES GERENTE PUEDE AGREGAR AUTOS EN LA APLICACION. EL EMPLEADO TIENE DESHABILITADA ESA OPCION.

-- Tabla para Auto
CREATE TABLE Auto (
    ID_auto INT PRIMARY KEY identity (1,1) ,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Patente NVARCHAR(20) NOT NULL,
    Anio INT NOT NULL,
    Estado NVARCHAR(50) CHECK (Estado IN ('disponible', 'vendido')), -- Restricción para estado
    ID_empleado INT NOT NULL,
	Precio decimal (10,2) NOT NULL, 
    FOREIGN KEY (ID_empleado) REFERENCES Empleados(ID_empleado) -- Relación con Empleados
);

-- Tabla para Comprobante
CREATE TABLE Comprobante (
    ID_comprobante INT PRIMARY KEY identity (1,1),
    Tipo NVARCHAR(50) NOT NULL CHECK (Tipo IN ('compra', 'venta')), -- Restricción para tipo
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha actual por defecto
    ID_auto INT NOT NULL,
    ID_empleado INT NOT NULL,
    Estado NVARCHAR(50),
    Observaciones NVARCHAR(MAX),
    Precio DECIMAL(10, 2) NOT NULL, -- Precio en decimales
    FOREIGN KEY (ID_auto) REFERENCES Auto(ID_auto), -- Relación con Auto
    FOREIGN KEY (ID_empleado) REFERENCES Empleados(ID_empleado) -- Relación con Empleados
);

-- Tabla para Servicios
CREATE TABLE Servicios
(
    ID_servicio INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(255) NOT NULL,
    Fecha DATETIME NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    ID_empleado INT NOT NULL,
    FOREIGN KEY (ID_empleado) REFERENCES Empleados(ID_empleado)
);


INSERT INTO Empleados(Nombre, Apellido, NombreUsuario,Contraseña,Turno,Puesto)
VALUES ('Gaston', 'Quiroga', 'Empleado', 'Contraseña','Mañana', 'Empleado'),
('Franco','Milani', 'Gerente', 'Contraseña', 'Mañana', 'Gerente');

INSERT INTO Auto (Marca, Modelo, Color, Patente, Anio, Estado, ID_empleado, Precio) 
VALUES ('Toyota', 'Corolla', 'Blanco', 'AAA111', 2020, 'disponible', 1, 3500000),
('Ford', 'Fiesta', 'Negro', 'BBB222', 2018, 'disponible', 1, 2800000),
('Chevrolet', 'Onix', 'Rojo', 'CCC333', 2021, 'disponible', 1, 3300000),
('Renault', 'Kwid', 'Gris', 'DDD444', 2019, 'disponible', 1, 2500000),
('Volkswagen', 'Gol', 'Azul', 'EEE555', 2022, 'disponible', 1, 3700000),
('Peugeot', '208', 'Negro', 'FFF666', 2020, 'disponible', 1, 3000000),
('Fiat', 'Cronos', 'Blanco', 'GGG777', 2021, 'disponible', 1, 3400000),
('Nissan', 'Versa', 'Gris', 'HHH888', 2023, 'disponible', 1, 3900000),
('Honda', 'Civic', 'Rojo', 'III999', 2017, 'vendido', 1, 3200000),
('Citroën', 'C3', 'Verde', 'JJJ000', 2018, 'disponible', 1, 3100000);

INSERT INTO Comprobante (Tipo, FechaHora, ID_auto, ID_empleado, Estado, Observaciones, Precio) 
VALUES  ('venta', '2025-04-10', 2, 2, 'emitido', 'Cliente pagó en efectivo', 2800000),
('venta','2025-04-10', 4, 2, 'emitido', 'Financiación 12 cuotas', 2500000),
('compra','2025-04-15', 1, 1, 'registrado', 'Auto recibido usado', 3500000),
('compra', '2025-04-25', 3, 1, 'registrado', 'Vehículo nuevo de agencia', 3300000),
('venta', '2025-04-20', 6, 2, 'emitido', 'Cliente habitual', 3000000),
('venta', '2025-04-05', 9, 1, 'emitido', 'Venta con descuento', 3200000),
('compra', '2025-04-12', 5, 1, 'registrado', 'Auto en promoción', 3700000),
('venta', '2025-04-12', 10, 2, 'emitido', 'Cliente empresa', 3100000),
('compra', GETDATE(), 7, 1, 'registrado', 'Auto parte de permuta', 3400000),
('venta', GETDATE(), 8, 2, 'emitido', 'Contado con factura A', 3900000);

INSERT INTO Servicios (Descripcion, Fecha, Estado, ID_empleado) VALUES
('Cambio de aceite y filtro', '2025-05-01', 'completado', 1),
('Alineación y balanceo', '2025-05-22', 'pendiente', 2),
('Revisión general', '2025-05-05', 'completado', 1),
('Lavado completo', '2025-05-16', 'pendiente', 2),
('Cambio de frenos', '2025-05-07', 'completado', 1),
('Cambio de neumáticos', '2025-05-18', 'pendiente', 2),
('Control de luces', '2025-05-09', 'completado', 1),
('Revisión aire acondicionado', '2025-05-15', 'pendiente', 2),
('Carga de batería', '2025-05-11', 'completado', 1),
('Diagnóstico electrónico', '2025-05-20', 'pendiente', 2);


