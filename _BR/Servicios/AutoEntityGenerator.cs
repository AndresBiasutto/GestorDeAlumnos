using System;
using tupacAlumnos.DB;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

public static class AutoEntityGenerator
{
    public static void CreateCourses(DBCourse dbCourse)
    {
        if (dbCourse.GetAll().Count > 0) return;

        var courses = new[]
        {
                new Course("Algoritmos y estructura de datos", 6, DateTime.Now.AddYears(-1)),
                new Course("Sistemas y organizaciones", 6, DateTime.Now.AddYears(-1)),
                new Course("Aljebra ", 6, DateTime.Now.AddYears(-1)),
                new Course("Analisis matematico", 6, DateTime.Now.AddYears(-1)),
                new Course("Física General", 6, DateTime.Now.AddYears(-1))
            };

        foreach (var c in courses)
            dbCourse.Save(c);
    }
    public static void CreateStudents(DBAlumno dbAlumno)
    {
        if (dbAlumno.GetAll().Count > 0) return;

        var students = new[]
        {
                new Alumno("Torres Ana", 31221001, new DateTime(2001, 5, 10)),
                new Alumno("Pérez Luis ", 31221002, new DateTime(2000, 8, 3)),
                new Alumno("Gómez Sofía ", 31221003, new DateTime(2002, 11, 15)),
                new Alumno("Silva Martín", 31221004, new DateTime(1999, 2, 28)),
                new Alumno("Domínguez Carla", 31221005, new DateTime(2001, 9, 20)),
                new Alumno("Morales Javier", 31221006, new DateTime(2000, 1, 12)),
                new Alumno("Fernández Lucía", 31221007, new DateTime(2003, 3, 8)),
                new Alumno("RamosDiego", 31221008, new DateTime(2002, 6, 30)),
                new Alumno("López María", 31221009, new DateTime(2001, 4, 22)),
                new Alumno("García Pedro", 31221010, new DateTime(1999, 12, 5))
            };

        foreach (var s in students)
            dbAlumno.Save(s);
    }
}