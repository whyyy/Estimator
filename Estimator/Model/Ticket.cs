using Redmine.Net.Api.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Estimator.Model
{
    public class Ticket : INotifyPropertyChanged
    {
        public Ticket(string statusName, int statusId)
        {
            StatusName = statusName;
            StatusId = statusId;
        }
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
        public Ticket(int id, string subject, DateTime? startDate,
           DateTime? endDate, DateTime? uatStartDate, DateTime? uatEndDate,
           int status, string statusName, IList<IssueCustomField> customFields, string testrailId)
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
            TestrailId = testrailId;
        }
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string subject;
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                RaisePropertyChanged("Subject");
            }
        }
        private DateTime? startDate;
        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        private DateTime? endDate;
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }
        private DateTime? uatStartDate;
        public DateTime? UatStartDate
        {
            get
            {
                return uatStartDate;
            }
            set
            {
                uatStartDate = value;
                RaisePropertyChanged("UatStartDate");
            }
        }
        private DateTime? uatEndDate;
        public DateTime? UatEndDate
        {
            get
            {
                return uatEndDate;
            }
            set
            {
                uatEndDate = value;
                RaisePropertyChanged("UatEndDate");
            }
        }
        private int statusId;
        public int StatusId
        {
            get
            {
                return statusId;
            }
            set
            {
                statusId = value;
                RaisePropertyChanged("StatusId");
            }
        }
        private string statusName;
        public string StatusName
        {
            get
            {
                return statusName;
            }
            set
            {
                statusName = value;
                RaisePropertyChanged("StatusName");
            }
        }
        private IList<IssueCustomField> customFields;
        public IList<IssueCustomField> CustomFields
        {
            get
            {
                return customFields;
            }
            set
            {
                customFields = value;
                RaisePropertyChanged("CustomFields");
            }
        }
        private string testrailId;
        public string TestrailId
        {
            get
            {
                return testrailId;
            }
            set
            {
                testrailId = value;
                RaisePropertyChanged("TestrailId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

