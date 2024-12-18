namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

           PrintExample example = new PrintExample();

        // Kör Run-metoden
        example.Run();
            // Kör Run-metoden

        }

        public delegate void PrintDelegate(string text);

        public class PrintExample
        {
            public void PrintToConsole(string text)
            {
                Console.WriteLine($"Console: {text}");
            }

            public void PrintToFile(string text)
            {
                // Simulerar skrivning till fil
                Console.WriteLine($"File: {text}");
            }

            public void Run()
            {
                PrintDelegate printHandler = PrintToConsole;
                printHandler += PrintToFile;

                printHandler("Hello from the delegate!");
                printHandler("Bob!");
            }
        }
    }
}