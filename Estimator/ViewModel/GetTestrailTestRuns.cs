using Estimator.Helpers;
using Estimator.Model;
using System.Collections.Generic;
using System.ComponentModel;
using TestRail;


namespace Estimator.ViewModel
{
    class GetTestrailTestRuns : INotifyPropertyChanged
    {
        public TestRailClient Connection { get; set; } = new TestRailClient("https://binashombre.testrail.io/", "matib95@gmail.com", "h0A4GCUnFS4Fi/XbaS1V");

        private List<TestrailTestRun> testRuns = new List<TestrailTestRun>();
        public List<TestrailTestRun> TestRuns
        {
            get
            {
                return testRuns;
            }
            set
            {
                testRuns = value;
                RaisePropertyChanged("TestRuns");
            }
        }
        private List<TestrailTestRun> selectedTestRuns = new List<TestrailTestRun>();
        public List<TestrailTestRun> SelectedTestRuns
        {
            get
            {
                return selectedTestRuns;
            }
            set
            {
                selectedTestRuns = value;
                RaisePropertyChanged("SelectedTestRuns");
            }
        }
        public GetTestrailTestRuns()
        {
            foreach (var testRun in Connection.GetRuns(1))
            {
                testRuns.Add(new TestrailTestRun(testRun.Name, testRun.ID, testRun.PassedCount, testRun.Description, testRun.MilestoneID, testRun.UntestedCount, testRun.FailedCount, testRun.CustomStatus1Count));
            }
        }
        public GetTestrailTestRuns(ulong? milestoneId)
        {
            foreach (var testRun in Connection.GetRuns(1))
            {
                testRuns.Add(new TestrailTestRun(testRun.Name, testRun.ID, testRun.PassedCount, testRun.Description, testRun.MilestoneID, testRun.UntestedCount, testRun.FailedCount, testRun.CustomStatus1Count));
            }
            foreach (var testRun in testRuns)
            {
                if (testRun.MilestoneId.Equals(milestoneId))
                {
                    selectedTestRuns.Add(new TestrailTestRun(testRun.Name, testRun.Id, testRun.PassedCounter, testRun.Description, testRun.MilestoneId, testRun.UntestedNumber, testRun.FailedNumber, testRun.WarningCasesNumber));
                }
            }
            selectedTestRuns.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
