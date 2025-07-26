using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TupacAlumnos;

namespace tupacAlumnos;

public class UIStudentGestor
{
    private string Option { get; set; } = string.Empty;
    public void MainMenu(GestorAcademico gestor, UICommons Commons)
    {
        do
        {
            Commons.ApplyTheme();
            Commons.Header("Gestor alumnos");
            Commons.MenuOption("1 - Alta alumno.");
            Commons.MenuOption("2 - Ver alumnos.");
            Commons.MenuOption("3 - Baja  alumno");
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
                    Commons.Message(false, "Opción no valida. Tocá cualquier tecla para continuar.");
                    break;
            }
        } while (Option != "v");
    }
    public void EnrollStudent(GestorAcademico gestor, UICommons Commons)
    {
        do
        {
            Commons.Header("Dar de alta alumno");
            string name;
            string lastName;
            string dNI;
            DateTime birthDate;
            name = Commons.InputText("Nombre");
            lastName = Commons.InputText("Apellido");
            while (true)
            {
                dNI = Commons.InputText("DNI");
                if (int.TryParse(dNI, out _))
                {
                    break;
                }
                Commons.Message(false, "DNI inválido. Ingresá solo números.");
            }

            while (true)
            {
                string birthDateStr = Commons.InputText("Nacimiento (dd/MM/yyyy)");
                if (DateTime.TryParseExact(birthDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    break;
                }
                Commons.Message(false, "Fecha inválida. Intente nuevamente con el formato dd/MM/yyyy.");
            }
            Commons.Alert(gestor.EnrollStudent(name, lastName, int.Parse(dNI), birthDate));
            Option = Commons.InputText("¿Querés agregar otro alumno? (S/N) ").ToLower();
        } while (Option != "n");
    }
    public void ShowStudentList(GestorAcademico gestor, UICommons Commons)
    {
        List<Alumno> students = gestor.GetAllStudents();
        if (!students.Any())
        {
            Commons.Header("Alumnos inscriptos");
            Commons.Message(false, "No hay alumnos registrados.");
        }
        else
        {
            Commons.PlayConfirmation();
            Commons.Header("Alumnos inscriptos");
            Commons.TableHeader("Matr.", "Nombre", "DNI", "Nacimiento");
            foreach (var student in students)
            {
                Commons.TableRow(student.GetUnicNumber(), student.GetFullName().ToUpper(), student.GetDNI(), student.GetBirthDate());
            }
            Commons.TableEnd();
            Commons.Message(true, "«« Presione cualquier tecla para volver");
        }
    }
    public void DeleteStudent(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Eliminar alumno");
        string unicNumber = Commons.InputText("ingresar Matricula");
        Commons.Message(false, gestor.DeleteStudent(unicNumber));
    }
    public void UpdateStudent(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Modificar datos");
        string unicNumber = Commons.InputText("ingresar Matricula");
        Alumno student = gestor.GetStudentByUnicNumber(unicNumber);
        if (student == null)
        {
            Commons.Message(false, $"No se encontró ningún alumno con la matrícula: {unicNumber}");
            return;
        }
        Commons.TableHeader("Matr.", "Nombre", "DNI", "Nacimiento");
        Commons.TableRow(student.GetUnicNumber(), student.GetFullName().ToUpper(), student.GetDNI().ToUpper(), student.GetBirthDate().ToUpper());
        Commons.TableEnd();
        string newName = Commons.InputText("Actualizar Nombre");
        string newLastName = Commons.InputText("Actualizar Apellido");
        string newDni;
        while (true)
        {
            newDni = Commons.InputText("Actualizar DNI");
            if (int.TryParse(newDni, out _))
            {
                break;
            }
            Commons.Message(false, "DNI inválido. Ingresá solo números.");
        }
        DateTime newBirthDate;
        while (true)
        {
            string birthDateStr = Commons.InputText("Actualizar Nacimiento (dd/MM/yyyy)");
            if (DateTime.TryParseExact(birthDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newBirthDate))
            {
                break;
            }
            Console.WriteLine("Fecha inválida. Intente nuevamente con el formato dd/MM/yyyy.");
        }
        Commons.Alert(gestor.UpdateStudent(unicNumber, newName, newLastName, int.Parse(newDni), newBirthDate));
        Commons.TableHeader("Matr.", "Nombre", "DNI", "Nacimiento");
        Commons.TableRow(student.GetUnicNumber(), student.GetFullName(), student.GetDNI(), student.GetBirthDate());
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");

    }
    public void FindStudent(GestorAcademico gestor, UICommons Commons)
    {
        Commons.Header("Buscar Alumno");
        string studentId = Commons.InputText("Ingresar matricula");
        Alumno student = gestor.GetStudentByUnicNumber(studentId);
        if (student == null)
        {
            Commons.Header("Buscar Alumno");
            Commons.Message(false, $"El alumno con la matricula {studentId} no existe");
            return;
        }
        Commons.Header("Buscar Alumno");
        Commons.MenuOption($"Cursos de {student.GetFullName()}");
        List<Course> courses = gestor.GetCoursesInStudent(student);
        if (courses.Count == 0)
        {
            Commons.Header("Buscar Alumno");
            Commons.Message(false, $"{student.GetFullName()} sin cursos que mostrar");
            return;
        }
        Commons.Header("Buscar Alumno");
        Commons.MenuOption($"Cursos de  {student.GetFullName()}");
        Commons.TableHeader("Id", "Nombre", "Año lectivo", "Cupo");
        for (int i = 0; i < courses.Count; i++)
        {
            Commons.TableRow(courses[i].GetUnicNumber(), courses[i].GetName(), courses[i].GetSchoolYear(), courses[i].GetMaxStudents());

        }
        Commons.TableEnd();
        Commons.Message(true, "«« Presione cualquier tecla para volver");
        Console.ReadKey();
    }

}