using Estimator.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestRail;

namespace Estimator.Testrail
{
    public class TestrailDataProvider
    {
        private List<TestRun> _testruns;

        private readonly ulong testrailId = Convert.ToUInt64(ConfigurationManager.AppSettings["testrailProjectId"]);

        public List<TestRun> Testruns;

        public TestrailConnectionProvider TestrailConnectionProvider = new TestrailConnectionProvider();

        public TestRailClient TestrailConnection { get; set; } = new TestRailClient(TestrailConnectionProvider.Url,
            TestrailConnectionProvider.Login, TestrailConnectionProvider.Password);

        public TestrailDataProvider()
        {
            Testruns = GetTestRuns();
        }

        public List<TestRun> GetTestRuns()
        {   
            _testruns = new List<TestRun>();
            foreach (var run in TestrailConnection.GetRuns(1))
            {
                TestRun testrun = new TestRun(run.Name, run.ID, run.PassedCount, run.Description, run.MilestoneID,
                    run.UntestedCount, run.FailedCount, run.RetestCount, run.BlockedCount, run.CustomStatus1Count, run.CustomStatus2Count);
                testrun.TotalNumber = testrun.GetTotalNumber();
                testrun.CoverageNumber = testrun.GetCoverageNumber();
                _testruns.Add(testrun);
            }
            return _testruns;
        }

    }
}
