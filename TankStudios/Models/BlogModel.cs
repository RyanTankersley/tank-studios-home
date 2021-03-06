﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TankStudios.Models
{
    public class BlogModel
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageLink { get; set; }

        public List<PostModel> Posts { get; set; }

        public BlogModel(string title, string subTitle, string imageLink)
        {
            this.Title = title;
            this.SubTitle = subTitle;
            this.ImageLink = imageLink;
            Posts = new List<PostModel>();
        }
    }
}
