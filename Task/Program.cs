using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BasicTaskExample example = new BasicTaskExample();
            await example.SimpleTaskExample();
            await example.MultipleTasksExample();
        }
    }
    public class BasicTaskExample
    {
        // Skapa och kör en enkel task
        public async Task SimpleTaskExample()
        {
            // Skapa task som returnerar string
            Task<string> task = Task.Run(() =>
            {
                // Simulera arbete
                Thread.Sleep(1000);
                return "Task slutförd";
            });

            // Vänta på resultat
            string result = await task;
            Console.WriteLine(result);
        }
        // Använd Task.WhenAll
        public async Task MultipleTasksExample()
        {
            var task1 = Task.Run(() => "Resultat 1");
            var task2 = Task.Run(() => "Resultat 2");
            var task3 = Task.Run(() => "Resultat 3");
            // Vänta på alla tasks
            string[] results = await Task.WhenAll(task1, task2, task3);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
