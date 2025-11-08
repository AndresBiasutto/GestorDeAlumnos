using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.DB;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor
{
    public class InscriptionGestor
    {
        public DBAlumno Students { get; set; }
        public DBCourse Courses { get; set; }
        public DBForms Forms { get; set; }
        public InscriptionGestor(DBAlumno students, DBCourse courses, DBForms forms)
        {
            Students = students;
            Courses = courses;
            Forms = forms;
        }
        public string EnrolStudentInCourse(Course course, Alumno student)
        {
            string courseId = course.GetId();
            string studentId = student.GetId();

            bool alreadyEnrolled = Forms.GetAll()
                .Any(f => f.StudentId == studentId && f.CourseId == courseId && f.Active);

            if (alreadyEnrolled)
                return $"{student.GetName()} ya está inscripto en {course.GetName()}";

            Form newForm = new Form(studentId, courseId);
            Forms.Save(newForm);
            return $"{student.GetName()} fue inscripto correctamente en {course.GetName()}";
        }
        public string UnsubscribeStudentfromCourse(Course course, Alumno student)
        {
            string courseId = course.GetId();
            string studentId = student.GetId();

            var form = Forms.GetAll()
                .FirstOrDefault(f => f.StudentId == studentId && f.CourseId == courseId && f.Active);

            if (form == null)
                return $"El alumno {student.GetName()} no está inscripto en {course.GetName()}";

            form.Cancel();
            return $"{student.GetName()} fue dado de baja del curso {course.GetName()}";
        }
        public List<Alumno> GetEnrolledStudentsInACourse(Course course)
        {
            string courseId = course.GetId();

            var enrolledForms = Forms.GetAll()
                .Where(f => f.CourseId == courseId && f.Active)
                .ToList();

            var students = new List<Alumno>();

            foreach (var form in enrolledForms)
            {
                var student = Students.GetAll()
                    .FirstOrDefault(s => s.GetId() == form.StudentId);
                if (student != null)
                    students.Add(student);
            }

            return students;
        }
        public List<Course> GetCoursesOfAStudent(Alumno student)
        {
            string studentId = student.GetId();

            var enrolledForms = Forms.GetAll()
                .Where(f => f.StudentId == studentId && f.Active)
                .ToList();

            var courses = new List<Course>();

            foreach (var form in enrolledForms)
            {
                var course = Courses.GetAll()
                    .FirstOrDefault(c => c.GetId() == form.CourseId);
                if (course != null)
                    courses.Add(course);
            }

            return courses;
        }
    }
}
