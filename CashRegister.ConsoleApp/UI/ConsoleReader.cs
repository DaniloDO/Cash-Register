using System;

namespace CashRegister.ConsoleApp.UI;

public class ConsoleReader
{
    public string ReadString(string message)
    {
        Console.WriteLine(message);
        return (Console.ReadLine() ?? string.Empty).Trim(); 
    }
}
