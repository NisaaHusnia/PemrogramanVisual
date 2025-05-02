
using ToDoWebApp.Models;

namespace ToDoWebApp.Services;

public class TaskService
{
    private List<TaskItem> _tasks = new();

    public IReadOnlyList<TaskItem> GetAll() => _tasks;

    public void Add(string title, DateTime? deadline)
    {
        _tasks.Add(new TaskItem { Title = title, Deadline = deadline });
    }

    public void Update(Guid id, string newTitle, DateTime? newDeadline)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.Title = newTitle;
            task.Deadline = newDeadline;
        }
    }

    public void ToggleComplete(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            if (task.IsCompleted) task.MarkPending();
            else task.MarkCompleted();
        }
    }

    public void Delete(Guid id)
    {
        _tasks.RemoveAll(t => t.Id == id);
    }
}
