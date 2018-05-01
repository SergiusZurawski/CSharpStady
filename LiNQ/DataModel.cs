using System;
using System.Linq;

namespace DataModel
{
    public enum Status
    {
        Created,
        Accepted,
        Fixed,
        Reopened,
        Closed
    }

    public enum Servirity
    {
        Trivial,
        Minor,
        Major,
        Showstoper
    }

    public enum UserType
    {
        Customer,
        Developer,
        Tester,
        Manager
    }

    public class User
    {
        public string Name { get; set; }
        public UserType UserType { get; set; }
    }

    public class Defect
    {
        public Status Status { get; set; }
        public Servirity Servirity { get; set; }
        public User AssignedTo { get; set; }
        public User CreatedBy { get; set; }
        public Project Project { get; set; }
        public string Created { get; set; }
        public string ID { get; set; }
        public string LastModified { get; set; }
        public string Summary { get; set; }

    }

    public class Project
    {
        public string Name { get; set; }
    }

    public class NotificationSubscription
    {
        public string EmailAddress { get; set; }
    }

}
