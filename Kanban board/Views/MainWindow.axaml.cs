using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using Kanban_board.Models;
using Kanban_board.ViewModels;

namespace Kanban_board.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("NewBtn").Click += delegate
            {

                var context = this.DataContext as MainWindowViewModel;
                context.PlanTasks.Clear();
                context.ProcessingTasks.Clear();
                context.EndedTasks.Clear();
            };

            this.FindControl<MenuItem>("LoadBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.LoadFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("SaveBtn").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.SaveFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("ExitBtn").Click += delegate
            {
                Close();
            };
        }

        public async void AddImage(object sender, RoutedEventArgs e)
        {
            DailyTask task = (DailyTask)((Button)sender).DataContext;
            var taskPath = new OpenFileDialog()
            {
                Title = "Search File",
                Filters = null
            }.ShowAsync((Window)this.VisualRoot);

            string[]? filePath = await taskPath;

            if (filePath != null)
            {
                task.ImagePath = filePath[0];
            }
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            DailyTask task = (DailyTask)((Button)sender).DataContext;
            if (context != null)
            {
                switch (task.Status)
                {
                    case "Plan":
                        context.PlanTasks.Remove(task);
                        break;
                    case "Processing":
                        context.ProcessingTasks.Remove(task);
                        break;
                    case "Ended":
                        context.EndedTasks.Remove(task);
                        break;
                }
            }
        }

        private async void AboutPage(object control, RoutedEventArgs arg)
        {
            await new About().ShowDialog((Window)this.VisualRoot);
        }
    }
}
