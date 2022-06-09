using System;

public class Program
{
     static void ChangeValue(object x)
     {
          x = 200;

          Console.WriteLine(x);
     }

     public static void Main()
     {
          object o = 20;
          // Show value before
          Console.WriteLine(o);
          // Pass variable to function call func without ref/out
          ChangeValue(o);
          // Show value after call func without ref/out
          Console.WriteLine(o);
          // Pass variable to function call func with ref/out
          ChangeValue(o);
          // Show value after call func with ref/out
          Console.WriteLine(o);

          Console.WriteLine("---------------------------------");

          // ? Write a program to show the name of each printer.
          var printers = new[] { new CanonPrinter(), new CanonPrinterV1(), new CanonPrinterV2() };

          foreach (var printer in printers)
          {
               printer.GetName();
          }

          Console.WriteLine("---------------------------------");

          // ? Create an instance of CanonPrinterV1, cast and assign to CanonPrinter. What will GetName() returns;
          CanonPrinterV1 canonV1 = new CanonPrinterV1();
          CanonPrinter canonPrinter = (CanonPrinter)canonV1;
          canonV1.GetName();
          canonPrinter.GetName();

          Console.WriteLine("---------------------------------");

          // ? Create a folder with 10 sub folders with name from folder_1 to folder_2
          const string SOURCE_FOLDER = "./folder";
          const int NUMBER_OF_SUB_FOLDER = 10;
          const int MAX_RANDOM_AMOUNT_OF_FILE = 10;
          Random randomNumber = new Random();

          // create directory if not exists
          if (!Directory.Exists(SOURCE_FOLDER)) Directory.CreateDirectory("folder");

          for (int i = 1; i <= NUMBER_OF_SUB_FOLDER; i++)
          {
               string TARGET_FOLDER = SOURCE_FOLDER + "/folder_" + i;

               // Re create sub directory
               if (Directory.Exists(TARGET_FOLDER)) Directory.Delete(TARGET_FOLDER, true);
               Directory.CreateDirectory(TARGET_FOLDER);

               // ? In each folder, create random amount of files with max = 10. Using Random class.
               // Random Amount Of file in folder anf create files with MAX = 10
               int randomAmountOfFile = randomNumber.Next(MAX_RANDOM_AMOUNT_OF_FILE) + 1;
               for (int fileIndex = 0; fileIndex < randomAmountOfFile; fileIndex++)
               {
                    File.Create(TARGET_FOLDER + "/" + fileIndex).Dispose();
               }
          }

          Console.WriteLine("Folder generated");
          Console.WriteLine("---------------------------------");

          // ? Writer a program give a number and device that number with 0 and catch the exception and show that exception in console.
          int ten = 10;

          try
          {
               int tenDivideZero = ten / 0;
          }
          catch (System.DivideByZeroException)
          {
               Console.WriteLine("Cannot divide by zero");
               // throw;
          }

          Console.WriteLine("---------------------------------");

          // ? Create a program that performs 2 unit of work:
          ThreadExercise.start();

          // ? As same as Thread but using task.
          TaskExercise.start();
     }
}