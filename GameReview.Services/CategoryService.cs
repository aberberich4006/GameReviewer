using GameReview.Data;
using GameReviewer.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(CategoryCreate model)
        {
            var entity =
                new Category()
                {

                    Name = model.Name,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Category.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryId = e.CategoryId,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }
    }
}