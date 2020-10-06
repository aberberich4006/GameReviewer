using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Data
{
    public class UserReviewDetail
    {
        public int UserGameReviewId { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string CategoryName { get; set; }
        public decimal UserReview { get; set; }
        public string Review { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
