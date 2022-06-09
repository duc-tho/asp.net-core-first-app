public abstract class PrinterBase : IPrinter
{
     public abstract void Print();

     public virtual void GetName()
     {
          Console.WriteLine("This is printer Name");
     }
}