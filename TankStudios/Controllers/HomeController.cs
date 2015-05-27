using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TankStudios.Interfaces;
using TankStudios.Models;

namespace TankStudios.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactModel model)
        {
            await _contactService.SendContactMessage(model.FirstName, model.LastName, model.Email, model.Message);
            return RedirectToAction("Index");
        }
    }
}