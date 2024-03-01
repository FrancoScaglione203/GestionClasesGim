# Trabajo Final Programacion 3
Proyecto desarrollado para la facultad, especificamente para la materia Programacion 3, en la cual se pidio realizar un proyecto con login, register, ABM, funcionalidad y roles. Desarrollado en .NET CORE 6

---
---
## **Funcionalidad**
La API cuenta con Login y Register, tambien tiene dos tipos de usuarios: Alumno, el cual puede modificar sus datos de perfil e incribirse a las clases disponibles o en caso de ya estar anotado cancelar la inscripcion, tambien podra ver las clases en las cuales esta anotado. El otro tipo de usuario es el Admin, el cual puede usar el ABM de Alumnos y Clases, lo mas importante y que le da la principal funcionalidad a la API es la creacion de las clases que son a las que los alumnos se podran anotar, tambien podra consultar los alumnos inscriptos a cada clase.

---
---
## **Especificación de la Arquitectura**
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext. Ademas, tiene dos subcapas
•	DataBaseSeeding: donde se encuentran las seeds de cada entidad para cargar en la DB cuando se hace el Migration con EntityFrameWork
•	Repositories: donde definiremos las clases e interfaces correspondientes para realizar el repositorio genérico y los repositorios individuales, donde estara la mayor parte de la logica.

### **Capa DTOS**
En esta capa estan definidos todos los DataTransferObjects.

### **Capa Entities**
En esta capa estan definidas todas las entidades 
​
### **Capa Helpers**
Definiremos lógica que pueda ser de utilidad para todo el proyecto. En este caso el generador de JWT y y el encriptador de la clave

### **Capa Migrations**
Capa que se genera al realizar el migration con EntityFrameWork donde registra el migration y los datos insertados en la base de datos

### **Capa Services**
Capa donde se desarrollan la clase e interfaz UnitOfWorkService que trabaja en conjunto con el patron Repository

---
---
## **Entidades**
Tenemos 3 entidades principales: Alumnos, Clases e Historiales
Además también están las entidades Role, TipoMov y Usuario

---
---

## **Base de Datos**
Las tablas Usuarios, CuentasFiduciarias, CuentasCriptos e Historiales se llenaron con datos rapidos para poder testear.

Usuarios/Alumnos

![Usuarios](https://i.imgur.com/t5MguuL.png)

Clases
![CuentasFiduciarias](https://i.imgur.com/KaZrZmp.png)

Historiales

![CuentasCriptos](https://i.imgur.com/OoR9VXs.png)

Roles

![Historiales](https://i.imgur.com/AlRlGop.png)

Tipo Movimientos

![TipoMovimientos](https://i.imgur.com/PQXux2l.png)


---
---
## **Controllers**

LoginController: Tiene un EndPoint para realizar el login de usuario

UsuarioController: Tiene los EndPoints principales para un ABM de la clase Usuario

AlumnoController: Ademas de los EndPoints del ABM tambien hay varios EndPoints que aportan a la funcionalidad de la API como el GET de los alumnos por clase o el GET por dni

ClaseController: Tiene EndPoints de alta, baja y gets por dni o por alumnoId

RoleController: Tiene un EndPoint que muestra todos los roles disponibles

---
---

## **Paquetes Instalados**
![Logo de Mi Proyecto](https://i.imgur.com/7uNYWpK.png)

---
---


## **FrontEnd**
El frontend se realizo con razor: https://github.com/FrancoScaglione203/GestionClasesGimFront

Por el momento esta incompleto

---
---


## **Especificación de GIT**​
* Se implento el patron GitFlow. La rama donde se encuentran las versiones finales es Master, la rama principal a partir de la cual se crean ramas es Develop. La nomenclatura para el nombre de las ramas será la sigueinte: Feature/xx-Titulo (donde xx corresponde con el número de historia)
* El título del pull request debe contener el título de la historia tomada.
---
---
## **Autor**​
* Scaglione Franco
---
---
## **Contacto**
franco.scaglione2@gmail.com
