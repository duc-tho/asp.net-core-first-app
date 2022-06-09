public class TaskExercise
{
     public static void start()
     {
          Task printOddNumberTask = printOddNumber(20);
          Task printEvenNumberTask = printEvenNumber(20);

          Task.WaitAll(printEvenNumberTask, printOddNumberTask);
     }

     public static Task printOddNumber(object sleepTime)
     {
          Action action = new Action(() =>
          {
               for (int i = 1; i <= 99; i += 2)
               {
                    Console.WriteLine("  [Task] Print Odd Number: {0}", i);
                    Thread.Sleep((int)sleepTime);
               }
          });

          Task task = new Task(action);
          task.Start();

          return task;
     }

     public static Task printEvenNumber(object sleepTime)
     {
          Action action = new Action(() =>
          {
               for (int i = 0; i <= 100; i += 2)
               {
                    Console.WriteLine("  [Task] Print Even Number: {0}", i);
                    Thread.Sleep((int)sleepTime);
               }
          });

          Task task = new Task(action);
          task.Start();

          return task;
     }
}
