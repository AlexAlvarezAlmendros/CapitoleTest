# Task API Capitole

## Descripción

Task API Capitole es una aplicación API RESTful para gestionar tareas. Permite crear, leer, actualizar y eliminar tareas.

## Características

- Crear una nueva tarea.
- Obtener todas las tareas.
- Obtener una tarea específica por ID.
- Actualizar una tarea existente.
- Eliminar una tarea.

## Tecnologías

- .NET 8
- ASP.NET Core
- Entity Framework Core
- MongoDB
- xUnit (para pruebas)
- Moq (para pruebas)

## Configuración del Proyecto

### Requisitos Previos

- .NET 8 SDK
- MongoDB

### Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/tu-usuario/TaskAPICapitole.git
    ```

2. Ve al directorio del proyecto:
    ```bash
    cd TaskAPICapitole
    ```

3. Restaura los paquetes NuGet:
    ```bash
    dotnet restore
    ```

### Configuración de la Base de Datos

Asegúrate de tener MongoDB en ejecución y configura la cadena de conexión en `appsettings.json`:

```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CapitoleTestDb"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
