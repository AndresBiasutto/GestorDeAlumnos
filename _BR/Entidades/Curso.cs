using System;
using tupacAlumnos;

namespace TupacAlumnos.entity;

public class Course : Entity
{
    private int MaxStudents { get; set; }
    private DateTime SchoolYear { get; set; }

    public Course(string name, int dataNumber, DateTime date): base(name, dataNumber, date)
    {
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

}