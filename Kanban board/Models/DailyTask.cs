using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kanban_board.Models
{
    public class DailyTask : INotifyPropertyChanged
    {
        string name;
        string description;
        string imagePath;
        public event PropertyChangedEventHandler PropertyChanged;
        public DailyTask(string _status, string _name = "Поиграть в доту", string _description = "Пикнуть techies или pudge",
            string _imagePath = @"/Assets/goodness.jpg")
        {
            name = _name;
            description = _description;
            imagePath = _imagePath;
            Status = _status;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Status { get; set; }
        public string Name 
        { 
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                NotifyPropertyChanged();
            }
        }
    }
}
