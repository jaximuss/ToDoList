using Microsoft.Office.Interop.Word;

namespace AppTest;

public partial class MainPage : ContentPage
{
	private List<string> tasks = new List<string>();

	public MainPage()
	{
		InitializeComponent();
		taskListView.ItemsSource = tasks;	
	}

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        string taskText = taskEntry.Text;
        if (!string.IsNullOrWhiteSpace(taskText))
        {
            tasks.Add(taskText);
            taskEntry.Text = string.Empty; // Clear the entry field after adding task
            taskListView.ItemsSource = null;
            taskListView.ItemsSource = tasks; // Update the ListView's item source to reflect the changes

        }
    }
}

