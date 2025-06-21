# ⚡ CiberElectrikMVC

Proyecto ASP.NET MVC 5 desarrollado con Visual Studio 2022 para la gestión de productos, marcas y categorías en una tienda tipo retail llamada **CiberElectrik**.

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.2-blue?logo=dotnet)
![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio%202022-purple?logo=visualstudio)
![Estado](https://img.shields.io/badge/Proyecto-Activo-brightgreen)

---

## 🌍 Sitio en producción

👉 [http://ciberelectrik.somee.com](http://ciberelectrik.somee.com)


## 🧠 Tecnologías utilizadas

- ASP.NET MVC 5
- C# .NET Framework 4.8
- Entity Framework 6
- Bootstrap 5 (Frontend)
- Razor Views
- SQL Server (conexión configurada a AlwaysData)

---

## 📁 Estructura del Proyecto

```
CiberElectrikMVC/
│
├── Controllers/
│   ├── CategoriaController.cs
│   ├── MarcaController.cs
│   └── ProductoController.cs
│
├── Models/
│   ├── Categoria.cs
│   ├── Marca.cs
│   └── Producto.cs
│
├── Views/
│   ├── Categoria/ (CRUD)
│   ├── Marca/     (CRUD)
│   ├── Producto/  (CRUD)
│   └── Shared/
│
├── App_Start/
│   ├── RouteConfig.cs
│   ├── BundleConfig.cs
│   └── FilterConfig.cs
│
├── Scripts/ (Bootstrap, jQuery)
└── Content/ (Estilos)
```

---

## ⚙️ Configuración

1. Clona el repositorio:

```bash
git clone https://github.com/JogaLuck/CiberElectrikMVC.git
```

2. Abre la solución en **Visual Studio 2022**

3. Asegúrate de configurar tu cadena de conexión en `Web.config`:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=SERVIDOR;Initial Catalog=bdciberelectrikws;User ID=USUARIO;Password=CLAVE;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

4. Ejecuta el proyecto (`Ctrl + F5`) o con IIS Express.

---

## 📝 Funcionalidades

- CRUD de Categorías
- CRUD de Marcas
- CRUD de Productos (con relaciones a Categoría y Marca)
- Inicio de sesión básico
- Validación de formularios con Bootstrap

---

## 🌐 Demo Online

> Puedes alojar la base de datos en [AlwaysData](https://alwaysdata.com) y desplegar el frontend en servicios como Render, Azure o Netlify (si lo conviertes en Web API + frontend SPA).

---

## 🙋 Autor

**Josue [@JogaLuck](https://github.com/JogaLuck)**

Si te sirvió este proyecto, ¡dale una estrella ⭐ y sígueme para más proyectos!

---

## 📄 Licencia

Este proyecto es libre para uso educativo. Si lo usas en producción, personalízalo o mejora la seguridad del login.
