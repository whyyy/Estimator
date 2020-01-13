using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Testrail
{
    public class TestrailConnectionDetails
    {

        public TestrailConnectionDetails(string url, string login, string password)
        {
            Url = url;
            Login = login;
            Password = password;
        }

        public static string Url { get; set; }

        public static string Login { get; set; }

        public static string Password { get; set; }
    }
}
