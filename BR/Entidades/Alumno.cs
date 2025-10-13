using System;
using System.Collections.Generic;

namespace tupacAlumnos;

public class Alumno : Entity, IEntity
{
    private string FirstName { get; set; }
    private List<string> EnrolledCoursesIds { get; set; }
    public Alumno(string name, string firstName, int dataNumber, DateTime date) : base(name, dataNumber, date)
    {
        FirstName = firstName;
        EnrolledCoursesIds = new List<string>();
    }
    public string GetFullName()
    {
        return $"{FirstName}, {Name}";
    }
    public Alumno Update(string updatedName, string updatedFirsName, int updatedDni, DateTime updatedBirthDate)
    {
        Name = updatedName;
        FirstName = updatedFirsName;
        DataNumber = updatedDni;
        Date = updatedBirthDate;
        return this;
    }
    public string AddCourse(string courseId)
    {
        EnrolledCoursesIds.Add(courseId);
        return $"{Name}";
    }
    public string DeleteCourse(string courseId)
    {
        EnrolledCoursesIds.Remove(courseId);
        return Name;
    }
    public List<string> GetMyCourses()
    {
        return EnrolledCoursesIds;
    }
}