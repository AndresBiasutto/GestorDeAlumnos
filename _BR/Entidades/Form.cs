// File: entity/Form.cs
using System;

namespace tupacAlumnos.entity;

public class Form
{
    private static int lastId = 0;
    public int Id { get; private set; }
    public string StudentId { get; private set; }
    public string CourseId { get; private set; }
    public DateTime InscriptionDate { get; private set; }
    public bool Active { get; private set; }

    public Form(string studentId, string courseId)
    {
        Id = ++lastId;
        StudentId = studentId;
        CourseId = courseId;
        InscriptionDate = DateTime.Now;
        Active = true;
    }

    public void Cancel()
    {
        Active = false;
    }
    public string GetId()
    {
        return $"{Id.ToString()}";
    }
}
