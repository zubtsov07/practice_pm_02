using IntegrationApp.Models;

namespace IntegrationApp.Modules;

public static class ReportModule
{
    public static void ShowUpcoming(List<TaskItem> tasks, int hours = 24)
    {
        var now = DateTime.Now;
        var upcoming = tasks
            .Where(t => t.Due >= now && t.Due <= now.AddHours(hours))
            .OrderBy(t => t.Due)
            .ToList();

        if (!upcoming.Any())
        {
            Console.WriteLine($"\nNo tasks in the next {hours} hours.");
            return;
        }

        Console.WriteLine($"\n--- Tasks in the next {hours} hours ---");
        foreach (var task in upcoming)
            Console.WriteLine($"- {task}");
    }
}