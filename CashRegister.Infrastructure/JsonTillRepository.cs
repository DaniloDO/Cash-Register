/*
 The JsonTillRepository class provides a JSON-based persistence mechanism 
 for the Till aggregate, Implements the ITillRepository interface 
 to support saving Till data in a JSON file.  

 Purpose:
 - Implements the ITillRepository interface to support saving Till data 
   in a JSON file.  
 - Designed to persist balance and transactions in a human-readable format.  

 Key aspects:
 - Uses System.Text.Json for serialization with indentation for readability.  
 - The file path can be customized via constructor injection, with a default 
   of "till.json".  
 - Save() method serializes the entire Till object asynchronously and writes 
   a local file.  
 - Load() is defined but not yet implemented, serving as a placeholder for 
   future deserialization support.  
*/

using System.Text.Json;
using CashRegister.Application.Interfaces;
using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure;

public class JsonTillRepository : ITillRepository
{
    private readonly string _filePath; 

    public JsonTillRepository(string filePath = "till.json")
    {
        _filePath = filePath; 
    }

    public async Task Save(Till till)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(till, options); 
        await File.WriteAllTextAsync(_filePath, json); 
        
    }

    public Till Load()
    {
        throw new NotImplementedException("JSON loading not implemented yet.");
    }
}
