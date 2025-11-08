using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.DB;
using tupacAlumnos.entity;
using tupacAlumnos.interfaces;

namespace tupacAlumnos.academicGestor;

public class StudentGestor : IGestor<Alumno>
{
     public DBAlumno Students { get; set; }
    public StudentGestor(DBAlumno students)
    {
        Students = students;
    }
    public string Create(string name, int dataNumber, DateTime date)
    {
        Alumno newStudent = new Alumno(name, dataNumber, date);
        Students.Save(newStudent);
        return $"{newStudent.GetName()} fue agregado correctamente";
    }
    public string Delete(string id)
    {
        if (Students.GetAll().Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetById(id);

        if (student != null)
        {
            string studentName = student.GetName();
            Students.Delete(student.GetId());
            return $"{studentName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun alumno con la matricula {id}";
        }
    }
    public List<Alumno> GetAll()
    {
        List<Alumno> orderedStudents = Students.GetAll().OrderBy(s => s.GetName()).ToList();
        return orderedStudents;
    }
    public Alumno GetById(string id)
    {
        Alumno student = Students.GetAll().FirstOrDefault(s => s.GetId() == id);
        return student;
    }
    public string Update(string id, string newName, int newDataNumber, DateTime newDate)
    {
        if (Students.GetAll().Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetById(id);
        if (student != null)
        {
            student.Update(id, newName, newDataNumber, newDate);
            return $"Datos de {newName} actualizados";

        }
        else
        {
            return $"{id} no existe en el sistema";
        }
    }
}