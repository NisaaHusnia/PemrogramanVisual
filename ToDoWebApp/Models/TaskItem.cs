
namespace ToDoWebApp.Models;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? Deadline { get; set; }
    public DateTime? CompletedAt { get; set; }

    public void MarkCompleted()
    {
        IsCompleted = true;
        CompletedAt = DateTime.Now;
    }

    public void MarkPending()
    {
        IsCompleted = false;
        CompletedAt = null;
    }
}
