using Estimator.Model;
using Estimator.Redmine;
using Estimator.Testrail;
using System.Collections.Generic;

namespace Estimator.Data
{
    public interface IDataProvider
    {
        Status Status { get; set; }
        Ticket Ticket { get; set; }

        List<Ticket> GetTickets(int selectedStatusId);

        RedmineDataProvider GetRedmineData();

        TestrailDataProvider GetTestrailData();

        List<TestRun> GetTestruns(ulong? milestoneId);

        ulong? GetMilestoneId(Ticket selectedTicket);
    }
}