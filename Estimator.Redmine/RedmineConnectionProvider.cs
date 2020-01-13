using System.Configuration;

namespace Estimator.Redmine
{ 
   public class RedmineConnectionProvider : IRedmineConnectionProvider
    {

        public RedmineConnectionProvider()
        {
            GetRedmineConnectionDetails();
        }

        public static string Host { get; set; }

        public static string Api { get; set; }

        public RedmineConnectionDetails GetRedmineConnectionDetails()
        {           
            Host = ConfigurationManager.AppSettings["Host"];
            Api = ConfigurationManager.AppSettings["Api"];
            return new RedmineConnectionDetails(Host, Api);
        }
    }
}
