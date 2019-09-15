using System.Collections.Generic;
using Redmine.Net;
using Redmine.Net.Api.Types;
using Estimator.Redmine;
using Redmine.Net.Api;
using System.ComponentModel;
using System.Collections.Specialized;

using System.Linq;
using TestRail;

namespace Estimator.Data.Model
{
    public class DataProvider
    {
        private static RedmineConnectionDetails _redmineConnectionDetails = new RedmineConnectionDetails();
        private TestRailClient _testrailConnection { get; set; } = new TestRailClient("https://binashombre.testrail.io/", "matib95@gmail.com", "h0A4GCUnFS4Fi/XbaS1V");
        public DataProvider()
        {
            Tickets = new List<Ticket>();
            foreach (var issue in RedmineConnection.GetObjects<Issue>("tracker_id", "4"))
            {
                Tickets.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            Statuses = new List<Status>();
            foreach (var status in RedmineConnection.GetObjects<IssueStatus>("tracker_id", "4"))
            {
                Statuses.Add(new Status(status.Id, status.Name));
            }
        }
        public DataProvider(string milestoneId)
        {
            foreach (var testRun in _testrailConnection.GetRuns(1))
            {
                Testruns.Add(new TestRun(testRun.Name, testRun.ID, testRun.PassedCount, testRun.Description, testRun.MilestoneID, testRun.UntestedCount, testRun.FailedCount, testRun.CustomStatus1Count));
            }
            foreach (var testRun in Testruns)
            {
                if (testRun.MilestoneId.Equals(milestoneId))
                {
                    SelectedTestruns.Add(new TestRun(testRun.Name, testRun.Id, testRun.PassedCounter, testRun.Description, testRun.MilestoneId, testRun.UntestedNumber, testRun.FailedNumber, testRun.WarningCasesNumber));
                }
            }

        }
        public DataProvider(string key, string value)
        {
            Tickets = new List<Ticket>();
            Parameters.Add("tracker_id", "4");
            Parameters.Add(key, value);
            foreach (var issue in RedmineConnection.GetObjects<Issue>(Parameters))
            {
                Tickets.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
        }
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public List<TestRun> Testruns { get; set; }
        public List<TestRun> SelectedTestruns { get; set; }
        public Status Status { get; set; }
        public Ticket Ticket { get; set; }
        public TestRun Testrun { get; set; }
        public NameValueCollection Parameters = new NameValueCollection();
        public RedmineManager RedmineConnection = new RedmineManager(_redmineConnectionDetails.Host, _redmineConnectionDetails.Api); 
    }
}
