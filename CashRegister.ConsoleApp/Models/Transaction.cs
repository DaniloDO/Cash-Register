using System;

namespace CashRegister.ConsoleApp.Models;

public class Transaction
{
    public Guid Id { get; }
    public TransactionType Type { get; private set; }
    public DateTime Timestamp { get; private set; }
    public decimal Amount { get; private set; }

    public Transaction(TransactionType type, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Transaction amount must be greater than zero.");
        }

        Id = Guid.NewGuid();
        Type = type; 
        Timestamp = DateTime.Now;
        Amount = amount;
    }
}
