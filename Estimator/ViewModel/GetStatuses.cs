using Estimator.Helpers;
using Estimator.Model;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Estimator.ViewModel
{
    class GetStatuses : INotifyPropertyChanged
    {
        RedmineManager Connection = new RedmineManager("http://127.0.0.1/redmine/", "e698087c45046c4e5b45e7b666fc3aa51d94f37f");
        private ObservableCollection<Ticket> statuses = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket> Statuses
        {
            get
            {
                return statuses;
            }
            set
            {
                //new ObservableCollection<Ticket>();
                statuses = value;
                RaisePropertyChanged("Statuses");
            }
        }

        NameValueCollection Parameters = new NameValueCollection();
        public GetStatuses(string key, string value)
        {
            Parameters.Add(key, value);
            foreach (var status in Connection.GetObjects<IssueStatus>(Parameters))
            {
                statuses.Add(new Ticket(status.Name, status.Id));
            }
            statuses.ToObservableCollection();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
