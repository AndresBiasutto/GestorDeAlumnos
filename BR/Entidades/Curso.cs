using System;
using System.Collections.Generic;
using tupacAlumnos;

namespace TupacAlumnos.entity;

public class Course : Entity
{
    private int MaxStudents { get; set; }
    private DateTime SchoolYear { get; set; }
    private List<string> StudentsIds { get; set; }
    // private List<Alumno> EnrolledStudents { get; set; }

    public Course(string name, int dataNumber, DateTime date): base(name, dataNumber, date)
    {
        StudentsIds = new List<string>();
    }
    public string GetMaxStudents()
    {
        return MaxStudents.ToString();
    }
    public string GetSchoolYear()
    {
        return SchoolYear.ToString("yyyy");
    }
    public Course Update(string updatedName, int updateMaxStudents, DateTime updatedSchoolYear)
    {
        Name = updatedName;
        MaxStudents = updateMaxStudents;
        SchoolYear = updatedSchoolYear;
        return this;
    }
    public string AddStudent(string studentId)
    {
        StudentsIds.Add(studentId);
        return $"{Name}";
    }
        public string DeleteStudent(string studentId)
    {
        StudentsIds.Remove(studentId);
        return Name;
    }
    public List<string> GetEnrolledStudents()
    {
        return StudentsIds;
    }
}