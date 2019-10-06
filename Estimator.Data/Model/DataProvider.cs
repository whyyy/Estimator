using Estimator.Testrail.Model;
using Estimator.Redmine.Model;
using System.Collections.Generic;

namespace Estimator.Data.Model
{
    public class DataProvider
    {
        private RedmineDataProvider _redmineData;

        public DataProvider()
        {
            RedmineData = GetRedmineData();
        }

        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public RedmineDataProvider RedmineData { get; set; }
        public TestrailDataProvider TestrailData { get; set; }
        public Status Status { get; set; }
        public Ticket Ticket { get; set; }
        public TestRun Testrun { get; set; }

        public RedmineDataProvider GetRedmineData()
        {
            _redmineData = new RedmineDataProvider();
            return _redmineData;
        }
        public List<Ticket> GetTickets(int selectedStatusId)
        {
            Tickets = new List<Ticket>();
            foreach (Ticket ticket in RedmineData.Tickets)
            {
                if (ticket.StatusId.Equals(selectedStatusId))
                {
                    Tickets.Add(ticket);
                }
            }
            return Tickets;
        }
    }
}
