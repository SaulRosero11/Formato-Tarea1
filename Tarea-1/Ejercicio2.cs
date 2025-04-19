using System; // Proporciona funcionalidades básicas como manejo de consola, excepciones, etc.

// Clase estática principal que contiene el menú y la lógica para invertir palabras
public static class Ejercicio2
{
  // Método principal que muestra el menú de opciones del ejercicio 2
  public static void Menu()
  {
    bool start = true; // Controla la ejecución del menú

    // Ciclo que mantiene el menú activo hasta que el usuario elija salir
    while (start)
    {
      Console.Clear(); // Limpia la consola
      Console.WriteLine("Menu 'Ejercicio 2'");
      Console.WriteLine("1. Ingresar una palabra para invertir los caracteres");
      Console.WriteLine("0. Regresar al menu principal");
      Console.WriteLine("Selecciona una opción:");

      // Captura la opción del usuario
      string option = Console.ReadLine() ?? "";

      // Evalúa la opción ingresada
      switch (option)
      {
        case "1":
          // Ejecuta la funcionalidad principal del ejercicio
          Execute();
          Console.WriteLine("Presiona [Enter] para continuar.");
          Console.ReadLine(); // Espera una tecla para continuar
          break;

        case "0":
          // Finaliza el menú
          start = false;
          break;

        default:
          // Opción no válida
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
      }
    }
  }

  // Método que ejecuta la lógica de inversión de palabras
  private static void Execute()
  {
    int counter = 0; // Contador para saber si ya se pidió reintento
    string word = ""; // Palabra ingresada por el usuario
    string invertedWord; // Palabra invertida

    // Bucle que asegura que la palabra tenga al menos 2 caracteres
    while (word.Length < 2)
    {
      Console.Clear(); // Limpia la consola

      // Muestra diferentes mensajes dependiendo si ya hubo un intento fallido
      if (counter > 0)
      {
        Console.WriteLine("Ingresa una palabra válida, debe tener al menos 2 caracteres:");
      }
      else
      {
        Console.WriteLine("Ingresa una palabra:");
      }

      // Captura la palabra del usuario
      word = Console.ReadLine() ?? "";
      counter++; // Incrementa el contador de intentos
    }

    try
    {
      // Llama al método que invierte la palabra
      invertedWord = InvestWord(word);

      // Muestra resultados
      Console.Clear();
      Console.WriteLine($"Palabra ingresada: {word}");
      Console.WriteLine($"Palabra invertida: {invertedWord}");
    }
    catch (Exception ex)
    {
      // Captura cualquier error inesperado
      Console.WriteLine($"Error : {ex.Message}");
    }
  }

  // Método que invierte una palabra
  private static string InvestWord(string word)
  {
    // Convierte la palabra en un arreglo de caracteres
    char[] arrayWord = word.ToCharArray();

    // Invierte el orden de los caracteres en el arreglo
    Array.Reverse(arrayWord);

    // Crea una nueva cadena a partir del arreglo invertido
    string result = new string(arrayWord);

    // Retorna la palabra invertida
    return result;
  }
}
