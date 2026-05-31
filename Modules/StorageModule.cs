using System.Text.Json;
using IntegrationApp.Models;

namespace IntegrationApp.Modules;

public class StorageModule
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _opts = new() { WriteIndented = true };

    public StorageModule(string filePath = "tasks.json")
    {
        _filePath = filePath;
    }

    public List<TaskItem> Load()
    {
        if (!File.Exists(_filePath))
            return new List<TaskItem>();
        
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void Save(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, _opts);
        File.WriteAllText(_filePath, json);
    }
}