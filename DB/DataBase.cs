using System.Collections.Generic;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

namespace tupacAlumnos.DB;

public class DataBase
{
        public List<Alumno> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
}