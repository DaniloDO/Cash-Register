using System;
using CashRegister.ConsoleApp.Models;

namespace CashRegister.ConsoleApp.Factories;

public class TransactionFactory
{
    public Transaction? CreateTransaction(Till till)
    {
        Console.WriteLine("Select Transaction Type:");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdrawal");

        string? input = Console.ReadLine();
        TransactionType type;
        switch (input)
        {
            case "1":
                type = TransactionType.Deposit;
                break;
            case "2":
                type = TransactionType.Withdrawal;
                break;
            default:
                Console.WriteLine("Invalid choice. Transaction cancelled.");
                Console.ReadLine(); 
                return null;
        }

        Console.Write("Enter transaction amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Invalid amount. Transaction cancelled.");
            return null;
        }

        if (type == TransactionType.Withdrawal && amount > till.Balance)
        {
            Console.WriteLine("Refund denied. Not enough balance in the till.");
            return null; 
        }

        if (amount > 10000)
        {
            Console.WriteLine("Transaction exceeds allowed limit.");
            return null; 
        }

        return new Transaction(type, amount);
    }
}
