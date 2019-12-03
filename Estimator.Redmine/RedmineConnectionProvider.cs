using System.Configuration;

namespace Estimator.Redmine
{ 
   public class RedmineConnectionProvider : IRedmineConnectionProvider
    {
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
            return new RedmineConnectionProvider(Host, Api);
        }
    }
}
