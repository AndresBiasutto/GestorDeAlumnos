using System;
using tupacAlumnos;
using tupacAlumnos.academicGestor;
using tupacAlumnos.DB;

namespace TupacAlumnos
{
    class Program
    {
        private static UICommons Commons { get; set; } = new();
        static void Main(string[] args)
        {
            string option;
            DBForms _dbForms = new DBForms();
            DBAlumno _dbAlumnos = new DBAlumno();
            DBCourse _dbCourses = new DBCourse();
            StudentGestor studentGestor = new(_dbAlumnos);
            CourseGestor courseGestor = new(_dbCourses);
            InscriptionGestor inscriptionGestor = new(_dbAlumnos, _dbCourses, _dbForms);
            UIStudentGestor uiStudentGestor = new();
            UICourseGestor uiCoursetGestor = new();
            UIInscriptionGestor uiInscriptionGestor = new();

            Console.Clear();
            Console.WriteLine("Usar pantalla completa para una mejor experiencia");
            Console.ReadKey();
            Commons.IntroScreen();
            do
            {
                Commons.ApplyTheme();
                Commons.Header("Instituto de formación Docente y Técnica");
                Commons.MenuOption("1. Gestión de Alumnos");
                Commons.MenuOption("2. Gestión de Cursos");
                Commons.MenuOption("3. Inscripción de Alumnos a Cursos");
                Commons.Menu1row2cols("L. Día / Noche", "S. Salir.", "blue", "red");
                option = Commons.InputText("Ingresa una opción").ToLower();
                switch (option)
                {
                    case "1":
                        uiStudentGestor.MainMenu(studentGestor, Commons);
                        break;
                    case "2":
                        uiCoursetGestor.MainMenu(courseGestor, Commons);
                        break;
                    case "3":
                        uiInscriptionGestor.MainMenu(inscriptionGestor, Commons);
                        break;
                    case "l":
                        Commons.Toggle();
                        break;
                    case "s":
                        break;
                    default:
                        Commons.Message(false, "Opción no valida. Tocá cualquier tecla para continuar.");
                        break;
                }
            } while (option != "s");
            Commons.Header("Instituto de formación Docente y Técnica");
            Commons.Message(true, "Gracias por usar el SISTEMA DE GESTIÓN ACADÉMICA TUPAC");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

        }
    }
}
