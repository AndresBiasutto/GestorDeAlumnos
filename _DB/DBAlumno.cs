using System.Collections.Generic;
using tupacAlumnos.entity;

namespace tupacAlumnos.DB;

public class DBAlumno : IDataBase<Alumno>
{
    public List<Alumno> Alumnos { get; private set; }

    public DBAlumno()
    {
        Alumnos = new List<Alumno>();
    }
       public void Save(Alumno form)
    {
        try
        {
            Alumnos.Add(form);
        }
        catch (System.Exception)
        {
            throw new System.Exception($"No se pudo guardar el formulario");
        }
    }
    public List<Alumno> GetAll()
    {
        try
        {
            return Alumnos;
        }
        catch (System.Exception)
        {

            throw new System.Exception($"Sin respuesta");
        }
    }
    public Alumno FindById(string id)
    {
        try
        {
           return Alumnos.Find(form => form.GetId() == id);
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
            Alumnos.RemoveAll( form => form.GetId() == id);
        }
        catch (System.Exception)
        {

            throw new System.Exception($"id:{id} sin respuesta");
        }
    }
    public void Update(Alumno item)
    {
        throw new System.NotImplementedException();
    }
}