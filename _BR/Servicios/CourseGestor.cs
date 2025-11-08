using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.DB;
using tupacAlumnos.interfaces;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor;


public class CourseGestor : IGestor<Course>
{
    public DBCourse Courses { get; set; }
    public CourseGestor(DBCourse courses)
    {
        Courses = courses;
    }
    public string Create(string name, int dataNumber, DateTime date)
    {
        Course NewCourse = new Course(name, dataNumber, date);
        Courses.Save(NewCourse);
        return $"{NewCourse.GetName()} fue agregado correctamente";
    }
    public string Delete(string id)
    {
        if (Courses.GetAll().Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetById(id);

        if (course != null)
        {
            string courseName = course.GetName();
            Courses.Delete(course.GetId());
            return $"{courseName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun alumno con la matricula {id}";
        }
    }
    public List<Course> GetAll()
    {
        List<Course> orderedCourses = Courses.GetAll().OrderBy(s => s.GetName()).ToList();
        return orderedCourses;
    }
    public Course GetById(string id)
    {
        Course course = Courses.GetAll().FirstOrDefault(s => s.GetId() == id);
        return course;
    }
    public string Update(string id, string newName, int newDataNumber, DateTime newDate)
    {
        if (Courses.GetAll().Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetById(id);
        if (course != null)
        {
            course.Update(newName, newDataNumber, newDate);
            return $"Datos de {newName} fueron actualizados";

        }
        else
        {
            return $"{id} no existe en el sistema";
        }
    }
}