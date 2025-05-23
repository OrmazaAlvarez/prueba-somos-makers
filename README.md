# Préstamos de Vida

Sistema completo para la gestión de solicitudes de préstamos, compuesto por un backend en **C# (.NET 8)** y un frontend en **React 19 + Vite + TypeScript**.

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

Este proyecto permite a los usuarios solicitar préstamos y a los administradores gestionar dichas solicitudes (aprobar/rechazar). Incluye autenticación, autorización por roles y validaciones tanto en frontend como en backend.

---

## Tecnologías

- **Backend:** C#, .NET 8, ASP.NET Core, SQL Server
- **Frontend:** React 19, Vite, TypeScript
- **Otros:** Swagger, ESLint, JWT (pendiente de implementación)

---

## Estructura del Proyecto

```bash
préstamos-vida/
├── backend/                  # Código fuente del backend (.NET)
│   ├── Controllers/          # Controladores de ASP.NET
│   ├── Models/               # Modelos de datos
│   ├── Repositories/         # Acceso a datos
│   ├── Services/             # Lógica de negocio
│   ├── DTOs/                 # Objetos de transferencia de datos
│   ├── Migrations/           # Migraciones de base de datos
│   └── Program.cs            # Punto de entrada
│
├── frontend/                 # Código fuente del frontend (React + Vite)
│   ├── src/
│   │   ├── components/       # Componentes de React
│   │   ├── pages/            # Páginas principales
│   │   ├── services/         # Servicios para llamadas a la API
│   │   ├── App.tsx           # Componente raíz
│   │   └── main.tsx          # Entrada de Vite
│   └── index.html            # HTML principal
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
   cd frontend
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

## Funcionalidades

- Solicitud de préstamos
- Aprobación y rechazo de solicitudes
- Registro y autenticación de usuarios
- Autorización basada en roles
- Validaciones en tiempo real
- Documentación de la API con Swagger

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
- [x] API RESTful para gestión de préstamos y usuarios.
- [x] Documentación Swagger básica.
- [x] Arquitectura por capas y patrón repositorio.
- [ ] Autenticación y autorización JWT.
- [ ] Manejo global de errores.
- [ ] Pruebas unitarias y de integración.
- [ ] Documentar todos los endpoints en Swagger.
- [ ] Paginación y optimización de consultas.

### Frontend
- [x] Estructura de componentes, páginas y servicios.
- [ ] Manejo de tokens y sesiones (autenticación).
- [ ] Validaciones avanzadas y mensajes de error.
- [ ] Mejoras de UI/UX.
- [ ] Tests unitarios.
- [ ] Internacionalización (i18n).

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
- [x] Arquitectura por capas (Controllers, Services, Repositories, DTOs, Domain)
- [x] Patrón Repositorio implementado
- [x] Uso de DTOs para entrada/salida de datos
- [x] Inyección de dependencias
- [x] Documentación Swagger básica
- [ ] **Autenticación y autorización JWT** (no implementado)
- [ ] **Endpoints de usuarios** (no se observa UsersController ni endpoints de registro/login)
- [ ] **Validaciones exhaustivas** (hay validaciones en los UseCase, pero falta validación global y manejo de errores centralizado)
- [ ] **Manejo global de errores** (no hay middleware de manejo de excepciones)
- [ ] **Pruebas unitarias y de integración** (no hay tests)
- [ ] **Paginación y filtros en endpoints** (no implementado en LoansRepository/GetLoans)
- [ ] **Optimización de consultas** (no se observa uso de proyecciones, paginación, ni índices)
- [ ] **Historial de solicitudes por usuario** (no implementado)
- [ ] **Sistema de notificaciones (correo o in-app)** (no implementado)
- [ ] **Internacionalización de mensajes de error** (no implementado)
- [ ] **Despliegue automatizado/documentado** (no hay scripts ni instrucciones avanzadas)
- [ ] **Pruebas de carga y rendimiento** (no implementado)
- [ ] **Roles y autorización por roles** (no implementado en endpoints)
- [ ] **Documentar todos los endpoints en Swagger** (solo básico)

### Frontend
- [x] Estructura modular (componentes, páginas, servicios)
- [x] Uso de React 19 + Vite + TypeScript
- [ ] **Consumo real de API** (actualmente todo es mock, no hay integración real con backend)
- [ ] **Autenticación y manejo de tokens/sesiones** (no implementado)
- [ ] **Gestión de roles y rutas protegidas** (no implementado)
- [ ] **Validaciones avanzadas y mensajes de error amigables** (solo validación básica en el formulario)
- [ ] **Internacionalización (i18n)** (no implementado)
- [ ] **Notificaciones (correo o in-app)** (no implementado)
- [ ] **Historial de solicitudes por usuario** (no implementado)
- [ ] **Mejoras de UI/UX** (diseño básico, sin feedback avanzado)
- [ ] **Tests unitarios y de integración** (no implementado)
- [ ] **Pruebas de carga y rendimiento** (no implementado)
- [ ] **Despliegue automatizado/documentado** (no hay scripts ni instrucciones avanzadas)

### General
- [ ] **Documentación técnica y de despliegue** (falta guía de despliegue, variables de entorno, etc.)
- [ ] **Licencia y contribución** (solo licencia, no hay guía de contribución)
- [ ] **Cumplimiento de todos los requerimientos funcionales y no funcionales del PDF** (varios puntos pendientes)

---

**Observaciones:**
- El backend carece de endpoints de autenticación y registro de usuarios, así como de middleware de manejo global de errores y paginación.
- El frontend no consume la API real, no implementa autenticación, ni roles, ni internacionalización.
- No hay pruebas automatizadas ni scripts/documentación de despliegue.
- Faltan funcionalidades clave como notificaciones, historial de solicitudes, y pruebas de carga.

---