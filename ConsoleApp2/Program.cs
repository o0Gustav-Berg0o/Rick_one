using static ConsoleApp2.Program;

namespace ConsoleApp2
{
    //Lägg till två till användare
    internal class Program
    {
        static void Main(string[] args)
        {
            // Print initial greeting message to the console
            Console.WriteLine("Hello, World!");

            // Create an instance of the MessageSystem class
            MessageSystem example = new MessageSystem();

            // Call the Run method to execute the logic
            example.Run();
        }

        // Define a delegate that takes a string parameter
        public delegate void MessageExample(string message);
    }

    public class MessageSystem
    {
        // Method to handle message sending to Admins
        public void MessageAdmin(string message)
        {
            Console.WriteLine("Hej Admin. Meddelande : " + message + " www.admin.updatepassword.com");
        }

        // Method to handle message sending to Users
        public void MessageUser(string message)
        {
            Console.WriteLine("Hej User. Meddelande : " + message + " www.user.updatepassword.com");
        }

        // Method that demonstrates the use of delegates
        public void Run()
        {
            // Initialize the delegate with the MessageAdmin method
            MessageExample messageSender = MessageAdmin;

            // Add MessageUser method to the delegate
            messageSender += MessageUser;

            // Trigger the delegate with a specific message
            messageSender("Du behöver uppdatera ditt lösenord. Gå in på :");
        }
    }
}

