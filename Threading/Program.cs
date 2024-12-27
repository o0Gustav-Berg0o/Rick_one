namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicThreadingExample test = new BasicThreadingExample();
            test.SimpleThreadExample();
        }
    }
  
        public class BasicThreadingExample
        {
            // Skapa och starta en ny tråd
            public void SimpleThreadExample()
            {
                // Skapa ny tråd med en metod
                Thread thread = new Thread(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"Tråd: {i}");
                        Thread.Sleep(1000);
                    }
                });

                // Starta tråden
                thread.Start();

                // Huvudtråden fortsätter här
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Huvudtråd: {i}");
                    Thread.Sleep(1000);
                }

                // Vänta på att tråden ska bli klar
                thread.Join();
            }
        }
}
