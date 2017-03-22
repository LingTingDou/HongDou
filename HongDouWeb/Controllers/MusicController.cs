using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HongDouWeb.DAL;

namespace HongDouWeb.Controllers
{
    public class MusicController : Controller
    {
        MusicService ms = new MusicService();
        // GET: Music
        public ActionResult Index()
        {
            return View(ms.SelectList());
        }

        

    }
}