﻿using System;

namespace Entities
{
    public class Content
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string EditorContent { get; set; }

        public Status Status { get; set; }

        public Image Image { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public Member CreatorMember { get; set; }
        public Member EditorMember { get; set; }
    }
}
