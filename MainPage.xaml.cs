using AppTest.DbContext;
using AppTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;

namespace AppTest;

public partial class MainPage : ContentPage
{
    private List<string> tasks = new List<string>();

    public MainPage()
    {
        InitializeComponent();
        RefreshTasksList();
    }

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        try
        {
            string taskText = taskEntry.Text;
            if (!string.IsNullOrWhiteSpace(taskText))
            {
                using (var db = new TaskDbContext())
                {
                    TasksModel task = new TasksModel { TaskText = taskText };
                    db.Tasks.Add(task);
                    db.SaveChanges();
                }

                taskEntry.Text = string.Empty; // Clear the entry field after adding task
                RefreshTasksList();
            }
        }
        catch (DbUpdateException ex)
        {
            // Handle database-related exceptions and log the inner exception details
            Console.WriteLine("Database Error: " + ex.Message);
            Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
            Console.WriteLine("StackTrace: " + ex.StackTrace);
        }
        catch (Exception ex)
        {
            // Catch any other unexpected exceptions
            Console.WriteLine("Unexpected Error: " + ex.Message);
            Console.WriteLine("StackTrace: " + ex.StackTrace);
        }
    }

    private void RefreshTasksList()
    {
        try
        {
            using (var db = new TaskDbContext())
            {
                var tasks = db.Tasks.Select(t => t.TaskText).ToList();
                taskListView.ItemsSource = tasks;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
        }
    }
}

