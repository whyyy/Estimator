using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Estimator.Redmine
{
    public class RedmineDataProvider
    {
        private List<Status> _statuses;

        private List<Ticket> _tickets;

        private List<TicketCustomField> _customFields = new List<TicketCustomField>();

        private static readonly string _trackerId = ConfigurationManager.AppSettings["tracker"];

        private NameValueCollection _parameters = new NameValueCollection();

        public List<Ticket> Tickets;

        public List<Status> Statuses;

        public RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

        public RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionProvider.Host, RedmineConnectionProvider.Api);

        public RedmineDataProvider()
        {
            _parameters.Add("tracker_id", _trackerId);
            Tickets = GetTickets();
            Statuses = GetStatuses();
        }

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
            _customFields = new List<TicketCustomField>();

            var _issuesQuery =
                from issue in RedmineConnection.GetObjects<Issue>(_parameters)
                select new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate,
                    issue.StartDate, issue.Status.Id, issue.Status.Name);

            foreach (var ticket in _issuesQuery)
            {
                _parameters.Clear();
                _parameters.Add("issue_id", ticket.Id.ToString());
                var _customFieldsQuery =
                from issue in RedmineConnection.GetObjects<Issue>(_parameters)
                from customField in issue.CustomFields
                from customFieldValues in customField.Values
                select new TicketCustomField(customField.Name, customFieldValues.Info);
                ticket.CustomFields = _customFieldsQuery.ToList();
                _tickets.Add(ticket);
            }
            
            return _tickets;
        }
    }
}
