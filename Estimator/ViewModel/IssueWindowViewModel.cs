using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;

namespace Estimator.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        public GetStatuses GetStatuses { get; set; }
        public GetIssues GetIssues { get; set; }
        public GetTrackers GetTrackers { get; set; }
        public NameValueCollection Parameters { get; set; } = new NameValueCollection();
        public string ProjectId { get; set; } = ConfigurationSettings.AppSettings.Get("projectTasks");
        public string TrackerNp { get; set; } = ConfigurationSettings.AppSettings.Get("trackerNP");

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertychanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        public IssueWindowViewModel()
        {
            GetStatuses = new GetStatuses("tracker_id", TrackerNp);
            GetIssues = new GetIssues("project_id", ProjectId);
            GetTrackers = new GetTrackers();
        }

    }
}
