using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankStudios.Models
{
    public class BlogModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public BlogModel(string title, string subTitle)
        {
            this.Title = title;
            this.SubTitle = subTitle;
        }
    }
}
