using Estimator.Helpers;
using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

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
        private string testrailId;
        public string TestrailId
        {
            get
            {
                return testrailId;
            }
            set
            {
                testrailId = value;
                RaisePropertyChanged("TestrailId");
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
            foreach (var issue in Connection.GetObjects<Issue>(parameters))
            {
                foreach (var issueCustomField in issue.CustomFields)
                {
                    if (issueCustomField.Name.Equals("Testrail id"))
                    {
                        foreach (var customFieldValue in issueCustomField.Values)
                        {
                            testrailId = customFieldValue.Info;
                        }
                    }
                }

                issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields, testrailId));
            }
            issues.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
