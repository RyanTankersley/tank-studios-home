using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStudios.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageLink { get; set; }
    }
}