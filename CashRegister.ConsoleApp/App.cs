using System;
using CashRegister.ConsoleApp.Menu;

namespace CashRegister.ConsoleApp;

public sealed class App
{
    private readonly Menu.MainMenu _mainMenu;

    public App(MainMenu mainMenu) => _mainMenu = mainMenu; 
    public void Run() => _mainMenu.Show(); 
}
