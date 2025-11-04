// File: utils/FormValidator.cs
using System;
using System.Globalization;

namespace tupacAlumnos.utils
{
    public static class Validations
    {
        public static int ValidateInt(string input, string fieldName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException($"{fieldName} no puede estar vacío.");
                if (!int.TryParse(input, out int result))
                    throw new ArgumentException($"{fieldName} inválido. Ingresá solo números.");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el campo '{fieldName}': {ex.Message}");
            }
        }

        public static DateTime ValidateDate(string input, string fieldName, string format)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException($"{fieldName} no puede estar vacío.");
                if (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    throw new ArgumentException($"Formato inválido para {fieldName}. Usa el formato {format}.");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el campo '{fieldName}': {ex.Message}");
            }
        }

        public static string ValidateNotEmpty(string input, string fieldName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException($"{fieldName} no puede estar vacío.");
                return input.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el campo '{fieldName}': {ex.Message}");
            }
        }

        public static int ValidateIntRange(int value, int min, int max, string fieldName)
        {
            try
            {
                if (value < min || value > max)
                    throw new ArgumentOutOfRangeException(fieldName, $"{fieldName} debe estar entre {min} y {max}.");
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el rango de '{fieldName}': {ex.Message}");
            }
        }

        public static DateTime ValidateDateRange(DateTime value, DateTime min, DateTime max, string fieldName)
        {
            try
            {
                if (value < min || value > max)
                    throw new ArgumentOutOfRangeException(fieldName, $"{fieldName} debe estar entre {min:dd/MM/yyyy} y {max:dd/MM/yyyy}.");
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el rango de '{fieldName}': {ex.Message}");
            }
        }
    }
}
