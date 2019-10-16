using Estimator.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestRail;

namespace Estimator.Testrail
{
    public class TestrailDataProvider
    {
        private TestRailClient _testrailConnection { get; set; } = new TestRailClient("https://binashombre.testrail.io/", 
            "matib95@gmail.com", "h0A4GCUnFS4Fi/XbaS1V");

        private List<TestRun> _testRuns;

        private readonly ulong testrailId = Convert.ToUInt64(ConfigurationManager.AppSettings["testrailProjectId"]);

        public List<TestRun> Testruns;

        public TestrailDataProvider(string milestoneId)
        {
            Testruns = GetTestRuns();
        }

        List<TestRun> GetTestRuns()
        {
            _testRuns = new List<TestRun>();
            foreach (var testRun in _testrailConnection.GetRuns(testrailId))
            {
                _testRuns.Add(new TestRun(testRun.Name, testRun.ID, testRun.PassedCount, testRun.Description, testRun.MilestoneID, 
                    testRun.UntestedCount, testRun.FailedCount, testRun.CustomStatus1Count));
            }
            return _testRuns;
        }
    }
}
