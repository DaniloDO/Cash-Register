using System;
using System.Text;
using CashRegister.Application.Interfaces;
using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure;

public class CsvTillRepository : ITillRepository
{
    private readonly string _filePath;
    public CsvTillRepository(string filePath = "till.csv")
    {
        _filePath = filePath;
    }

    public async Task Save(Till till)
    {
        var sb = new StringBuilder();
        sb.AppendLine("TransactionId, Type, Amount, Date");

        foreach (var transaction in till.Transactions)
        {
            sb.AppendLine
            (
                $"{transaction.Id}," +
                $"{transaction.Type}," +
                $"{transaction.Amount}," +
                $"{transaction.Timestamp:yyyy-MM-dd HH:mm:ss},"
            );
        }

        await File.WriteAllTextAsync(_filePath, sb.ToString()); 
    }

    public Till Load() 
    {
            throw new NotImplementedException("CSV loading not implemented yet.");
    }
}
