using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;

namespace Estimator.Redmine.Model
{
    public class RedmineDataProvider
    {
        private List<Status> _statuses;
        private List<Ticket> _tickets;
        private static readonly string _trackerId = ConfigurationManager.AppSettings["tracker"];
        private NameValueCollection _parameters = new NameValueCollection();
              
        public RedmineDataProvider()
        {
            _parameters.Add("tracker_id", _trackerId);
            Tickets = GetTickets();
            Statuses = GetStatuses();
        }

        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();
        public RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionProvider.Host, RedmineConnectionProvider.Api);

        List<Status> GetStatuses()
        {
            _statuses = new List<Status>();
            foreach (var status in RedmineConnection.GetObjects<IssueStatus>(_parameters))
            {
                _statuses.Add(new Status(status.Id, status.Name));
            }
            return _statuses;
        }

        List<Ticket> GetTickets()
        {
            _tickets = new List<Ticket>();
            foreach (var issue in RedmineConnection.GetObjects<Issue>(_parameters))
            {
                _tickets.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            return _tickets;
        }
    }
}
