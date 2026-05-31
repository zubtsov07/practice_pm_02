using IntegrationApp.Models;
using IntegrationApp.Modules;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var storage = new StorageModule();
var tasks = storage.Load();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\n=== Module Integration System (Production Practice) ===");
    Console.WriteLine("1. Add production task");
    Console.WriteLine("2. Show upcoming tasks (24 hours)");
    Console.WriteLine("3. Save and exit");
    Console.Write("Choice: ");
    
    string? choice = Console.ReadLine();
    
    try
    {
        switch (choice)
        {
            case "1":
                var newTask = InputModule.ReadTask();
                tasks.Add(newTask);
                Console.WriteLine("✓ Task added.");
                break;
            case "2":
                ReportModule.ShowUpcoming(tasks, 24);
                break;
            case "3":
                storage.Save(tasks);
                Console.WriteLine("✓ Data saved. Exiting...");
                exit = true;
                break;
            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}