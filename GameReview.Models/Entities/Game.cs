using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set;}
        public virtual Category Category { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        [Display(Name="Release Year")]
        public int ReleaseYear { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public ICollection<UserGameReview> UserGameReviews { get; set; }
        
    }
}
