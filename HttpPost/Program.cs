using System.Text.Json;
using System.Text;

namespace HttpPost
{
    public class HttpPost
    {
        public async Task<bool> CreateUserExample(string name, int age)
        {
            using var client = new HttpClient();

            // Skapa användardata som ska skickas
            var userData = new
            {
                Name = name,
                Age = age
            };

            // Konvertera till JSON
            var content = new StringContent(

                JsonSerializer.Serialize(userData),
                Encoding.UTF8,
                "application/json");

            try
            {
                var response = await client.PostAsync(

                    "https://api.example.com/users",

                    content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpPost test = new HttpPost();
            var result = await test.CreateUserExample("Bob", 41);  // Await the async call
            Console.WriteLine(result);
            Console.WriteLine("Hello, World!");
        }
    }
}
