using System;

namespace Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public string SiteTitle { get; set; }
        public string SiteDescription { get; set; }
        public string SiteTags { get; set; }

        public string GeneralTelephone { get; set; }
        public string GeneralAddress { get; set; }
        public string GeneralEmailAddress { get; set; }

        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string YouTubeUrl { get; set; }

        public Member EditorMember { get; set; }

        public DateTime EditDate { get; set; }
    }
}
