using System;

namespace tupacAlumnos.interfaces;

public interface IEntity
{
    string GetUnicNumber();
    string GetName();
    string GetDataNumber();
    string GetDate();
}