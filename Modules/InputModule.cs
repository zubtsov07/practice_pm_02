using IntegrationApp.Models;

namespace IntegrationApp.Modules;

public static class InputModule
{
    public static TaskItem ReadTask()
    {
        Console.WriteLine("\nTask name: ");
        string title = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Task name cannot be empty");

        DateTime due;
        while (true)
        {
            Console.WriteLine("Deadline (yyyy-MM-dd HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out due))
                break;
            Console.WriteLine("Invalid date format. Try again.");
        }
        
        if (due < DateTime.Now)
            Console.WriteLine("Warning: deadline is in the past!");

        Console.WriteLine("Description: ");
        string desc = (Console.ReadLine() ?? "").Trim();

        return new TaskItem { Title = title, Due = due, Description = desc };
    }
}