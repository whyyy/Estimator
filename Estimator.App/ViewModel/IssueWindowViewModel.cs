using Estimator.App.Helpers;
using Estimator.Data;
using Estimator.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Estimator.App.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        private DataProvider _loadedData;

        private List<Status> _statuses;

        private List<Ticket> _tickets;

        public event PropertyChangedEventHandler PropertyChanged;

        public IssueWindowViewModel()
        {
            FilterByStatusChosenCommand = new Commander(_filterByStatusChosen, _canFilterByStatusChosen);
            _loadedData = new DataProvider();
            _statuses = _loadedData.RedmineData.Statuses;
            Statuses = _statuses;
        }

        public ICommand FilterByStatusChosenCommand { get; set; }

        public ICommand DisplaySettingsWindowCommand { get; set; }

        public RelayCommand ShowSettingsView { private set; get; }

        public Status SelectedStatus
        {
            get
            {
                return _loadedData.Status;
            }
            set
            {
                _loadedData.Status = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public Ticket SelectedTicket
        {
            get
            {
                return _loadedData.Ticket;
            }
            set
            {
                _loadedData.Ticket = value;
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

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void _filterByStatusChosen(object obj)
        {
            _tickets = new List<Ticket>();
            _tickets = _loadedData.GetTickets(SelectedStatus.Id);
            Tickets = _tickets;
        }

        private bool _canFilterByStatusChosen(object obj)
        {
            if (SelectedStatus != null)
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
