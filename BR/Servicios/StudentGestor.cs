using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.entity;
using tupacAlumnos.interfaces;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor;


public class StudentGestor : IGestor<Alumno>
{
    public List<Alumno> Students { get; set; }
    public List<Course> Courses { get; set; }
    public StudentGestor(List<Alumno> students, List<Course> courses)
    {
        Students = students;
        Courses = courses;
    }
    public string Create(string name, int dataNumber, DateTime date)
    {
        Alumno newStudent = new Alumno(name, dataNumber, date);
        Students.Add(newStudent);
        return $"{newStudent.GetName()} fue agregado correctamente";
    }
    public string Delete(string unicNumber)
    {
        if (Students.Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetById(unicNumber);

        if (student != null)
        {
            string studentName = student.GetName();
            Students.Remove(student);
            return $"{studentName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun alumno con la matricula {unicNumber}";
        }
    }
    public List<Alumno> GetAll()
    {
        List<Alumno> orderedStudents = Students.OrderBy(s => s.GetName()).ToList();
        return orderedStudents;
    }
    public Alumno GetById(string unicNumber)
    {
        Alumno student = Students.FirstOrDefault(s => s.GetUnicNumber() == unicNumber);
        return student;
    }
    public string Update(string unicNumber, string newName, int newDataNumber, DateTime newDate)
    {
        if (Students.Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetById(unicNumber);
        if (student != null)
        {
            student.Update(unicNumber, newName, newDataNumber, newDate);
            return $"Datos de {newName} actualizados";

        }
        else
        {
            return $"{unicNumber} no existe en el sistema";
        }
    }
    public List<Course> GetCoursesInStudent(Alumno student)
    {
        List<string> coursesIds = student.GetMyCourses();
        List<Course> courses = new List<Course>();
        for (int i = 0; i < coursesIds.Count; i++)
        {
            for (int j = 0; j < Courses.Count(); j++)
            {
                if (coursesIds[i] == Courses[j].GetUnicNumber())
                {
                    courses.Add(Courses[j]);
                }
            }
        }
        return courses;
    }
}