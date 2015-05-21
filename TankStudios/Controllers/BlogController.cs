using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankStudios.Models;

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
                var model = new BlogModel(blog.Title, blog.SubTitle);
                return View(model);
            }
            else
                return HttpNotFound();
        }

        public void Dispose()
        {
            context.Dispose();
            base.Dispose();
        }
    }
}