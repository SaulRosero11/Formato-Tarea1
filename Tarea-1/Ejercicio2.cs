using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class Ejercicio2
{
  public static void Menu()
  {
    // Variable para controlar el ciclo del menu
    bool start = true;

    while (start)
    {
      Console.Clear();
      Console.WriteLine("Menu 'Ejercicio 2'");
      Console.WriteLine("1. Ingresar una palabra para invertir los caracteres");
      Console.WriteLine("0. Regresar al menu principal");
      Console.WriteLine("Selecciona una opción:");

      string option = Console.ReadLine() ?? "";

      switch (option)
      {
        case "1":
          // Llamamos al metodo privado Ejecutar
          Execute();
          Console.WriteLine("Presiona [Enter] para continuar.");
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

  private static void Execute() {

    // Inciamos las variables
    int counter = 0;
    string word = "";
    string invertedWord;

    // Ingresamos un caracter y validamos hasta que ingrese un caracter valido al menos 2 caracteres para ver la funcionalidad
    while(word.Length < 2) {
      Console.Clear();
      if(counter > 0) {
        Console.WriteLine("Ingresa una palabra valida, debe tener al menos 2 caracteres:");
      } else {
        Console.WriteLine("Ingresa una frase:");
      }

      word = Console.ReadLine() ?? "";
      counter ++;
    }

    try {

      // Ejecucion de funcion para invertir la palabra
      invertedWord = InvestWord(word);

      // Imprimimos el resultado
      Console.Clear();
      Console.WriteLine($"Palabra ingresada: {word}");
      Console.WriteLine($"Palabra invertida: {invertedWord}");

    } catch (Exception ex)
    {
      Console.WriteLine($"Error : {ex.Message}");
    }
  }

  private static string InvestWord(string word){
    
    // Convertimos la palabra en un arrego de caracteres
    char[] arrayWord = word.ToCharArray();
    // Usamos el array reverse para revertir el arreglo y conseguir el efecto de invertir la palabra
    Array.Reverse(arrayWord);

    // Guardamos en un string el arreglo
    string result = new string(arrayWord);

    return result;
  }

}