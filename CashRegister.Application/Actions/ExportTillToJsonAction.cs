/*
 The ExportTillToJsonAction class provides the ability to persist the current 
state of the Till into a JSON file.  

 Key responsibilities include:
 - Integrating with an ITillRepository implementation (JSON-based).  
 - Saving the Till’s balance and transactions to a structured JSON file.  
 - Giving user feedback upon successful export.  
*/


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
        _repository.Save(_till);
        Console.WriteLine("Till successfully exported");
        Console.ReadLine();
    }
}
