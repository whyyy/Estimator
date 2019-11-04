using Estimator.Model;
using Estimator.Redmine;
using Estimator.Testrail;
using System.Collections.Generic;

namespace Estimator.Data
{
    public interface IDataProvider
    {
        List<Ticket> GetTickets(int selectedStatusId);

        RedmineDataProvider GetRedmineData();

        TestrailDataProvider GetTestrailData();
    }
}