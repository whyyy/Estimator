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
        public void RedmineConnectionProvider_DataLoadingFromConfigFile_PropertiesSet()
        {
            RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

            string Host = ConfigurationManager.AppSettings["Host"];

            string Api = ConfigurationManager.AppSettings["Api"];

            Assert.AreEqual(Host, RedmineConnectionProvider.Host);

            Assert.AreEqual(Api, RedmineConnectionProvider.Api);
        }

        [Test]
        public void RedmineConnection_ValidHostAndApi_RedmineConnectionEstablished()
        {
            RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

            RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionProvider.Host, RedmineConnectionProvider.Api);

            Assert.NotNull(RedmineConnection);

            Assert.NotNull(RedmineConnection.Host);
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