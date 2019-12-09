using Estimator.App.Helpers;
using Estimator.Data;
using Estimator.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Estimator.App.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {

        private List<Status> _statuses;

        private List<Ticket> _tickets;

        private List<TestRun> _testruns;
    
        private readonly IDataProvider _dataProvider;

        public event PropertyChangedEventHandler PropertyChanged;

        public IssueWindowViewModel()
        {
            FilterByStatusChosenCommand = new Commander(_filterByStatusChosen, _canFilterByStatusChosen);
            _dataProvider = new DataProvider();
            _statuses = _dataProvider.GetRedmineData().Statuses;
            Statuses = _statuses;
            DisplayTestruns = new Commander(_displayTestrun, _canDisplayTestrun);
        }

        public ICommand FilterByStatusChosenCommand { get; set; }

        public ICommand DisplaySettingsWindowCommand { get; set; }

        public ICommand DisplayTestruns { get; set; }

        public RelayCommand ShowSettingsView { private set; get; }

        public Status SelectedStatus
        {
            get
            {
                return _dataProvider.Status;
            }
            set
            {
                _dataProvider.Status = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public Ticket SelectedTicket
        {
            get
            {
                return _dataProvider.Ticket;
            }
            set
            {
                _dataProvider.Ticket = value;
                RaisePropertyChanged("SelectedTicket");
            }
        }

        public List<Ticket> Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                _tickets = value;
                RaisePropertyChanged("Tickets");
            }
        }

        public List<Status> Statuses
        {
            get
            {
                return _statuses;
            }
            set
            {
                _statuses = value;
                RaisePropertyChanged("Statuses");
            }
        }

        public List<TestRun> TestRuns
        {
            get
            {
                return _testruns;
            }
            set
            {
                _testruns = value;
                RaisePropertyChanged("TestRuns");
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void _filterByStatusChosen(object obj)
        {
            _tickets = new List<Ticket>();
            _tickets = _dataProvider.GetTickets(SelectedStatus.Id);
            Tickets = _tickets;
        }

        private bool _canFilterByStatusChosen(object obj)
        {
            if (SelectedStatus != null)
                return true;
            return false;
        }

        private void _displayTestrun(object obj)
        {
            _testruns = new List<TestRun>();
            SelectedTicket.MilestoneId = _dataProvider.GetMilestoneId(SelectedTicket);
            _testruns = _dataProvider.GetTestruns(Convert.ToUInt32(SelectedTicket.MilestoneId));
            TestRuns = _testruns;
        }

        private bool _canDisplayTestrun(object obj)
        {
            if (SelectedTicket != null)
                return true;
            return false;
        }

        private void _displaySettingsWindow()
        {
            Messenger.Default.Send(new NotificationMessage("SettingsView"));
        }

        private bool _canDisplaySettingsWindow(object obj)
        {
            return true;
        }
    }
}
