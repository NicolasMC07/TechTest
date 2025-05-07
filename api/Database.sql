-- Script completo para SQL Server
CREATE DATABASE PruebaTecnicaDB;
GO

USE PruebaTecnicaDB;
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) UNIQUE NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    FechaNacimiento DATE
);
GO

-- Datos de prueba
INSERT INTO Usuarios (Nombre, Apellido, Cedula, Direccion, Telefono, FechaNacimiento)
VALUES 
    ('Juan', 'Pérez', '1234567890', 'Calle 123', '3001234567', '1985-05-15'),
    ('María', 'Gómez', '0987654321', 'Avenida 456', '3109876543', '1990-10-20');
GO