using GameReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameReviewer.WebMVC.Controllers
{

    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var model = new GameListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}