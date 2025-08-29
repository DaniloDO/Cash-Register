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
        Console.WriteLine("\n=== Reports Menu ===");
        Console.WriteLine("1. Till Summary");
        Console.WriteLine("2. Deposits vs Withdrawals");
        Console.WriteLine("3. Display Transactions");
        Console.Write("Choose an option: ");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                ShowTillSummary();
                break;
            case "2":
                ShowDepositsVsWithdrawals();
                break;
            case "3":
                ShowTransactions();
                break; 
            default:
                Console.WriteLine("Invalid choice");
                Console.ReadLine();
                break;
        }
    }

    public void ShowTillSummary()
    {
        Console.WriteLine("=== Till Summary ===");
        Console.WriteLine($"Current Balance: {_till.Balance}");
        Console.WriteLine($"Total Transactions: {_till.Transactions.Count}");
        Console.ReadLine(); 
    }

    public void ShowDepositsVsWithdrawals()
    {
        var deposits = _till.Transactions
            .Where(tx => tx.Type == TransactionType.Deposit)
            .Sum(tx => tx.Amount);

        var withdrawals = _till.Transactions
            .Where(tx => tx.Type == TransactionType.Withdrawal)
            .Sum(tx => tx.Amount);

        Console.WriteLine("=== Deposits vs Withdrawals ===");
        Console.WriteLine($"Total Deposited: ${deposits}");
        Console.WriteLine($"Total Withdrawn: ${withdrawals}");
        Console.WriteLine($"Net Flow: {deposits - withdrawals:C}");
        Console.ReadLine(); 
    }

    public void ShowTransactions()
    {
        if(!_till.Transactions.Any())
        {
            Console.WriteLine("No transactions recorded yet.");
            Console.ReadLine();
            return; 
        }
        
        Console.WriteLine("\nTransactions:");
        foreach(var tx in _till.Transactions)
        {
            Console.WriteLine($"- {tx.Timestamp:g} | {tx.Type} | Amount: {tx.Amount}$ | ID: {tx.Id}");
        }
        Console.WriteLine("Press Enter to return to menu");
        Console.ReadLine();
    }
}
