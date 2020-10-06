using GameReview.Data;
using GameReview.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameReviewer.WebMVC.Controllers
{
    [Authorize]
    public class UserGameReviewController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserReviewService(userId);
            var model = service.GetUserReviews();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserReviewService(userId);

            service.CreateUserReview(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserReviewService();
            var model = svc.GetUserReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateUserReviewService();
            var detail = service.GetUserReviewById(id);
            var model =
                new UserReviewEdit
                {
                    UserGameReviewId = detail.UserGameReviewId,
                    GameId = detail.GameId,
                    UserReview = detail.UserReview,
                    Review = detail.Review,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserGameReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserReviewService();

            if (service.UpdateUserReview(model))
            {
                TempData["SaveResult"] = "Your review was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserReviewService();
            var model = svc.GetUserReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserReviewService();

            service.DeleteUserReview(id);

            TempData["SaveResult"] = "Your game was deleted";

            return RedirectToAction("Index");
        }

        private UserReviewService CreateUserReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserReviewService(userId);
            return service;
        }
    }
}