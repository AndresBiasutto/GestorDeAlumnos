using System.Collections.Generic;
using tupacAlumnos.entity;

namespace tupacAlumnos.DB;

public class DBForms : IDataBase<Form>
{
    public List<Form> Forms { get; private set; }
    public DBForms()
    {
        Forms = new List<Form>();
    }
    public void Save(Form form)
    {
        try
        {
            Forms.Add(form);
        }
        catch (System.Exception)
        {
            throw new System.Exception($"No se pudo guardar el formulario");
        }
    }
    public List<Form> GetAll()
    {
        try
        {
            return Forms;
        }
        catch (System.Exception)
        {

            throw new System.Exception($"Sin respuesta");
        }
    }
    public Form FindById(string id)
    {
        try
        {
           return Forms.Find(form => form.GetId() == id);
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
            Forms.Remove(FindById(id));
        }
        catch (System.Exception)
        {

            throw new System.Exception($"id:{id} sin respuesta");
        }
    }
    public void Update(Form item)
    {
        throw new System.NotImplementedException();
    }
}