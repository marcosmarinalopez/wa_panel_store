using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wa_panel_store;

namespace wa_panel_store.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private wa_panel_store.Models.cUserManager m_c_user_manager { get; set; }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(wa_panel_store.Models.cUserManager c_user_manager)
        {
            return View();
        }
    }
}