// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

namespace CashRegister.ConsoleApp;

class Program 
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection(); 
        //Console UI services
        services.AddSingleton<App>();
        services.AddSingleton<Menu.MainMenu>(); 
        services.AddSingleton<UI.ConsoleReader>(); 
        services.AddSingleton<UI.ConsoleWriter>();

        using var provider = services.BuildServiceProvider();  
        provider.GetRequiredService<App>().Run(); 
    }
}
