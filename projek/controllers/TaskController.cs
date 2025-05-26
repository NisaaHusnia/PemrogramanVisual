using System.Collections.Generic;
using MyFirstApp.projek.models;

public class TaskController
{
    private TaskModel taskModel = new TaskModel();

    // Get all tasks as domain model list
    public List<Task> GetTasks()
    {
        return taskModel.GetAll();
    }

    // Add new task
    public bool AddTask(Task task)
    {
        TaskModel model = TaskModel.FromDomain(task);
        return taskModel.Insert(model);
    }

    // Update existing task
    public bool UpdateTask(Task task)
    {
        TaskModel model = TaskModel.FromDomain(task);
        return taskModel.Update(model);
    }

    // Delete task by id
    public bool DeleteTask(int id)
    {
        return taskModel.Delete(id);
    }
}
