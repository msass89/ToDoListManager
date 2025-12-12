using System;
using System.Collections.Generic;  // Needed for List<T>

class Program
{
    public static List<string> tasks = new List<string>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            ShowMenu();

            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayTasks();
                        break;
                    case 2:
                        AddTask();
                        break;

                    case 3:
                        MarkTaskComplete();
                        break;
                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    // Displays the menu options to the user
    static void ShowMenu()
    {
        Console.WriteLine("\n1. View Tasks");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Mark Task Complete");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
    }

    // Displays the list of tasks to the user
    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    // Adds a new task to the list
    static void AddTask()
    {
        Console.Write("Enter the task: ");
        string? taskInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(taskInput))
        {
            string task = taskInput.Trim();
            tasks.Add(task);
            Console.WriteLine("Task added.");
        }
        else
        {
            Console.WriteLine("Task cannot be empty.");
        }
    }

    // Marks a specified task as complete
    static void MarkTaskComplete()
    {
        Console.WriteLine("Enter the task number to mark complete: ");
        string? numInput = Console.ReadLine();
        if (int.TryParse(numInput, out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            // If the task is already marked complete, inform the user
            if (tasks[taskNumber - 1].Contains("[Complete]"))
            {
                Console.WriteLine("Task is already marked complete.");
            }
            // Mark the task as complete
            else
            {
                tasks[taskNumber - 1] += " [Complete]";
                Console.WriteLine($"Task number '{taskNumber}' marked as complete.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}