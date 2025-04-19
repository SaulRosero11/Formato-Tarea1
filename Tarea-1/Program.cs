using System; // Importa funcionalidades básicas del sistema como entrada/salida de consola y control de flujo

// Clase principal que contiene el punto de entrada del programa
class Program
{
  // Método principal donde inicia la ejecución del programa
  static void Main()
  {
    bool start = true; // Controla si el menú principal sigue mostrándose

    // Bucle principal que muestra el menú mientras 'start' sea true
    while (start)
    {
      Console.Clear(); // Limpia la consola para una mejor visualización
      Console.WriteLine("Menu Principal 'TAREA 1'");
      Console.WriteLine("1. Ejercicio 1");
      Console.WriteLine("2. Ejercicio 2");
      Console.WriteLine("0. Salir");
      Console.WriteLine("Selecciona una opción:");

      // Lee la opción seleccionada por el usuario
      string option = Console.ReadLine() ?? "";

      // Controla el flujo según la opción elegida
      switch (option)
      {
        case "1":
          /*
          EJERCICIO 1:
          En un archivo de texto se encuentran las notas de un grupo de alumnos, separadas por comas.
          Las notas están entre 0 y 10, y el último valor es -50 para indicar el final.
          El objetivo es calcular la nota promedio del grupo.
          */
          Ejercicio1.Menu(); // Llama al menú del ejercicio 1
          break;

        case "2":
          /*
          EJERCICIO 2:
          Solicita al usuario una palabra o frase, y muestra la misma invertida.
          Ejemplo: "calor" → "rolac"
          Ejemplo: "uisrael.edu.ec" → "ce.ude.learsiu"
          */
          Ejercicio2.Menu(); // Llama al menú del ejercicio 2
          break;

        case "0":
          // Finaliza el ciclo y cierra el programa
          start = false;
          break;

        default:
          // Opción no válida
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine(); // Espera que el usuario presione Enter para continuar
          break;
      }
    }

    // Mensaje de despedida al cerrar el programa
    Console.Clear();
    Console.WriteLine("Muchas gracias por usar el programa");
    Console.WriteLine("-----------UISRAEL-----------");
    Console.WriteLine("1. Steven Castillo");
    Console.WriteLine("2. Anthony Rosero"); // Participantes del trabajo
  }
}
