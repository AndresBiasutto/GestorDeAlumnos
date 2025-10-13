using System;
using System.Collections.Generic;
using System.Linq;
using TupacAlumnos;

namespace tupacAlumnos;

public class GestorAcademico
{
    private List<Alumno> Students { get; set; } = new List<Alumno>();
    private List<Course> Courses { get; set; } = new List<Course>();
    public string EnrollStudent(string names, string lastName, int dNI, DateTime birthdate)
    {
        Alumno newStudent = new Alumno(names, lastName, dNI, birthdate);
        Students.Add(newStudent);
        return $"{newStudent.GetName()} fue agregado correctamente";
    }
    public List<Alumno> GetAllStudents()
    {
        List<Alumno> orderedStudents = Students.OrderBy(s => s.GetName()).ToList();
        return orderedStudents;
    }
    public Alumno GetStudentByUnicNumber(string unicNumber)
    {
        Alumno student = Students.FirstOrDefault(s => s.GetUnicNumber() == unicNumber);
        return student;
    }
    public string DeleteStudent(string unicNumber)
    {
        if (Students.Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetStudentByUnicNumber(unicNumber);

        if (student != null)
        {
            string studentName = student.GetName();
            Students.Remove(student);
            return $"{studentName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun alumno con la matricula {unicNumber}";
        }
    }
    public string UpdateStudent(string unicNumber, string newName, string newLastName, int newDni, DateTime newBirthDate)
    {
        if (Students.Count() == 0)
        {
            return "Aun no hay alumnos registrados";
        }
        Alumno student = GetStudentByUnicNumber(unicNumber);
        if (student != null)
        {
            student.Update(newName, newLastName, newDni, newBirthDate);
            return $"Datos de {newName} {newLastName} actualizados";

        }
        else
        {
            return $"{unicNumber} no existe en el sistema";
        }
    }
    public string CreateCourse(string name, int maxStudents, DateTime SchoolYear)
    {
        Course NewCourse = new Course(name, maxStudents, SchoolYear);
        Courses.Add(NewCourse);
        return $"{NewCourse.GetName()} fue creado correctamente";
    }
    public List<Course> GetAllCourses()
    {
        List<Course> orderedCourses = Courses.OrderBy(s => s.GetName()).ToList();
        return orderedCourses;
    }
    public Course GetCourseByUnicNumber(string unicNumber)
    {
        Course course = Courses.FirstOrDefault(s => s.GetUnicNumber() == unicNumber);
        return course;
    }
    public string DeleteCourse(string unicNumber)
    {
        if (Courses.Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetCourseByUnicNumber(unicNumber);

        if (course != null)
        {
            string courseName = course.GetName();
            Courses.Remove(course);
            return $"El curso de {courseName} fue eliminado del sistema";

        }
        else
        {
            return $"No hay ningun curso con la matricula {unicNumber}";
        }
    }
    public string UpdateCourse(string unicNumber, string newName, int newMaxCourses, DateTime newSchoolYear)
    {
        if (Courses.Count() == 0)
        {
            return "Aun no hay cursos registrados";
        }
        Course course = GetCourseByUnicNumber(unicNumber);
        if (course != null)
        {
            course.Update(newName, newMaxCourses, newSchoolYear);
            return $"Datos del curso de {newName} actualizados";

        }
        else
        {
            return $"El curso con la matricula {unicNumber} no existe en el sistema";
        }
    }
    public string EnrollStudentInCourse(Course course, Alumno student)
    {
        List<string> enroledSt = course.GetEnrolledStudents();
        string studentUnicNumber = student.GetUnicNumber();
        string courseUnicNumber = course.GetUnicNumber();
        for (int i = 0; i < enroledSt.Count; i++)
        {
            if (enroledSt[i] == studentUnicNumber)
            {
                return $"{studentUnicNumber} ya esta inscripto";
            }
        }
        if (int.Parse(course.GetDataNumber()) <= course.GetEnrolledStudents().Count())
        {
            return $"cupo máximo superado para {course.GetName()}";
        }
        return $"{student.AddCourse(courseUnicNumber)} fue inscripto en {course.AddStudent(studentUnicNumber)}";
    }
    public string UnsubscribeStudentfromCourse(Course course, Alumno student)
    {
        List<string> enroledSt = course.GetEnrolledStudents();
        string studentUnicNumber = student.GetUnicNumber();
        string courseUnicNumber = course.GetUnicNumber();
        for (int i = 0; i < enroledSt.Count; i++)
        {
            if (enroledSt[i] == studentUnicNumber)
            {
                return $"{student.DeleteCourse(courseUnicNumber)} fue eliminado de {course.DeleteStudent(studentUnicNumber)}";
            }
        }
        return $"El alumno no esta inscripto en {course.GetName()}";
    }
    public List<Alumno> GetEnrolledStudentsInCourse(Course course)
    {
        List<string> StudentsIds = course.GetEnrolledStudents();
        List<Alumno> students = new List<Alumno>();
        for (int i = 0; i < StudentsIds.Count; i++)
        {
            for (int j = 0; j < Students.Count(); j++)
            {
                if (StudentsIds[i] == Students[j].GetUnicNumber())
                {
                    students.Add(Students[j]);
                }
            }
        }
        return students;
    }
    public List<Course> GetCoursesInStudent(Alumno student)
    {
        List<string> coursesIds = student.GetMyCourses();
        List<Course> courses = new List<Course>();
        for (int i = 0; i < coursesIds.Count; i++)
        {
            for (int j = 0; j < Courses.Count(); j++)
            {
                if (coursesIds[i] == Courses[j].GetUnicNumber())
                {
                    courses.Add(Courses[j]);
                }
            }
        }
        return courses;
    }
}