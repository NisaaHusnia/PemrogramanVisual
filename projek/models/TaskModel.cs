using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class TaskModel
{
    private string connectionString = "server=localhost;database=todolist_db;uid=root;pwd=;";

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    // Mapping to domain
    public MyFirstApp.projek.models.Task ToDomain()
    {
        return new MyFirstApp.projek.models.Task
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description
        };
    }

    // Mapping from domain
    public static TaskModel FromDomain(MyFirstApp.projek.models.Task task)
    {
        return new TaskModel
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };
    }

    // Get all tasks from DB
    public List<MyFirstApp.projek.models.Task> GetAll()
    {
        List<MyFirstApp.projek.models.Task> tasks = new List<MyFirstApp.projek.models.Task>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT id, title, description FROM tasks";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TaskModel taskModel = new TaskModel
                    {
                        Id = reader.GetInt32("id"),
                        Title = reader.GetString("title"),
                        Description = reader.GetString("description")
                    };
                    tasks.Add(taskModel.ToDomain());
                }
            }
        }

        return tasks;
    }

    // Insert task to DB
    public bool Insert(TaskModel task)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO tasks (title, description) VALUES (@title, @description)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", task.Title);
                command.Parameters.AddWithValue("@description", task.Description);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }

    // Update task
    public bool Update(TaskModel task)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE tasks SET title=@title, description=@description WHERE id=@id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", task.Title);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@id", task.Id);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }

    // Delete task
    public bool Delete(int id)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM tasks WHERE id=@id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
