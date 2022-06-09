public class CanonPrinter : PrinterBase
{
     public override void Print()
     {
          Console.WriteLine("CanonPrinter is printing...");
     }

     public override void GetName()
     {
          Console.WriteLine("This is Canon Printer");
     }
}