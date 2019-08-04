using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Estimator.ViewModel
{
    class GetStatuses
    {
        RedmineManager Connection = new RedmineManager("http://127.0.0.1/redmine/", "e698087c45046c4e5b45e7b666fc3aa51d94f37f");
        public List<Ticket> Statuses { get; set; } = new List<Ticket>();
        NameValueCollection Parameters = new NameValueCollection();
        public GetStatuses(string key, string value)
        {
            Parameters.Add(key, value);
            foreach (var status in Connection.GetObjects<IssueStatus>(Parameters))
            {
                Statuses.Add(new Ticket(status.Name, status.Id));
            }
        }
    }
}
