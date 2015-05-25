using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TankStudios.Models
{
    public class CreateBlogPostModel
    {
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
    }
}