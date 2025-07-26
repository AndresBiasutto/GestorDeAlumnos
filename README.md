# Sistema de Gestión Académica - TupacAlumnos 
 
Este proyecto fue desarrollado como parte del Trabajo Práctico de Programación 1. 
 
## Datos del Alumno 
- **Nombre completo:** [Biasutto Andrés Alberto] 
- **Documento:** [31669143] 
 
## Docente Responsable 
- Javier Pablo de Jorge 
 
## Estructura del Proyecto 
- `UI/`: Interfaz de usuario (menú y entrada/salida por consola). 
- `BR/Entidades/`: Clases que representan alumnos, cursos, etc. 
- `BR/Servicios/`: Lógica de negocio. 
 
## Instrucciones 
1. Abrir la carpeta en Visual Studio Code. 
2. Compilar con `dotnet build`. 
3. Ejecutar con `dotnet run` desde la carpeta `UI` si se configura como proyecto principal. 

---

## Clases Principales

### 1. `Entity`

Clase base abstracta para generar un identificador único (`UnicNumber`) incremental para todas las entidades del sistema.

```csharp
- int UnicNumber
+ string GetUnicNumber()
```

### 2. `Alumno` (Hereda de `Entity`)

Representa un estudiante del instituto.

```csharp
- string Name
- string LastName
- int DNI
- DateTime BirthDate
- List<string> EnrolledCoursesIds

+ string GetFullName()
+ string GetDNI()
+ string GetBirthDate()
+ Alumno Update(string, string, int, DateTime)
+ string AddCourse(string)
+ string DeleteCourse(string)
+ List<string> GetMyCourses()
```

### 3. `Course` (Hereda de `Entity`)

Representa un curso disponible.

```csharp
- string Name
- int MaxStudents
- DateTime SchoolYear
- List<string> StudentsIds

+ string GetName()
+ string GetMaxStudents()
+ string GetSchoolYear()
+ Course Update(string, int, DateTime)
+ string AddStudent(string)
+ string DeleteStudent(string)
+ List<string> GetEnrolledStudents()
```

### 4. `GestorAcademico`

Gestor principal de entidades `Alumno` y `Course`.

```csharp
- List<Alumno> students
- List<Course> courses

+ string EnrollStudent(...)
+ string DeleteStudent(...)
+ string UpdateStudent(...)
+ Alumno GetStudentByUnicNumber(string)
+ string EnrollStudentInCourse(...)
+ string UnsubscribeStudentfromCourse(...)
+ List<Alumno> GetAllStudents()
+ List<Course> GetAllCourses()
+ List<Course> GetCoursesInStudent(Alumno)
+ List<Alumno> GetEnrolledStudentsInCourse(Course)
```

### 5. `UICommons`

Encapsula la lógica común de la consola como temas, mensajes, input, etc.

```csharp
- bool IsNightMode

+ bool Toggle()
+ void ApplyTheme()
+ void Header(string)
+ void MenuOption(string)
+ void TableHeader(...)
+ void TableRow(...)
+ void TableEnd()
+ void InputPlaceholder(string)
+ string InputText(string)
+ void Message(bool, string)
+ void IntroScreen()
+ void PlaySuccess()
+ void PlayError()
```

### 6. `UIStudentGestor`

Interfaz para la gestión de estudiantes.

```csharp
- string Option

+ void MainMenu(...)
+ void EnrollStudent(...)
+ void ShowStudentList(...)
+ void DeleteStudent(...)
+ void FindStudent(...)
+ void UpdateStudent(...)
```

### 7. `UICourseGestor`

Interfaz para la gestión de cursos.

```csharp
- string Option

+ void MainMenu(...)
+ void CreateCourse(...)
+ void ShowCoursesList(...)
+ void DeleteCourse(...)
+ void FindCourse(...)
+ void UpdateCourse(...)
```

### 8. `UIInscriptionGestor`

Interfaz para inscripción y desinscripción de estudiantes en cursos.

```csharp
- string Option

+ void MainMenu(...)
+ void SubscribeStudentInCourse(...)
+ void UnsuscribeStudent(...)
+ void ListCoursesInStudent(...)
+ void ListStudentsInCourse(...)
```

### 9. `Program`

Clase de entrada principal del sistema.

```csharp
+ void Main(string[] args)
```

---

## Relaciones

- **Herencia**: `Alumno` y `Course` heredan de `Entity`
- **Agregación**:
  - `GestorAcademico` gestiona `List<Alumno>` y `List<Course>`
  - `Alumno` contiene `List<string>` de IDs de cursos
  - `Course` contiene `List<string>` de IDs de estudiantes
- **Colaboración**:
  - `Program` crea instancias de `GestorAcademico`, `UICommons`, `UIStudentGestor`, `UICourseGestor`, `UIInscriptionGestor`
  - Las clases `UI*Gestor` utilizan `GestorAcademico` y `UICommons`

---

## Notas

- Todos los ID generados son únicos e incrementales.
- Se utiliza consola con visual y sonidos para mejorar la experiencia del usuario.
- Se implementa modo noche.

## Diagrama UML

![Diagrama UML Gestor Academico](./UML%20gestor%20de%20alumnos.png "Diagrama UML Gestor Academico")