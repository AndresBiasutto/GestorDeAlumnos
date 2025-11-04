using System;
using tupacAlumnos.interfaces;

namespace tupacAlumnos;

public class Entity : IEntity
{
    protected static int lastUnicNumber = 0;
    protected int UnicNumber { get; set; }
    protected string Name { get; set; }
    protected int DataNumber { get; set; }
    protected DateTime Date { get; set; }
    public Entity(string name, int dataNumber, DateTime date)
    {
        UnicNumber = ++lastUnicNumber;
        Name = name;
        DataNumber = dataNumber;
        Date = date;
    }
    public string GetUnicNumber()
    {
        return $"{UnicNumber.ToString()}";
    }
        public string GetName()
    {
        return $"{Name}";
    }
    public string GetDataNumber()
    {
        return $"{DataNumber.ToString()}";
    }
    public string GetDate()
    {
        return $"{Date.ToString("dd/MM/yyyy")}";
    }
}