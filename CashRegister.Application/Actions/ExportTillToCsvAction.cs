/*
 The ExportTillToCsvAction class enables persistence of the current Till 
state into a CSV file.

 Key responsibilities include:
 - Leveraging an ITillRepository implementation (CSV-based).  
 - Saving Till data such as balance and transactions in a flat, 
   comma-separated format for portability and readability.  
 - Providing user confirmation when the export is completed.  
*/

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
        _repository.Save(_till);
        Console.WriteLine("Till successfully exported");
        Console.ReadLine();
    }
}
