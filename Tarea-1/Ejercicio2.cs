using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class Ejercicio2
{
  public static void Menu()
  {
    bool start = true;

    while (start)
    {
      Console.Clear();
      Console.WriteLine("Menu 'Ejercicio 2'");
      Console.WriteLine("1. Ingresar texto");
      Console.WriteLine("0. Regresar al menu principal");
      Console.WriteLine("Selecciona una opción:");

      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
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
}