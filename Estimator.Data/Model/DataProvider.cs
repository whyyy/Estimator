using System.Collections.Generic;
using Redmine.Net;
using Redmine.Net.Api.Types;
using Estimator.Redmine;
using Estimator.Helpers;
using Redmine.Net.Api;
using System.ComponentModel;
using System.Collections.Specialized;
using Estimator.Model;

namespace Estimator.Data.Model
{
    public class DataProvider : INotifyPropertyChanged
    {
        static RedmineConnectionDetails RedmineConnectionDetails = new RedmineConnectionDetails();
        NameValueCollection Parameters = new NameValueCollection();
        private List<Ticket> _issues;
        public List<Ticket> Issues
        {
            get
            {
                return _issues;
            }
            set
            {
                _issues = value;
                RaisePropertyChanged("Issues");
            }
        }

        private List<Status> _statuses;
        public List<Status> Statuses
        {
            get
            {
                return _statuses;
            }
            set
            {
                _statuses = value;
                RaisePropertyChanged("Statuses");
            }
        }
        public RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionDetails.Host, RedmineConnectionDetails.Api);
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataProvider()
        {   
            _issues = new List<Ticket>();
            foreach(var issue in RedmineConnection.GetObjects<Issue>("tracker_id", "4"))
            {
                _issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            _issues.ToObservableCollection();
            _statuses = new List<Status>();
            foreach (var issue in RedmineConnection.GetObjects<IssueStatus>("tracker_id", "4"))
            {
                _statuses.Add(new Status(issue.Id, issue.Name));
            }
            _statuses.ToObservableCollection();
            
        }
      
        public DataProvider(string key, string value)
        {
            _issues = new List<Ticket>();
            Parameters.Add("tracker_id", "4");
            Parameters.Add(key, value);
            foreach (var issue in RedmineConnection.GetObjects<Issue>(Parameters))
            {
                _issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            _issues.ToObservableCollection();
        }
        
    }
}
