using Redmine.Net.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Redmine
{
    public interface IRedmineConnectionProvider
    {
        RedmineManager GetRedmineConnection();
    }
}