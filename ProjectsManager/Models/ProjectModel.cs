using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManager.Models
{
    public class ProjectModel : INotifyPropertyChanged
    {
        /*
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }*/
        public int Id { get; set; }

        private string name;
        public string Name { 
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        private string teamLeadName;
        public string TeamLeadName
        {
            get
            {
                return teamLeadName;
            }
            set
            {
                teamLeadName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TeamLeadName"));
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, e);
        }


    }
}
