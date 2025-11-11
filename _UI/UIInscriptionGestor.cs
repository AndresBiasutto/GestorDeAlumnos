using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.academicGestor;
using tupacAlumnos.entity;
using tupacAlumnos.utils;
using TupacAlumnos.entity;

namespace tupacAlumnos
{
    public class UIInscriptionGestor
    {
        private string Option { get; set; } = string.Empty;
        public void MainMenu(InscriptionGestor gestor, UICommons Commons)
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
                UICommons.PlayConfirmation();
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
                }
            } while (Option != "v");
        }
        public void SubscribeStudentInCourse(InscriptionGestor gestor, UICommons Commons)
        {
            List<Course> courses = gestor.GetAllCourses();
            List<Alumno> students = gestor.GetAllStudents();

            if (courses.Count == 0)
            {
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }
            // if (!students.Any())
            // {
            //     Commons.Message(false, "«« No hay estudiantes registrados.");
            //     return;
            // }

            Commons.Header("Inscribir alumno a curso");
            foreach (var c in courses)
                Commons.MenuOption($"{c.GetId()}. {c.GetName()}");
            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID de curso"), "ID curso");
                Course selectedCourse = gestor.GetCourseById(courseId);
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
                        Commons.TableRow(s.GetId(), s.GetName(), "", "");
                    Commons.TableEnd();

                    string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                    Alumno selectedStudent = gestor.GetStudentById(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Message(false, $"No se encontró alumno con matrícula: {studentId}");
                        Console.ReadKey();
                        return;
                    }

                    Commons.Alert(gestor.EnrollStudent(courseId, studentId, selectedStudent, selectedCourse, DateTime.Now));
                    option = Commons.InputText("¿Deseas agregar otro alumno? (S/N)").ToLower();
                } while (option != "n");
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }
        public void UnsuscribeStudent(InscriptionGestor gestor, UICommons Commons)
        {
            List<Course> courses = gestor.GetAllCourses().OrderBy(s => s.GetName()).ToList();
            List<Alumno> students = gestor.GetAllStudents().OrderBy(s => s.GetName()).ToList();

            if (courses.Count == 0)
            {
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }
            if (students.Count == 0)
            {
                Commons.Message(false, "«« No hay estudiantes registrados.");
                return;
            }

            Commons.Header("Desinscribir alumno de curso");
            foreach (var c in courses)
                Commons.MenuOption($"{c.GetId()}. {c.GetName()}");

            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID de curso"), "ID curso");
                Course selectedCourse = gestor.GetCourseById(courseId);
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
                        Commons.TableRow(s.GetId(), s.GetName(), "", "");
                    Commons.TableEnd();

                    string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                    Alumno selectedStudent = gestor.GetStudentById(studentId);
                    if (selectedStudent == null)
                    {
                        Commons.Message(false, $"No se encontró alumno con matrícula: {studentId}");
                        Console.ReadKey();
                        return;
                    }

                    Commons.Alert(gestor.CancelEnrollment(selectedCourse.GetId(), selectedStudent.GetId()));
                    option = Commons.InputText("¿Deseas desinscribir otro alumno? (S/N)").ToLower();
                } while (option != "n");
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
                Console.ReadKey();
            }
        }        // {
        public void ListStudentsInCourse(InscriptionGestor gestor, UICommons Commons)
        {
            List<Course> forms = gestor.GetAllCourses().OrderBy(s => s.GetName()).ToList();;
            if (forms.Count == 0)
            {
                Commons.Header("Listar alumnos inscirptos a cursos");
                Commons.Message(false, "«« No hay cursos registrados.");
                return;
            }

            Commons.Header("Listar alumnos inscirptos a cursos");
            foreach (var course in forms)
                Commons.MenuOption($"{course.GetId()}. {course.GetName()}");

            try
            {
                string courseId = Validations.ValidateNotEmpty(Commons.InputText("Ingresa el ID de un curso"), "ID curso");
                Course selectedCourse = gestor.GetCourseById(courseId);
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
                List<Alumno> enrolledStudents = gestor.GetStudentsEnrolledInCourse(selectedCourse.GetId());
                foreach (var student in enrolledStudents)
                    Commons.TableRow(student.GetId(), student.GetName(), "", "");
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
        public void ListCoursesInStudent(InscriptionGestor gestor, UICommons Commons)
        {
            var forms = gestor.GetAllStudents().OrderBy(s => s.GetName()).ToList();;
            if (forms.Count == 0)
            {
                Commons.Header("Listar cursos de un alumno.");
                Commons.Message(false, "«« No hay alumnos registrados.");
                Console.ReadKey();
                return;
            }

            UICommons.PlayConfirmation();
            Commons.Header("Listar cursos de un alumno.");
            foreach (var student in forms)
                Commons.MenuOption($"{student.GetId()}. {student.GetName()}");

            try
            {
                string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresa el ID de un alumno"), "Matrícula");
                Alumno selectedStudent = gestor.GetStudentById(studentId);
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
                List<Course> enrolledCourses = gestor.GetCoursesOfAStudent(selectedStudent.GetId());
                foreach (var course in enrolledCourses)
                    Commons.TableRow(course.GetId(), course.GetName(), "", "");
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