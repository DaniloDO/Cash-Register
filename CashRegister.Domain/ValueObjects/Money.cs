using System;

namespace CashRegister.Domain.ValueObjects;

public readonly record struct Money(decimal amount)
{
    public static Money Zero => new(0m);
    public override string ToString() => amount.ToString("C2");
    public static Money operator +(Money a, Money b) => new(a.amount + b.amount);
    public static Money operator -(Money a, Money b) => new(a.amount - b.amount);
    public static Money operator *(Money a, decimal f) => new(a.amount * f); 
}
