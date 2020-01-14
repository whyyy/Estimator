using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model
{
    public class TicketCustomField
    {
        public TicketCustomField(string name, string details, int issueId)
        {

            Name = name;
            Details = details;
            IssueId = issueId;
        }

        public string Name { get; set; }

        public string Details { get; set; }

        public int IssueId { get; set; }

    }
}
