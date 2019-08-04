using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Estimator.ViewModel
{
    public class GetIssues
    {
        RedmineManager Connection = new RedmineManager("http://127.0.0.1/redmine/", "e698087c45046c4e5b45e7b666fc3aa51d94f37f");
        public List<Ticket> Issues { get; set; } = new List<Ticket>();
        NameValueCollection Parameters = new NameValueCollection();

        public GetIssues()
        {

            foreach (var issue in Connection.GetObjects<Issue>())
            {
                Issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name));
            }
        }
        public GetIssues(string key, string value)
        {
            Parameters.Add(key, value);
            foreach (var issue in Connection.GetObjects<Issue>(Parameters))
            {
                Issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name));
            }
        }
    }
}
