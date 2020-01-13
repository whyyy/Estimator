using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Testrail
{
    public class TestrailConnectionProvider : ITestrailConnectionProvider
    {

        public TestrailConnectionProvider()
        {
            GetTestrailConnectionDetails();
        }


        public static string Url { get; set; }

        public static string Login { get; set; }

        public static string Password { get; set; }

        public TestrailConnectionDetails GetTestrailConnectionDetails()
        {
            Url = ConfigurationManager.AppSettings["testrailUrl"];
            Login = ConfigurationManager.AppSettings["testrailLogin"];
            Password = ConfigurationManager.AppSettings["testrailPassword"];
            return new TestrailConnectionDetails(Url, Login, Password);
        }
    }
}
