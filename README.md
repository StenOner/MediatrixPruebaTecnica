# MedatrixPruebaTecnica

API RESTful desarrollada con **.NET 8** utilizando **Arquitectura Hexagonal**, **Patrón Repository** y **Unit of Work**.

## Tabla de Contenidos Backend

- [Características](#características)
- [Tecnologías](#tecnologías)
- [Instalación y Configuración](#instalación-y-configuración)
- [Ejecución](#ejecución)

---

## Características

- **Arquitectura Hexagonal** (Ports & Adapters)
- **Autenticación JWT** con roles (Admin/Usuario)
- **Gestión de Empleados** (4 tipos: Asalariado, Por Horas, Por Comisión, Asalariado por Comisión)
- **Cálculo Automático de Nómina** según tipo de empleado
- **Reportes de Pagos** por periodo
- **Filtros Avanzados** por nombre, departamento y estado
- **Documentación Swagger/OpenAPI**
- **SQL Server** como base de datos

---

## Tecnologías

- **.NET 8** - Framework principal
- **Entity Framework Core 8** - ORM
- **SQL Server** - Base de datos
- **JWT Bearer** - Autenticación
- **BCrypt.Net** - Hash de contraseñas
- **Swagger/OpenAPI** - Documentación de API

---

## Instalación y Configuración

### 1. Clonar o Descargar el Proyecto

```bash
# Si usas Git
git clone <URL_DEL_REPOSITORIO>
cd MediatrixPruebaTecnica\MediatrixPruebaTecnicaBackend

# O simplemente descarga el ZIP y extraerlo
```

### 2. Instalar Dependencias NuGet

Navega a la carpeta raíz del proyecto y ejecuta:

```bash
# Restaurar paquetes NuGet
dotnet restore
```

### 3. Configurar la Cadena de Conexión

Abre el archivo `appsettings.json` y configura tu cadena de conexión a SQL Server:

```json
{
  "ConnectionStrings": {
    "SqlServerConnection": "Server=(localdb)\\mssqllocaldb;database=MediatrixPruebaTecnica"
  }
}
```

### 4. Configurar JWT Secret Key

En `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "Tu_Super_Secreto_Key_Minimo_32_Caracteres_Para_Mayor_Seguridad",
    "Issuer": "MediatrixPruebaTecnicaAPI",
    "Audience": "MediatrixPruebaTecnicaClient",
    "ExpirationHours": 8
  }
}
```

### 5. Crear y Aplicar Migraciones

Desde la carpeta raíz del proyecto, ejecuta:

```bash
cd API

# Aplicar las migraciones a la base de datos
dotnet ef database update -p MediatrixPruebaTecnica.Gateways.RepositoryEFCore -s MediatrixPruebaTecnica.Gateways.RepositoryEFCore
```

### 6. Ejecutar Script SQL de Datos Iniciales

Una vez creada la base de datos, ejecuta el script `INSERTAR_DATOS_INICIALES.sql` para poblar las tablas con datos iniciales.

1. Abre SSMS y conéctate a tu servidor
2. Selecciona la base de datos `MediatrixPruebaTecnica`
3. Abre el archivo `INSERTAR_DATOS_INICIALES.sql`
4. Presiona `F5` o haz clic en "Ejecutar"

---

## Ejecución

### Ejecutar el Proyecto

Desde la carpeta `MediatrixPruebaTecnica.Api`, ejecuta:

```bash
dotnet run
```

También puedes ejecutar el proyecto desde Visual Studio.
