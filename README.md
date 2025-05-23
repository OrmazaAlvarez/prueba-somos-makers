# Préstamos de Vida (Prueba Makers)

Sistema para la gestión de solicitudes de préstamos bancarios, compuesto por un backend en **C# (.NET 8)** y un frontend en **React 19 + Vite + TypeScript**. Este proyecto es una implementación parcial de los requerimientos solicitados en la prueba técnica.

---

## Tabla de Contenidos

- [Descripción](#descripción)
- [Tecnologías](#tecnologías)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Instalación y Ejecución](#instalación-y-ejecución)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [Funcionalidades](#funcionalidades)
- [Próximos Pasos y Pendientes](#próximos-pasos-y-pendientes)
- [Licencia](#licencia)
- [Arquitectura y Patrones Implementados](#arquitectura-y-patrones-implementados)
- [Estado de Implementación vs. Requerimientos](#estado-de-implementación-vs-requerimientos)
- [Checklist Técnico Detallado y Observaciones](#checklist-técnico-detallado-y-observaciones)

---

## Descripción

Este proyecto implementa un sistema básico que permite a los usuarios solicitar préstamos y a los administradores gestionar dichas solicitudes (aprobar/rechazar). El sistema está en desarrollo y actualmente cuenta con una implementación parcial de las funcionalidades requeridas.

---

## Tecnologías

- **Backend:** C#, .NET 8, ASP.NET Core, SQL Server
- **Frontend:** React 19, Vite, TypeScript
- **Otros:** Swagger, ESLint, JWT (pendiente de implementación)

---

## Estructura del Proyecto

```bash
préstamos-vida/
├── PrestamosDeVida/          # Código fuente del backend (.NET)
│   ├── .vs/                  # Archivos de Visual Studio
│   ├── Domain/               # Capa de dominio
│   ├── Master.Base/          # Clases base y utilidades
│   ├── PrestamosDeVida/      # Proyecto principal
│   ├── Shared/               # Componentes compartidos
│   ├── UseCase/              # Casos de uso de la aplicación
│   ├── .gitignore            # Exclusiones de Git
│   └── PrestamosDeVida.sln   # Solución de Visual Studio
│
├── FrontEnd/                # Código fuente del frontend
│   └── prestamos-de-vida/    # Proyecto React + Vite + TypeScript
│       ├── .github/          # Archivos de GitHub
│       ├── .vscode/          # Configuración de VS Code
│       ├── node_modules/     # Dependencias de Node.js
│       ├── public/           # Archivos públicos
│       ├── src/              # Código fuente
│       ├── .gitignore        # Exclusiones de Git
│       ├── eslint.config.js  # Configuración de ESLint
│       ├── index.html        # HTML principal
│       ├── package-lock.json # Bloqueo de versiones de dependencias
│       ├── package.json      # Configuración del proyecto
│       ├── README.md         # Documentación del frontend
│       ├── tsconfig.app.json # Configuración de TypeScript para la app
│       ├── tsconfig.json     # Configuración principal de TypeScript
│       ├── tsconfig.node.json # Configuración de TypeScript para Node
│       └── vite.config.ts    # Configuración de Vite
│
├── .gitignore                # Exclusiones de Git
├── README.md                 # Documentación
└── LICENSE                   # Licencia
```

---

## Instalación y Ejecución

### Backend

**Requisitos previos:**  
- .NET 8 SDK  
- SQL Server (local o remoto)

**Pasos para levantar el backend:**
1. Configura la cadena de conexión en `PrestamosDeVida/PrestamosDeVida/appsettings.json`.
2. Abre la solución `PrestamosDeVida.sln` en Visual Studio o VS Code.
3. Restaura los paquetes NuGet:
   ```sh
   dotnet restore
   ```
4. Aplica las migraciones (si es necesario):
   ```sh
   dotnet ef database update --project PrestamosDeVida/PrestamosDeVida/PrestamosDeVida.csproj
   ```
5. Ejecuta el backend:
   ```sh
   dotnet run --project PrestamosDeVida/PrestamosDeVida/PrestamosDeVida.csproj
   ```
6. Accede a la documentación Swagger en `http://localhost:5138/swagger`.

**Pendientes Backend:**
- Implementar autenticación JWT.
- Mejorar manejo de errores global.
- Agregar pruebas unitarias y de integración.
- Documentar endpoints adicionales en Swagger.

---

### Frontend

1. **Clona el repositorio** si aún no lo hiciste.
2. **Navega a la carpeta del frontend**:
   ```sh
   cd FrontEnd/prestamos-de-vida
   ```
3. **Instala las dependencias**:
   ```sh
   npm install
   ```
4. **Configura la URL de la API** en un archivo `.env` en la raíz del frontend:
   ```
   VITE_API_URL=http://localhost:5138
   ```
5. **Inicia la aplicación**:
   ```sh
   npm run dev
   ```
6. Accede a `http://localhost:5173` en tu navegador.

**Notas:**
- Asegúrate de que el backend esté corriendo antes de iniciar el frontend.
- Puedes modificar el puerto de Vite en el archivo `.env` si es necesario.

---

## Funcionalidades Implementadas vs. Requeridas

### Implementado:
- Estructura básica del backend con arquitectura por capas
- Endpoints básicos para préstamos (crear, actualizar, obtener)
- Estructura básica del frontend con React y TypeScript

### Pendiente de implementación:
- Autenticación y autorización con JWT
- Registro de usuarios y gestión de roles
- Validaciones completas en frontend y backend
- Caché para consultas repetitivas
- Manejo de transacciones en aprobaciones de préstamos
- Tests unitarios
- Manejo global de errores
- Integración real entre frontend y backend

---

## Próximos Pasos y Pendientes

### Backend
- [ ] Implementar autenticación y autorización JWT.
- [ ] Mejorar el manejo global de errores.
- [ ] Agregar pruebas unitarias y de integración.
- [ ] Documentar todos los endpoints en Swagger.
- [ ] Optimizar consultas y agregar paginación.

### Frontend
- [ ] Mejorar validaciones y mensajes de error.
- [ ] Implementar manejo de tokens y sesiones.
- [ ] Mejorar la experiencia de usuario (UI/UX).
- [ ] Agregar tests unitarios (Jest/React Testing Library).
- [ ] Internacionalización (i18n).

### General
- [ ] Implementar sistema de notificaciones (correo o in-app).
- [ ] Agregar historial de solicitudes por usuario.
- [ ] Realizar pruebas de carga y rendimiento.
- [ ] Desplegar en un servidor de producción (Docker, Azure, AWS, etc.).
- [ ] Documentar el proceso de despliegue.

---

## Arquitectura y Patrones Implementados

### Backend (`/PrestamosDeVida`)

- **Arquitectura por capas:** Separación clara entre controladores (API), servicios (lógica de negocio), repositorios (acceso a datos), modelos y DTOs.
- **Patrón Repositorio:** Interfaces y clases para el acceso a datos, facilitando la abstracción y pruebas.
- **DTOs:** Uso de objetos de transferencia de datos para separar las entidades de dominio de los datos expuestos por la API.
- **Inyección de dependencias:** Utilizada para servicios y repositorios, siguiendo las buenas prácticas de ASP.NET Core.
- **Entity Framework:** Para persistencia y migraciones de base de datos.
- **Swagger:** Documentación automática de la API.

### Frontend (`/FrontEnd/prestamos-de-vida`)

- **Componentización:** Uso de componentes funcionales de React para la UI.
- **Separación de responsabilidades:** Componentes, páginas y servicios bien diferenciados.
- **Vite + TypeScript:** Configuración moderna para desarrollo rápido y tipado seguro.
- **Servicios:** Abstracción de llamadas a la API en una carpeta dedicada.

---

## Estado de Implementación vs. Requerimientos

### Backend
- [x] Estructura básica con arquitectura por capas
- [x] Patrón repositorio implementado parcialmente
- [x] Endpoints básicos para préstamos (crear, actualizar, obtener)
- [ ] CRUD completo para usuarios
- [ ] Autenticación y autorización JWT
- [ ] Manejo global de errores
- [ ] Implementación de caché para consultas repetitivas
- [ ] Implementación de transacciones en aprobaciones
- [ ] Pruebas unitarias
- [ ] Documentación Swagger completa
- [ ] Paginación y optimización de consultas

### Frontend
- [x] Estructura básica del proyecto React con TypeScript
- [ ] Implementación de las tres interfaces requeridas (login, usuario, administrador)
- [ ] Autenticación y autorización con JWT
- [ ] Consumo real de la API del backend
- [ ] Validaciones en formularios
- [ ] Gestión segura del estado de la aplicación
- [ ] Tests unitarios
- [ ] Mejoras de UI/UX según los mockups proporcionados

### General
- [ ] Sistema de notificaciones (correo o in-app).
- [ ] Historial de solicitudes por usuario.
- [ ] Pruebas de carga y rendimiento.
- [ ] Despliegue en producción y documentación del proceso.

---

## Licencia

Este proyecto está bajo la Licencia MIT. Consulte el archivo LICENSE para más detalles.

---

## Checklist Técnico Detallado y Observaciones

### Backend
- [x] Arquitectura por capas (Domain, UseCase, PrestamosDeVida)
- [x] Patrón Repositorio implementado parcialmente
- [x] Uso de DTOs para entrada/salida de datos en los casos implementados
- [x] Inyección de dependencias básica
- [ ] **CRUD completo para usuarios** (no implementado)
- [ ] **Autenticación y autorización JWT** (no implementado)
- [ ] **Endpoints de usuarios** (carpeta existe pero no hay implementación)
- [ ] **Validaciones exhaustivas** (implementación parcial en UseCase)
- [ ] **Manejo global de errores** (no implementado)
- [ ] **Implementación de caché** (no implementado)
- [ ] **Transacciones en aprobaciones** (no implementado)
- [ ] **Pruebas unitarias** (no implementado)
- [ ] **Paginación y filtros en endpoints** (no implementado)
- [ ] **Documentación Swagger** (no implementado)

### Frontend
- [x] Estructura básica con React 19 + Vite + TypeScript
- [ ] **Implementación de las tres interfaces requeridas** (no implementado):
  - [ ] Pantalla de login
  - [ ] Pantalla de usuario para solicitar préstamos y ver estado
  - [ ] Pantalla de administrador para aprobar/rechazar préstamos
- [ ] **Consumo real de API** (no implementado)
- [ ] **Autenticación y manejo de tokens/sesiones** (no implementado)
- [ ] **Gestión de roles y rutas protegidas** (no implementado)
- [ ] **Validaciones en formularios** (no implementado)
- [ ] **Gestión segura del estado** (no implementado)
- [ ] **Tests unitarios** (no implementado)

### General
- [ ] **Documentación técnica y de despliegue** (falta guía de despliegue, variables de entorno, etc.)
- [ ] **Licencia y contribución** (solo licencia, no hay guía de contribución)
- [ ] **Cumplimiento de todos los requerimientos funcionales y no funcionales del PDF** (varios puntos pendientes)

---

**Observaciones finales:**

- **Backend**: Se ha implementado una estructura básica con arquitectura por capas, pero faltan componentes clave como autenticación JWT, manejo de usuarios, caché, transacciones, y pruebas unitarias requeridas en la especificación.

- **Frontend**: Solo se ha configurado la estructura básica del proyecto React, pero no se han implementado las tres interfaces requeridas (login, usuario, administrador) según los mockups proporcionados, ni la integración con el backend.

- **Integración**: No hay evidencia de integración entre el frontend y el backend.

**Próximos pasos prioritarios:**

1. Implementar las tres interfaces de usuario según los mockups
2. Completar la implementación de endpoints para usuarios y préstamos
3. Implementar autenticación y autorización JWT
4. Integrar frontend y backend

---