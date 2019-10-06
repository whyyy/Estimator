﻿using Redmine.Net.Api.Types;
using System;
using System.Collections.Generic;

namespace Estimator.Redmine.Model
{
    public class Ticket 
    {
        public Ticket(int id, string subject, DateTime? startDate,
            DateTime? endDate, DateTime? uatStartDate, DateTime? uatEndDate,
            int status, string statusName, IList<IssueCustomField> customFields)
        {
            Id = id;
            Subject = subject;
            StartDate = startDate;
            EndDate = endDate;
            UatStartDate = uatStartDate;
            UatEndDate = uatEndDate;
            StatusId = status;
            StatusName = statusName;
            CustomFields = customFields;
        }
       
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UatStartDate { get; set; }
        public DateTime? UatEndDate { get; set; }
        public int  StatusId { get; set; }
        public string StatusName { get; set; }
        public IList<IssueCustomField> CustomFields { get; set; }
        public string MilestoneId { get; set; }
    }
}
