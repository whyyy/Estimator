using Estimator.Testrail;
using Estimator.Redmine;
using System.Collections.Generic;
using Estimator.Model;
using System;
using System.Linq;

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
            Tickets = RedmineData.Tickets
                .Where(ticket => ticket.StatusId.Equals(selectedStatusId))
                .Select(ticket => ticket)
                .ToList();

            return Tickets;
        }

        public List<TestRun> GetTestruns(ulong? milestoneId)
        {
            Testruns = TestrailData.Testruns
                .Where(testrun => testrun.MilestoneId.Equals(milestoneId))
                .Select(testrun => testrun)
                .ToList();
                
            return Testruns;
        }

        public ulong? GetMilestoneId(Ticket ticket)
        {
            ulong? milestoneId = null;

            var customFieldQuery = ticket.CustomFields
                .Where(customFieldName => customFieldName.Name.Equals("Testrail id"))
                .SelectMany(customField => customField.Details
                .Select(customFieldDetails => Convert.ToUInt32(customField.Details)));

            return milestoneId;
        }

    }
}
