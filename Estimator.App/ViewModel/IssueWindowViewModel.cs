using Estimator.Data.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Data;
using System.Windows.Input;
using Estimator.Data.Helpers;
using System.Windows;
using Estimator.App.View;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Estimator.App.ViewModel
{
    class IssueWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand FilterByStatusChosenCommand { get; set; }

        private void FilterByStatusChosen(object obj)
        {
            Issues = new DataProvider("status_id", SelectedStatus.Id.ToString());
        }   

        private bool _canFilterByStatusChosen(object obj)
        {
            if (SelectedStatus != null)
                return true;
            return false;
        }
        public ICommand DisplaySettingsWindowCommand { get; set; }
        private void DisplaySettingsWindow()
        {
            Messenger.Default.Send(new NotificationMessage("SettingsView"));
        }
        private bool _canDisplaySettingsWindow(object obj)
        {
            return true;
        }

        public RelayCommand ShowSettingsView { private set; get; }

        public IssueWindowViewModel() 
        {
            FilterByStatusChosenCommand = new Commander(FilterByStatusChosen, _canFilterByStatusChosen);
            _statuses = new DataProvider();
    }
        
        private Status _selectedStatus;
        public Status SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }
        private Ticket _selectedIssue;
        public Ticket SelectedIssue
        {
            get
            {
                return _selectedIssue;
            }
            set
            {
                _selectedIssue = value;
                RaisePropertyChanged("SelectedIssue");
            }
        }

        private DataProvider _issues;
        public DataProvider Issues
        {
            get
            {
                return _issues;
            }
            set
            {
                _issues = value;
                RaisePropertyChanged("Issues");
            }
        }
        private DataProvider _statuses;
        public DataProvider Statuses
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
    }
}
