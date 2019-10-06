using System.Collections.Generic;
using System.Configuration;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;

namespace Estimator.Redmine.Model
{
    public class RedmineDataProvider
    {
        private List<Status> _statuses;
        private List<Ticket> _tickets;

        public RedmineDataProvider()
        {
            Tickets = GetTickets();
            Statuses = GetStatuses();
        }

        List<Status> GetStatuses()
        {
            _statuses = new List<Status>();
            foreach (var status in RedmineConnection.GetObjects<IssueStatus>("tracker_id", ConfigurationManager.AppSettings["tracker"]))
            {
                _statuses.Add(new Status(status.Id, status.Name));
            }
            return _statuses;
        }

        List<Ticket> GetTickets()
        {
            _tickets = new List<Ticket>();
            foreach (var issue in RedmineConnection.GetObjects<Issue>("tracker_id", ConfigurationManager.AppSettings["tracker"]))
            {
                _tickets.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            return _tickets;
        }
        public RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();
        public RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionProvider.Host, RedmineConnectionProvider.Api);
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
    }
}
