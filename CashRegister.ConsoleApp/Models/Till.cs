using System;
using System.Reflection.Metadata;

namespace CashRegister.ConsoleApp.Models;

public class Till
{
    private readonly List<Transaction> _transactions = new(); 
    public IReadOnlyList<Transaction> Transactions { get => _transactions.AsReadOnly(); }
    public decimal Balance { get; private set; }

    public void ApplyTransaction(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case TransactionType.Sale:
                Balance += transaction.Amount;
                break; 
            case TransactionType.Refund:
                if (transaction.Amount > Balance)
                {
                    throw new InvalidOperationException("Insufficient funds in till for refund"); 
                }

                Balance -= transaction.Amount; 
                break;
            default:
            throw new InvalidOperationException("Unsupported transaction type");
        }

        _transactions.Add(transaction); 
    }

}
