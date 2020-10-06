using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Data
{
    public class UserReviewCreate
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
