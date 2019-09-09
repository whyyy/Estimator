﻿using System.Collections.Generic;
using Redmine.Net;
using Redmine.Net.Api.Types;
using Estimator.Redmine;
using Redmine.Net.Api;
using System.ComponentModel;
using System.Collections.Specialized;
using Estimator.Model;
using System.Linq;

namespace Estimator.Data.Model
{
    public class DataProvider
    {
        private static RedmineConnectionDetails _redmineConnectionDetails = new RedmineConnectionDetails();
        public DataProvider()
        {
            Issues = new List<Ticket>();
            foreach (var issue in RedmineConnection.GetObjects<Issue>("tracker_id", "4"))
            {
                Issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
            Statuses = new List<Status>();
            foreach (var status in RedmineConnection.GetObjects<IssueStatus>("tracker_id", "4"))
            {
                Statuses.Add(new Status(status.Id, status.Name));
            }
        }
        public DataProvider(string key, string value)
        {
            Issues = new List<Ticket>();
            Parameters.Add("tracker_id", "4");
            Parameters.Add(key, value);
            foreach (var issue in RedmineConnection.GetObjects<Issue>(Parameters))
            {
                Issues.Add(new Ticket(issue.Id, issue.Subject, issue.StartDate, issue.StartDate, issue.StartDate, issue.StartDate, issue.Status.Id, issue.Status.Name, issue.CustomFields));
            }
        }
        public List<Ticket> Issues { get; set; }
        public List<Status> Statuses { get; set; }
        public Status Status { get; set; }
        public Ticket Issue { get; set; }
        public NameValueCollection Parameters = new NameValueCollection();
        public RedmineManager RedmineConnection = new RedmineManager(_redmineConnectionDetails.Host, _redmineConnectionDetails.Api); 
    }
}