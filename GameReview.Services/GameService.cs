using GameReview.Data;
using GameReview.Models;
using GameReviewer.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    
                    Name = model.Name,
                    Developer = model.Developer,
                    ReleaseYear = model.ReleaseYear,
                    CreatedUtc = DateTimeOffset.Now
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
