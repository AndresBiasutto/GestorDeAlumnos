using System;

namespace tupacAlumnos.entity;

public class Alumno : Entity
{
    public Alumno(string name, int dataNumber, DateTime date) : base(name, dataNumber, date)
    {
    }
    public Alumno Update(string unicNumber, string newName, int newDataNumber, DateTime newDate)
    {
        Name = newName;
        DataNumber = newDataNumber;
        Date = newDate;
        return this;
    }
}