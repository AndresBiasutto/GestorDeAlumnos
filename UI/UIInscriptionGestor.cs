using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.academicGestor;
using tupacAlumnos.entity;
using tupacAlumnos.utils;
using TupacAlumnos;
using TupacAlumnos.entity;

namespace tupacAlumnos
{
    public class UIInscriptionGestor
    {
        private string Option { get; set; } = string.Empty;

        public void MainMenu(InscriptionGestor gestor, StudentGestor studentGestor, CourseGestor courseGestor, UICommons Commons)
        {
            do
            {
                Commons.ApplyTheme();
                Commons.Header("Gestor de inscripciones");
                Commons.MenuOption("1 - Inscribir alumno.");
                Commons.MenuOption("2 - Baja de inscripción.");
                Commons.MenuOption("3 - Lista de alumnos por curso");
                Commons.MenuOption("4 - Cursos asociados a un alumno");
                Commons.Menu1row2cols("L. Día / Noche", "V - volver", "blue", "green");
                Commons.PlayConfirmation();
                Option = Commons.InputText("Ingresa una opción").ToLower();

                switch (Option)
                {
                    case "1":
                        SubscribeStudentInCourse(gestor, studentGestor, courseGestor, Commons);
                        break;
                    case "2":
                        UnsuscribeStudent(gestor, studentGestor, courseGestor, Commons);
                        break;
                    case "3":
                        ListStudentsInCourse(courseGestor, Commons);
                        break;
                    case "4":
                        ListCoursesInStudent(studentGestor, Commons);
                        break;
                    case "l":
                        Commons.Toggle();
                        break;
                }
            } while (Option != "v");
        }

        public void SubscribeStudentInCourse(InscriptionGestor gestor, StudentGestor studentGestor, CourseGestor courseGestor, UICommons Commons)
        {
            var courses = courseGestor.GetAll();
            var students = studentGestor.GetAll();

            if (!courses.Any())
            {
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }
            if (!students.Any())
            {
                Commons.Message(false, "«« No hay estudiantes registrados.");
                return;
            }

            Commons.Header("Inscribir alumno a curso");
            foreach (var c in courses)
                Commons.MenuOption($"{c.GetUnicNumber()}. {c.GetName()}");

            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID de curso"), "ID curso");
                Course selectedCourse = courseGestor.GetById(courseId);
                if (selectedCourse == null)
                {
                    Commons.Message(false, $"No se encontró curso con ID: {courseId}");
                    Console.ReadKey();
                    return;
                }

                string option;
                do
                {
                    Commons.Header($"Agregar alumnos a {selectedCourse.GetName()}");
                    Commons.TableHeader("Matr.", "Nombre", "", "");
                    foreach (var s in students)
                        Commons.TableRow(s.GetUnicNumber(), s.GetName(), "", "");
                    Commons.TableEnd();

                    string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                    Alumno selectedStudent = studentGestor.GetById(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Message(false, $"No se encontró alumno con matrícula: {studentId}");
                        Console.ReadKey();
                        return;
                    }

                    Commons.Alert(gestor.EnrollStudentInCourse(selectedCourse, selectedStudent));
                    option = Commons.InputText("¿Deseas agregar otro alumno? (S/N)").ToLower();
                } while (option != "n");
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }

        public void UnsuscribeStudent(InscriptionGestor gestor, StudentGestor studentGestor, CourseGestor courseGestor, UICommons Commons)
        {
            var courses = courseGestor.GetAll();
            var students = studentGestor.GetAll();

            if (!courses.Any())
            {
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }
            if (!students.Any())
            {
                Commons.Message(false, "«« No hay estudiantes registrados.");
                return;
            }

            Commons.Header("Desinscribir alumno de curso");
            foreach (var c in courses)
                Commons.MenuOption($"{c.GetUnicNumber()}. {c.GetName()}");

            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID de curso"), "ID curso");
                Course selectedCourse = courseGestor.GetById(courseId);
                if (selectedCourse == null)
                {
                    Commons.Message(false, $"No se encontró curso con ID: {courseId}");
                    Console.ReadKey();
                    return;
                }

                string option;
                do
                {
                    Commons.Header($"Desinscribir de {selectedCourse.GetName()}");
                    Commons.TableHeader("Matr.", "Nombre", "", "");
                    foreach (var s in students)
                        Commons.TableRow(s.GetUnicNumber(), s.GetName(), "", "");
                    Commons.TableEnd();

                    string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                    Alumno selectedStudent = studentGestor.GetById(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Message(false, $"No se encontró alumno con matrícula: {studentId}");
                        Console.ReadKey();
                        return;
                    }

                    Commons.Alert(gestor.UnsubscribeStudentfromCourse(selectedCourse, selectedStudent));
                    option = Commons.InputText("¿Deseas desinscribir otro alumno? (S/N)").ToLower();
                } while (option != "n");
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }

        public void ListStudentsInCourse(CourseGestor courseGestor, UICommons Commons)
        {
            var courses = courseGestor.GetAll();
            if (!courses.Any())
            {
                Commons.Header("Listar alumnos inscirptos a cursos");
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }

            Commons.PlayConfirmation();
            Commons.Header("Listar alumnos inscirptos a cursos");
            foreach (var course in courses)
                Commons.MenuOption($"{course.GetUnicNumber()}. {course.GetName()}");

            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresa el ID de un curso"), "ID curso");
                Course selectedCourse = courseGestor.GetById(courseId);
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
                List<Alumno> enrolledStudents = courseGestor.GetEnrolledStudentsInCourse(selectedCourse);
                foreach (var student in enrolledStudents)
                    Commons.TableRow(student.GetUnicNumber(), student.GetName(), "", "");
                Commons.TableEnd();
                Commons.Message(true, "«« Presione cualquier tecla para volver");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }

        public void ListCoursesInStudent(StudentGestor studentGestor, UICommons Commons)
        {
            var students = studentGestor.GetAll();
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
                Commons.MenuOption($"{student.GetUnicNumber()}. {student.GetName()}");

            try
            {
                string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresa el ID de un alumno"), "Matrícula");
                Alumno selectedStudent = studentGestor.GetById(studentId);
                if (selectedStudent == null)
                {
                    Commons.Header("Listar cursos de un alumno.");
                    Commons.Message(false, $"No se encontró ningún alumno con el ID: {studentId}");
                    Console.ReadKey();
                    return;
                }

                Commons.Header("Listar cursos de un alumno.");
                Commons.MenuOption($"Cursos de {selectedStudent.GetName()}");
                Commons.TableHeader("ID", "Materia", "", "");
                List<Course> enrolledCourses = studentGestor.GetCoursesInStudent(selectedStudent);
                foreach (var course in enrolledCourses)
                    Commons.TableRow(course.GetUnicNumber(), course.GetName(), "", "");
                Commons.TableEnd();
                Commons.Message(true, "«« Presione cualquier tecla para volver");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }
    }
}