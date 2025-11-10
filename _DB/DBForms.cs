using System.Collections.Generic;
using tupacAlumnos.entity;

namespace tupacAlumnos.DB;

public class DBForms : IDataBase<InscriptionForm>
{
    public List<InscriptionForm> InscriptionForms { get; private set; }
    public DBForms()
    {
        InscriptionForms = new List<InscriptionForm>();
    }
    public void Save(InscriptionForm form)
    {
        try
        {
            InscriptionForms.Add(form);
        }
        catch (System.Exception)
        {
            throw new System.Exception($"No se pudo guardar el formulario");
        }
    }
    public List<InscriptionForm> GetAll()
    {
        try
        {
            return InscriptionForms;
        }
        catch (System.Exception)
        {

            throw new System.Exception($"Sin respuesta");
        }
    }
    public InscriptionForm FindById(string id)
    {
        try
        {
           return InscriptionForms.Find(form => form.GetId() == id);
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
            InscriptionForms.Remove(FindById(id));
        }
        catch (System.Exception)
        {

            throw new System.Exception($"id:{id} sin respuesta");
        }
    }
    public void Update(InscriptionForm item)
    {
        throw new System.NotImplementedException();
    }
}