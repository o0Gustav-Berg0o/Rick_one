using System;

// Definiera delegater
public delegate void MessageHandler(string message);
public delegate int MathOperation(int a, int b);

public class MessagingSystem
{
    // Meddelandehantering: Metoder kopplade till delegaten
    public void LogToConsole(string message)
    {
        Console.WriteLine($"[Console Log]: {message}");
    }

    public void LogToFile(string message)
    {
        Console.WriteLine($"[File Log]: {message}"); // Simulerar filskrivning
    }

    public void LogToDatabase(string message)
    {
        Console.WriteLine($"[Database Log]: {message}"); // Simulerar databasloggning
    }

    public void ProcessMessages()
    {
        MessageHandler handler = LogToConsole;
        handler += LogToFile;
        handler += LogToDatabase;

        Console.WriteLine("Processing messages...");
        handler("System initialized successfully.");
        handler("User logged in.");
    }
}

public class Calculator
{
    // Matematiska operationer: Metoder kopplade till delegaten
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public void PerformCalculations()
    {
        MathOperation operation = Add;
        Console.WriteLine($"Addition: {operation(10, 5)}");

        operation = Subtract;
        Console.WriteLine($"Subtraction: {operation(10, 5)}");

        operation = Multiply;
        Console.WriteLine($"Multiplication: {operation(10, 5)}");

        operation = Divide;
        Console.WriteLine($"Division: {operation(10, 5)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Delegate Example Program");

        // Exempel på meddelandehantering
        MessagingSystem messagingSystem = new MessagingSystem();
        messagingSystem.ProcessMessages();

        Console.WriteLine();

        // Exempel på matematiska operationer
        Calculator calculator = new Calculator();
        calculator.PerformCalculations();
    }
}
