using System;

namespace Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public int CreatorMemberId { get; set; }
        public Member CreatorMember { get; set; }

        public int EditorMemberId { get; set; }
        public Member EditorMember { get; set; }
    }
}
