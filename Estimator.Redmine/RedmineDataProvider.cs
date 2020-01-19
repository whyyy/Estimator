using Estimator.Model;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Estimator.Redmine
{
    public class RedmineDataProvider : IRedmineDataProvider

    {
        private static readonly string _trackerId = ConfigurationManager.AppSettings["tracker"];

        private NameValueCollection _parameters = new NameValueCollection();

        public List<Ticket> Tickets;

        public List<Status> Statuses;

        public RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

        public RedmineDataProvider()
        {
            _parameters.Add("tracker_id", _trackerId);
            Tickets = GetTickets();
            Statuses = GetStatuses();
        }

        public List<Status> GetStatuses()
        {
            List<Status> statuses = new List<Status>();

            statuses = RedmineConnectionProvider.RedmineConnection
                .GetObjects<IssueStatus>(_parameters)
                .Select(status => new Status(status.Id, status.Name))
                .ToList();

            return statuses;
        }

        public List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            tickets =
                RedmineConnectionProvider.RedmineConnection.GetObjects<Issue>(_parameters)
                .Select(issue => new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate,
                 issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields
                .SelectMany(customFieldName => customFieldName.Name
                .SelectMany(customFieldValues => customFieldName.Values
                .SelectMany(customFieldInfo => customFieldInfo.Info
                .Select(customFields => new TicketCustomField(customFieldName.Name, customFieldInfo.Info, issue.Id)))))
                .ToList<TicketCustomField>()))
                .ToList<Ticket>();
            //TODO: Same custom fields are populated many times, reduce populating

            return tickets;
        }
    }
}