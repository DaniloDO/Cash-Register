using System;

namespace CashRegister.ConsoleApp.Models;

public class Transaction
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public decimal Amount { get; private set; }

    public Transaction(decimal amount)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Amount = amount; 
    }
}
