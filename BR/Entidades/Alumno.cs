using System;
using System.Collections.Generic;

namespace tupacAlumnos;

public class Alumno : Entity
{
    private string Name { get; set; }
    private string LastName { get; set; }
    private int DNI { get; set; }
    private DateTime BirthDate { get; set; }
    private List<string> EnrolledCoursesIds { get; set; }
    public Alumno(string name, string lastName, int dNI, DateTime birthDate)
    {
        Name = name;
        LastName = lastName;
        DNI = dNI;
        BirthDate = birthDate;
        EnrolledCoursesIds = new List<string>();
    }
    public string GetFullName()
    {
        return $"{LastName}, {Name}";
    }
    public string GetDNI()
    {
        return $"{DNI.ToString()}";
    }
    public string GetBirthDate()
    {
        return $"{BirthDate.ToString("dd/MM/yyyy")}";
    }
    public Alumno Update(string updatedName, string updatedLastName, int updatedDni, DateTime updatedBirthDate)
    {
        Name = updatedName;
        LastName = updatedLastName;
        DNI = updatedDni;
        BirthDate = updatedBirthDate;
        return this;
    }
    public string AddCourse(string courseId)
    {
        EnrolledCoursesIds.Add(courseId);
        return $"{LastName}";
    }
    public string DeleteCourse(string courseId)
    {
        EnrolledCoursesIds.Remove(courseId);
        return LastName;
    }
    public List<string> GetMyCourses()
    {
        return EnrolledCoursesIds;
    }
}