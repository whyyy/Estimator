using Estimator.Model;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using Estimator.Helpers;
using System.Windows.Input;

namespace Estimator.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        public ICommand FilterByStatusChosenCommand { get; set; }

        private GetStatuses getStatuses;
        public GetStatuses GetStatuses
        {
            get
            {
                return getStatuses;
            }
            set
            {
                getStatuses = value;
                RaisePropertyChanged("GetStatuses");
            }
        }
        private GetIssues getIssues;
        public GetIssues GetIssues
        {
            get
            {
                return getIssues;
            }
            set
            {
                getIssues = value;
                RaisePropertyChanged("GetIssues");
            }
        }
        private GetTrackers getTrackers;
        public GetTrackers GetTrackers
        {
            get
            {
                return getTrackers;
            }
            set
            {
                getTrackers = value;
                RaisePropertyChanged("GetTrackers");
            }
        }
        
        public NameValueCollection Parameters { get; set; } = new NameValueCollection();
        public string ProjectId { get; set; } = ConfigurationSettings.AppSettings.Get("projectTasks");
        public string TrackerNp { get; set; } = ConfigurationSettings.AppSettings.Get("trackerNP");

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Ticket selectedStatus;
        public Ticket SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public IssueWindowViewModel()
        {
            GetStatuses = new GetStatuses("tracker_id", TrackerNp);
            GetIssues = new GetIssues();
            GetTrackers = new GetTrackers();
            FilterByStatusChosenCommand = new Commander(FilterByStatusChosen , CanFilterByStatusChosen);
        }

        private void FilterByStatusChosen(object obj)
        {
            GetIssues.Issues.Clear();
            Parameters.Clear();
            Parameters.Add("tracker_id", TrackerNp);
            Parameters.Add("status_id", SelectedStatus.StatusId.ToString());
            GetIssues = new GetIssues(Parameters);
        }

        private bool CanFilterByStatusChosen(object obj)
        {
            if (SelectedStatus != null)
                return true;
            return false;
        }
    }
}
