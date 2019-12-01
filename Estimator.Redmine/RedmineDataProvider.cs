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
            foreach (var issue in RedmineConnection.GetObjects<Issue>(_parameters))
            {
                _customFields = new List<TicketCustomField>();
                foreach (var customField in issue.CustomFields)
                {
                    _customFields.AddRange(from value in customField.Values
                                           select new TicketCustomField(customField.Name, value.Info));
                    if (customField.Name.Equals("Testrail id"))
                    {
                        foreach (var customFieldValue in from customFieldValue in customField.Values
                                let testrailId = customFieldValue.Info
                                select new { })
                        {
                        }
                    }
                }
                _tickets.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate,
                    issue.StartDate, issue.Status.Id, issue.Status.Name, _customFields));
            }
            return _tickets;
        }


    }
}
