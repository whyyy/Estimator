using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Estimator.ViewModel
{
    class GetTrackers
    {
        RedmineManager Connection = new RedmineManager("http://127.0.0.1/redmine/", "e698087c45046c4e5b45e7b666fc3aa51d94f37f");
        public List<IValue> Trackers { get; set; } = new List<IValue>();
        public string ProjectId = ConfigurationManager.AppSettings["QATasks"];
        NameValueCollection parameters = new NameValueCollection { { "project_id", "2" } };

        public GetTrackers()
        {
            foreach (var project in Connection.GetObjects<Project>(parameters))
            {
                Trackers.Add(project.Trackers as IValue);
            }
        }
    }
}
