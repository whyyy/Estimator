using System.Configuration;

namespace Estimator.Redmine
{ 
   public class RedmineConnectionProvider
    {
        private RedmineConnectionProvider _redmineConnectionDetails;

        public RedmineConnectionProvider()
        {
            GetRedmineConnectionDetails();
        }

        public RedmineConnectionProvider(string host, string api)
        {

        }

        public static string Host { get; set; }

        public static string Api { get; set; }

        public RedmineConnectionProvider GetRedmineConnectionDetails()
        {           
            Host = ConfigurationManager.AppSettings["Host"];
            Api = ConfigurationManager.AppSettings["Api"];
            return _redmineConnectionDetails = new RedmineConnectionProvider(Host, Api);
        }
    }
}
