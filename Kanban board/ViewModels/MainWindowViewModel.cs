using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using Kanban_board.Models;

namespace Kanban_board.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<DailyTask> planTasks;
        ObservableCollection<DailyTask> processingTasks;
        ObservableCollection<DailyTask> endedTasks;

        public MainWindowViewModel()
        {
            planTasks = new ObservableCollection<DailyTask>();
            processingTasks = new ObservableCollection<DailyTask>();
            endedTasks = new ObservableCollection<DailyTask>();
        }

        public ObservableCollection<DailyTask> PlanTasks
        {
            get => planTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref planTasks, value);
            }
        }

        public ObservableCollection<DailyTask> ProcessingTasks
        {
            get => processingTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref processingTasks, value);
            }
        }

        public ObservableCollection<DailyTask> EndedTasks
        {
            get => endedTasks;
            set
            {
                this.RaiseAndSetIfChanged(ref endedTasks, value);
            }
        }

        public void AddTask(string taskType)
        {
            switch (taskType)
            {
                case "Plan":
                    PlanTasks.Add(new DailyTask("Plan"));
                    break;
                case "Processing":
                    ProcessingTasks.Add(new DailyTask("Processing"));
                    break;
                case "Ended":
                    EndedTasks.Add(new DailyTask("Ended"));
                    break;
            }
        }

        public void SaveFile(string path)
        {
            List<ObservableCollection<DailyTask>> tasks = new List<ObservableCollection<DailyTask>> { PlanTasks, ProcessingTasks, EndedTasks };
            ProcessingFile.SaveFile(path, tasks);
        }

        public void LoadFile(string path)
        {
            List<ObservableCollection<DailyTask>> tasks = ProcessingFile.LoadFile(path);
            PlanTasks = tasks[0];
            ProcessingTasks = tasks[1];
            EndedTasks = tasks[2];
        } 
    }
}
