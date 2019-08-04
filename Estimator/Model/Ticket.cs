using System;

namespace Estimator.Model
{
    public class Ticket
    {
        public Ticket(string statusName, int statusId)
        {
            StatusName = statusName;
            StatusId = statusId;
        }
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

        public int Id { get; }
        public String Subject { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime? UatStartDate { get; private set; }
        public DateTime? UatEndDate { get; private set; }
        public int StatusId { get; private set; }
        public string StatusName { get; set; }


    }
}

