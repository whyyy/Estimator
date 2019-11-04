using Estimator.Testrail;
using Estimator.Redmine;
using System.Collections.Generic;
using Estimator.Model;
using System;

namespace Estimator.Data
{
    public class DataProvider: IDataProvider
    {
        private RedmineDataProvider _redmineData;

        private TestrailDataProvider _testrailData;

        public DataProvider()
        {
            RedmineData = GetRedmineData();
            TestrailData = GetTestrailData();
        }

        public List<Ticket> Tickets { get; set; }

        public List<TestRun> Testruns { get; set; }

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

        public TestrailDataProvider GetTestrailData()
        {
            _testrailData = new TestrailDataProvider();
            return _testrailData;
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

        public List<TestRun> GetTestruns(ulong? milestoneId)
        {
            Testruns = new List<TestRun>();
            foreach(TestRun testrun in TestrailData.Testruns)
                if (testrun.MilestoneId.Equals(milestoneId))
                {
                    Testruns.Add(testrun);
                }
            return Testruns;
        }

        public ulong? GetMilestoneId(Ticket ticket)
        {
            ulong? milestoneId = null;
            foreach (var customField in ticket.CustomFields)
            {
                if (customField.Name.Equals("Testrail id"))
                {
                    milestoneId = Convert.ToUInt32(customField.Details);
                }
            }
            return milestoneId;
        }

    }
}
