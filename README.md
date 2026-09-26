# ClientesAPI

ClientesAPI es una API REST diseñada para la administración y gestión de clientes de una empresa. El proyecto está desarrollado utilizando Visual Basic .NET, Entity Framework Core y SQL Server.

## Características
* Arquitectura REST limpia y estructurada.
* Mapeo de datos mediante Entity Framework Core.
* Documentación interactiva de endpoints con Swagger.
* Inicialización automática de datos de prueba mediante script SQL.

## Requisitos Previos
Antes de comenzar, asegúrate de tener instalado lo siguiente en tu entorno local:
* Visual Studio 2022 (con la carga de trabajo de desarrollo web y de escritorio de .NET).
* .NET SDK (versión compatible con el proyecto).
* SQL Server Express ejecutándose localmente.

## 1. Clonar el repositorio
Abre tu terminal y ejecuta los siguientes comandos para clonar el proyecto y acceder al directorio:

```bash
git clone https://github.com/eliasccd/ClientesAPI.git
cd ClientesAPI
```

## 2. Configurar la Base de Datos
Para crear la base de datos y cargar los registros iniciales de prueba, ejecuta el script SQL ubicado en `SQL/EmpresaDB.sql` o utiliza el siguiente bloque en SQL Server Management Studio:

```sql
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
```

## 3. Conexión a la Base de Datos
La cadena de conexión está configurada por defecto para apuntar al servidor local `.\SQLEXPRESS` utilizando Autenticación de Windows. La instancia local debe coincidir con este nombre para evitar errores de conexión.

Si utilizas una instancia diferente, modifica la cadena en `appsettings.json`:

```json
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
```

## 4. Abrir el proyecto en Visual Studio
1. Inicia Visual Studio 2022.
2. Selecciona la opción "Abrir un proyecto o una solución".
3. Busca y abre el archivo de configuración del proyecto:  
   `ClientesAPI/ClientesAPI/ClientesAPI.vbproj`

## 5. Ejecución y Pruebas
Para ejecutar la aplicación:
Si la página no se abre automáticamente al ejecutar el proyecto, accede manualmente a esta url. De acuerdo al localhost que aparezca solo agregar el /swagger/index.html al final de la url siendo el puerto 56582 o 61260.
   ```
   https://localhost:56582/swagger/index.html
   https://localhost:61260/swagger/index.html

   ```
Debido a que Visual Studio a veces intenta resolver la ruta web antes de que el servidor local de desarrollo se inicialice por completo, es posible que la página inicial no cargue de forma automática al presionar "Ejecutar".

## Endpoints disponibles

Una vez que Swagger esté abierto, podrás interactuar con los siguientes endpoints:

- **GET** `/api/clientes` - Obtiene la lista de todos los clientes
- **GET** `/api/clientes/{id}` - Obtiene un cliente específico por ID
- **POST** `/api/clientes` - Crea un nuevo cliente
- **PUT** `/api/clientes/{id}` - Actualiza un cliente existente
- **DELETE** `/api/clientes/{id}` - Elimina un cliente

## Estructura del Proyecto

```
ClientesAPI/
├── Controllers/         # Controladores REST
├── Models/              # Modelos de datos
├── Services/            # Lógica de negocio
├── Repositories/        # Acceso a datos
├── Data/                # Configuración de DbContext
├── Properties/          # Configuración del proyecto
├── appsettings.json     # Configuración de la aplicación
├── Program.vb           # Punto de entrada
└── README.md            # Este archivo
