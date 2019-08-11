using System;

namespace Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public Status Status { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public Member CreatorMember { get; set; }
        public Member EditorMember { get; set; }
    }
}
