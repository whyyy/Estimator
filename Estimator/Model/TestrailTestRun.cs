using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model
{
    class TestrailTestRun : INotifyPropertyChanged
    {
        private ulong? id;
        public ulong? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        private uint? passedCounter;
        public uint? PassedCounter
        {
            get
            {
                return passedCounter;
            }
            set
            {
                passedCounter = value;
                RaisePropertyChanged("PassedCounter");
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
                RaisePropertyChanged("Description");
            }
        }
        private ulong? milestoneId;
        public ulong? MilestoneId
        {
            get
            {
                return milestoneId;
            }
            set
            {
                milestoneId = value;
                RaisePropertyChanged("MilestoneId");
            }
        }

        public TestrailTestRun(string name, ulong? iD, uint? passedCount, string description, ulong? milestoneId)
        {
            Name = name;
            iD = Id;
            PassedCounter = passedCount;
            Description = description;
            MilestoneId = milestoneId;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
