# Sistema de Gestión de Usuarios - API y Frontend

## Descripción del Proyecto

Este proyecto consiste en un sistema completo para la gestión de usuarios que incluye:

1. **API RESTful** desarrollada en .NET Framework con ADO.NET para acceso a SQL Server
2. **Interfaz de usuario** en .NET Core/.NET Framework que consume la API
3. **Scripts adicionales** con soluciones a problemas de programación

## Requisitos Técnicos

- .NET 8.0
- SQL Server 2012 o superior
- Visual Studio 2019/2022 (recomendado)
- VS CODE

## Estructura del Proyecto

```
/
├── API/                  # Proyecto de la API
├── Frontend/             # Aplicación de interfaz de usuario
├── Scripts/              # Scripts adicionales
│   ├── ContadorTresEnTres.cs   # Script de números 0-100 de 3 en 3
│   └── CombinacionesCadena.cs  # Generador de combinaciones
├── Database/
│   ├── Scripts/          # Scripts SQL
│   └── Migrations/       # Migraciones de base de datos
└── README.md             # Este archivo
```

## Instalación y Configuración

1. **Base de Datos**:
   - Ejecutar el script `Database.sql` en SQL Server
   - Configurar la cadena de conexión en `appsettings.json` de la API

2. **API**:
   ```bash
   cd api
   dotnet restore
   dotnet run
   ```

3. **Frontend**:
   ```bash
   cd Front
   dotnet restore
   dotnet run
   ```

## Funcionalidades Implementadas

### 1. API RESTful (2 Puntos)

- **Endpoints**:
  - `GET /api/usuarios` - Listar todos los usuarios
  - `GET /api/usuarios/{id}` - Obtener usuario por ID
  - `POST /api/usuarios` - Crear nuevo usuario
  - `PUT /api/usuarios/{id}` - Actualizar usuario existente
  - `DELETE /api/usuarios/{id}` - Eliminar usuario

### 2. Interfaz de Usuario (2 Puntos)

- **Vistas**:
  - Listado de usuarios con paginación
  - Formulario de creación/edición
  - Modal de confirmación para eliminación

- **Características**:
  - Consumo completo de la API
  - Manejo de errores
  - Diseño responsive

### 3. Script de Números (0.5 Puntos)

### 4. Generador de Combinaciones (0.5 Puntos)

## Consideraciones Adicionales

- **Seguridad**: La API incluye validación básica de entrada
- **Performance**: Uso de ADO.NET optimizado para las consultas
