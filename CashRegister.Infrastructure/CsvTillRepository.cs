/*
 The CsvTillRepository class provides a CSV-based persistence mechanism 
 for the Till aggregate. Implements the ITillRepository interface 
 to support saving Till data in a simple, tabular format (CSV).   

 Key aspects:
 - Default file path is "till.csv", configurable via constructor.  
 - Save() builds a local CSV file with a header row and appends each transaction’s 
   ID, type, amount, and timestamp.  
 - Data is written asynchronously to improve performance and responsiveness.  
 - Load() is defined but not yet implemented, reserved for future parsing 
   of persisted CSV data back into Till objects.  
*/

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
