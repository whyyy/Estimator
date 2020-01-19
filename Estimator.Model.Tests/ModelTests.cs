using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estimator.Model.Tests
{
    public class ModelTests
    {
        [TestCase("customField1", "details", 1)]
        [TestCase("", "", -1)]
        [TestCase("123", "123", 99999999)]
        public void TicketCustomField_CheckInstanceCreationForValidData_TicketCustomFieldInstance(
            string customFieldName, string customFieldDetails, int issueId)
        {
            TicketCustomField customField = new TicketCustomField(customFieldName, customFieldDetails, issueId);
            Assert.IsNotNull(customField);
            Assert.AreEqual(customFieldName, customField.Name);
            Assert.AreEqual(customFieldDetails, customField.Details);
            Assert.AreEqual(issueId, customField.IssueId);
        }

        [TestCase(1, "subject1", "01/01/2020", "01/30/2020", "02/01/2020", "02/16/2020", 3, "In testing", "customField1", "details", 1)]
        public void Ticket_CheckInstanceCreationForValidData_TicketInstance(
            int id, string subject, string startDate,
            string endDate, string uatStartDate, string uatEndDate,
            int status, string statusName, string customFieldName, string customFieldDetails, int issueId)
        {
            List<TicketCustomField> customFields = new List<TicketCustomField>();
            TicketCustomField customField = new TicketCustomField(customFieldName, customFieldDetails, issueId);
            customFields.Add(customField);

            DateTime? StartDate = Convert.ToDateTime(startDate);
            DateTime? EndDate = Convert.ToDateTime(endDate);
            DateTime? UatStartDate = Convert.ToDateTime(uatStartDate);
            DateTime? UatEndDate = Convert.ToDateTime(uatEndDate);

            Ticket ticket = new Ticket(id, subject, StartDate, EndDate, UatStartDate, UatEndDate, status, statusName, customFields);

            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(subject, ticket.Subject);
            Assert.IsNotNull(ticket);
        }
    }
}