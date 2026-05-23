# Sistema Web de Gestión de Inventario y Órdenes

Sistema web desarrollado para la administración de bares y restaurantes, enfocado en el control de inventario, gestión de órdenes, optimización de procesos operativos del negocio y comunicación con terminal móvil.

## Descripción

Aplicación web desarrollada bajo arquitectura MVC utilizando tecnologías Microsoft.  
El sistema permite administrar productos, inventario, órdenes, clientes, mesas y personal de atención, facilitando el control y seguimiento de las operaciones diarias dentro de bares y restaurantes. Además, incorpora servicio **API REST** que permite la integración con aplicaciones móviles para consumo de datos en tiempo real.


# Características Principales

- ✅ Gestión de inventario
- ✅ Registro y control de órdenes
- ✅ Administración de clientes
- ✅ Gestión de mesas
- ✅ Control de meseros
- ✅ Registro de entradas y salidas
- ✅ API REST para aplicación móvil
- ✅ Validaciones en frontend y backend
- ✅ Arquitectura MVC organizada
- ✅ Acceso a datos con Entity Framework 6 (Code First)
- ✅ Consultas y procedimientos en SQL Server
- ✅ Interfaz dinámica con JavaScript y jQuery
- ✅ Manejo de autenticación y autorización

# Tecnologías Utilizadas

| Tecnología | Descripción |
|---|---|
| .NET Framework | Framework principal del proyecto |
| ASP.NET MVC | Arquitectura del sistema |
| Entity Framework 6 | ORM utilizando Code First |
| SQL Server | Base de datos relacional |
| JavaScript | Funcionalidades dinámicas |
| jQuery | Manipulación del DOM y AJAX |
| Bootstrap | Diseño responsive |
| HTML5 / CSS3 | Estructura y estilos |

# Funcionalidades del Sistema
  1. Inventario
    -  Registro de productos
    - Actualización de stock
    - Control de entradas y salidas
    - Validación de disponibilidad
  2. Órdenes
    - Creación de órdenes
    - Asociación de clientes y mesas
    - Detalle de productos por orden
    - Estados de órdenes
  3. Clientes
    - Registro de clientes
    - Gestión de información personal
    - Historial de órdenes
  4. API REST
    -  Endpoints JSON
    -  Integración móvil
    -  Consumo desde aplicaciones externas
  5. Administración
    - Gestión de meseros
    - Control de mesas
    - Administración general del negocio
    - Base de Datos
  6. Seguridad
    - Validación de formularios
    - Manejo de sesiones
    - Control de acceso
    - Protección de rutas

# Instalación
1. Clonar repositorio
  git clone https://github.com/lcd97/WA_Gastrobar.git
2. Abrir solución
  Abrir el archivo .sln en Visual Studio.
3. Configurar conexión SQL Server
4. Modificar la cadena de conexión en:
  Web.config
5. Ejecutar migraciones
  Update-Database
6. Ejecutar proyecto

 ## Requisitos
Visual Studio 2019 o 2022
SQL Server
.NET Framework
IIS Express

# Arquitectura del Proyecto

```bash
📦 Proyecto
 ┣ 📂 Areas
    ┣ 📂 API
 ┣ 📂 Controllers
 ┣ 📂 Models
 ┣ 📂 Views
 ┣ 📂 Scripts
 ┣ 📂 Content
 ┣ 📂 DAL / Repository
 ┣ 📂 Migrations
 ┗ 📂 Database
```

# Recursos del Proyecto

| Documento | Descripción |
|---|---|
| [Manual de Usuario](https://drive.google.com/file/d/19qaXVwJqSotBNifqDdPvbze9PjxgaGwP/view?usp=drive_link) | Guía de uso del sistema |
| [Manual Técnico](https://repositorio.unan.edu.ni/id/eprint/15042/1/15042.pdf) | Arquitectura y desarrollo |

# Usuario de Prueba

| Rol | Usuario | Contraseña |
|---|---|---|
| Cocinero | gilme060185 | xalli2021 |
| Mesero | jose010690 | xalli2021 |

> ⚠️ Usuarios disponibles únicamente para fines de demostración.

# Autores

Daniela Cordero -
Software Engineer

Josiel Castillo -
Software Engineer

# Licencia

Este proyecto es de uso académico y demostrativo.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-red)
![JavaScript](https://img.shields.io/badge/JavaScript-ES6-yellow)
![jQuery](https://img.shields.io/badge/jQuery-3.x-blue)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-purple)
![REST API](https://img.shields.io/badge/API-REST-orange)
![License](https://img.shields.io/badge/License-Academic-lightgrey)
