using GameReview.Data;
using GameReview.Models;
using GameReview.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var model = service.GetGames();

            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateCategoryService();
            var category = service.GetCategories();
            var banana = new SelectList(category, "categoryId", "Name");

            ViewBag.Category = banana;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);

            service.CreateGame(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var catService = CreateCategoryService();
            var category = catService.GetCategories();
            var banana = new SelectList(category, "categoryId", "Name");

            ViewBag.Category = banana;
            var service = CreateGameService();
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    GameId = detail.GameId,
                    Name = detail.Name,
                    CategoryId = detail.CategoryId,
                    Category = detail.Category,
                    Developer = detail.Developer,
                    ReleaseYear = detail.ReleaseYear
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your game was deleted";

            return RedirectToAction("Index");
        }

        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }
    }
}