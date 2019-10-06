namespace Estimator.Testrail.Model
{
    public class TestRun 
    {
        public TestRun(string name, ulong? iD, uint? passedCount, string description, ulong? milestoneId, uint? untestedNumber, uint? failedNumber, ulong warningCasesNumber)
        {
            Name = name;
            Id = iD;
            PassedCounter = passedCount;
            Description = description;
            MilestoneId = milestoneId;
            UntestedNumber = untestedNumber;
            FailedNumber = failedNumber;
            WarningCasesNumber = warningCasesNumber;
        }
        public ulong? Id { get; set; }
        public string Name { get; set; }
        public uint? PassedCounter { get; set; }
        public string Description { get; set; }
        public ulong? MilestoneId { get; set; }
        public uint? UntestedNumber { get; set; }
        public uint? FailedNumber { get; set; }
        public ulong WarningCasesNumber { get; set; }
    }
}
