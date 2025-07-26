using System;
using System.Collections.Generic;
using tupacAlumnos;

namespace TupacAlumnos;

public class Course : Entity
{
    private string Name { get; set; }
    private int MaxStudents { get; set; }
    private DateTime SchoolYear { get; set; }
    private List<string> StudentsIds { get; set; }
    // private List<Alumno> EnrolledStudents { get; set; }

    public Course(string name, int maxStudents, DateTime schoolYear)
    {
        Name = name;
        MaxStudents = maxStudents;
        SchoolYear = schoolYear;
        StudentsIds = new List<string>();
    }
    public string GetName()
    {
        return $"{Name}";
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