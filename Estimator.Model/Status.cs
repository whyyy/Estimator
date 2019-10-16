namespace Estimator.Model
{
    public class Status
    {
        public Status(int id, string status)
        {
            Id = id;
            StatusName = status;
        }

        public int Id { get; set; }

        public string StatusName { get; set; }
    }
}
