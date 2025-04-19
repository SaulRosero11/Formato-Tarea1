using System; // Importa funcionalidades básicas del sistema (consola, excepciones, etc.)
using System.Globalization; // Se utiliza para formateo y conversión cultural de números y fechas

// Clase estática principal del ejercicio
public static class Ejercicio1
{
  // Método que muestra el menú principal del ejercicio
  public static void Menu()
  {
    bool start = true; // Controla el ciclo del menú

    // Bucle que muestra el menú hasta que el usuario elija salir
    while (start)
    {
      Console.Clear(); // Limpia la consola
      Console.WriteLine("Menu 'Ejercicio 1'");
      Console.WriteLine("1. Ingresar dirección del documento.");
      Console.WriteLine("0. Regresar al menu principal");
      Console.WriteLine("Selecciona una opción:");

      // Lee la opción seleccionada por el usuario
      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
          // Llama al método que ejecuta la lógica de lectura y cálculo
          Execute();
          Console.WriteLine("Presiona [Enter] para continuar.");
          Console.ReadLine();
          break;

        case "0":
          // Finaliza el bucle y regresa al menú principal
          start = false;
          break;

        default:
          // Opción inválida
          Console.WriteLine("Opción no válida. Presiona [Enter] para intentar nuevamente.");
          Console.ReadLine();
          break;
      }
    }
  }

  // Método que ejecuta la lógica principal del ejercicio
  private static void Execute()
  {
    List<double> qualifications = new List<double>(); // Lista para almacenar calificaciones válidas
    double qualification; // Variable temporal para cada nota
    int maxStudents = 100; // Límite máximo de estudiantes
    List<string> listError = new List<string>(); // Lista para acumular errores

    Console.Clear(); // Limpia la consola
    Console.Write("Ingresa la ruta completa del archivo:");
    string filePath = Console.ReadLine() ?? ""; // Captura la ruta del archivo

    // Verifica si el archivo existe
    if (!File.Exists(filePath))
    {
      Console.WriteLine("El archivo no existe. verifica la ruta ingresada e intenalo de nuevo.");
      return;
    }

    try
    {
      // Lee todo el contenido del archivo como un solo string
      string content = File.ReadAllText(filePath);

      // Divide las calificaciones usando la coma como separador
      string[] values = content.Split(',');

      // Valida que al menos haya una calificación
      if (values[0] == "")
      {
        Console.WriteLine("Ingresa al menos una calificación para poder calcular el promedio.");
        return;
      }

      // Recorre cada valor para validarlo
      foreach (string value in values)
      {
        // Intenta convertir el valor a tipo double
        if (!double.TryParse(value.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out qualification))
        {
          listError.Add($"Valor no válido: '{value}'");
          continue; // Pasa al siguiente valor si hubo error de conversión
        }

        // Detiene la lectura si se encuentra el valor -50 (marcador de fin)
        if (qualification == -50)
          break;

        // Valida que la nota esté en el rango permitido (0 a 10)
        if (qualification < 0 || qualification > 10)
        {
          listError.Add($"Nota fuera de rango (0-10): {qualification}");
        }

        // Agrega la nota a la lista si es válida
        qualifications.Add(qualification);

        // Verifica si se supera el número máximo permitido de estudiantes
        if (qualifications.Count > maxStudents)
        {
          listError.Add("Se ha superado el número máximo de alumnos permitido (100). (Separe el documento)");
          break;
        }
      }

      // Si se encontraron errores, se muestran y termina la ejecución
      if (listError.Count > 0)
      {
        foreach (var e in listError)
        {
          Console.WriteLine(e);
        }
        Console.WriteLine("Revisa el documento y vuelve a intentarlo.");
        return;
      }

      // Llama al método que calcula y muestra el promedio
      ViewAverage(qualifications);
    }
    catch (Exception ex)
    {
      // Maneja errores inesperados (como errores de lectura)
      Console.WriteLine($"Error : {ex.Message}");
    }
  }

  // Método para calcular y mostrar el promedio de las calificaciones
  private static void ViewAverage(List<double> qualifications)
  {
    // Verifica si hay notas válidas
    if (qualifications.Count == 0)
    {
      Console.WriteLine("No se ingresaron notas válidas.");
      return;
    }

    // Calcula la suma total
    double sum = 0;
    foreach (var n in qualifications)
      sum += n;

    // Calcula el promedio
    double average = sum / qualifications.Count;

    // Muestra el promedio con dos decimales
    Console.WriteLine($"El promedio es: {average:F2}");
  }
}
