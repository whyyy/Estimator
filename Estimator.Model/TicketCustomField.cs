using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model
{
    public class TicketCustomField
    {
        public TicketCustomField(string name, string details)
        {
            Name = name;
            Details = details;
        }

        public string Name { get; set; }

        public string Details { get; set; }
    }
}
