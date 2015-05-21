using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankStudios.Objects
{
    public class Blog
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public ImageType ImageType { get; set; }

        public virtual List<BlogPost> BlogPosts { get; set; }
    }
}
