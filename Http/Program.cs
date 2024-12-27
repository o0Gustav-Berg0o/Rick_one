using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace Http
{   
    public class HttpTest
    {
        public async Task<string> GetDataExample()
        {
            // Skapa en HTTP-klient
            using var client = new HttpClient();

            try
            {
                // Gör GET-request och vänta på svar

                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

                // Kontrollera om requesten lyckades
                if (response.IsSuccessStatusCode)
                {

                    // Läs innehållet som string
                    return await response.Content.ReadAsStringAsync();

                }
                return $"Fel: {response.StatusCode}";
            }
            catch (Exception ex)
            {
                return $"Ett fel uppstod: {ex.Message}";

            }
        }
    }
    internal class Program
    {
        static async Task Main(string[] args)  // Note: Made Main async
        {
            HttpTest test = new HttpTest();
            var result = await test.GetDataExample();  // Await the async call
            Console.WriteLine(result);
        }
    }
}
