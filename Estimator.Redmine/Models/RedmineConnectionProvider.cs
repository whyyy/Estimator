using System.Configuration;

namespace Estimator.Redmine.Model
{ 
   public class RedmineConnectionProvider
    {
        public RedmineConnectionProvider()
        {
            Host = ConfigurationManager.AppSettings["Host"];
            Api = ConfigurationManager.AppSettings["Api"];
        }
        public static string Host { get; set; }
        public static string Api { get; set; }
    }
}
