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

    private string tasksFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.txt");

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        try
        {
            string taskText = taskEntry.Text;
            if (!string.IsNullOrWhiteSpace(taskText))
            {
                // Save the task to the text file
                File.AppendAllText(tasksFilePath, taskText + Environment.NewLine);

                taskEntry.Text = string.Empty; // Clear the entry field after adding task
                RefreshTasksList();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void RefreshTasksList()
    {
        try
        {
            // Read tasks from the text file
            if (File.Exists(tasksFilePath))
            {
                string[] tasks = File.ReadAllLines(tasksFilePath);
                taskListView.ItemsSource = tasks;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

