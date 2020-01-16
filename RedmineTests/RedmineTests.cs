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
        public void TestRedmineConnectionDetailsLoading()
        {
            RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

            string Host = ConfigurationManager.AppSettings["Host"];

            string Api = ConfigurationManager.AppSettings["Api"];

            Assert.AreEqual(Host, RedmineConnectionProvider.Host);

            Assert.AreEqual(Api, RedmineConnectionProvider.Api);
        }

        [Test]
        public void TestRedmineConnectionEstablishing()
        {
            RedmineConnectionProvider RedmineConnectionProvider = new RedmineConnectionProvider();

            RedmineManager RedmineConnection = new RedmineManager(RedmineConnectionProvider.Host, RedmineConnectionProvider.Api);

            Assert.NotNull(RedmineConnection);

            Assert.NotNull(RedmineConnection.Host);
        }

        [Test]
        public void TestParametersLoading()
        {
            string _trackerId = ConfigurationManager.AppSettings["tracker"];

            NameValueCollection Parameters = new NameValueCollection();

            Assert.IsEmpty(Parameters);

            Parameters.Add("tracker_id", _trackerId);

            Assert.IsNotEmpty(Parameters);
        }

        [Test]
        public void TestRedmineProviderCreating()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.NotNull(RedmineDataProvider);
        }

        [Test]
        public void TestStatusesCreating()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.IsNotEmpty(RedmineDataProvider.Statuses);
        }

        [Test]
        public void TestTicketsCreating()
        {
            RedmineDataProvider RedmineDataProvider = new RedmineDataProvider();

            Assert.IsNotEmpty(RedmineDataProvider.Tickets);
        }

    }
}
