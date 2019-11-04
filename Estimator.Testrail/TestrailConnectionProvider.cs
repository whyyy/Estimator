using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Testrail
{
    public class TestrailConnectionProvider
    {
        private TestrailConnectionProvider _testrailConnectionDetails;

        public TestrailConnectionProvider()
        {
            GetTestrailConnectionDetails();
        }

        public TestrailConnectionProvider(string url, string login, string password)
        {
           
        }

        public static string Url { get; set; }

        public static string Login { get; set; }

        public static string Password { get; set; }

        public TestrailConnectionProvider GetTestrailConnectionDetails()
        {
            Url = ConfigurationManager.AppSettings["testrailUrl"];
            Login = ConfigurationManager.AppSettings["testrailLogin"];
            Password = ConfigurationManager.AppSettings["testrailPassword"];
            return _testrailConnectionDetails = new TestrailConnectionProvider(Url, Login, Password);
        }
    }
}
