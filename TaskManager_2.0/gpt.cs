using System;
using System.Collections.Generic;
using System.Linq;

class TaskManager
{
    class Task
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; }
    }

    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(string description, DateTime deadline, int priority, string category)
    {
        Task newTask = new Task
        {
            Description = description,
            Deadline = deadline,
            Priority = priority,
            Category = category
        };

        tasks.Add(newTask);
        Console.WriteLine("Task added successfully!");
    }

    public void MarkAsCompleted(int taskId)
    {
        if (taskId >= 0 && taskId < tasks.Count)
        {
            tasks[taskId].IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task ID!");
        }
    }

    public void ViewTasks()
    {
        Console.WriteLine("\nTasks:");
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("| ID | Description         | Deadline           | Priority | Category | Completed |");
        Console.WriteLine("---------------------------------------------------------------");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"| {i,-2} | {tasks[i].Description,-20} | {tasks[i].Deadline,-19} | {tasks[i].Priority,-8} | {tasks[i].Category,-8} | {tasks[i].IsCompleted,-9} |");
        }

        Console.WriteLine("---------------------------------------------------------------\n");
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();

                    Console.Write("Enter task deadline (YYYY-MM-DD): ");
                    DateTime deadline = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter task priority (1-5, where 1 is the highest): ");
                    int priority = int.Parse(Console.ReadLine());

                    Console.Write("Enter task category: ");
                    string category = Console.ReadLine();

                    taskManager.AddTask(description, deadline, priority, category);
                    break;

                case "2":
                    Console.Write("Enter the ID of the task to mark as completed: ");
                    int taskId = int.Parse(Console.ReadLine());
                    taskManager.MarkAsCompleted(taskId);
                    break;

                case "3":
                    taskManager.ViewTasks();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
