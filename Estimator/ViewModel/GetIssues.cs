using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;
using Estimator.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Estimator.Helpers;

namespace Estimator.ViewModel
{
    public class GetIssues : INotifyPropertyChanged
    {
        RedmineManager Connection = new RedmineManager("http://127.0.0.1/redmine/", "e698087c45046c4e5b45e7b666fc3aa51d94f37f");
        private List<Ticket> issues = new List<Ticket>();
        public List<Ticket> Issues 
        {
            get
            {
                return issues;
            }
            set
            {
               // new ObservableCollection<Ticket>();
                issues = value;
                RaisePropertyChanged("Issues");
            }
        } 
        NameValueCollection Parameters = new NameValueCollection();

        public GetIssues()
        {

            foreach (var issue in Connection.GetObjects<Issue>())
            {
                issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            issues.ToObservableCollection();
        }
        public GetIssues(NameValueCollection parameters)
        {
            //Parameters.Add(key, value);
            foreach (var issue in Connection.GetObjects<Issue>(parameters))
            {
                Issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            Issues.ToObservableCollection();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
