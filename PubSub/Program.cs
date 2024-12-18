/// <summary>
/// Klass som representerar en nyhetstjänst (Publisher/Utgivare)
/// </summary>
public class NewsletterService
{
    // Definiera ett event som skickar en sträng (nyheten)
    public event EventHandler<string> BreakingNews;

    /// <summary>
    /// Metod för att publicera en nyhet
    /// </summary>
    public void PublishNews(string news)
    {
        Console.WriteLine($"\nNYHETSREDAKTÖREN: Publicerar nyheten: {news}");

        // Kontrollera om någon prenumererar på eventet och skicka nyheten
        BreakingNews?.Invoke(this, news);
    }
}

/// <summary>
/// Klass som representerar en nyhetsprenumerant (Subscriber)
/// </summary>
public class NewsSubscriber
{
    private string name;

    public NewsSubscriber(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Metod som anropas när en nyhet tas emot
    /// </summary>
    public void HandleNews(object sender, string news)
    {
        Console.WriteLine($"PRENUMERANT {name}: Jag fick just nyheten: {news}!");
    }
}

/// <summary>
/// Huvudprogram som demonstrerar användningen
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Skapa nyhetstjänsten (Publisher)
        var newsService = new NewsletterService();

        // Skapa två prenumeranter
        var subscriber1 = new NewsSubscriber("Anna");
        var subscriber2 = new NewsSubscriber("Erik");

        // Prenumerera på nyheterna (registrera event handlers)
        newsService.BreakingNews += subscriber1.HandleNews;
        newsService.BreakingNews += subscriber2.HandleNews;

        // Publicera en nyhet - båda prenumeranterna kommer att meddelas
        newsService.PublishNews("Sverige vann VM-guld!");

        Console.WriteLine("\n--- Erik avslutar sin prenumeration ---\n");

        // Avsluta Eriks prenumeration
        newsService.BreakingNews -= subscriber2.HandleNews;

        // Publicera en ny nyhet - bara Anna får den här nyheten
        newsService.PublishNews("Ny glassmak lanseras!");
    }
}