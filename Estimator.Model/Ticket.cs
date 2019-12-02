using System;
using System.Collections.Generic;

namespace Estimator.Model
{
    public class Ticket 
    {

        public Ticket(int id, string subject, DateTime? startDate,
            DateTime? endDate, DateTime? uatStartDate, DateTime? uatEndDate,
            int status, string statusName)
        {
            Id = id;
            Subject = subject;
            StartDate = startDate;
            EndDate = endDate;
            UatStartDate = uatStartDate;
            UatEndDate = uatEndDate;
            StatusId = status;
            StatusName = statusName;
        }

        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? UatStartDate { get; set; }

        public DateTime? UatEndDate { get; set; }

        public int  StatusId { get; set; }

        public string StatusName { get; set; }

        public List<TicketCustomField> CustomFields { get; set; }

        public ulong? MilestoneId { get; set; }
        
        public string CustomFieldName { get; set; }

        public string  CustomFieldDetails { get; set; }
    }
}

