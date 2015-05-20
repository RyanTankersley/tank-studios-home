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

        // GET: Blog
        public ActionResult Read(string id)
        {
            ViewBag.BlogName = id;
            return View();
        }
    }
}