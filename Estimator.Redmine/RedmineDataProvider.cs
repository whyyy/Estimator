using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Estimator.Redmine
{
    public class RedmineDataProvider : IRedmineDataProvider

    {
        private List<Status> _statuses;

        private List<Ticket> _tickets;

        private List<TicketCustomField> _customFields;

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

        public List<Status> GetStatuses()
        {
            _statuses = new List<Status>();
            _statuses = RedmineConnection.GetObjects<IssueStatus>(_parameters).Select(status => new Status(status.Id, status.Name)).ToList();
            return _statuses;
        }

        public List<Ticket> GetTickets()
        {
            _tickets = new List<Ticket>();
            var _redmineConnection = RedmineConnection.GetObjects<Issue>(_parameters);

            _customFields = new List<TicketCustomField>();

            var _ticketsQuery = _redmineConnection
               .SelectMany(issue => (new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate,
                   issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields
                    .SelectMany(customField => customField.Name
                    .SelectMany(customFieldValues => customField.Values
                    .SelectMany(ticketCustomFieldInfo => new TicketCustomField(customField.Name, ticketCustomFieldInfo.Info)).ToList<TicketCustomField>())))));
  
            _tickets = _ticketsQuery;

            return _tickets;
        }
    }
}
