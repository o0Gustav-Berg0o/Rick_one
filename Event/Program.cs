/// <summary>
/// Huvudprogramklassen som demonstrerar användning av händelsehantering (events)
/// </summary>
internal class Program
{
    /// <summary>
    /// Programmets startpunkt. Skapar en MessageService-instans och prenumererar på dess händelser.
    /// </summary>
    /// <param name="args">Kommandoradsargument (används ej)</param>
    static void Main(string[] args)
    {
        // Skapa en ny instans av meddelandetjänsten
        MessageService messenger = new MessageService();

        // Prenumerera på NewMessage-eventet med en lambda-funktion som eventhandler
        // Denna handler körs varje gång ett nytt meddelande skickas
        messenger.NewMessage += (sender, message) =>
        {
            // Skriv ut det mottagna meddelandet till konsolen
            Console.WriteLine($"Nytt meddelande: {message}");
        };

        // Testa att skicka ett meddelande som kommer att trigga eventet
        messenger.SendMessage("Hej världen!");
    }
}

/// <summary>
/// En tjänst för att hantera meddelanden med hjälp av event-mönstret
/// </summary>
public class MessageService
{
    /// <summary>
    /// Event som triggas när ett nytt meddelande skickas
    /// EventHandler<string> är en inbyggd delegattyp som tar en sändare (object) 
    /// och ett meddelande (string) som parametrar
    /// </summary>
    public event EventHandler<string> NewMessage;

    /// <summary>
    /// Metod för att skicka ett meddelande och notifiera alla prenumeranter
    /// </summary>
    /// <param name="message">Meddelandet som ska skickas</param>
    public void SendMessage(string message)
    {
        // Null-conditional operator (?.) används för att säkert anropa eventet
        // Invoke anropas endast om det finns prenumeranter på eventet
        NewMessage?.Invoke(this, message);
    }
}