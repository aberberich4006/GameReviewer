using GameReview.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class GameCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Category Id")]
        public int CategoryId { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        [Display(Name="Release Year")]
        public int ReleaseYear { get; set; }

    }
}
