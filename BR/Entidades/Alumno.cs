using System;
using System.Collections.Generic;

namespace tupacAlumnos.entity;

public class Alumno : Entity
{
    private List<string> EnrolledCoursesIds { get; set; }
    public Alumno(string name, int dataNumber, DateTime date) : base(name, dataNumber, date)
    {
        EnrolledCoursesIds = new List<string>();
    }
    // public string GetFullName()
    // {
    //     return $"{FirstName}, {Name}";
    // }
    public Alumno Update(string unicNumber, string newName, int newDataNumber, DateTime newDate)
    {
        Name = newName;
        // FirstName = updatedFirsName;
        DataNumber = newDataNumber;
        Date = newDate;
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