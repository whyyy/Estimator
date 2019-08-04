using Estimator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRail;


namespace Estimator.ViewModel
{
    class GetTestrailProjects
    {
        public TestRailClient Connection { get; set; } = new TestRailClient("https://binashombre.testrail.io/", "matib95@gmail.com", "h0A4GCUnFS4Fi/XbaS1V");
        public List<TestrailMilestone> Milestones { get; set; } = new List<TestrailMilestone> ();

        public GetTestrailProjects()
        {
            foreach(var milestone in Connection.GetMilestones(1))
            {
                Milestones.Add(new TestrailMilestone(milestone.Name, milestone.ID, milestone.IsStarted, milestone.DueOn, milestone.IsCompleted));
            }

        }
    }
}
