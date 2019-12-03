using Estimator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Testrail
{
    public interface ITestrailDataProvider
    {
        List<TestRun> GetTestRuns();
    }
}
