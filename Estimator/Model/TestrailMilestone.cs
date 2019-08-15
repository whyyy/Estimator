using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model
{
    class TestrailMilestone : INotifyPropertyChanged
    {
        private string milestoneName;
        public string MilestoneName
        {
            get
            {
                return milestoneName;
            }
            set
            {
                milestoneName = value;
                RaisePropertyChanged("MilestoneName");
            }
        }
        private ulong milestoneId;
        public ulong MilestoneId
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
        private bool? isStarted;
        public bool? IsStarted
        {
            get
            {
                return isStarted;
            }
            set
            {
                isStarted = value;
                RaisePropertyChanged("IsStarted");
            }
        }
        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }
        private bool? isCompleted;
        public bool? IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
                RaisePropertyChanged("IsCompleted");
            }
        }
        public TestrailMilestone(string milestoneName)
        {
            MilestoneName = milestoneName;
        }

        public TestrailMilestone(string milestoneName, ulong milestoneId, bool? isStarted, DateTime? dueDate, bool? isCompleted)
        {
            MilestoneName = milestoneName;
            MilestoneId = milestoneId;
            IsStarted = isStarted;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
