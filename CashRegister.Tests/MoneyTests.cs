using System;
using CashRegister.Domain.ValueObjects; 

namespace CashRegister.Tests;

public class MoneyTests
{
    [Fact]
    public void Addition_Works()
    {
        var a = new Money(1.20m);
        var b = new Money(2.30m);
        var sum = a + b;
        Assert.Equal(3.50m, sum.amount); 
    }
}
