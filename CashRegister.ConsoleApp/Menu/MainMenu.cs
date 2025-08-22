using System;

namespace CashRegister.ConsoleApp.Menu;

public class MainMenu
{
    private readonly UI.ConsoleReader _reader;
    private readonly UI.ConsoleWriter _writer;

    public MainMenu(UI.ConsoleReader reader, UI.ConsoleWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void Show()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Cash Register ===");
            Console.WriteLine("1. About");
            Console.WriteLine("2. Exit");

            string choice = _reader.ReadString("Choose: ");
            switch (choice)
            {
                case "1":
                _writer.Info("Modular console shell ready. Next steps: domain services & checkout.");
                _writer.Pause(); 
                break;
                case "2":
                exit = true; 
                break;
                default:
                _writer.Warn("Invalid option");
                _writer.Pause(); 
                break; 
            }
        }

    }

}
