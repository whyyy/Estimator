using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model
{
    class TestrailMilestone
    {
        public string MilestoneName { get; set; }
        public ulong MilestoneId { get; set; }
        public bool? IsStarted { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsCompleted { get; set; }

        public TestrailMilestone()
        {

        }

        public TestrailMilestone(string milestoneName, ulong milestoneId, bool? isStarted, DateTime? dueDate, bool? isCompleted)
        {
            MilestoneName = milestoneName;
            MilestoneId = milestoneId;
            IsStarted = isStarted;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
    }
}
