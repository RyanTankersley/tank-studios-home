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
                model.Posts.AddRange(posts.Select(bp => new PostModel() { Title = bp.Title, SubTitle = bp.SubTitle, ImageLink = bp.CoverImageLink.StartsWith("~") ? Url.Content(bp.CoverImageLink) : bp.CoverImageLink, Id = bp.ID, DatePosted = bp.DatePublished }));
                return View(model);
            }
            else
                return HttpNotFound();
        }

        public ActionResult ReadPost(string id)
        {
            var post = context.Posts.SingleOrDefault(p => p.ID.ToString() == id);
            if (post == null)
                return new HttpNotFoundResult();

            var model = new ReadPostModel()
            {
                Id = post.ID,
                Content = post.FixedContent,
                Title = post.Title,
                SubTitle = post.SubTitle,
                ImageLink = post.CoverImageLink.StartsWith("~") ? Url.Content(post.CoverImageLink) : post.CoverImageLink
            };

            return View(model);
        }

        public ActionResult Create(string id = null)
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                CreateBlogPostModel model;
                var blogTitles = context.Blogs.Select(b => new BlogIdTitleModel() { Id = b.ID, Name = b.Title }).ToList();
                if (id != null)
                {
                    var post = context.Posts.SingleOrDefault(p => p.ID.ToString() == id);
                    if (post == null)
                        return new HttpNotFoundResult();
                    model = CreateBlogPostModel.CreateFromPost(post, blogTitles);
                }
                else
                {
                    model = CreateBlogPostModel.CreateEmpty(blogTitles);
                }

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

            BlogPost post;
            if (model.Id == null)
            {
                var blogPost = BlogPost.Create(blog, model.PostHtml, model.PostTitle, model.PostSubTitle, model.PostImageLink);
                context.Posts.Add(blogPost);
                post = blogPost;
            }
            else
            {
                var contextPost = context.Posts.SingleOrDefault(p => p.ID.ToString() == model.Id);
                if (contextPost == null)
                    return new HttpNotFoundResult();

                var entry = context.Entry(contextPost);
                entry.Entity.Title = model.PostTitle;
                entry.Entity.SubTitle = model.PostSubTitle;
                entry.Entity.Content = model.PostHtml;
                entry.Entity.CoverImageLink = model.PostImageLink;
                entry.State = System.Data.Entity.EntityState.Modified;
                post = contextPost;
            }

            context.SaveChanges();

            return RedirectToAction("ReadPost", new { id= post.ID.ToString() });
        }

        public void Dispose()
        {
            context.Dispose();
            base.Dispose();
        }
    }
}