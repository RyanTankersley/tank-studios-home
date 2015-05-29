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
        
        public string FixedContent { get
            {
                var newContent = this.Content.Replace("*!", "/>").Replace("!*", "<");
                return newContent;
            }
        }

        public string Title { get; set; }

        public string SubTitle { get; set; }
        
        public string CoverImageLink { get; set; }

        public static BlogPost Create(Blog blog, string content, string title, string subTitle, string coverImageLink)
        {
            var post = new BlogPost()
            {
                Blog = blog,
                BlogID = blog.ID,
                DatePublished = DateTime.Now,
                Content = content,
                Title = title,
                SubTitle = subTitle,
                CoverImageLink = coverImageLink
            };
            return post;
        }
    }
}
