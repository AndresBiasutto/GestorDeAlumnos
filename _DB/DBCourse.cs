using System.Collections.Generic;
using tupacAlumnos.entity;
using TupacAlumnos.entity;

namespace tupacAlumnos.DB;

public class DBCourse : IDataBase<Course>
{
    public List<Course> Courses { get; private set; }

    public DBCourse()
    {
        Courses = new List<Course>();
    }
      public void Save(Course form)
    {
        try
        {
            Courses.Add(form);
        }
        catch (System.Exception)
        {
            throw new System.Exception($"No se pudo guardar el formulario");
        }
    }
    public List<Course> GetAll()
    {
        try
        {
            return Courses;
        }
        catch (System.Exception)
        {

            throw new System.Exception($"Sin respuesta");
        }
    }
    public Course FindById(string id)
    {
        try
        {
          return  Courses.Find(form => form.GetId() == id);
        }
        catch (System.Exception)
        {

            throw new System.Exception($"id:{id} sin respuesta");
        }
    }
    public void Delete(string id)
    {
        try
        {
            Courses.Remove(FindById(id));
        }
        catch (System.Exception)
        {

            throw new System.Exception($"id:{id} sin respuesta");
        }
    }
    public void Update(Course item)
    {
        throw new System.NotImplementedException();
    }
}