using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankStudios.Models;
using TankStudios.Objects;

namespace TankStudios.Controllers
{
    public class BlogController : Controller
    {
        ApplicationDbContext context;

        public BlogController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Blog
        public ActionResult Read(string id)
        {
            if(id == null)
                return HttpNotFound();

            var check = id.Replace('_', ' ');
            var blog = context.Blogs.FirstOrDefault(b => b.Title == check);
            if (blog != null)
            {
                var path = ImageTypeHelper.GetImageRelativePath(blog.ImageType);
                var url = Url.Content(path);
                var model = new BlogModel(blog.Title, blog.SubTitle, url);
                var posts = context.Posts.Where(p => p.BlogID == blog.ID).ToList();
                model.Posts.AddRange(posts.Select(bp => new PostModel() { Title = bp.Title, SubTitle = bp.SubTitle, ImageLink = Url.Content(bp.CoverImageLink) }));
                return View(model);
            }
            else
                return HttpNotFound();
        }

        public ActionResult ReadPost(string id)
        {
            return HttpNotFound();
        }
        public ActionResult Create()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                var model = new CreateBlogPostModel();
                model.BlogTitles = context.Blogs.Select(b => new BlogIdTitleModel() { Id = b.ID, Name = b.Title }).ToList();
                return View(model);
            }

            return new HttpUnauthorizedResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBlogPostModel model)
        {
            if(string.IsNullOrEmpty(User.Identity.Name))
                return new HttpUnauthorizedResult();

            if (!ModelState.IsValid)
                return View(model);

            var blog = context.Blogs.SingleOrDefault(b => b.ID == model.SelectedBlogId);
            if (blog == null)
            {
                ModelState.AddModelError("", "Invalid blog title");
                return View(model);
            }

            var blogPost = BlogPost.Create(blog, model.PostHtml, model.PostTitle, model.PostSubTitle, model.PostImageLink);
            context.Posts.Add(blogPost);
            context.SaveChanges();
            blog = context.Blogs.SingleOrDefault(b => b.ID == model.SelectedBlogId);
            var post = blog.BlogPosts.Last();
            return RedirectToAction("ReadPost", new object[] { post.ID.ToString() });
        }

        public void Dispose()
        {
            context.Dispose();
            base.Dispose();
        }
    }
}