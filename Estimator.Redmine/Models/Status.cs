using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Redmine.Model
{
    public class Status
    {
        public Status(int id, string status)
        {
            Id = id;
            StatusName = status;
        }
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
