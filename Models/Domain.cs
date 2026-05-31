namespace IntegrationApp.Models;

public class TaskItem
{
    public string Title { get; set; } = string.Empty;
    public DateTime Due { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public override string ToString() => $"{Title} - {Due:g} - {Description}";
}