public class ThreadExercise
{
     public static void start()
     {
          // 1 thread start to print odd number from 1 to 99
          Thread printOddNumberThread = new Thread(printOddNumber);
          printOddNumberThread.Start(20);

          // 1 thread start to print event number from 0 to 100
          Thread printEvenNumberThread = new Thread(printEvenNumber);
          printEvenNumberThread.Start(20);
     }

     public static void printOddNumber(object sleepTime)
     {
          for (int i = 1; i <= 99; i += 2)
          {
               Console.WriteLine("[Thread] Print Odd Number: {0}", i);
               Thread.Sleep((int)sleepTime);
          }

          Console.WriteLine("");
     }

     public static void printEvenNumber(object sleepTime)
     {
          for (int i = 0; i <= 100; i += 2)
          {
               Console.WriteLine("[Thread] Print Even Number: {0}", i);
               Thread.Sleep((int)sleepTime);
          }
     }
}