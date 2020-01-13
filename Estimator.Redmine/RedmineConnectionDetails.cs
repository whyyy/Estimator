using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Redmine
{
    public class RedmineConnectionDetails
    {
        public RedmineConnectionDetails(string host, string api)
        {
            Host = host;
            Api = api;
        }

        public static string Host { get; set; }

        public static string Api { get; set; }
    }
}
