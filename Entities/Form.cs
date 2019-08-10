using System;

namespace Entities
{
    public class Form
    {
        public int Id { get; set; }

        public string ParentFullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string StudentFullName { get; set; }

        public Campus Campus { get; set; }

        public string IpAddress { get; set; }

        public DateTime SentDate { get; set; }
    }
}
