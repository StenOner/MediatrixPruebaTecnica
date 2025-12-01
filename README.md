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
cd MediatrixPruebaTecnicaBackend

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

---

## Tabla de Contenidos Frontend

- [Requisitos](#requisitos)
- [Variables de Entorno](#variables-de-entorno)
- [Instalación Frontend](#instalación-frontend)
- [Ejecución Frontend](#ejecución-frontend)

---

## Requisitos

- **Node.js 18+**
- **Next.js 16**

---

## Variables de Entorno

Crear un archivo **.env.local** en la raíz del proyecto con:

```
NEXT_PUBLIC_API_BASE_URL=
TOKEN_KEY=
```

---

## Instalación Frontend

```bash
cd frontend
npm install
```

---

## Ejecución Frontend

```bash
npm run dev
```

La aplicación se ejecuta en **http://localhost:3000** como cualquier proyecto Next.js.

---

## Preguntas y Respuestas Técnicas

1. **¿Cómo aplicarías Clean Architecture en un proyecto .NET?**  
   Organizando el código en capas independientes (Domain, Application, Adapters, API), asegurando que el dominio no dependa de frameworks. Se usan interfaces para desacoplar lógica de negocio y persistencia, y se aplican inyecciones de dependencias para mantener un flujo limpio y testeable.

2. **¿Cómo garantizarías la seguridad en una API REST que maneja datos sensibles?**  
   Implementando autenticación JWT, validación estricta de entradas, HTTPS obligatorio, protección contra ataques comunes (SQL Injection) y políticas de autorización por roles. También cifrado de datos sensibles y uso de secrets en variables de entorno.

3. **¿Cuándo usarías microservicios y cuándo un monolito?**  
   Microservicios cuando existen dominios bien delimitados, alta escalabilidad y equipos distribuidos. Monolito cuando el proyecto es pequeño o mediano, con lógica poco acoplada y necesidad de rapidez en desarrollo y despliegue.

4. **¿Qué diferencia hay entre Entity Framework y Dapper y cuándo usarías cada uno?**  
   EF es un ORM completo que simplifica el mapeo y facilita desarrollo rápido; Dapper es un micro ORM más veloz y controlable. Usaría EF para CRUDs estándar y Dapper para consultas de alto rendimiento o reportes.

5. **¿Cómo has trabajado en proyectos con equipos ágiles y qué herramientas has usado?**  
   Utilizando Scrum, con dailies, sprints y retrospectivas. Herramientas como Azure DevOps, Jira, GitHub Projects y pipelines CI/CD para integraciones continuas, control de versiones y despliegues.

6. **¿Cómo garantizas que el código de la aplicación puede ser probado?**  
   Aplicando principios SOLID, inyección de dependencias, separación de responsabilidades y capas bien definidas. Uso de interfaces, mocks y pruebas unitarias en servicios y casos de uso.

7. **¿Cómo evitarías la saturación de una API?**  
   Implementando rate limiting, paginación, colas (RabbitMQ/Azure Service Bus), compresión de respuestas y escalado automático. También optimización de consultas a la base de datos.

8. **¿Cómo deben comunicarse los componentes en una arquitectura basada en componentes?**  
   A través de interfaces bien definidas, eventos o props (en frontend), evitando acoplamiento directo. La comunicación debe seguir contratos claros y ser predecible, permitiendo reemplazar o actualizar componentes sin romper el sistema.
