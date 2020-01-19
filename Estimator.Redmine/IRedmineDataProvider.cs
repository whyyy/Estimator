using Estimator.Model;
using Redmine.Net.Api;
using System.Collections.Generic;

namespace Estimator.Redmine
{
    public interface IRedmineDataProvider
    {
        List<Status> GetStatuses();

        List<Ticket> GetTickets();
    }
}