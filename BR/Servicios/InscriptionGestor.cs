using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor;

public class InscriptionGestor
{
    public List<Alumno> Students { get; set; }
    public List<Course> Courses { get; set; }
    public InscriptionGestor(List<Alumno> students, List<Course> courses)
    {
        Students = students;
        Courses = courses;
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
}