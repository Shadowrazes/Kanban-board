using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Kanban_board.Models
{
    public class ProcessingFile
    {
        public static void SaveFile(string path, List<ObservableCollection<DailyTask>> tasks)
        {
            File.WriteAllText(path, "");
            List<string> data = new List<string>();
            foreach(ObservableCollection<DailyTask> taskList in tasks)
            {
                foreach (DailyTask task in taskList)
                {
                    data.Add(task.Status);
                    data.Add(task.Name);
                    data.Add(task.Description);
                    data.Add(task.ImagePath);
                }
                data.Add("");
            }
            File.WriteAllLines(path, data);
        }

        public static List<ObservableCollection<DailyTask>> LoadFile(string path)
        {
            List<ObservableCollection<DailyTask>> tasks = new List<ObservableCollection<DailyTask>>
            {
                new ObservableCollection<DailyTask>(),
                new ObservableCollection<DailyTask>(),
                new ObservableCollection<DailyTask>()
            };

            StreamReader file = new StreamReader(path);

            try
            {
                for (int i = 0; i < tasks.Count(); i++)
                {
                    ObservableCollection<DailyTask> tmp = new ObservableCollection<DailyTask>();
                    while (true)
                    {
                        string status = file.ReadLine();
                        if (status == "")
                            break;
                        string name = file.ReadLine();
                        string description = file.ReadLine();
                        string imagePath = file.ReadLine();

                        tmp.Add(new DailyTask(status, name, description, imagePath));
                    }
                    tasks[i] = tmp;
                }
                file.Close();
                return tasks;
            }
            catch
            {
                file.Close();
                return new List<ObservableCollection<DailyTask>>
                {
                    new ObservableCollection<DailyTask>(),
                    new ObservableCollection<DailyTask>(),
                    new ObservableCollection<DailyTask>()
                };
            }
        }
    }
}
