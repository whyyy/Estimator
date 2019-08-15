using Estimator.Helpers;
using Estimator.Model;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;

namespace Estimator.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        public ICommand FilterByStatusChosenCommand { get; set; }
        public ICommand CheckIsStartedCommand { get; set; }
        public ICommand DisplayTicketDetailsCommand { get; set; }
        public ICommand DisplayTestrailInfoCommand { get; set; }

        private GetStatuses getStatuses;
        public GetStatuses GetStatuses
        {
            get
            {
                return getStatuses;
            }
            set
            {
                getStatuses = value;
                RaisePropertyChanged("GetStatuses");
            }
        }
        private GetIssues getIssues;
        public GetIssues GetIssues
        {
            get
            {
                return getIssues;
            }
            set
            {
                getIssues = value;
                RaisePropertyChanged("GetIssues");
            }
        }


        private GetTestrailTestRuns getTestrailTestRuns;
        public GetTestrailTestRuns GetTestrailTestRuns
        {
            get
            {
                return getTestrailTestRuns;
            }
            set
            {
                getTestrailTestRuns = value;
                RaisePropertyChanged("GetTestrailTestRuns");
            }
        }

        public NameValueCollection Parameters { get; set; } = new NameValueCollection();
        public string ProjectId { get; set; } = ConfigurationSettings.AppSettings.Get("projectTasks");
        public string TrackerNp { get; set; } = ConfigurationSettings.AppSettings.Get("trackerNP");
        public string StatusEstimated { get; set; } = ConfigurationSettings.AppSettings.Get("statusEstimated");


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Ticket selectedStatus;
        public Ticket SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }
        private Ticket selectedTicket;
        public Ticket SelectedTicket
        {
            get
            {
                return selectedTicket;
            }
            set
            {
                selectedTicket = value;
                RaisePropertyChanged("SelectedTicket");
            }
        }
        private Ticket startDate;
        public Ticket StartDate
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

        public IssueWindowViewModel()
        {
            GetStatuses = new GetStatuses("tracker_id", TrackerNp);
            FilterByStatusChosenCommand = new Commander(FilterByStatusChosen, CanFilterByStatusChosen);
            CheckIsStartedCommand = new Commander(CheckIsStarted, CanCheckIsStarted);
            DisplayTicketDetailsCommand = new Commander(DisplayTicketDetails, CanDisplayTicketDetails);
            DisplayTestrailInfoCommand = new Commander(DisplayTestrailInfo, CanDisplayTestrailInfo);
        }

        private void FilterByStatusChosen(object obj)
        {
            Parameters.Clear();
            Parameters.Add("tracker_id", TrackerNp);
            Parameters.Add("status_id", SelectedStatus.StatusId.ToString());
            GetIssues = new GetIssues(Parameters);
        }

        private bool CanFilterByStatusChosen(object obj)
        {
            if (SelectedStatus != null)
                return true;
            return false;
        }
        private void DisplayTestrailInfo(object obj)
        {
            GetTestrailTestRuns = new GetTestrailTestRuns(Convert.ToUInt64(SelectedTicket.TestrailId));
        }


        private bool CanDisplayTestrailInfo(object obj)
        {
            if (SelectedTicket != null)
                return true;
            return false;

        }

        private void DisplayTicketDetails(object obj)
        {
            Parameters.Add("ticket_id", SelectedTicket.Id.ToString());
            GetIssues = new GetIssues(Parameters);
        }

        private bool CanDisplayTicketDetails(object obj)
        {
            if (SelectedTicket != null)
                return true;
            return false;
        }


        private void CheckIsStarted(object obj)
        {

            GetIssues.Issues.Select(x => { x.StartDate = DateTime.Today; return x; }).ToList();

        }

        private bool CanCheckIsStarted(object obj)
        {
            if (SelectedStatus.StatusId == 7)
                return true;
            return false;
        }
    }
}
