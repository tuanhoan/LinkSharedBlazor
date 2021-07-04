using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Models
{
    public class Social
    {
        public Social()
        {
            Links = new HashSet<Link>();
        }
        public int Id { get; set; }
        public string SocialName { get; set; }
        public string Icon { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
