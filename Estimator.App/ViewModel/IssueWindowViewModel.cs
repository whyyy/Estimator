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
            _issues = new DataProvider("status_id", SelectedStatus.Id.ToString());
            Issues = _issues.Issues;
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
        private DataProvider _issues;
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
        public Ticket SelectedIssue
        {
            get
            {
                return _issues.Issue;
            }
            set
            {
                _issues.Issue = value;
                RaisePropertyChanged("SelectedIssue");
            }
        }
        public List<Ticket> Issues
        {
            get
            {
                return _issues.Issues;
            }
            set
            {
                _issues.Issues = value;
                RaisePropertyChanged("Issues");
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
