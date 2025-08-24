using System;
using CashRegister.ConsoleApp.Models;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class ViewTillStatusAction : IMenuAction
{
    private readonly Till _till;
    public string Name { get => "View Till Status"; }

    public ViewTillStatusAction(Till till)
    {
        _till = till;
    }

    public void Execute()
    {
        Console.WriteLine($"\nCurrent Till Balance: {_till.Balance:C}");
        if (!_till.Transactions.Any())
        {
            Console.WriteLine("No transactions recorded yet.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nTransactions:");
        foreach (var tx in _till.Transactions)
        {
            Console.WriteLine($"- {tx.Timestamp:g} | {tx.Type} | Amount: {tx.Amount}$ | ID: {tx.Id}");
        }

        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
