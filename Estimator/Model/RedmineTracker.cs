using System.ComponentModel;

namespace Estimator.Model
{
    class RedmineTracker : INotifyPropertyChanged
    {
        private string trackerName;
        public string TrackerName
        {
            get
            {
                return trackerName;
            }
            set
            {
                trackerName = value;
                RaisePropertyChanged("TrackerName");
            }
        }
        private int trackerId;
        public int TrackerId
        {
            get
            {
                return trackerId;
            }
            set
            {
                trackerId = value;
                RaisePropertyChanged("TrackerId");
            }
        }
        public RedmineTracker(string trackerName, int trackerId)
        {
            TrackerName = trackerName;
            TrackerId = trackerId;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));    
        }
    }
}
