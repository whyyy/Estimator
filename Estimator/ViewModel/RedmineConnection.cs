using Redmine.Net.Api;

namespace Estimator.ViewModel
{
    class RedmineConnection
    {
        public RedmineConnection()
        {
            RedmineConnectionDetails Details = new RedmineConnectionDetails();
            RedmineManager manager = new RedmineManager(Details.Host, Details.Api);
        }
    }
}
