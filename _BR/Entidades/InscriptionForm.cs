// File: entity/Form.cs
using System;
using System.Collections.Generic;
using TupacAlumnos.entity;

namespace tupacAlumnos.entity;

public class InscriptionForm
{
    protected static int lastId = 0;
    protected int Id { get; set; }
    private string CourseId { get; set; }
    private string StudentId { get; set; }
    private Alumno Student { get; set; }
    private Course Course { get; set; }
    private DateTime InscriptionDate { get; set; }

    public InscriptionForm(string courseId, string studentId, Alumno student, Course course, DateTime date)
    {
        Id = ++lastId;
        CourseId = courseId;
        StudentId = studentId;
        Student = student;
        Course = course;
        InscriptionDate = date;
    }

    public string GetId()
    {
        return $"{Id}";
    }

    public string GetCourseId()
    {
        return $"{CourseId}";
    }
    public string GetCourseName()
    {
        return $"{Course.GetName()}";
    }
    public string GetStudentId()
    {
        return $"{StudentId}";
    }
    public DateTime GetInscriptionDate()
    {
        return InscriptionDate;
    }
    public Alumno GetStudent()
    {
        return Student;
    }
    public Course GetCourse()
    {
        return Course;
    }
    // public string EnrollStudent(string studentId)
    // {
    //     try
    //     {
    //         EnroledStudentsIds.Add(studentId);
    //         return "estudiante inscripto con éxito";
    //     }
    //     catch (Exception)
    //     {
    //         throw new Exception($"No se pudo inscribir al estudiante con el id {studentId} - ");
    //     }
    // }
    // public List<string> GetEnroledStudentsIds()
    // {
    //     return EnroledStudentsIds;
    // }
}
