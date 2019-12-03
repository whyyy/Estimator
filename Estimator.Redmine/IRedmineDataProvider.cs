using Estimator.Model;
using System.Collections.Generic;

namespace Estimator.Redmine
{
    public interface IRedmineDataProvider
    {
        List<Status> GetStatuses();

        List<Ticket> GetTickets();

    }
}