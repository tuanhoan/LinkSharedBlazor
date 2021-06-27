using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Models
{
    public class Link
    {
        public int SocialId { get; set; }
        public int UserId { get; set; }
        public string SocialLink { get; set; } 
        public DateTime CreatedAt { get; set; }
        public virtual Social SocialNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
