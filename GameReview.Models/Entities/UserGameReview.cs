﻿using GameReviewer.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReview.Data
{
    public class UserGameReview
    {
        [Key]
        public int UserGameReviewId { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }    
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Range(1,10, ErrorMessage ="Please choose a number between 1 and 10.")]
        [Display(Name ="Review Score")]
        public decimal UserReview { get; set; }
        public string Review { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
