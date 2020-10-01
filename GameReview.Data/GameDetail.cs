using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Data
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Name { get; set; }

        [Display(Name="Category Id")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryName { get; set; }
        public string Developer { get; set; }
        public int ReleaseYear { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }


    }
}
