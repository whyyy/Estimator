using Redmine.Net.Api;
using System.Configuration;

namespace Estimator.Redmine
{
    public class RedmineConnectionProvider : IRedmineConnectionProvider
    {
        public RedmineConnectionProvider()
        {
            RedmineConnection = GetRedmineConnection();
        }

        private RedmineConnectionDetails _redmineConnectionDetails;

        public RedmineManager RedmineConnection { get; set; }

        private RedmineConnectionDetails _getRedmineConnectionDetails()
        {
            string _host = ConfigurationManager.AppSettings["Host"];

            string _api = ConfigurationManager.AppSettings["Api"];

            return new RedmineConnectionDetails(_host, _api);
        }

        public RedmineManager GetRedmineConnection()
        {
            _redmineConnectionDetails = _getRedmineConnectionDetails();

            return new RedmineManager(RedmineConnectionDetails.Host, RedmineConnectionDetails.Api);
        }
    }
}