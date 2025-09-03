using System;
using CashRegister.Application.Interfaces;
using CashRegister.Domain.Models;

namespace CashRegister.Application.Actions;

public class ExportTillToCsvAction : IMenuAction
{
    private readonly Till _till;
    private readonly ITillRepository _repository; 
    public string Name { get => "Export till to csv"; }

    public ExportTillToCsvAction(Till till, ITillRepository repository)
    {
        _till = till;
        _repository = repository; 
    }

    public void Execute()
    {
        const string filePath = "csv.json";
        _repository.Save(_till);
        Console.WriteLine("Till successfully exported");
        Console.ReadLine();
    }
}
