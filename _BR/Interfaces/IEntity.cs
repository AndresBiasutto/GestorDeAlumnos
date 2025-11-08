using System;

namespace tupacAlumnos.interfaces;

public interface IEntity
{
    string GetId();
    string GetName();
    string GetDataNumber();
    string GetDate();
}