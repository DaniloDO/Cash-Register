using System;
using CashRegister.ConsoleApp.Models;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class StartTransactionAction : IMenuAction
{
    private readonly Till _till;
    public string Name { get => "Start Transaction"; }

    public StartTransactionAction(Till till)
    {
        _till = till;
    }

    public void Execute()
    {
        Console.WriteLine("Enter transaction amount: ");
        string? input = Console.ReadLine();
        if (decimal.TryParse(input, out var amount))
        {
            var transaction = new Transaction(amount);
            _till.AddTransaction(transaction);
            Console.WriteLine($"Transaction added, Till balance: {_till.Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Transaction cancelled.");
        }

        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
