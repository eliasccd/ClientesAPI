USE master;
GO

IF DB_ID('EmpresaDB') IS NULL
BEGIN
    CREATE DATABASE EmpresaDB;
END
GO

USE EmpresaDB;
GO

IF OBJECT_ID('dbo.Clientes', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        Apellido VARCHAR(100) NOT NULL,
        Email VARCHAR(150) NOT NULL,
        Telefono VARCHAR(30) NULL
    );
END
GO

INSERT INTO dbo.Clientes (Nombre, Apellido, Email, Telefono)
VALUES
    ('Ana', 'García', 'ana.garcia@email.com', '555-1001'),
    ('Luis', 'Pérez', 'luis.perez@email.com', '555-1002'),
    ('María', 'López', 'maria.lopez@email.com', '555-1003');
GO
