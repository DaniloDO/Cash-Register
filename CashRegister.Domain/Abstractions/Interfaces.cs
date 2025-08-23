using System;
using CashRegister.Domain.ValueObjects;
using CashRegister.Domain.Cash; 

namespace CashRegister.Domain.Abstractions;

public interface ITaxCalculator
{
    public Money CalculateTax(Money net); 
}

public interface IPricingStrategy
{
    public Money ComputeTotal(IEnumerable<(string sku, int qty, Money unitPrice)> items); 
} 

public interface IChangeCalculator
{
    IDictionary<Denomination, int> MakeChange(int ChangeDueCents, IDictionary<Denomination, int> available);
}

public interface ICashDrawer
{
    public int TotalCents { get; }

    public void Deposit(IDictionary<Denomination, int> tendered); 
    IDictionary<Denomination, int> WithdrawChange(int ChangeDueCents); 
}