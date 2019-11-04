using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Redmine
{
    public interface IRedmineConnectionProvider
    {
        RedmineConnectionProvider GetRedmineConnectionDetails();
    }
}
