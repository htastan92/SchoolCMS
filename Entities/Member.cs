using System;
using System.Collections.Generic;

namespace Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public int StatusId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public int CreatorMemberId { get; set; }

        public int EditorMemberId { get; set; }

        public ICollection<Settings> Settings { get; set; }
    }
}
