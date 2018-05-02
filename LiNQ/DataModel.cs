using System;
using System.Linq;

namespace DataModel
{
    public enum Status : byte
    {
        /// <summary>
        /// Defect has been opened, but not verified as reproducible or an issue.
        /// </summary>
        Created,
        /// <summary>
        /// Defect has been verified as an issue requiring work.
        /// </summary>
        Accepted,
        /// <summary>
        /// Defect has been fixed in code, but not verified other than through developer testing.
        /// </summary>
        Fixed,
        /// <summary>
        /// Defect was fixed, but has now been reopened due to failing verification.
        /// </summary>
        Reopened,
        /// <summary>
        /// Defect has been fixed and tested; the fix is satisfactory.
        /// </summary>
        Closed,
    }

    public enum Severity : byte
    {
        Trivial,
        Minor,
        Major,
        Showstopper,
    }

    public enum UserType : byte
    {
        Customer,
        Developer,
        Tester,
        Manager,
    }

    public static class StaticCounter
    {
        static int next = 1;
        public static int Next()
        {
            return next++;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public User(string name, UserType userType)
        {
            Name = name;
            UserType = userType;
        }
        public override string ToString()
        {
            return string.Format("User: {0} ({1})", Name, UserType);
        }
    }

    public class Defect
    {
        public Project Project { get; set; }
        /// <summary>
        /// Which user is this defect currently assigned to? Should not be null until the status is Closed.
        /// </summary>
        public User AssignedTo { get; set; }
        public string Summary { get; set; }
        public Severity Severity { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public User CreatedBy { get; set; }
        public int ID { get; private set; }

        public Defect()
        {
            ID = StaticCounter.Next();
        }

        public override string ToString()
        {
            return string.Format("{0,2}: {1}\r\n    ({2:d}-{3:d}, {4}/{5}, {6} -> {7})",
                ID, Summary, Created, LastModified, Severity, Status, CreatedBy.Name,
                AssignedTo == null ? "n/a" : AssignedTo.Name);
        }
    }

    public class Project
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Project: {0}", Name);
        }
    }

    public class NotificationSubscription
    {
        /// <summary>
        /// Project for which this subscriber is notified
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// The address to send the notification to
        /// </summary>
        public string EmailAddress { get; set; }
    }

}
