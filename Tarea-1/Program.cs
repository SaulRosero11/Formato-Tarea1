using System;

class Program
{
  static void Main()
  {
    // Variable para controlar el ciclo del menu
    bool start = true;

    while (start)
    {
      Console.Clear();
      Console.WriteLine("Menu Principal 'TAREA 1'");
      Console.WriteLine("1. Ejercicio 1");
      Console.WriteLine("2. Ejercicio 2");
      Console.WriteLine("0. Salir");
      Console.WriteLine("Selecciona una opción:");

      // Leer la opción del usuario
      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
          // Ejecutamos el Ejercicio1
          /*
          En un archivo tenemos las notas de un grupo de alumnos de una clase con valores Nota(1), Nota(2), ..., Nota(n – 1), establecidas entre 0 y 10.
          El último dato es un dato con valor – 50. El número de notas que contiene el fichero no se conoce, pero se sabe que el mínimo número de alumnos
          en la clase es 1 y el máximo 100. Se desea crear un programa que determine la nota media.
          */
          Ejercicio1.Menu();
          break;
        case "2":
          // Ejecutamos el Ejercicio2
          /*
          Crea un programa en C que pida una cadena al usuario y muestre por pantalla la cadena invertida. Por ejemplo, si la cadena introducida es calor,
          deberá mostrarse por pantalla rolac. Si la cadena introducida es uisrael.edu.ec deberá mostrarse por pantalla ce.ude.learsiu
          */
          Ejercicio2.Menu();
          break;
        case "0":
          // Finalizamos el programa y salimos del ciclo del menu
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