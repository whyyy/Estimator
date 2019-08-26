using System.Collections.Generic;
using System.ComponentModel;

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
        private uint? untestedNumber;
        public uint? UntestedNumber
        {
            get
            {
                return untestedNumber;
            }
            set
            {
                untestedNumber = value;
                RaisePropertyChanged("UntestedNumber");
            }
        }

        private uint? failedNumber;
        public uint? FailedNumber
        {
            get
            {
                return failedNumber;
            }
            set
            {
                failedNumber = value;
                RaisePropertyChanged("FailedNumber");
            }
        }

        private ulong warningCasesNumber;
        public ulong WarningCasesNumber
        {
            get
            {
                return warningCasesNumber;
            }
            set
            {
                warningCasesNumber = value;
                RaisePropertyChanged("WarningCasesNumber");
            }
        }



        public TestrailTestRun(string name, ulong? iD, uint? passedCount, string description, ulong? milestoneId, uint? untestedNumber, uint? failedNumber, ulong warningCasesNumber)
        {
            Name = name;
            Id = iD;
            PassedCounter = passedCount;
            Description = description;
            MilestoneId = milestoneId;
            UntestedNumber = untestedNumber;
            FailedNumber = failedNumber;
            WarningCasesNumber = warningCasesNumber;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
