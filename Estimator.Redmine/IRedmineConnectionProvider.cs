using Redmine.Net.Api;

namespace Estimator.Redmine
{
    public interface IRedmineConnectionProvider
    {
        RedmineManager GetRedmineConnection();
    }
}