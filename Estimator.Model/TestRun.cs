using System;

namespace Estimator.Model
{
    public class TestRun 
    {
        public TestRun(string name, ulong? iD, uint? passedCount, string description, ulong? milestoneId, uint? untestedNumber, 
            uint? failedNumber, uint? retestNumber, uint? blockedNumber, ulong warningNumber, ulong? onHoldNumber)
        {
            Name = name;
            Id = iD;
            PassedCounter = passedCount;
            Description = description;
            MilestoneId = milestoneId;
            UntestedNumber = untestedNumber;
            FailedNumber = failedNumber;
            RetestNumber = retestNumber;
            BlockedNumber = blockedNumber;
            WarningNumber = warningNumber;
            OnHoldNumber = onHoldNumber;
        }

        public ulong? Id { get; set; }

        public string Name { get; set; }

        public uint? PassedCounter { get; set; }

        public string Description { get; set; }

        public ulong? MilestoneId { get; set; }

        public uint? UntestedNumber { get; set; }

        public uint? FailedNumber { get; set; }

        public uint? RetestNumber { get; set; }

        public uint? BlockedNumber { get; set; }

        public ulong? OnHoldNumber { get; private set; }

        public ulong WarningNumber { get; set; }

        public int TotalNumber { get; set; }

        public int CoverageNumber { get; set; }

        public int GetTotalNumber()
        {
            TotalNumber = Convert.ToInt32(PassedCounter + UntestedNumber + FailedNumber +
               RetestNumber + BlockedNumber + WarningNumber + OnHoldNumber);
            return TotalNumber;
        }

        public int GetCoverageNumber()
        {
            CoverageNumber = Convert.ToInt32(PassedCounter + FailedNumber + WarningNumber);
                return CoverageNumber;
        }
    }
}
