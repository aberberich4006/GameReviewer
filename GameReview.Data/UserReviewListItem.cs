using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Data
{
    public class UserReviewListItem
    {
        [Display(Name="Game Review Id")]
        public int UserGameReviewId { get; set; }
        public string Game { get; set; }
    }
}
