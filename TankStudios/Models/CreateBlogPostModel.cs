using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankStudios.Objects;

namespace TankStudios.Models
{
    public class CreateBlogPostModel
    {
        public string Id { get; set; }

        public List<BlogIdTitleModel> BlogTitles { get; set; }

        public int SelectedBlogId { get; set; }

        public IEnumerable<SelectListItem> BlogTitleSelectList
        {
            get
            {
                return new SelectList(BlogTitles, "Id", "Name");
            }
        }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostSubTitle { get; set; }

        [AllowHtml]
        [Required]
        public string PostHtml { get; set; }

        [Required]
        public string PostImageLink { get; set; }

        public static CreateBlogPostModel CreateEmpty(List<BlogIdTitleModel> blogTitles)
        {
            var model = new CreateBlogPostModel()
            {
                Id = null,
                BlogTitles = blogTitles
            };
            return model;
        }
        public static CreateBlogPostModel CreateFromPost(BlogPost post, List<BlogIdTitleModel> blogTitles)
        {
            var model = new CreateBlogPostModel()
            {
                Id = post.ID.ToString(),
                BlogTitles = blogTitles,
                PostTitle = post.Title,
                PostSubTitle = post.SubTitle,
                PostHtml = post.Content,
                PostImageLink = post.CoverImageLink
            };

            return model;
        }
    }
}