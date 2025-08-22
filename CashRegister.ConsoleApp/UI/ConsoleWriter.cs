using System;

namespace CashRegister.ConsoleApp.UI;

public class ConsoleWriter
{
    public void Info(string message) => Console.WriteLine(message);
    public void Warn(string message) => Console.WriteLine($"[!] {message}");
    public void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(); 
    }
}
