using System;
using System.Collections.Generic;

namespace tupacAlumnos.interfaces;

public interface IGestor<T>
{
    // List<T> Items {get; set;}
    string Create(string name, int dataNumber, DateTime date);
    List<T> GetAll();
    T GetById(string unicNumber);
    string Update(string unicNumber, string newName, int newDataNumber, DateTime newDate);
    string Delete(string unicNumber);
}