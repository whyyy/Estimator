﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Testrail
{
    public interface ITestrailConnectionProvider
    {
        TestrailConnectionProvider GetTestrailConnectionDetails();
    }
}