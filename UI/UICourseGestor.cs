using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TupacAlumnos;

namespace tupacAlumnos;

public class UICourseGestor
{
    private string Option { get; set; } = string.Empty;
    public void MainMenu(GestorAcademico gestor, UICommons Commons)
    {
        do
        {
            Commons.ApplyTheme();
            Commons.PlayConfirmation();
            Commons.Header("Gestor CURSOS");
            Commons.MenuOption("1 - Alta curso.");
            Commons.MenuOption("2 - Ver cursos.");
            Commons.MenuOption("3 - Baja  curso");
            Commons.MenuOption("4 - Buscar curso");
            Commons.MenuOption("5 - Modificar curso");
            Commons.Menu1row2cols("L. Día / Noche", "V - volver", "blue", "green");
            Option = Commons.InputText("Ingresa una opción").ToLower();
            switch (Option)
            {
                case "1":
                    CreateCourse(gestor, Commons);
                    break;
                case "2":
                    ShowCoursesList(gestor, Commons);
                    break;
                case "3":
                    DeleteCourse(gestor, Commons);
                    break;
                case "4":
                    FindCourse(gestor, Commons);
                    break;
                case "5":
                    UpdateCourse(gestor, Commons);
                    break;
                case "l":
                    Commons.Toggle();
                    break;
                case "s":
                case "v":
                    break;
                default:
                    Commons.Message(false, "Opción no valida. Tocá cualquier tecla para continuar.");
                    break;
            }
        } while (Option != "v");
    }
    public void CreateCourse(GestorAcademico gestor, UICommons Commons)
    {
        do
        {
            Commons.Header("Crear curso");
            string name;
            string maxStudents;
            DateTime schoolYear;
            name = Commons.InputText("Nombre");
            while (true)
            {
                maxStudents = Commons.InputText("Cupo máximo de estudiantes");
                if (int.TryParse(maxStudents, out _))
                {
                    break;
                }
                Commons.Message(false, "Cupo inválido. Ingresá solo números.");
            }
            while (true)
            {
                string schoolYearStr = Commons.InputText("Año lectivo (yyyy)");
                if (DateTime.TryParseExact(schoolYearStr, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out schoolYear))
                {
                    break;
                }
                Commons.Message(false, "«« Fecha inválida. Intente nuevamente con el formato yyyy.");
            }
            Commons.Alert(gestor.CreateCourse(name, int.Parse(maxStudents), schoolYear));
            Option = Commons.InputText("¿Querés crear otro curso? (S/N) ").ToLower();
        } while (Option != "n");
    }
    public void ShowCoursesList(GestorAcademico gestor, UICommons Commons)
    {
        List<Course> courses = gestor.GetAllCourses();
        if (!courses.Any())
        {
            Commons.Header("Todos los cursos");
            Commons.Message(false, "«« No hay cursos registrados.");
        }
        else
        {
            Commons.PlayConfirmation();
            Commons.Header("Todos los cursos");
            Commons.Table("ID", "Nombre", "Cupo", "Año lectivo", courses);
        }
    }
    public void DeleteCourse(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Eliminar curso");
        string unicNumber = Commons.InputText("ingresar id curso");
        Commons.Message(false, gestor.DeleteCourse(unicNumber));
    }
    public void UpdateCourse(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Modificar Curso");
        string unicNumber = Commons.InputText("ingresar id curso");
        Course course = gestor.GetCourseByUnicNumber(unicNumber);
        if (course == null)
        {
            Commons.Message(false, $"No se encontró ningún curso con la matrícula: {unicNumber}");
            return;
        }
        Commons.TableHeader("ID", "Materia", "Cupo", "Año lectivo");
        Commons.TableRow(course.GetUnicNumber(), course.GetName(), course.GetMaxStudents(), course.GetSchoolYear());
        Commons.TableEnd();
        string newName = Commons.InputText("Actualizar Nombre");
        string newMaxStudents;
        while (true)
        {
            newMaxStudents = Commons.InputText("Actualizar DNI");
            if (int.TryParse(newMaxStudents, out _))
            {
                break;
            }
            Commons.Message(false, "DNI inválido. Ingresá solo números.");
        }
        DateTime newSchoolYear;
        while (true)
        {
            string birthDateStr = Commons.InputText("Actualizar Año lectivo (yyyy)");
            if (DateTime.TryParseExact(birthDateStr, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newSchoolYear))
            {
                break;
            }
            Commons.Message(false, "Año inválido. Intente nuevamente con el formato yyyy.");
        }
        Commons.Alert(gestor.UpdateCourse(unicNumber, newName, int.Parse(newMaxStudents), newSchoolYear));
        Commons.TableHeader("ID", "Materia", "Cupo", "Año lectivo");
        Commons.TableRow(course.GetUnicNumber(), course.GetName(), course.GetMaxStudents(), course.GetSchoolYear());
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");
    }
    public void FindCourse(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Buscar Curso");
        string courseId = Commons.InputText("Ingresar el ID de un curso");
        Course course = gestor.GetCourseByUnicNumber(courseId);
        if (course == null)
        {
            Commons.Header("Buscar Curso");
            Commons.Message(false, $"El alumno con la matricula {courseId} no existe");
            return;
        }
        Commons.Header("Buscar Curso");
        Commons.MenuOption($"Cursos de {course.GetName()}");
        List<Alumno> courses = gestor.GetEnrolledStudentsInCourse(course);
        if (courses.Count == 0)
        {
            Commons.Header("Buscar Curso");
            Commons.Message(false, $"{course.GetName()} sin alumnos que mostrar");
            return;
        }
        Commons.Header("Buscar Curso");
        Commons.MenuOption($"Alumnos inscriptos en {course.GetName()}");
        Commons.TableHeader("Matr.", "Nombre", "D.N.I", "F. De Nacimiento");
        for (int i = 0; i < courses.Count; i++)
        {
            Commons.TableRow(courses[i].GetUnicNumber(), courses[i].GetFullName(), courses[i].GetDataNumber(), courses[i].GetDate());

        }
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");
    }
}