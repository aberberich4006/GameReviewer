using GameReview.Data;
using GameReviewer.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Services
{
    public class UserReviewService
    {
        private readonly Guid _userId;

        public UserReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserReview(UserReviewCreate model)
        {
            var entity =
                new UserGameReview()
                {
                    OwnerId = _userId,
                    GameId = model.GameId,
                    UserReview = model.Rating,
                    Review = model.Review,
                    CreatedUtc = DateTime.UtcNow

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserGameReviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserReviewListItem> GetUserReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserGameReviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserReviewListItem
                                {
                                    UserGameReviewId = e.UserGameReviewId,
                                    Game = e.Game.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public UserReviewDetail GetUserReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserGameReviews
                        .Single(e => e.UserGameReviewId == id && e.OwnerId == _userId);
                return
                    new UserReviewDetail
                    {
                        UserGameReviewId = entity.UserGameReviewId,
                        GameId = entity.GameId,
                        GameName = entity.Game.Name,
                        CategoryName = entity.Game.Category.Name,
                        UserReview = entity.UserReview,
                        Review = entity.Review,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateUserReview(UserReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserGameReviews
                        .Single(e => e.UserGameReviewId == model.UserGameReviewId && e.OwnerId == _userId);

                entity.UserGameReviewId = model.UserGameReviewId;
                entity.GameId = model.GameId;
                entity.UserReview = model.UserReview;
                entity.Review = model.Review;



                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserReview(int userGameReviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserGameReviews
                        .Single(e => e.UserGameReviewId == userGameReviewId && e.OwnerId == _userId);

                ctx.UserGameReviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

