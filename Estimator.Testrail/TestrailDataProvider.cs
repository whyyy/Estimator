﻿using Estimator.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestRail;
using System.Linq;
using TestRail.Types;

namespace Estimator.Testrail
{
    public class TestrailDataProvider: ITestrailDataProvider
    {
        private List<TestRun> _testruns;

        private readonly ulong testrailId = Convert.ToUInt64(ConfigurationManager.AppSettings["testrailProjectId"]);

        public List<TestRun> Testruns;

        public TestrailConnectionProvider TestrailConnectionProvider = new TestrailConnectionProvider();

        public TestRailClient TestrailConnection { get; set; } = new TestRailClient(TestrailConnectionProvider.Url,
                                                                                    TestrailConnectionProvider.Login, 
                                                                                    TestrailConnectionProvider.Password);

        public TestrailDataProvider()
        {
            Testruns = GetTestRuns();
        }

        public List<TestRun> GetTestRuns()
        {   
            _testruns = new List<TestRun>();
            IEnumerable<Run> _runQuery = 
            from run in TestrailConnection.GetRuns(testrailId)
            select run;

            IEnumerable<TestRun> _testRunQuery =
            from run in _runQuery
            select new TestRun(run.Name, run.ID, run.PassedCount, run.Description, run.MilestoneID,
                                               run.UntestedCount, run.FailedCount, run.RetestCount, run.BlockedCount,
                                               run.CustomStatus1Count, run.CustomStatus2Count);

            foreach(var run in _testRunQuery)
            {
                _testruns.Add(run);
            }

            return _testruns;
        }

    }
}
