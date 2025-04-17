using System;

class Program
{
  static void Main()
  {
    bool start = true;

    while (start)
    {
      Console.Clear();
      Console.WriteLine("Menu Principal 'TAREA 1'");
      Console.WriteLine("1. Ejercicio 1");
      Console.WriteLine("2. Ejercicio 2");
      Console.WriteLine("0. Salir");
      Console.WriteLine("Selecciona una opción:");

      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
          Ejercicio1.Menu();
          break;
        case "2":
          Ejercicio2.Menu();
          break;
        case "0":
          start = false;
          break;
        default:
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
      }
    }

    Console.Clear();
    Console.WriteLine("Muchas gracias por usar el programa");
    Console.WriteLine("-----------UISRAEL-----------");
    Console.WriteLine("1. Steven Castillo");
    Console.WriteLine("2. Anthony Rosero");

  }
}