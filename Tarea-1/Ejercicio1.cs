using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class Ejercicio1
{
  // Submenu del ejercicio 1 para poder ejecutar varias veces el mismo ejercicio
  public static void Menu()
  {
    // Variable para controlar el ciclo del menu
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
          // Llamamos al metodo privado Ejecutar
          Ejecutar();
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
        case "0":
          // Finalizamos el ciclo y regresamos al menu principal
          start = false;
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
    // Declaracion de variables
    List<double> qualifications = new List<double>();
    double qualification;
    int maxStudents = 100;
    List<string> listError = new List<string>();

    Console.Clear();
    Console.Write("Ingresa la ruta completa del archivo:");
    // Captura la ruta del archivo
    string filePath = Console.ReadLine() ?? "";

    // Validamos que el archivo exista
    if (!File.Exists(filePath))
    {
      Console.WriteLine("El archivo no existe. verifica la ruta ingresada e intenalo de nuevo.");
      return;
    }

    try
    {
      // Extraemos la informacion del documento
      string content = File.ReadAllText(filePath);
      // Extraemos y generamos un arreglo con la información de las calficaciones
      string[] values = content.Split(',');

      // Validamos que la menos tenga 1 alumno para calcular el promedio
      if (values[0] == "")
      {
        Console.WriteLine("Ingresa al menos una calificación para poder calcular el promedio.");
        return;
      }

      // Recorremos el arreglo para validar cada numero y ver si cumple con los parametros
      foreach (string value in values)
      {
        // Convertimos cada valor a numero
        if (!double.TryParse(value.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out qualification))
        {
          listError.Add($"Valor no válido: '{value}'");
        }

        // Validacion de que termina en -50 ya que es el ultimo numero
        if (qualification == -50)
          break;

        if (qualification < 0 || qualification > 10)
        {
          listError.Add($"Nota fuera de rango (0-10): {qualification}");
        }

        qualifications.Add(qualification);

        if (qualifications.Count > maxStudents)
        {
          listError.Add($"Se ha superado el número máximo de alumnos permitido (100). (Separe el documento)");
          break;
        }
      }

      // Mostramos todos los errores que se encontraron en temas de validacion de calificaciones
      if (listError.Count > 0)
      {
        foreach (var e in listError)
        {
          Console.WriteLine(e);
        }
        Console.WriteLine("Revisa el documento y vuelve a intentarlo.");
        return;
      }

      MostrarPromedio(qualifications); // Calculamos y mostramos el promedio

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