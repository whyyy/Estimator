namespace Estimator.Model
{
    class RedmineTracker
    {
        public string TrackerName { get; set; }
        public int TrackerId { get; set; }
        public RedmineTracker(string trackerName, int trackerId)
        {
            TrackerName = trackerName;
            TrackerId = trackerId;
        }
    }
}
