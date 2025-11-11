using System;
using tupacAlumnos.interfaces;

namespace tupacAlumnos;

public class Entity : IEntity
{
    protected static int lastId = 0;
    protected int Id { get; set; }
    protected string Name { get; set; }
    protected int DataNumber { get; set; }
    protected DateTime Date { get; set; }
    public Entity(string name, int dataNumber, DateTime date)
    {
        Id = ++lastId;
        Name = name;
        DataNumber = dataNumber;
        Date = date;
    }
    public string GetId()
    {
        return $"{Id.ToString()}";
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