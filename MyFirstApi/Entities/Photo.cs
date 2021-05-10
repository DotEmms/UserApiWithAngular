using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }
        public int AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}
