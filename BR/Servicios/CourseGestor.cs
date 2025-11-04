using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.entity;
using tupacAlumnos.interfaces;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor;


public class CourseGestor : IGestor<Course>
{
    public List<Alumno> Students { get; set; }
    public List<Course> Courses { get; set; }
    public CourseGestor(List<Alumno> students, List<Course> courses)
    {
        Students = students;
        Courses = courses;
    }
    public string Create(string name, int dataNumber, DateTime date)
    {
        Course NewCourse = new Course(name, dataNumber, date);
        Courses.Add(NewCourse);
        return $"{NewCourse.GetName()} fue creado correctamente";
    }
    public string Delete(string unicNumber)
    {
        if (Courses.Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetById(unicNumber);

        if (course != null)
        {
            string courseName = course.GetName();
            Courses.Remove(course);
            return $"{courseName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun alumno con la matricula {unicNumber}";
        }
    }
    public List<Course> GetAll()
    {
        List<Course> orderedCourses = Courses.OrderBy(s => s.GetName()).ToList();
        return orderedCourses;
    }
    public Course GetById(string unicNumber)
    {
        Course course = Courses.FirstOrDefault(s => s.GetUnicNumber() == unicNumber);
        return course;
    }
    public string Update(string unicNumber, string newName, int newDataNumber, DateTime newDate)
    {
        if (Courses.Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetById(unicNumber);
        if (course != null)
        {
            course.Update(newName, newDataNumber, newDate);
            return $"Datos de {newName} fueron actualizados";

        }
        else
        {
            return $"{unicNumber} no existe en el sistema";
        }
    }
    public string EnrollStudentInCourse(Course course, Alumno student)
    {
        List<string> enroledSt = course.GetEnrolledStudents();
        string studentUnicNumber = student.GetUnicNumber();
        string courseUnicNumber = course.GetUnicNumber();
        for (int i = 0; i < enroledSt.Count; i++)
        {
            if (enroledSt[i] == studentUnicNumber)
            {
                return $"{studentUnicNumber} ya esta inscripto";
            }
        }
        if (int.Parse(course.GetDataNumber()) <= course.GetEnrolledStudents().Count())
        {
            return $"cupo máximo superado para {course.GetName()}";
        }
        return $"{student.AddCourse(courseUnicNumber)} fue inscripto en {course.AddStudent(studentUnicNumber)}";
    }
    public string UnsubscribeStudentfromCourse(Course course, Alumno student)
    {
        List<string> enroledSt = course.GetEnrolledStudents();
        string studentUnicNumber = student.GetUnicNumber();
        string courseUnicNumber = course.GetUnicNumber();
        for (int i = 0; i < enroledSt.Count; i++)
        {
            if (enroledSt[i] == studentUnicNumber)
            {
                return $"{student.DeleteCourse(courseUnicNumber)} fue eliminado de {course.DeleteStudent(studentUnicNumber)}";
            }
        }
        return $"El alumno no esta inscripto en {course.GetName()}";
    }
    public List<Alumno> GetEnrolledStudentsInCourse(Course course)
    {
        List<string> StudentsIds = course.GetEnrolledStudents();
        List<Alumno> students = new List<Alumno>();
        for (int i = 0; i < StudentsIds.Count; i++)
        {
            for (int j = 0; j < Students.Count(); j++)
            {
                if (StudentsIds[i] == Students[j].GetUnicNumber())
                {
                    students.Add(Students[j]);
                }
            }
        }
        return students;
    }

}