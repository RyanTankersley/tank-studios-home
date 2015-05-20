using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankStudios.Objects
{
    public class BlogPost
    {
        public int ID { get; set; }

        public int BlogID { get; set; }

        public virtual Blog Blog { get; set; }

        public DateTime DatePublished { get; set; }

        public string Content { get; set; }
        
        public string Title { get; set; }

        public string CoverImageLink { get; set; }
    }
}
