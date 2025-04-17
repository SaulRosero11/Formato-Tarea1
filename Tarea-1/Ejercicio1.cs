using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class Ejercicio1
{
  public static void Menu()
  {
    bool start = true;

    while (start)
    {
      Console.Clear();
      Console.WriteLine("Menu 'Ejercicio 1'");
      Console.WriteLine("1. Ingresar dirección del documento.");
      Console.WriteLine("0. Regresar al menu principal");
      Console.WriteLine("Selecciona una opción:");

      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
          Ejecutar();
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
        case "0":
          break;
        default:
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
      }
    }
  }

  private static void Ejecutar()
  {
    Console.Clear();
    Console.Write("Ingresa la ruta completa del archivo:");
    string filePath = Console.ReadLine() ?? "";

    List<double> qualifications = new List<double>();
    double qualification;
    int maxStudents = 100;
    List<string> listError = new List<string>();

    if (!File.Exists(filePath))
    {
      Console.WriteLine("el archivo no existe. verifica la ruta ingresada e intenalo de nuevo.");
      return;
    }

    try
    {
      using (StreamReader sr = new StreamReader(filePath))
      {
        string line;
        while ((line = sr.ReadLine() ?? "") != null)
        {
          if (!double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture, out qualification))
          {
            listError.Add($"Línea inválida: '{line}' no es número válido.");
          }

          if (qualification == -50)
            break;

          if (qualification < 0 || qualification > 10)
          {
            listError.Add($"Nota fuera de rango (0-10): {qualification}");
            break;
          }

          qualifications.Add(qualification);

          if (qualifications.Count > maxStudents)
          {
            listError.Add($"Se ha superado el número máximo de alumnos permitido (100). (Separe el documento)");
            break;
          }
        }
      }

      if (listError.Count > 0)
      {
        foreach (var e in listError)
        {
          Console.WriteLine(e);
        }
        Console.WriteLine("Revisa el documento y vuelve a intentarlo.");
        return;
      }

      MostrarPromedio(qualifications);

    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error : {ex.Message}");
    }
  }

  private static void MostrarPromedio(List<double> qualifications)
  {
    if (qualifications.Count == 0)
    {
      Console.WriteLine("No se ingresaron notas válidas.");
      return;
    }

    double suma = 0;
    foreach (var n in qualifications)
      suma += n;

    double media = suma / qualifications.Count;
    Console.WriteLine($"El promedio es: {media:F2}");
  }
}