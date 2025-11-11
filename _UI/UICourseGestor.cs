// File: ui/UICourseGestor.cs
using System;
using System.Linq;
using tupacAlumnos.academicGestor;
using tupacAlumnos.utils;
using TupacAlumnos.entity;

namespace tupacAlumnos
{
    public class UICourseGestor
    {
        private string Option { get; set; } = string.Empty;
        public void MainMenu(CourseGestor gestor, UICommons Commons)
        {
            do
            {
                Commons.ApplyTheme();
                UICommons.PlayConfirmation();
                Commons.Header("Gestor CURSOS");
                Commons.MenuOption("1 - Alta curso.");
                Commons.MenuOption("2 - Ver cursos.");
                Commons.MenuOption("3 - Baja curso");
                Commons.MenuOption("4 - Modificar curso");
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
                        UpdateCourse(gestor, Commons);
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
        public void CreateCourse(CourseGestor gestor, UICommons Commons)
        {
            do
            {
                Commons.Header("Crear curso");
                try
                {
                    string name = Validations.ValidateNotEmpty(Commons.InputText("Nombre"), "Nombre");

                    int maxStudents = Validations.ValidateInt(Commons.InputText("Cupo máximo de estudiantes"), "Cupo máximo");
                    Validations.ValidateIntRange(maxStudents, 5, 200, "Cupo máximo");

                    DateTime schoolYear = Validations.ValidateDate(Commons.InputText("Año lectivo (yyyy)"), "Año lectivo", "yyyy");
                    Validations.ValidateDateRange(schoolYear, new DateTime(2020, 1, 1), new DateTime(2030, 12, 31), "Año lectivo");

                    Commons.Alert(gestor.Create(name, maxStudents, schoolYear));
                }
                catch (Exception ex)
                {
                    Commons.Message(false, ex.Message);
                }

                Option = Commons.InputText("¿Querés crear otro curso? (S/N)").ToLower();
            } while (Option != "n");
        }
        public void ShowCoursesList(CourseGestor gestor, UICommons Commons)
        {
            var courses = gestor.GetAll();
            Commons.Header("Todos los cursos");
            if (!courses.Any())
                Commons.Message(false, "«« No hay cursos registrados.");
            else
            {
                UICommons.PlayConfirmation();
                Commons.Table("ID", "Nombre", "Cupo", "Año lectivo", courses);
            }
        }
        public void DeleteCourse(CourseGestor gestor, UICommons Commons)
        {
            try
            {
                Commons.Header("Eliminar curso");
                string id = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID curso"), "ID curso");
                Commons.Message(false, gestor.Delete(id));
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
            }
        }
        public void UpdateCourse(CourseGestor gestor, UICommons Commons)
        {
            Commons.Header("Modificar Curso");
            try
            {
                string id = Validations.ValidateNotEmpty(Commons.InputText("Ingresar ID curso"), "ID curso");
                Course course = gestor.GetById(id);
                if (course == null)
                {
                    Commons.Message(false, $"No se encontró ningún curso con la matrícula: {id}");
                    return;
                }

                Commons.TableHeader("ID", "Materia", "Cupo", "Año lectivo");
                Commons.TableRow(course.GetId(), course.GetName(), course.GetDataNumber(), course.GetDate());
                Commons.TableEnd();

                string newName = Validations.ValidateNotEmpty(Commons.InputText("Actualizar Nombre"), "Nombre");
                int newMaxStudents = Validations.ValidateInt(Commons.InputText("Actualizar cupo máximo"), "Cupo máximo");
                Validations.ValidateIntRange(newMaxStudents, 5, 200, "Cupo máximo");

                DateTime newSchoolYear = Validations.ValidateDate(Commons.InputText("Actualizar Año lectivo (yyyy)"), "Año lectivo", "yyyy");
                Validations.ValidateDateRange(newSchoolYear, new DateTime(2020, 1, 1), new DateTime(2030, 12, 31), "Año lectivo");

                Commons.Alert(gestor.Update(id, newName, newMaxStudents, newSchoolYear));
            }
            catch (Exception ex)
            {
                Commons.Message(false, ex.Message);
            }

            Commons.Message(true, "«« Presione cualquier tecla para volver");
        }
    }
}
