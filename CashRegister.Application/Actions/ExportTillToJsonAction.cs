using System;
using CashRegister.Domain.Models;
using CashRegister.Application.Interfaces;

namespace CashRegister.Application.Actions;

public class ExportTillToJsonAction : IMenuAction
{
    private readonly Till _till;
    private readonly ITillRepository _repository;
    public string Name { get => "Export till to json"; }

    public ExportTillToJsonAction(Till till, ITillRepository repository)
    {
        _till = till;
        _repository = repository;
    }

    public void Execute()
    {
        const string filePath = "till.json";
        _repository.Save(_till);
        Console.WriteLine("Till successfully exported");
        Console.ReadLine();
    }
}
