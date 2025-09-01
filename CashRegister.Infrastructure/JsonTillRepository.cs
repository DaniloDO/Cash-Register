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
        if(!File.Exists(_filePath))
            throw new FileNotFoundException($"The file {_filePath} doesn't exists"); 

        var json = File.ReadAllText(_filePath); 
        return JsonSerializer.Deserialize<Till>(json) ?? new Till(); 
    }



}
