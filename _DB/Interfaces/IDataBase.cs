using System.Collections.Generic;

namespace tupacAlumnos.DB;

public interface IDataBase<T>
{
    void Save(T item);
    List<T> GetAll();
    T FindById(string id);
    void Delete(string id);
    void Update(T item);

}