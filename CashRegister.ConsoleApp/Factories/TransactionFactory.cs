using System;
using CashRegister.ConsoleApp.Models; 

namespace CashRegister.ConsoleApp.Factories;

public class TransactionFactory
{
    public Transaction? CreateTransaction()
    {
        Console.WriteLine("Select Transaction Type:");
        Console.WriteLine("1. Sale");
        Console.WriteLine("2. Refund");

        string? input = Console.ReadLine();
        TransactionType type;
        switch (input)
        {
            case "1":
                type = TransactionType.Sale;
                break;
            case "2":
                type = TransactionType.Refund;
                break;
            default:
                Console.WriteLine("Invalid choice. Transaction cancelled.");
                return null;
        }

        Console.Write("Enter transaction amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount. Transaction cancelled.");
            return null;
        }

        return new Transaction(type, amount); 
    }
}
