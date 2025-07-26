using System;
using System.Collections.Generic;
using System.Linq;
using TupacAlumnos;

namespace tupacAlumnos;

public class UIInscriptionGestor
{
    private string Option { get; set; } = string.Empty;
    public void MainMenu(GestorAcademico gestor, UICommons Commons)
    {
        do
        {
            Commons.ApplyTheme();
            Commons.Header("Gestor de inscripciones.");
            Commons.MenuOption("1 - Inscribir alumno.");
            Commons.MenuOption("2 - Baja de inscripción.");
            Commons.MenuOption("3 - Lista de alumnos inscriptos a un curso");
            Commons.MenuOption("4 - Lista de cursos asociados a un alumno");
            Commons.Menu1row2cols("L. Día / Noche", "V - volver", "blue", "green");
            Commons.PlayConfirmation();
            Option = Commons.InputText("Ingresa una opción").ToLower();
            switch (Option)
            {
                case "1":
                    SubscribeStudentInCourse(gestor, Commons);
                    break;
                case "2":
                    UnsuscribeStudent(gestor, Commons);
                    break;
                case "3":
                    ListStudentsInCourse(gestor, Commons);
                    break;
                case "4":
                    ListCoursesInStudent(gestor, Commons);
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
    public void SubscribeStudentInCourse(GestorAcademico gestor, UICommons Commons)
    {
        List<Course> courses = gestor.GetAllCourses();
        List<Alumno> students = gestor.GetAllStudents();
        if (!courses.Any())
        {
            Commons.Header("Incribir alumno a curso");
            Commons.Message(false, "«« No hay cursos registrados.");
            return;
        }
        if (!students.Any())
        {
            Commons.Header("Incribir alumno a curso");
            Commons.Message(false, "«« No hay estudiantes registrados.");
            return;
        }
        else
        {
            Commons.PlayConfirmation();
            Commons.Header("Incribir alumno a curso");
            foreach (var course in courses)
            {
                Commons.MenuOption($"{course.GetUnicNumber()}. {course.GetName()}");
            }
            string courseId = Commons.InputText("Ingresa el ID de un curso");
            Course selectedCourse = gestor.GetCourseByUnicNumber(courseId);
            if (selectedCourse == null)
            {
                Commons.Message(false, $"No se encontró ningún curso con el ID: {courseId}");
                Console.ReadKey();
                return;
            }
            else
            {
                string option;
                do
                {
                    Commons.Header("Incribir alumno a curso");
                    Commons.MenuOption($"Agregar estudiantes a {selectedCourse.GetName()}");
                    Commons.TableHeader("Matr.", "Nombre", "", "");
                    foreach (var student in students)
                    {
                        Commons.TableRow(student.GetUnicNumber(), student.GetFullName(), "", "");
                    }
                    Commons.TableEnd();
                    string studentId = Commons.InputText("Ingresa matricula");
                    Alumno selectedStudent = gestor.GetStudentByUnicNumber(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Header("Incribir alumno a curso");
                        Commons.Message(false, $"No se encontró ningún curso con la matrícula: {studentId}");
                        return;
                    }
                    Commons.Message(true, gestor.EnrollStudentInCourse(selectedCourse, selectedStudent));
                    Console.WriteLine();
                    option = Commons.InputText("Deseas agregar otro alumno? (S/N)").ToLower();
                } while (option != "n");
            }
        }
    }
    public void ListStudentsInCourse(GestorAcademico gestor, UICommons Commons)
    {
        List<Course> courses = gestor.GetAllCourses();
        if (!courses.Any())
        {
            Commons.Header("Listar alumnos inscirptos a cursos");
            Commons.Message(false, "«« No hay cursos registrados.");
            return;
        }
        Commons.PlayConfirmation();
        Commons.Header("Listar alumnos inscirptos a cursos");
        foreach (var course in courses)
        {
            Commons.MenuOption($"{course.GetUnicNumber()}. {course.GetName()}");
        }
        string courseId = Commons.InputText("Ingresa el ID de un curso");
        Course selectedCourse = gestor.GetCourseByUnicNumber(courseId);
        if (selectedCourse == null)
        {
            Console.Clear();
            Commons.Header("Listar alumnos inscirptos a cursos");
            Commons.Message(false, $"No se encontró ningún curso con el ID: {courseId}");
            Console.ReadKey();
            return;
        }
        Commons.Header("Listar alumnos inscirptos a cursos");
        Commons.MenuOption($"Estudiantes inscriptos en {selectedCourse.GetName()}");
        Commons.TableHeader("Matr.", "Nombre", "", "");
        List<Alumno> enrolledStudents = gestor.GetEnrolledStudentsInCourse(selectedCourse);
        foreach (var student in enrolledStudents)
        {
            Commons.TableRow(student.GetUnicNumber(), student.GetFullName(), "", "");
        }
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");
    }
    public void ListCoursesInStudent(GestorAcademico gestor, UICommons Commons)
    {
        List<Alumno> students = gestor.GetAllStudents();
        if (!students.Any())
        {
            Commons.Header("Listar cursos de un alumno.");
            Commons.Message(false, "«« No hay alumnos registrados.");
            Console.ReadKey();
            return;
        }
        Commons.PlayConfirmation();
        Commons.Header("Listar cursos de un alumno.");
        foreach (var student in students)
        {
            Commons.MenuOption($"{student.GetUnicNumber()}. {student.GetFullName()}");
        }
        string studentId = Commons.InputText("Ingresa el ID de un alumno");
        Alumno selectedStudent = gestor.GetStudentByUnicNumber(studentId);
        if (selectedStudent == null)
        {
            Commons.Header("Listar cursos de un alumno.");
            Commons.Message(false, $"No se encontró ningún alumno con el ID: {studentId}");
            return;
        }
        Commons.Header("Listar cursos de un alumno.");
        Commons.MenuOption($"Cursos de {selectedStudent.GetFullName()}");
        Commons.TableHeader("ID", "Materia", "", "");
        List<Course> enrolledCourses = gestor.GetCoursesInStudent(selectedStudent);
        foreach (var course in enrolledCourses)
        {
            Commons.TableRow(course.GetUnicNumber(), course.GetName(), "", "");
        }
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");
    }
    public void UnsuscribeStudent(GestorAcademico gestor, UICommons Commons)
    {
        List<Course> courses = gestor.GetAllCourses();
        List<Alumno> students = gestor.GetAllStudents();
        if (!courses.Any())
        {
            Commons.Header("Desinscribir alumno de curso");
            Commons.Message(false, "«« No hay cursos registrados.");
            return;
        }
        if (!students.Any())
        {
            Commons.Header("Desinscribir alumno de curso");
            Commons.Message(false, "«« No hay estudiantes registrados.");
            return;
        }
        else
        {
            Commons.PlayConfirmation();
            Commons.Header("Desinscribir alumno de curso");
            foreach (var course in courses)
            {
                Commons.MenuOption($"{course.GetUnicNumber()}. {course.GetName()}");
            }
            string courseId = Commons.InputText("Ingresa el ID de un curso");
            Course selectedCourse = gestor.GetCourseByUnicNumber(courseId);
            if (selectedCourse == null)
            {
                Commons.Header("Desinscribir alumno de curso");
                Commons.Message(false, $"No se encontró ningún curso con el ID: {courseId}");
                return;
            }
            else
            {
                string option;
                do
                {
                    Commons.Header("Desinscribir alumno de curso");
                    Commons.MenuOption($"Ejegir alumno para desinscirbir de {selectedCourse.GetName()}");
                    Commons.TableHeader("Matr.", "Nombre", "", "");
                    foreach (var student in students)
                    {
                        Commons.TableRow(student.GetUnicNumber(), student.GetFullName(), "", "");
                    }
                    Commons.TableEnd();
                    string studentId = Commons.InputText("Ingresa matricula");
                    Alumno selectedStudent = gestor.GetStudentByUnicNumber(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Header("Desinscribir alumno de curso");
                        Commons.Message(false, $"No se encontró ningún curso con la matrícula: {studentId}");
                        return;
                    }
                    Commons.Message(true, gestor.UnsubscribeStudentfromCourse(selectedCourse, selectedStudent));
                    option = Commons.InputText("Deseas desinscribir otro alumno? (S/N)").ToLower();
                } while (option != "n");

            }

        }
    }
}