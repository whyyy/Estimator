using Estimator.Model;
using Estimator.Redmine;
using NUnit.Framework;
using Redmine.Net.Api;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineTests
{
    [TestFixture]
    public class RedmineTests
    {
        [Test]
        public void GetRedmineConnection__CreateRedmineConnectionProviderInstance_RedmineConnectionEstablished()
        {
            RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

            Assert.NotNull(RedmineConnectionProvider.RedmineConnection);
        }

        [Test]
        public void NameValueCollection_TrackerIdFromConfigFile_CollectionWithItemValuesSet()
        {
            string _trackerId = ConfigurationManager.AppSettings["tracker"];

            NameValueCollection Parameters = new NameValueCollection();

            Assert.IsEmpty(Parameters);

            Parameters.Add("tracker_id", _trackerId);

            Assert.IsNotEmpty(Parameters);
        }

        [Test]
        public void RedmineDataProvider_InstanceCreation_RedmineDataProviderInstance()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.NotNull(RedmineDataProvider);
        }

        [Test]
        public void RedmineDataProvider_StatusesInstancesCreation_RedmineDataProviderStatuses()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.IsNotEmpty(RedmineDataProvider.Statuses);
        }

        [Test]
        public void RedmineDataProvider_TicketsInstancesCreation_RedmineDataProviderTickets()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.IsNotEmpty(RedmineDataProvider.Tickets);
        }
    }
}