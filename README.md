    Requisitos previos
- .NET 8 SDK
- Node.js 18+
- MySQL 8+
- Angular CLI (npm install -g @angular/cli)

    Arranque
Backend:
cd (ruta del proyecto backend)
dotnet restore
dotnet build
dotnet run
- La base de datos y tablas se crean automáticamente

    Frontend:
cd (ruta al proyecto frontend)
npm install
ng serve
- Disponible en http://localhost:4200

    Estado actual
[descripción breve]

    Tecnologías
- Frontend: Angular 21
- Backend: .NET 8 con arquitectura por capas
- Base de datos: MySQL con Entity Framework Core
- Autenticación: JWT + BCrypt

    Funcionalidades implementadas
Búsqueda de imágenes por texto llamando a APIs externas (Unsplash + Pixabay)
Sistema de fallback automático: si Unsplash falla o devuelve vacío, usa Pixabay
Creación automática de álbumes vinculados al usuario al buscar
Vista de álbumes del usuario con preview de imágenes
Vista de detalle de álbum con todas sus imágenes
Navegación entre vistas con Angular Route

    Seguridad
Autenticación con JWT (JSON Web Token)
Hasheo de contraseñas con BCrypt
Rutas protegidas con Guards en Angular
Endpoints protegidos con "Authorize" en el backend
Las claves de APIs externas nunca se exponen al frontend (solo estan en el backend)
Diferenciación de funcionalidades entre usuario registrado y no registrado  


    Pendiente
Sesión cronometrada de dibujo
Valoración de imágenes (aceptar/rechazar) para personalizar recomendaciones
Despliegue con Docker y docker-compose
Mejoras de estilos y experiencia de usuario

    Estructura
Arquitectura cliente-servidor: Angular 21 (frontend) + .NET 8 (backend) + MySQL (base de datos)
Backend con arquitectura por capas: Controllers, Services, Infrastructure, Domain
Frontend con estructura modular: features, core, components
Despliegue con Docker (en progreso)

    Endpoints
  Método, Ruta, Auth, Descripción:
POST, /api/auth/register, No, Registrarse con los datos del usuario
POST, /api/auth/login, No, Hacer Login con datos del usuario
GET, /api/imagenes, No, Buscar imágenes y ver la lista
GET, /api/albumes/user-albumes, Sí, Ver albumes del usuario
GET, /api/albumes/{id}/imagenes, Sí,  Ver imágenes de un álbum
POST, /api/albumes/{id}/ampliar, Sí, Añadir imágenes a un álbum