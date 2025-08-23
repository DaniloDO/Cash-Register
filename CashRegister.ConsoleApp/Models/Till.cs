using System;

namespace CashRegister.ConsoleApp.Models;

public class Till
{
    private readonly List<Transaction> _transactions = new(); 
    public IReadOnlyList<Transaction> Transactions { get => _transactions.AsReadOnly(); }
    public decimal Balance { get; private set; }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction); 
        Balance += transaction.Amount; 
    }

}
