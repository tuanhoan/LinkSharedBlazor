using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Models
{
    public class User
    {
        public User()
        {
            Links = new HashSet<Link>();
        }
        public Guid Id{ get; set; }
        public string Name { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; } 
        public ICollection<Link> Links { get; set; } 
    }
}
