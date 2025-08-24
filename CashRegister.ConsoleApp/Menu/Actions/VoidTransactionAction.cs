using System.Linq;
using CashRegister.ConsoleApp.Models;

namespace CashRegister.ConsoleApp.Menu.Actions;

public class VoidTransactionAction : IMenuAction
{
    private readonly Till _till;
    public string Name { get => "Void Transaction"; }
    public VoidTransactionAction(Till till)
    {
        _till = till;
    }

    public void Execute()
    {
        Console.WriteLine("Enter the ID of the transaction to void:");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Operation cancelled.");
            return;
        }

        if (!Guid.TryParse(input, out Guid transactionId))
        {
            Console.WriteLine("Invalid ID format. Operation cancelled.");
            return;
        }

        var transaction = _till.Transactions.FirstOrDefault(tx => tx.Id == transactionId);

        if (transaction == null)
        {
            Console.WriteLine("Transaction not found");
            return;
        }

        Console.WriteLine($"Are you sure you want to void transaction {transaction.Id}? (y/n)");
        string? confirm = Console.ReadLine();

        if (confirm?.ToLower() != "y")
        {
            Console.WriteLine("Operation cancelled.");
            return;
        }

        _till.VoidTransactionAction(transaction); 
        Console.WriteLine("Transaction eliminated successfully"); 
        Console.ReadKey(); 
    }
}
