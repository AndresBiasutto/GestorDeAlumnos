using System;
using System.Collections.Generic;
using System.Linq;
using tupacAlumnos.DB;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

namespace tupacAlumnos.academicGestor
{
    public class InscriptionGestor
    {
        private DBAlumno Students { get; set; }
        private DBCourse Courses { get; set; }
        private DBForms InscriptionForms { get; set; }
        public InscriptionGestor(DBAlumno students, DBCourse courses, DBForms forms)
        {
            Students = students;
            Courses = courses;
            InscriptionForms = forms;
        }
        public List<InscriptionForm> GetAllForms()
        {
            return InscriptionForms.GetAll();
        }
        public List<Course> GetAllCourses()
        {
            return Courses.GetAll();
        }
        public Course GetCourseById(string id)
        {
            return Courses.FindById(id);
        }
        public List<Alumno> GetAllStudents()
        {
            return Students.GetAll();
        }
        public Alumno GetStudentById(string id)
        {
            return Students.FindById(id);
        }
        public string EnrollStudent(string courseId, string studentId, Alumno student, Course course, DateTime date)
        {
            if (InscriptionForms.GetAll()
                .Any(f => f.GetCourseId() == courseId && f.GetStudentId() == studentId))
            {
                return $"{student.GetName()} ya está inscripto en {course.GetName()}";
            }
            InscriptionForm newForm = new InscriptionForm(courseId, studentId, student, course, date);
            InscriptionForms.Save(newForm);
            return $"{student.GetName()} fue inscripto correctamente en {course.GetName()}";
        }
        public List<Alumno> GetStudentsEnrolledInCourse(string id)
        {
            List<Alumno> students = InscriptionForms.GetAll()
                .Where(f => f.GetCourseId() == id)
                .Select(f => f.GetStudent())
                .ToList();
            return students;
        }
        public List<Course> GetCoursesOfAStudent(string id)
        {
            List<Course> courses = InscriptionForms.GetAll()
                .Where(f => f.GetStudentId() == id)
                .Select(f => f.GetCourse())
                .ToList();
            return courses;
        }
        public string GetEnrollmentDate(string courseId, string studentId)
        {
            InscriptionForm form = InscriptionForms.GetAll()
                .FirstOrDefault(f => f.GetCourseId() == courseId && f.GetStudentId() == studentId);
            if (form != null)
            {
                return form.GetInscriptionDate().ToString("dd/MM/yyyy");
            }
            return "No inscrito";
        }
        public string CancelEnrollment(string courseId, string studentId)
        {
            InscriptionForm form = InscriptionForms.GetAll()
                .FirstOrDefault(f => f.GetCourseId() == courseId && f.GetStudentId() == studentId);
            if (form != null)
            {
                InscriptionForms.Delete(form.GetId());
                return "Inscripción cancelada con éxito";
            }
            return "No se encontró la inscripción para cancelar";
        }
    }
}
