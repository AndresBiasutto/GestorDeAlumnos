// File: ui/UIStudentGestor.cs
using System;
using System.Linq;
using tupacAlumnos.academicGestor;
using tupacAlumnos.entity;
using tupacAlumnos.utils;

namespace tupacAlumnos
{
    public class UIStudentGestor
    {
        private string Option { get; set; } = string.Empty;

        public void MainMenu(StudentGestor gestor, UICommons Commons)
        {
            do
            {
                Commons.ApplyTheme();
                Commons.Header("Gestor alumnos");
                Commons.MenuOption("1 - Alta alumno.");
                Commons.MenuOption("2 - Ver alumnos.");
                Commons.MenuOption("3 - Baja alumno");
                Commons.MenuOption("4 - Buscar alumno");
                Commons.MenuOption("5 - Modificar alumno");
                Commons.Menu1row2cols("L. Día / Noche", "V - volver", "blue", "green");
                Commons.PlayConfirmation();
                Option = Commons.InputText("Ingresa una opción").ToLower();

                switch (Option)
                {
                    case "1":
                        EnrollStudent(gestor, Commons);
                        break;
                    case "2":
                        ShowStudentList(gestor, Commons);
                        break;
                    case "3":
                        DeleteStudent(gestor, Commons);
                        break;
                    case "4":
                        FindStudent(gestor, Commons);
                        break;
                    case "5":
                        UpdateStudent(gestor, Commons);
                        break;
                    case "l":
                        Commons.Toggle();
                        break;
                    case "v":
                        break;
                    default:
                        Commons.Message(false, "Opción no válida. Tocá cualquier tecla para continuar.");
                        break;
                }
            } while (Option != "v");
        }

        public void EnrollStudent(StudentGestor gestor, UICommons Commons)
        {
            do
            {
                Commons.Header("Dar de alta alumno");
                try
                {
                    string name = Validations.ValidateNotEmpty(Commons.InputText("Nombre"), "Nombre");
                    string lastName = Validations.ValidateNotEmpty(Commons.InputText("Apellido"), "Apellido");
                    int dni = Validations.ValidateInt(Commons.InputText("DNI"), "DNI");
                    Validations.ValidateIntRange(dni, 1000000, 99999999, "DNI");

                    DateTime birthDate = Validations.ValidateDate(Commons.InputText("Nacimiento (dd/MM/yyyy)"), "Nacimiento", "dd/MM/yyyy");
                    Validations.ValidateDateRange(birthDate, new DateTime(1940, 1, 1), DateTime.Today, "Nacimiento");

                    Commons.Alert(gestor.Create($"{name} {lastName}", dni, birthDate));
                }
                catch (Exception ex)
                {
                    Commons.Message(false, ex.Message);
                }

                Option = Commons.InputText("¿Querés agregar otro alumno? (S/N)").ToLower();
            } while (Option != "n");
        }

        public void ShowStudentList(StudentGestor gestor, UICommons Commons)
        {
            var students = gestor.GetAll();
            Commons.Header("Alumnos inscriptos");
            if (!students.Any())
                Commons.Message(false, "No hay alumnos registrados.");
            else
                Commons.Table("Matr.", "Nombre", "DNI", "Nacimiento", students);
        }

        public void DeleteStudent(StudentGestor gestor, UICommons Commons)
        {
            try
            {
                Commons.Header("Eliminar alumno");
                string unicNumber = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                Commons.Message(false, gestor.Delete(unicNumber));
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
            }
        }

        public void UpdateStudent(StudentGestor gestor, UICommons Commons)
        {
            Commons.Header("Modificar datos");
            try
            {
                string unicNumber = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                Alumno student = gestor.GetById(unicNumber);
                if (student == null)
                {
                    Commons.Message(false, $"No se encontró ningún alumno con la matrícula: {unicNumber}");
                    return;
                }

                Commons.TableHeader("Matr.", "Nombre", "DNI", "Nacimiento");
                Commons.TableRow(student.GetUnicNumber(), student.GetName(), student.GetDataNumber(), student.GetDate());
                Commons.TableEnd();

                string newName = Validations.ValidateNotEmpty(Commons.InputText("Actualizar Nombre"), "Nombre");
                string newLastName = Validations.ValidateNotEmpty(Commons.InputText("Actualizar Apellido"), "Apellido");
                int newDni = Validations.ValidateInt(Commons.InputText("Actualizar DNI"), "DNI");
                Validations.ValidateIntRange(newDni, 1000000, 99999999, "DNI");

                DateTime newBirthDate = Validations.ValidateDate(Commons.InputText("Actualizar Nacimiento (dd/MM/yyyy)"), "Nacimiento", "dd/MM/yyyy");
                Validations.ValidateDateRange(newBirthDate, new DateTime(1940, 1, 1), DateTime.Today, "Nacimiento");

                Commons.Alert(gestor.Update(unicNumber, $"{newName} {newLastName}", newDni, newBirthDate));
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
            }

            Commons.Message(true, "«« Presione cualquier tecla para volver");
        }

        public void FindStudent(StudentGestor gestor, UICommons Commons)
        {
            try
            {
                Commons.Header("Buscar Alumno");
                string studentId = Validations.ValidateNotEmpty(Commons.InputText("Ingresar matrícula"), "Matrícula");
                Alumno student = gestor.GetById(studentId);
                if (student == null)
                {
                    Commons.Message(false, $"El alumno con la matrícula {studentId} no existe");
                    return;
                }

                var courses = gestor.GetCoursesInStudent(student);
                Commons.Header($"Cursos de {student.GetName()}");
                if (!courses.Any())
                    Commons.Message(false, $"{student.GetName()} sin cursos que mostrar");
                else
                {
                    Commons.TableHeader("Id", "Nombre", "Año lectivo", "Cupo");
                    foreach (var c in courses)
                        Commons.TableRow(c.GetUnicNumber(), c.GetName(), c.GetSchoolYear(), c.GetDataNumber());
                    Commons.TableEnd();
                }
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
            }
        }
    }
}
