using Estimator.App.Helpers;
using Estimator.Data.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Estimator.App.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        private void _filterByStatusChosen(object obj)
        {
            _tickets = new DataProvider("status_id", SelectedStatus.Id.ToString());
            Tickets = _tickets.Tickets;
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
        private DataProvider _tickets;
        private DataProvider _statuses;
        public IssueWindowViewModel()
        {
            FilterByStatusChosenCommand = new Commander(_filterByStatusChosen, _canFilterByStatusChosen);
            _statuses = new DataProvider();
            Statuses = _statuses.Statuses;
        }
        public ICommand FilterByStatusChosenCommand { get; set; }
        public ICommand DisplaySettingsWindowCommand { get; set; }
        public RelayCommand ShowSettingsView { private set; get; }
        public Status SelectedStatus
        {
            get
            {
                return _statuses.Status;
            }
            set
            {
                _statuses.Status = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }
        public Ticket SelectedTicket
        {
            get
            {
                return _tickets.Ticket;
            }
            set
            {
                _tickets.Ticket = value;
                RaisePropertyChanged("SelectedTicket");
            }
        }
        public List<Ticket> Tickets
        {
            get
            {
                return _tickets.Tickets;
            }
            set
            {
                _tickets.Tickets = value;
                RaisePropertyChanged("Tickets");
            }
        }
        public List<Status> Statuses
        {
            get
            {
                return _statuses.Statuses;
            }
            set
            {
                _statuses.Statuses = value;
                RaisePropertyChanged("Statuses");
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
